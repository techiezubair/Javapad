using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Javapad
{
    public partial class Javapad : Form
    {
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

        private bool expand = false;
        private bool isHoldCtrl = false;
        private bool fileSaved = true;
        private bool tab = false;

        private int currentCol = 1;
        private int currentLine = 1;
        private int currentPos = 1;
        private int curr_position = 0;
        private int counter = 0;

        private const int MIN_EXPAND = 60;
        private string file = "";
        private string filename = "";
        About about;

        private ConsoleView consoleView = new ConsoleView();
        private ProblemsView problemsView = new ProblemsView();

        private DetectJDK detectJDK = new DetectJDK();
        private string jdk_path = "";

        static Process InterProc = new Process();
        Process process = new Process();
        bool isRunning = false;
        
        public static Process InterProcess
        {
            get { return InterProc; }
        }
        
        public Javapad()
        {
            InitializeComponent();
        }

        private void Javapad_Load(object sender, EventArgs e)
        {
            encode.Add(COLOR1, keywordset1);
            encode.Add(COLOR2, keywordset2);
            encode.Add(COLOR6, keywordset3);
            encode.Add(COLOR7, keywordset4);
            encode.Add(COLOR5, keywordset5);
            encode.Add(COLOR4, keywordset6);
            lineBox.Font = editorBox.Font;
            editorBox.Select();
            AddLineNumbers();
            showConsolePanel();
            posLabel.Text = "Ln " + currentLine + ", Col " + currentCol + ", Pos " + currentPos;
            searchJDKWorker.RunWorkerAsync();
            if(!String.IsNullOrEmpty(Properties.Settings.Default.jdkPath))
            {
                jdk_path = Properties.Settings.Default.jdkPath;
            }
        }
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
                    // check if the line contains a single line comment 
                    int currentLine = textBox.GetLineFromCharIndex(start);
                    int firstCharofLine = textBox.GetFirstCharIndexFromLine(currentLine);
                    string lineText = "";
                    try
                    {
                        //lineText = textBox.Lines[currentLine];
                    }catch(IndexOutOfRangeException ex)
                    {

                    }
                    int posOfComment = lineText.IndexOf("//");
                    if (lineText.Contains("//"))
                    {
                        textBox.Select(firstCharofLine + posOfComment, lineText.Length);
                        textBox.SelectionColor = convertColor(COLOR6);
                        textBox.Select(start, 0);
                    }
                    else
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
        private Color convertColor(string color)
        {
            return System.Drawing.ColorTranslator.FromHtml(color);
        }

        private void showConsolePanel()
        {
            lblConsole.Font = new Font(lblConsole.Font.Name, lblConsole.Font.SizeInPoints, FontStyle.Underline);
            lblProblems.Font = new Font(lblProblems.Font.Name, lblProblems.Font.SizeInPoints, FontStyle.Regular);
            consoleView.TopLevel = false;
            outputBodyPanel.Controls.Remove(problemsView);
            outputBodyPanel.Controls.Add(consoleView);
            consoleView.Show();
        }

        private void showProblemsPanel()
        {
            lblProblems.Font = new Font(lblProblems.Font.Name, lblProblems.Font.SizeInPoints, FontStyle.Underline);
            lblConsole.Font = new Font(lblConsole.Font.Name, lblConsole.Font.SizeInPoints, FontStyle.Regular);
            problemsView.TopLevel = false;
            outputBodyPanel.Controls.Remove(consoleView);
            outputBodyPanel.Controls.Add(problemsView);
            problemsView.Show();
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
            //Console.WriteLine("font changed!");
            lineBox.Font = editorBox.Font;
            editorBox.Select();
            AddLineNumbers();
        }
        bool shift = false;
        private void editorBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.ControlKey)
            {
                lineBox.ZoomFactor = editorBox.ZoomFactor;
                isHoldCtrl = true;
                //isPaste = false;
                //MessageBox.Show("paste");
            }
            if (isHoldCtrl)
            {
                if (e.KeyCode == Keys.V)
                {
                    editorBox.SuspendLayout();
                    editorBox.ForeColor = Color.White;
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
                    editorBox.ResumeLayout();
                    // cancel the paste
                    e.Handled = true;
                }
                // open file 
                if (e.KeyCode == Keys.O)
                {
                    //Console.WriteLine("open file");
                    isHoldCtrl = false;
                    openFile();
                }
                // save file
                if (e.KeyCode == Keys.S && !shift)
                {
                    //Console.WriteLine("save file");
                    isHoldCtrl = false;
                    save();
                }
                // close this and open a new file...
                if (e.KeyCode == Keys.N)
                {
                    //Console.WriteLine("new file");
                    newFile();
                    isHoldCtrl = false;
                }
                if(e.KeyCode == Keys.ShiftKey)
                {
                    //Console.WriteLine("shift pressed");
                    shift = true;
                }
                if (shift)
                {
                    //Console.WriteLine("s is true");
                    if(e.KeyCode == Keys.S)
                    {
                        Console.WriteLine("prompt to save as");
                        saveAs();
                        shift = false;
                        isHoldCtrl = false;
                    }
                    if(e.KeyCode == Keys.N)
                    {
                        // new window
                        newWindow();
                    }
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                /*string file = editorBox.Text;
                using (StreamWriter sw = new StreamWriter("Test.java", false))
                {
                    sw.WriteLine(file);
                }*/
                //MessageBox.Show(Properties.Settings.Default.jdkFound + " and " + jdk_path);

                //compile(true);
                F5();
                
                //Console.WriteLine("\"" + file + "\"");
                // usage
                //compilerWorker.RunWorkerAsync();
                //compile(true); // compile and run

            }
            if(e.KeyCode == Keys.F4)
            {
                //Console.WriteLine("f4 pressed");
                // first save the file

                //compile_run = true;
                F4();
            }

        }
        private void F5()
        {
            compile_run = true;
            save();
        }
        private void F4()
        {
            save();
            // only compile
            compile(false);
        }
        private bool compile_run = false;
        private bool run = false;
        private void compile(bool run)
        {
            this.run = run;
            if(!String.IsNullOrEmpty(file))
                compilerWorker.RunWorkerAsync();
        }
        private void saveAs()
        {
            //Console.WriteLine("saveAs exec");
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save As";
            saveFileDialog.Filter = "Java files (*.java)|*.java|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = saveFileDialog.FileName;
                Console.WriteLine("dialogok");
                if (compile_run)
                {

                    compile(true);
                    compile_run = false;
                    Console.WriteLine("dialogok internal");
                }
                editorBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                this.Text = "Javapad - " + saveFileDialog.FileName;
                fileSaved = true;
            }else
            {
                saveFileDialog = null;
                fileSaved = false;
            }
        }
        SaveFileDialog saveFileDialog;
        private void save()
        {

            if (saveFileDialog != null || openFileDialog != null)
            {
                //Console.WriteLine("NULL both exec");
                if (saveFileDialog != null)
                {
                    file = saveFileDialog.FileName;
                    //Console.WriteLine("saveFile: " + file);
                }
                if(openFileDialog != null)
                {
                    file = openFileDialog.FileName;
                    //Console.WriteLine("openFile: " + file);
                }
                using (StreamWriter sw = new StreamWriter(file, false))
                {
                    sw.WriteLine(editorBox.Text);
                    fileSaved = true;
                }
                if (compile_run)
                {

                    compile(true);
                    compile_run = false;
                    Console.WriteLine("dialogok internal");
                }
            }
            else
            {
                saveAs();   
                /*if (openFileDialog1 != null)
                {
                    Console.WriteLine(openFileDialog1.FileName);
                    /*
                    using (StreamWriter sw = new StreamWriter(openFileDialog1.FileName, false))
                    {
                        sw.WriteLine(editorBox.Text);
                    }

                }
                else
                {
                    Console.WriteLine("Untitled document");
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        editorBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                    }
                }*/
            }
            
        }
        OpenFileDialog openFileDialog;
        private void openFile()
        {
            openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Java files (*.java)|*.java|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                   
                    editorBox.Text = File.ReadAllText(openFileDialog.FileName);
                    this.Text = "Javapad - " + openFileDialog.FileName;
                    //fileSaved = true;
                       
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }else
            {
                openFileDialog = null;
            }
        }
        private void newFile()
        {
            //Console.WriteLine("fileSaved:::::: " + fileSaved);
            if (fileSaved)
            {
                editorBox.Text = "";
                this.Text = "Javapad - Untitled";
            }
            else
            {
                save();
                if (fileSaved)
                {
                    editorBox.Text = "";
                    // call it again cuz we changed the text
                    this.Text = "Javapad - Untitled";
                }
            }
            //fileSaved = false;
            
        }
        private void newWindow()
        {
            Javapad j = new Javapad();
            j.Show();
        }
        private void editorBox_KeyUp(object sender, KeyEventArgs e)
        {
            //Console.WriteLine("ishold" + isHoldCtrl);
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
            fileSaved = false;
            curr_position = editorBox.SelectionStart;
            encodeData(editorBox, curr_position, encode);
            
        }

        private void editorBox_VScroll(object sender, EventArgs e)
        {
            lineBox.Text = "";
            AddLineNumbers();
            lineBox.Invalidate();
        }
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
        #region Console Run After Compiled

        /// <summary>
        /// This console runs after the code is compiled
        /// it is required
        /// </summary>
        private void Run(string jdkpath, string filepath, string jFile)
        {
            try
            {
                /*
                 * An exception of type 'System.ComponentModel.Win32Exception' occurred in System.dll but was not handled in user code
                   Additional information: The parameter is incorrect
                   If there is a handler for this exception, the program may be safely continued.
                 */
                //Console.WriteLine("\"" + jdkpath + "\"java");
                run = false;
                // update the bottompanel to red
                //bottomPanel.BackColor = Color.Orange;
                setBottomBackColor("#ffa500", "#f4b94e");


                if (String.IsNullOrEmpty(jdkpath))
                {
                    jdkpath = "java";
                }
                else
                {
                    jdkpath = jdkpath + "java.exe";
                }
                //fn = fn.Replace("\"\"", "");
                if (isRunning) { InterProc = new Process(); isRunning = false; }
                isRunning = true;
                InterProc.StartInfo.UseShellExecute = false;
                InterProc.StartInfo.FileName = jdkpath;
                //Console.WriteLine("path: \"" + filepath + "\"  s::: " + jFile);
                InterProc.StartInfo.Arguments = "-classpath \"" + filepath + "\" " + jFile;
                InterProc.StartInfo.RedirectStandardInput = true;
                InterProc.StartInfo.RedirectStandardOutput = true;
                InterProc.StartInfo.RedirectStandardError = true;
                InterProc.StartInfo.CreateNoWindow = true;
                InterProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                InterProc.OutputDataReceived += new DataReceivedEventHandler(InterProcOutputHandler);

                bool started = InterProc.Start();
                // terminate button visible now
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
                /*if (InterProc.ExitCode == 0)
                {
                    // orage 
                    // orage ffa500
                    setBottomBackColor("#68217a");
                }else
                {
                    setBottomBackColor("#68217a");
                }*/
            }
        }
        #endregion
        private string hoverBackColor = "#812e96";
        private void setBottomBackColor(string color, string backColor)
        {
            bottomPanel.BackColor = convertColor(color);
            hoverBackColor = backColor;
            // also the labels 812e96
            jdkLabel.BackColor = convertColor(color);
            aboutMeLabel.BackColor = convertColor(color);
            posLabel.BackColor = convertColor(color);
        }
        private void compilerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Properties.Settings.Default.jdkFound)
            {
                Console.WriteLine("running compilerWorker: " + jdk_path);
                compiler(jdk_path);
            }else
            {
                MessageBox.Show("JDK Not found!");
            }

        }
        private void compiler(string jdkpath)
        {
            Console.WriteLine("file: "+  "\"" + file + "\"");
            if (String.IsNullOrEmpty(jdkpath))
            {
                Console.WriteLine("jdk is null so run javac only");
                jdkpath = "javac";
            }else
            {

                jdkpath = jdkpath + "javac.exe";
                Console.WriteLine("jdkpath: " + jdkpath);
            }
            process.StartInfo = new ProcessStartInfo()
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = jdkpath,
                Arguments = "\"" + file + "\"",
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
                //string output = process.StandardOutput.ReadToEnd();
                //consoleBox.Text = "";
                //ConsoleView.SetText("", false);
                ConsoleView.TextBox().Text = "";
                //pnlBottom.BackColor = Color.Green;
                //bottomPanel.BackColor = Color.Green;
                // green 008000
                setBottomBackColor("#008000", "#50cf50");
                showConsolePanel();
                //Form1.displayConsolePanel();
                //Form1.SetCompileStatus("Compiled");
                runWorker.RunWorkerAsync();
                //MessageBox.Show("a: " + a + " out: "+ output);
            }
            else
            {
                //MessageBox.Show("error");
                //setCompileStatus("Compile Error");
                //Form1.SetCompileStatus("Compile Error");
                string output = process.StandardError.ReadToEnd();
                string error = CompileErrors(output);
                //Console.WriteLine("er" + error);
                int errNum;
                bool num = Int32.TryParse(error, out errNum);
                //problemsBox.Text = output;
                //problemsBox.SelectionStart = problemsBox.Text.Length;
                //problemsBox.ScrollToCaret();
                //bottomPanel.BackColor = Color.Red;
                setBottomBackColor("#ff0000", "#f72929");
                //Form1.displayProblemsPanel();
                showProblemsPanel();
                ProblemsView.TextBox().Text = output;
                ProblemsView.TextBox().SelectionStart = ProblemsView.TextBox().Text.Length;
                ProblemsView.TextBox().ScrollToCaret();
                //ProblemsView;
                if (num)
                {
                    //lblProblems.Text = "PROBLEMS " + errNum;

                }
                else
                {
                    //lblProblems.Text = "PROBLEMS -TOO MANY!";
                }
                //pnlBottom.BackColor = Color.Red;
                //showProblemsPanel();
                //Form1.displayProblemsPanel(true);
                //MessageBox.Show("a: " + a + " out: " + output);
            }
        }
        private string CompileErrors(string output)
        {
            var result = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).Reverse().Take(2).ToArray();

            var numErrors = "";
            try
            {
                numErrors = result[1].Substring(0, result[1].IndexOf(' '));
            }
            catch (IndexOutOfRangeException ex)
            {

            }
            return numErrors.Trim();
        }
        // DETECT jdk in the system!

        private void runWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string javaFile = file.Replace(".java", "");
            //Console.WriteLine("javaFile: " + javaFile);
            var s = javaFile.Split('\\');
            string filepath = "";
            for(int i = 0; i < s.Length; i++)
            {
                if (i < s.Length-1)
                    filepath += s[i] + "\\\\";
            }
            //Console.WriteLine("path: \"" + filepath + "\"  s::: " + s[s.Length - 1]);
            javaFile = s[s.Length - 1];
            //Console.WriteLine("path: \"" + filepath + "\"  s::: " + javaFile);
            if (Properties.Settings.Default.jdkFound)
            {
                if (run)
                    Run(jdk_path, filepath, javaFile);
            }
                
        }

        private void runWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void lblOutput_Click(object sender, EventArgs e)
        {
            showConsolePanel();
            /*if (ExpanderMove(0) > this.Height - MIN_EXPAND - 100)
                ExpanderMove(-100); */
        }

        private void lblProblems_Click(object sender, EventArgs e)
        {
            showProblemsPanel();
        }

        private void Javapad_Resize(object sender, EventArgs e)
        {
            if(outputExpander.Location.Y < 0)
            {
                outputExpander.Location = new Point(0, 10);
                ExpanderMove(0);
            }
            if(outputExpander.Location.Y > this.Height)
            {
                outputExpander.Location = new Point(0, this.Height - MIN_EXPAND - 60);
                ExpanderMove(0);
            }
        }

        private void outputBodyPanel_Resize(object sender, EventArgs e)
        {
            if(consoleView != null)
            {
                consoleView.Size = outputBodyPanel.Size;
            }
            if(problemsView != null)
            {
                problemsView.Size = outputBodyPanel.Size;
            }
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

        private void Javapad_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Console.WriteLine("filesaved: " + fileSaved);
            if (!fileSaved)
            {
                //SaveAlertBox saveBox = new SaveAlertBox();
                prompt(true);
                e.Cancel = true;
            }
        }
        private void prompt(bool close)
        {
            //Console.WriteLine("fileSaved: " + fileSaved);
            Point location = new Point(this.Location.X + 80, this.Location.Y + 100);//this.PointToScreen(this.Location);
            Console.WriteLine(location.X + " " + location.Y);
            string state = Prompt.ShowDialog(file, location);
            if (close)
            {
                if (Prompt.prompt.DialogResult == DialogResult.OK)
                {
                    //Console.WriteLine("state: : " + state);
                    if (state == "save")
                    {
                        save();
                    }
                    else if (state == "dont_save")
                    {
                        if (close)
                            Process.GetCurrentProcess().Kill();
                        else
                        {
                            editorBox.Text = "";
                            this.Text = "Java - Untitled";

                            fileSaved = true;
                        }

                    }
                    //Console.WriteLine("fafterileSaved: " + fileSaved);
                }
                else //if(Prompt.prompt.DialogResult == DialogResult.Cancel)
                {
                    //Console.WriteLine("cancelled!!!!");
                    state = "cancel";
                    fileSaved = false;
                }
            }else
            {
                if (Prompt.prompt.DialogResult == DialogResult.OK)
                {
                    editorBox.Text = "";
                    this.Text = "Java - Untitled";
                    fileSaved = true;
                }
                else
                {
                    
                }
                
            }
        }
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
            detectJDK.Begin();
            if (Properties.Settings.Default.jdkFound)
            {
                jdk_path = Properties.Settings.Default.jdkPath;
            }
        }

        private void searchJDKWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Properties.Settings.Default.jdkFound)
                updateSearch("jdk: Detected", Color.White);
            else
                updateSearch("jdk: NOT FOUND", Color.OrangeRed);
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
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showAbout();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //newFile();
            if(!fileSaved)
                prompt(false);
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
            F4();
        }
    }
}
