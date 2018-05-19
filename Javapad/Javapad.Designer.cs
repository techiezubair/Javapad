namespace Javapad
{
    partial class Javapad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Javapad));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.editorBox = new System.Windows.Forms.RichTextBox();
            this.lineBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildSolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startDebuggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.outputPanel = new System.Windows.Forms.Panel();
            this.lblProfile = new System.Windows.Forms.Label();
            this.lblProjectEuler = new System.Windows.Forms.Label();
            this.outputBodyPanel = new System.Windows.Forms.Panel();
            this.lblProblems = new System.Windows.Forms.Label();
            this.lblConsole = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.aboutMeLabel = new System.Windows.Forms.Label();
            this.jdkLabel = new System.Windows.Forms.Label();
            this.posLabel = new System.Windows.Forms.Label();
            this.outputExpander = new System.Windows.Forms.Panel();
            this.compilerWorker = new System.ComponentModel.BackgroundWorker();
            this.runWorker = new System.ComponentModel.BackgroundWorker();
            this.searchJDKWorker = new System.ComponentModel.BackgroundWorker();
            this.mainPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.outputPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.mainPanel.Controls.Add(this.editorBox);
            this.mainPanel.Controls.Add(this.lineBox);
            this.mainPanel.Controls.Add(this.menuStrip1);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(659, 375);
            this.mainPanel.TabIndex = 0;
            // 
            // editorBox
            // 
            this.editorBox.AcceptsTab = true;
            this.editorBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.editorBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editorBox.DetectUrls = false;
            this.editorBox.Font = new System.Drawing.Font("Courier New", 14.25F);
            this.editorBox.ForeColor = System.Drawing.Color.White;
            this.editorBox.Location = new System.Drawing.Point(64, 27);
            this.editorBox.Name = "editorBox";
            this.editorBox.Size = new System.Drawing.Size(596, 348);
            this.editorBox.TabIndex = 0;
            this.editorBox.Text = "";
            this.editorBox.WordWrap = false;
            this.editorBox.SelectionChanged += new System.EventHandler(this.editorBox_SelectionChanged);
            this.editorBox.VScroll += new System.EventHandler(this.editorBox_VScroll);
            this.editorBox.Click += new System.EventHandler(this.editorBox_Click);
            this.editorBox.FontChanged += new System.EventHandler(this.editorBox_FontChanged);
            this.editorBox.TextChanged += new System.EventHandler(this.editorBox_TextChanged);
            this.editorBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editorBox_KeyDown);
            this.editorBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.editorBox_KeyUp);
            // 
            // lineBox
            // 
            this.lineBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lineBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lineBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lineBox.DetectUrls = false;
            this.lineBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lineBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lineBox.Location = new System.Drawing.Point(0, 27);
            this.lineBox.Name = "lineBox";
            this.lineBox.ReadOnly = true;
            this.lineBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.lineBox.Size = new System.Drawing.Size(64, 348);
            this.lineBox.TabIndex = 0;
            this.lineBox.TabStop = false;
            this.lineBox.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.buildToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(659, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.newWinToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // newWinToolStripMenuItem
            // 
            this.newWinToolStripMenuItem.Image = global::Javapad.Properties.Resources.blank_document_big_J;
            this.newWinToolStripMenuItem.Name = "newWinToolStripMenuItem";
            this.newWinToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.newWinToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.newWinToolStripMenuItem.Text = "New &Window";
            this.newWinToolStripMenuItem.Click += new System.EventHandler(this.newWinToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(217, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(217, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(220, 22);
            this.exitToolStripMenuItem1.Text = "E&xit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildSolutionToolStripMenuItem});
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.buildToolStripMenuItem.Text = "&Build";
            // 
            // buildSolutionToolStripMenuItem
            // 
            this.buildSolutionToolStripMenuItem.Name = "buildSolutionToolStripMenuItem";
            this.buildSolutionToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.buildSolutionToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.buildSolutionToolStripMenuItem.Text = "Build &Solution";
            this.buildSolutionToolStripMenuItem.Click += new System.EventHandler(this.buildSolutionToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startDebuggingToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "&Debug";
            // 
            // startDebuggingToolStripMenuItem
            // 
            this.startDebuggingToolStripMenuItem.Image = global::Javapad.Properties.Resources.run;
            this.startDebuggingToolStripMenuItem.Name = "startDebuggingToolStripMenuItem";
            this.startDebuggingToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.startDebuggingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startDebuggingToolStripMenuItem.Text = "&Run";
            this.startDebuggingToolStripMenuItem.Click += new System.EventHandler(this.startDebuggingToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem1.Text = "&Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem1.Text = "&About...";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // outputPanel
            // 
            this.outputPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.outputPanel.Controls.Add(this.lblProfile);
            this.outputPanel.Controls.Add(this.lblProjectEuler);
            this.outputPanel.Controls.Add(this.outputBodyPanel);
            this.outputPanel.Controls.Add(this.lblProblems);
            this.outputPanel.Controls.Add(this.lblConsole);
            this.outputPanel.Location = new System.Drawing.Point(0, 375);
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.Size = new System.Drawing.Size(659, 112);
            this.outputPanel.TabIndex = 1;
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Font = new System.Drawing.Font("DengXian", 12F);
            this.lblProfile.ForeColor = System.Drawing.Color.White;
            this.lblProfile.Location = new System.Drawing.Point(288, 9);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(52, 17);
            this.lblProfile.TabIndex = 5;
            this.lblProfile.Text = "Profile";
            this.lblProfile.Click += new System.EventHandler(this.lblProfile_Click);
            // 
            // lblProjectEuler
            // 
            this.lblProjectEuler.AutoSize = true;
            this.lblProjectEuler.Font = new System.Drawing.Font("DengXian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectEuler.ForeColor = System.Drawing.Color.White;
            this.lblProjectEuler.Location = new System.Drawing.Point(183, 9);
            this.lblProjectEuler.Name = "lblProjectEuler";
            this.lblProjectEuler.Size = new System.Drawing.Size(89, 17);
            this.lblProjectEuler.TabIndex = 4;
            this.lblProjectEuler.Text = "ProjectEuler";
            this.lblProjectEuler.Click += new System.EventHandler(this.lblProjectEuler_Click);
            // 
            // outputBodyPanel
            // 
            this.outputBodyPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputBodyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.outputBodyPanel.Location = new System.Drawing.Point(4, 31);
            this.outputBodyPanel.Name = "outputBodyPanel";
            this.outputBodyPanel.Size = new System.Drawing.Size(652, 75);
            this.outputBodyPanel.TabIndex = 3;
            this.outputBodyPanel.Resize += new System.EventHandler(this.outputBodyPanel_Resize);
            // 
            // lblProblems
            // 
            this.lblProblems.AutoSize = true;
            this.lblProblems.Font = new System.Drawing.Font("DengXian", 12F);
            this.lblProblems.ForeColor = System.Drawing.Color.White;
            this.lblProblems.Location = new System.Drawing.Point(95, 9);
            this.lblProblems.Name = "lblProblems";
            this.lblProblems.Size = new System.Drawing.Size(72, 17);
            this.lblProblems.TabIndex = 2;
            this.lblProblems.Text = "Problems";
            this.lblProblems.Click += new System.EventHandler(this.lblProblems_Click);
            // 
            // lblConsole
            // 
            this.lblConsole.AutoSize = true;
            this.lblConsole.Font = new System.Drawing.Font("DengXian", 12F, System.Drawing.FontStyle.Underline);
            this.lblConsole.ForeColor = System.Drawing.Color.White;
            this.lblConsole.Location = new System.Drawing.Point(15, 9);
            this.lblConsole.Name = "lblConsole";
            this.lblConsole.Size = new System.Drawing.Size(64, 17);
            this.lblConsole.TabIndex = 1;
            this.lblConsole.Text = "Console";
            this.lblConsole.Click += new System.EventHandler(this.lblOutput_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(33)))), ((int)(((byte)(122)))));
            this.bottomPanel.Controls.Add(this.aboutMeLabel);
            this.bottomPanel.Controls.Add(this.jdkLabel);
            this.bottomPanel.Controls.Add(this.posLabel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 487);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(660, 20);
            this.bottomPanel.TabIndex = 2;
            // 
            // aboutMeLabel
            // 
            this.aboutMeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutMeLabel.BackColor = System.Drawing.Color.Transparent;
            this.aboutMeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutMeLabel.ForeColor = System.Drawing.Color.White;
            this.aboutMeLabel.Location = new System.Drawing.Point(634, 0);
            this.aboutMeLabel.Name = "aboutMeLabel";
            this.aboutMeLabel.Padding = new System.Windows.Forms.Padding(4, 0, 5, 0);
            this.aboutMeLabel.Size = new System.Drawing.Size(20, 20);
            this.aboutMeLabel.TabIndex = 2;
            this.aboutMeLabel.Text = "!";
            this.aboutMeLabel.Click += new System.EventHandler(this.aboutMeLabel_Click);
            this.aboutMeLabel.MouseEnter += new System.EventHandler(this.aboutMeLabel_MouseEnter);
            this.aboutMeLabel.MouseLeave += new System.EventHandler(this.aboutMeLabel_MouseLeave);
            // 
            // jdkLabel
            // 
            this.jdkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.jdkLabel.AutoSize = true;
            this.jdkLabel.ForeColor = System.Drawing.Color.White;
            this.jdkLabel.Location = new System.Drawing.Point(13, 0);
            this.jdkLabel.Name = "jdkLabel";
            this.jdkLabel.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.jdkLabel.Size = new System.Drawing.Size(78, 16);
            this.jdkLabel.TabIndex = 1;
            this.jdkLabel.Text = "jdk: not found";
            this.jdkLabel.Click += new System.EventHandler(this.jdkLabel_Click);
            this.jdkLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.jdkLabel_MouseClick);
            this.jdkLabel.MouseEnter += new System.EventHandler(this.jdkLabel_MouseEnter);
            this.jdkLabel.MouseLeave += new System.EventHandler(this.jdkLabel_MouseLeave);
            // 
            // posLabel
            // 
            this.posLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.posLabel.AutoSize = true;
            this.posLabel.BackColor = System.Drawing.Color.Transparent;
            this.posLabel.ForeColor = System.Drawing.Color.White;
            this.posLabel.Location = new System.Drawing.Point(327, 0);
            this.posLabel.Name = "posLabel";
            this.posLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.posLabel.Size = new System.Drawing.Size(64, 16);
            this.posLabel.TabIndex = 0;
            this.posLabel.Text = "Ln, Col, Pos";
            // 
            // outputExpander
            // 
            this.outputExpander.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputExpander.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.outputExpander.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.outputExpander.Location = new System.Drawing.Point(0, 375);
            this.outputExpander.Name = "outputExpander";
            this.outputExpander.Size = new System.Drawing.Size(659, 4);
            this.outputExpander.TabIndex = 0;
            this.outputExpander.MouseDown += new System.Windows.Forms.MouseEventHandler(this.outputExpander_MouseDown);
            this.outputExpander.MouseMove += new System.Windows.Forms.MouseEventHandler(this.outputExpander_MouseMove);
            this.outputExpander.MouseUp += new System.Windows.Forms.MouseEventHandler(this.outputExpander_MouseUp);
            // 
            // compilerWorker
            // 
            this.compilerWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.compilerWorker_DoWork);
            this.compilerWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.compilerWorker_RunWorkerCompleted);
            // 
            // runWorker
            // 
            this.runWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.runWorker_DoWork);
            this.runWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.runWorker_RunWorkerCompleted);
            // 
            // searchJDKWorker
            // 
            this.searchJDKWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.searchJDKWorker_DoWork);
            this.searchJDKWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.searchJDKWorker_RunWorkerCompleted);
            // 
            // Javapad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(660, 507);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.outputExpander);
            this.Controls.Add(this.outputPanel);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Javapad";
            this.Text = "Javapad - Untitled";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Javapad_FormClosing);
            this.Load += new System.EventHandler(this.Javapad_Load);
            this.Move += new System.EventHandler(this.Javapad_Move);
            this.Resize += new System.EventHandler(this.Javapad_Resize);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.outputPanel.ResumeLayout(false);
            this.outputPanel.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel outputPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel outputExpander;
        private System.Windows.Forms.Label jdkLabel;
        private System.Windows.Forms.Label posLabel;
        private System.Windows.Forms.RichTextBox editorBox;
        private System.Windows.Forms.RichTextBox lineBox;
        private System.Windows.Forms.Panel outputBodyPanel;
        private System.Windows.Forms.Label lblProblems;
        private System.Windows.Forms.Label lblConsole;
        private System.ComponentModel.BackgroundWorker compilerWorker;
        private System.ComponentModel.BackgroundWorker runWorker;
        private System.Windows.Forms.Label aboutMeLabel;
        private System.ComponentModel.BackgroundWorker searchJDKWorker;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newWinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildSolutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startDebuggingToolStripMenuItem;
        private System.Windows.Forms.Label lblProjectEuler;
        private System.Windows.Forms.Label lblProfile;
    }
}

