using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Javapad
{
    public partial class Javapad : Form
    {
        public static Point location;
        #region Editor variables for color coding
        private Dictionary<string, string[]> encode = new Dictionary<string, string[]>();
        private string[] keywordset1 = { "public", "private", "protected", "class", "true", "false" };
        private string[] keywordset2 = { "System.out" };
        private string[] keywordset3 = { "int", "String", "double", "long", "byte", "char" };
        private string[] keywordset4 = { "while", "do", "if", "else", "for", "return", "break", "switch", "case", "new" };
        private string[] keywordset5 = { "void" };
        private string[] keywordset6 = { "print", "println" };
        private string[] comments = { "//" };

        // Color constants
        private const string COLOR1 = "#4290d6"; // dark blue 
        private const string COLOR2 = "#9cdcfe"; // light blue
        private const string COLOR3 = "#c86931"; // orange
        private const string COLOR4 = "#d6dc8b"; // light yellow
        private const string COLOR5 = "#4cc386"; // light green
        private const string COLOR6 = "#608b3a"; // green for comments
        private const string COLOR7 = "#c586c0"; // purple 
        #endregion

        private string jdk_path = "";
        private string file = "";
        private string hoverBackColor = "#812e96";

        private bool expand = false;
        private bool isHoldCtrl = false;
        private bool isRunning = false;
        private bool run = false;
        // keyboard shortcuts
        private bool shift = false;

        private const int MIN_EXPAND = 60;
        private int currentCol = 1;
        private int currentLine = 1;
        private int currentPos = 1;
        private int curr_position = 0;
        private int counter = 0;
        
        private Document doc;
        private DialogResult state;
        private About about;
        private static Javapad form = null;
        private ConsoleView consoleView = new ConsoleView();
        private ProblemsView problemsView = new ProblemsView();
        private ProjectEulerView eulerView = new ProjectEulerView();
        private ProfileView profileView = new ProfileView();
        private DetectJDK detectJDK = new DetectJDK();
        
        
        private Process InterProc = new Process();
        private Process process = new Process();

        #region Delegate Process
        private delegate Process ProcInter();
        public static Process InterProcDelegate()
        {
            return form.InterProc;
        }
        private Process UpdateInterProcDelegate()
        {
            if (InvokeRequired)
            {
                this.Invoke(new ProcInter(UpdateInterProcDelegate));
                return InterProc;
            }
            return InterProc;
        }
        #endregion

        public Javapad()
        {
            InitializeComponent();
        }

        #region Javapad Form functions [about me, prompt] + extra functions
        private void Javapad_Load(object sender, EventArgs e)
        {
            form = this;
            location = this.Location;
            doc = new Document();
            encode.Add(COLOR1, keywordset1);
            encode.Add(COLOR2, keywordset2);
            encode.Add(COLOR6, keywordset3);
            encode.Add(COLOR7, keywordset4);
            encode.Add(COLOR5, keywordset5);
            encode.Add(COLOR4, keywordset6);
            lineBox.Font = editorBox.Font;
            editorBox.Select();
            AddLineNumbers();
            ShowPanel(consoleView, lblConsole);
            posLabel.Text = "Ln " + currentLine + ", Col " + currentCol + ", Pos " + currentPos;
            // Detect JDK [also runs the registry functions]
            searchJDKWorker.RunWorkerAsync();
            
            if (!String.IsNullOrEmpty(RegistryManager.JDKPath))
            {
                jdk_path = RegistryManager.JDKPath;
            }
        }
        private void Javapad_Resize(object sender, EventArgs e)
        {
            if(this.WindowState != FormWindowState.Minimized)
            {
                if (outputExpander.Location.Y < 0)
                {
                    outputExpander.Location = new Point(0, 10);
                    ExpanderMove(0);
                }
                if (outputExpander.Location.Y > this.Height)
                {
                    outputExpander.Location = new Point(0, this.Height - MIN_EXPAND - 60);
                    ExpanderMove(0);
                }
            }
            
        }
        private void Javapad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!doc.IsSaved)
            {
                prompt();
                if (state == DialogResult.Abort)
                {
                    // call this if newWindow() creates another thread
                    // Application.ExitThread();
                    // but since newWindow calls Javapad.exe, we can use .Exit()
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                // Application.ExitThread();
                Application.Exit();
            }
        }
        private void aboutMeLabel_MouseEnter(object sender, EventArgs e)
        {
            aboutMeLabel.BackColor = convertColor(hoverBackColor);
        }

        private void aboutMeLabel_MouseLeave(object sender, EventArgs e)
        {
            aboutMeLabel.BackColor = bottomPanel.BackColor;
        }
        private void aboutMeLabel_Click(object sender, EventArgs e)
        {
            showAbout();
        }
        private void showAbout()
        {
            if (about != null && !about.IsDisposed)
            {
                about.BringToFront();
                about.Show();
                about.setLocation(this.Location.X + 80, this.Location.Y + 80);
            }
            else
            {
                about = new About();
                about.Show();
                about.setLocation(this.Location.X + 80, this.Location.Y + 80);
            }
        }
        private void prompt()
        {
            Point location = new Point(this.Location.X + 80, this.Location.Y + 100);
            state = Prompt.ShowDialog(file, location);

            if (state == DialogResult.OK)
            {
                save();
                newFile();
            }
            else if (state == DialogResult.Abort)
            {
                newDoc();
            }

        }
        private Color convertColor(string color)
        {
            return System.Drawing.ColorTranslator.FromHtml(color);
        }
        #endregion
        
        #region EditorBox and LineNumbers _all
        public void AddLineNumbers()
        {
            // create & set Point pt to (0,0)    
            Point pt = new Point(0, 0);
            // get First Index & First Line from richTextBox1    
            int First_Index = editorBox.GetCharIndexFromPosition(pt);
            int First_Line = editorBox.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // get Last Index & Last Line from richTextBox1    
            int Last_Index = editorBox.GetCharIndexFromPosition(pt);
            int Last_Line = editorBox.GetLineFromCharIndex(Last_Index);
            // set Center alignment to lineBox    
            lineBox.SelectionAlignment = HorizontalAlignment.Center;
            // set lineBox text to null & width to getWidth() function value    
            lineBox.Text = "";
            //lineBox.Width = getWidth();
            // now add each line number to lineBox upto last line    
            for (int i = First_Line; i <= Last_Line + 2; i++)
            {
                lineBox.Text += i + 1 + "\n";
            }
        }
        public int getWidth()
        {
            int w = 25;
            // get total lines of richTextBox1    
            int line = editorBox.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)editorBox.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)editorBox.Font.Size;
            }
            else
            {
                w = 50 + (int)editorBox.Font.Size;
            }

            return w;
        }
        private void reEncode()
        {
            foreach (var line in editorBox.Lines)
            {
                foreach(var word in encode)
                {
                    for (int i = 0; i < word.Value.Length; i++)
                    {
                        //color(textBox, start, word.Key, word.Value[i]);
                    }
                }
            }
        }
        private void encodeData(RichTextBox textBox, int start, Dictionary<string, string[]> encode)
        {
            foreach (var word in encode)
            {
                for (int i = 0; i < word.Value.Length; i++)
                {
                    color(textBox, start, word.Key, word.Value[i]);
                }
            }
        }
        private void color(RichTextBox textBox, int start, string color, string keyword)
        {
            try
            {
                if (start >= keyword.Length)
                {
                    counter++;
                    // it's better to customize richTextbox 
                    // perhaps in the beta version...
                    /*
                    // check if the line contains a single line comment 
                    int currentLine = textBox.GetLineFromCharIndex(start);
                    int firstCharofLine = textBox.GetFirstCharIndexFromLine(currentLine);
                    string lineText = "";
                    lineText = textBox.Lines[currentLine];
                    int posOfComment = lineText.IndexOf("//");
                    if (lineText.Contains("//"))
                    {
                        textBox.Select(firstCharofLine + posOfComment, lineText.Length);
                        textBox.SelectionColor = convertColor(COLOR6);
                        textBox.Select(start, 0);
                    }*/
                    {
                        textBox.ForeColor = Color.White;
                        int pos = textBox.Find(keyword, start - keyword.Length, start, RichTextBoxFinds.MatchCase);
                        if (pos != -1)
                        {
                            textBox.Select(pos, keyword.Length);
                            textBox.SelectionColor = convertColor(color);
                            textBox.Select(pos + keyword.Length, 0);
                        }
                    }

                }

                textBox.SelectionColor = Color.White;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
            }
        }
        
        private void editorBox_Click(object sender, EventArgs e)
        {
            currentPos = editorBox.SelectionStart + 1;
            currentLine = editorBox.GetLineFromCharIndex(currentPos) + 1;
            //firstChar = richTextBox1.GetFirstCharIndexFromLine(currentLine);
            int index = editorBox.SelectionStart;
            int line = editorBox.GetLineFromCharIndex(index);

            // Get the column.
            int firstChar = editorBox.GetFirstCharIndexFromLine(line);
            int column = index - firstChar;
            if (currentLine > 0)
            {
                currentCol = currentPos - firstChar;
            }
            posLabel.Text = "Ln " + currentLine + ", Col " + currentCol + ", Pos " + currentPos;
        }

        private void editorBox_FontChanged(object sender, EventArgs e)
        {
            lineBox.Font = editorBox.Font;
            editorBox.Select();
            AddLineNumbers();
        }

        private void editorBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool ctrlV = e.Modifiers == Keys.Control && e.KeyCode == Keys.V;
            bool shiftIns = e.Modifiers == Keys.Shift && e.KeyCode == Keys.Insert;
            bool ctrlShiftO = e.Modifiers == (Keys.Control | Keys.Shift) && e.KeyCode == Keys.X;

            if (e.KeyCode == Keys.ControlKey)
            {
                lineBox.ZoomFactor = editorBox.ZoomFactor;
            }
            if (ctrlV || shiftIns)
            {
                editorBox.ForeColor = Color.White;
                //editorBox.SuspendLayout();
                // get insertion point
                int insPt = editorBox.SelectionStart;
                // preserve text from after insertion pont to end of RTF content
                string postRTFContent = editorBox.Text.Substring(insPt);
                // remove the content after the insertion point
                editorBox.Text = editorBox.Text.Substring(0, insPt);
                // add the clipboard content and then the preserved postRTF content
                editorBox.Text += (string)Clipboard.GetData("Text") + postRTFContent;
                // adjust the insertion point to just after the inserted text
                editorBox.SelectionStart = editorBox.TextLength - postRTFContent.Length;
                // restore layout
                //editorBox.ResumeLayout();
                // cancel the paste
                reEncode();
                e.Handled = true;
            }
             
        }
        private void editorBox_KeyUp(object sender, KeyEventArgs e)
        {
            isHoldCtrl = false;
            currentPos = editorBox.SelectionStart + 1;
            currentLine = editorBox.GetLineFromCharIndex(currentPos) + 1;
            int index = editorBox.SelectionStart;
            int line = editorBox.GetLineFromCharIndex(index);
            // Get the column.
            int firstChar = editorBox.GetFirstCharIndexFromLine(line);
            int column = index - firstChar;
            if (currentLine > 0)
            {
                currentCol = currentPos - 1 - firstChar;
            }
            posLabel.Text = "Ln " + currentLine + ", Col " + currentCol + ", Pos " + currentPos;
        }

        private void editorBox_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = editorBox.GetPositionFromCharIndex(editorBox.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }
        }

        private void editorBox_TextChanged(object sender, EventArgs e)
        {
            if (doc != null)
                doc.IsSaved = false;
            curr_position = editorBox.SelectionStart;
            encodeData(editorBox, curr_position, encode);

        }

        private void editorBox_VScroll(object sender, EventArgs e)
        {
            lineBox.Text = "";
            AddLineNumbers();
            lineBox.Invalidate();
        }
        #endregion

        #region Body (top) panel
        private void outputBodyPanel_Resize(object sender, EventArgs e)
        {
            if (consoleView != null)
            {
                consoleView.Size = outputBodyPanel.Size;
            }
            if (problemsView != null)
            {
                problemsView.Size = outputBodyPanel.Size;
            }
            if(eulerView != null)
            {
                eulerView.Size = outputBodyPanel.Size;
            }
            if(profileView != null)
            {
                profileView.Size = outputBodyPanel.Size;
            }
        }
        #endregion
        #region Expander
        private void outputExpander_MouseDown(object sender, MouseEventArgs e)
        {
            expand = true;
        }

        private void outputExpander_MouseMove(object sender, MouseEventArgs e)
        {
            if (expand)
            {
                ExpanderMove(e.Y);
            }
        }
        private int ExpanderMove(int e)
        {
            Point getExPos = outputExpander.Location;
            outputExpander.Location = new Point(0, getExPos.Y + e);
            // change the height of the mainPanel
            mainPanel.Height = outputExpander.Location.Y;
            // change the height of the outputPanel
            outputPanel.Height = this.Height - mainPanel.Height - 60; // 60 to make sure the bottomPanel is exposed.// change the location of the bottomPanel as well
            outputPanel.Location = new Point(0, outputExpander.Location.Y);
            return outputExpander.Location.Y;

        }
        private void outputExpander_MouseUp(object sender, MouseEventArgs e)
        {
            expand = false;
            if (outputExpander.Location.Y > this.Height - MIN_EXPAND)
                outputExpander.Location = new Point(0, this.Height - MIN_EXPAND);
            if (outputExpander.Location.Y < 0)
            {
                outputExpander.Location = new Point(0, 10);
                outputPanel.Location = new Point(0, 12);
                outputPanel.Height -= 12;
            }
        }
        #endregion
        #region Bottom Panel
        private void lblOutput_Click(object sender, EventArgs e)
        {
            ShowPanel(consoleView, lblConsole);
            /*if (ExpanderMove(0) > this.Height - MIN_EXPAND - 100)
                ExpanderMove(-100); */
        }

        private void lblProblems_Click(object sender, EventArgs e)
        {
            ShowPanel(problemsView, lblProblems);
        }
        private void _showConsolePanel()
        {
            lblConsole.Font = new Font(lblConsole.Font.Name, lblConsole.Font.SizeInPoints, FontStyle.Underline);
            lblProblems.Font = new Font(lblProblems.Font.Name, lblProblems.Font.SizeInPoints, FontStyle.Regular);
            consoleView.TopLevel = false;
            outputBodyPanel.Controls.Remove(problemsView);
            outputBodyPanel.Controls.Add(consoleView);
            consoleView.Show();
        }

        private void _showProblemsPanel()
        {
            lblProblems.Font = new Font(lblProblems.Font.Name, lblProblems.Font.SizeInPoints, FontStyle.Underline);
            lblConsole.Font = new Font(lblConsole.Font.Name, lblConsole.Font.SizeInPoints, FontStyle.Regular);
            problemsView.TopLevel = false;
            outputBodyPanel.Controls.Remove(consoleView);
            outputBodyPanel.Controls.Add(problemsView);
            problemsView.Show();
        }
        #region bottom bar
        private void setBottomBackColor(string color, string backColor)
        {
            bottomPanel.BackColor = convertColor(color);
            // set the hover backcolor for each label
            hoverBackColor = backColor;
            // and the labels...
            jdkLabel.BackColor = convertColor(color);
            aboutMeLabel.BackColor = convertColor(color);
            posLabel.BackColor = convertColor(color);
        }
        private void jdkLabel_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void jdkLabel_MouseEnter(object sender, EventArgs e)
        {
            jdkLabel.BackColor = convertColor(hoverBackColor);
        }

        private void jdkLabel_MouseLeave(object sender, EventArgs e)
        {
            jdkLabel.BackColor = bottomPanel.BackColor;
        }
        #endregion
        #endregion

        #region PressedKeys Functions
        private void F5()
        {
            //if(!doc.IsSaved)
                save();
            if (String.IsNullOrEmpty(file)) file = doc.File;
            // compile & run
            compile(true);
        }
        private void F7()
        {
            //if (!doc.IsSaved)
                save();
            if (String.IsNullOrEmpty(file)) file = doc.File;
            // only compile
            compile(false);
        }
        #endregion

        #region Document Functions
        private void setFormTitle(string title)
        {
            this.Text = System.AppDomain.CurrentDomain.FriendlyName +" - " + title;
        }
        private void newDoc()
        {
            editorBox.Text = "";
            doc.IsSaved = true;
            setFormTitle("Untitled");
        }
        private void readDoc(string filepath)
        {
            if (!String.IsNullOrEmpty(filepath))
                editorBox.Text = File.ReadAllText(filepath);
            setFormTitle(filepath);
        }
        private void saveDoc(string file)
        {
            if (!String.IsNullOrEmpty(file))
                editorBox.SaveFile(file, RichTextBoxStreamType.PlainText);
        }
        private void newFile()
        {
            if (doc != null)
            {
                if (doc.IsSaved)
                {
                    doc = new Document();
                    newDoc();
                }
                else
                {
                    prompt();
                }
            }
            else
                doc = new Document();
        }
        private void openFile()
        {
            if (doc.IsSaved)
            {
                readDoc(file = doc.Open());
                doc.IsSaved = true;
                setFormTitle(file);
            }
            else
            {
                prompt();
                if(state == DialogResult.Cancel)
                {

                }else
                {
                    openFile();
                }
            }
        }
        private void save()
        {
            string text = editorBox.Text;
            doc.Save(text);
            if (!String.IsNullOrEmpty(doc.File))
                setFormTitle(doc.File);
        }
        private void saveAs()
        {
            string text = editorBox.Text;
            saveDoc(doc.SaveAs(text));
            if(!String.IsNullOrEmpty(doc.File))
                setFormTitle(doc.File);
        }
        
        private void newWindow()
        {
            /*Javapad j = new Javapad();
            var newApp = new Thread(() => Application.Run(j));
            newApp.SetApartmentState(ApartmentState.STA);
            newApp.Start();*/
            // it doesn't work when debugging
            // visualstudio adds vshost in the appname [appname.vshost.exe]
            Process.Start(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        }
        #endregion

        #region Compile 
        private void compile(bool run)
        {
            this.run = run;
            if (!String.IsNullOrEmpty(file))
            {
                if (!compilerWorker.IsBusy)
                    compilerWorker.RunWorkerAsync();
                else
                    MessageBox.Show("Compiler is busy, please try again.");
            }
        }

        private void compilerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (RegistryManager.JDKFound)
                compiler(RegistryManager.JDKPath);
            else
                MessageBox.Show("JDK Not found!");
        }
        private void compiler(string jdkpath)
        {
            
            if (String.IsNullOrEmpty(jdkpath))
                jdkpath = "javac";
            else
                jdkpath = jdkpath + "javac.exe";
            process.StartInfo = new ProcessStartInfo()
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = jdkpath,
                Arguments = "\"" + doc.File + "\"",
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };
            process.EnableRaisingEvents = true;
            process.Start();

            while (!process.HasExited)
            {
                Thread.Sleep(1000);
                if (!process.HasExited)
                    process.Kill();
            }
        }
        private void compilerWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (process.ExitCode == 0)
            {
                ConsoleView.TextBox().Text = "";
                setBottomBackColor("#008000", "#50cf50");
                ShowPanel(consoleView, lblConsole);
                runWorker.RunWorkerAsync();
            }
            else
            {
                string output = process.StandardError.ReadToEnd();
                int error = CompileErrors(output);
                setBottomBackColor("#ff0000", "#f72929");
                ShowPanel(problemsView, lblProblems);
                ProblemsView.TextBox().Text = output;
                ProblemsView.TextBox().SelectionStart = ProblemsView.TextBox().Text.Length;
                ProblemsView.TextBox().ScrollToCaret();
                // change this to a grid view...
                /*if (error > 0)
                    lblProblems.Text = "PROBLEMS " + error;
                else
                    lblProblems.Text = "PROBLEMS -TOO MANY!";
                    */
            }
        }
        private int CompileErrors(string output)
        { 
            var result = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            // Length - 2 because the last array is always empty output.Split
            var numErrors = "";
            if(result.Length > 2)
                numErrors = result[result.Length - 2];
            numErrors = numErrors.Replace("errors", "");
            numErrors = numErrors.Replace("error", "");
            int num = 0;
            Int32.TryParse(numErrors, out num);
            return num;
        }
        #endregion

        #region Run [After Compiling]

        /// <summary>
        /// This console runs after the code is compiled
        /// it is required
        /// </summary>
        private void runWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string javaFile = file.Replace(".java", "");
            var s = javaFile.Split('\\');
            string filepath = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 1)
                    filepath += s[i] + "\\\\";
            }
            javaFile = s[s.Length - 1];
            if(RegistryManager.JDKFound)
            {
                if (run)
                    Run(RegistryManager.JDKPath, filepath, javaFile, "testing 12 3");
            }

        }

        private void runWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // nothing to do yet...
        }
        private void Run(string jdkpath, string filepath, string jFile, string args)
        {
            try
            {
                run = false;
                // update the bottompanel to orange...
                setBottomBackColor("#ffa500", "#f4b94e");
                
                if (String.IsNullOrEmpty(jdkpath))
                    jdkpath = "java";
                else
                    jdkpath = jdkpath + "java.exe";

                // using isRunning for another component
                // the component has not been implemented in this version yet...
                if (isRunning) { InterProc = new Process(); isRunning = false; }
                isRunning = true;
                InterProc.StartInfo.UseShellExecute = false;
                InterProc.StartInfo.FileName = jdkpath;
                InterProc.StartInfo.Arguments = "-classpath \"" + filepath + "\" " + jFile + " " + args;
                InterProc.StartInfo.RedirectStandardInput = true;
                InterProc.StartInfo.RedirectStandardOutput = true;
                InterProc.StartInfo.RedirectStandardError = true;
                InterProc.StartInfo.CreateNoWindow = true;
                InterProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                InterProc.OutputDataReceived += new DataReceivedEventHandler(InterProcOutputHandler);

                bool started = InterProc.Start();
                // terminate button visible now [a future for the beta version]
                //btnTerminate.Enabled = true;
                //btnTerminate.Visible = true;
                InterProc.BeginOutputReadLine();
            }catch(System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show("An internal error has occurred, please use another compiler, or contact the sysAdmin.");
            }

        }

        private void AppendTextInBox(RichTextBox box, string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action<RichTextBox, string>)AppendTextInBox, ConsoleView.TextBox(), text);
            }
            else
            {
                box.Text += text;
            }
        }

        private void InterProcOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            AppendTextInBox(ConsoleView.TextBox(), outLine.Data + Environment.NewLine);
            if (InterProc.HasExited)
            {
                setBottomBackColor("#68217a", "#812e96");
                //if (InterProc.ExitCode == 0)
            }
        }
        #endregion
        
        #region Search in the background
        /*
         * This is to update jdkLabel from the thread 
         */
        private void updateSearch(string text, Color color)
        {
            if (this.jdkLabel.InvokeRequired)
            {
                this.jdkLabel.BeginInvoke((MethodInvoker)delegate () { this.jdkLabel.Text = text; this.jdkLabel.ForeColor = color; });
            }
            else
            {
                this.jdkLabel.Text = text;
                this.jdkLabel.ForeColor = color;
            }
        }

        private void searchJDKWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            updateSearch("jdk: searching...", Color.Yellow);
            // detects JDK and updates the registry
            // look into DetectJDK Begin() function
            detectJDK.Begin();
            if (RegistryManager.JDKFound)
                jdk_path = RegistryManager.JDKPath;
            
        }

        private void searchJDKWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (RegistryManager.JDKFound)
                updateSearch("jdk: Detected", Color.White);
            else
                updateSearch("jdk: NOT FOUND", Color.OrangeRed);
        }
        #endregion

        #region Menu Items _Click
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showAbout();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newFile();
        }

        private void newWinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newWindow();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAs();
        }

        private void startDebuggingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F5();
        }

        private void buildSolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F7();
        }
        #endregion

        private void jdkLabel_Click(object sender, EventArgs e)
        {
            DialogResult search = MessageBox.Show("Search Again?",
                                                   "JDK & JRE Location",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);
            if (search == DialogResult.Yes) { RegistryManager.UpdateJDK(false, ""); searchJDKWorker.RunWorkerAsync(); }
        }
        private void ShowPanel(Form view, Label label)
        {
            view.TopLevel = false;
            outputBodyPanel.Controls.Clear();
            outputBodyPanel.Controls.Add(view);
            view.Invalidate();
            view.Show();
            RemoveLabelUnderLine();
            label.Font = new Font(lblConsole.Font.Name, lblConsole.Font.SizeInPoints, FontStyle.Underline);
        }
        private void RemoveLabelUnderLine()
        {
            lblProjectEuler.Font = new Font(lblConsole.Font.Name, lblConsole.Font.SizeInPoints, FontStyle.Regular);
            lblProfile.Font = new Font(lblConsole.Font.Name, lblConsole.Font.SizeInPoints, FontStyle.Regular);
            lblConsole.Font = new Font(lblConsole.Font.Name, lblConsole.Font.SizeInPoints, FontStyle.Regular);
            lblProblems.Font = new Font(lblProblems.Font.Name, lblProblems.Font.SizeInPoints, FontStyle.Regular);
        }
        private void lblProfile_Click(object sender, EventArgs e)
        {
            ShowPanel(profileView, lblProfile);
            Console.WriteLine(ExpanderMove(0) + "");
            if (ExpanderMove(0) > this.Height - 304)
            {
                // do this later!!! fix it
                //MessageBox.Show(ExpanderMove(0)+" : " +(outputBodyPanel.Height - 81));
                ExpanderMove(-160);
            }
        }

        private void lblProjectEuler_Click(object sender, EventArgs e)
        {
            ShowPanel(eulerView, lblProjectEuler);
            if (ExpanderMove(0) > this.Height - 225)
                ExpanderMove(-160);
        }

        private void Javapad_Move(object sender, EventArgs e)
        {
            location = this.Location;
            Console.WriteLine("form: Location: " + this.Location);
        }
    }
}
