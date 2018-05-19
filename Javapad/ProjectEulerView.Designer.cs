namespace Javapad
{
    partial class ProjectEulerView
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
            this.jumptoTextBox = new System.Windows.Forms.TextBox();
            this.answerTextBox = new System.Windows.Forms.TextBox();
            this.problemTextBox = new System.Windows.Forms.RichTextBox();
            this.arrowRight = new System.Windows.Forms.PictureBox();
            this.arrowLeft = new System.Windows.Forms.PictureBox();
            this.pnlBG = new System.Windows.Forms.Panel();
            this.lblQestionNum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnZoomOut = new System.Windows.Forms.PictureBox();
            this.btnZoomIn = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.arrowRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowLeft)).BeginInit();
            this.pnlBG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnZoomOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnZoomIn)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // jumptoTextBox
            // 
            this.jumptoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.jumptoTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.jumptoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.jumptoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.jumptoTextBox.ForeColor = System.Drawing.Color.Orange;
            this.jumptoTextBox.Location = new System.Drawing.Point(431, 5);
            this.jumptoTextBox.Name = "jumptoTextBox";
            this.jumptoTextBox.Size = new System.Drawing.Size(150, 22);
            this.jumptoTextBox.TabIndex = 7;
            this.jumptoTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.jumptoTextBox_KeyDown);
            // 
            // answerTextBox
            // 
            this.answerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.answerTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.answerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.answerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.answerTextBox.ForeColor = System.Drawing.Color.Orange;
            this.answerTextBox.Location = new System.Drawing.Point(9, 3);
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(214, 22);
            this.answerTextBox.TabIndex = 1;
            this.answerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.answerTextBox_KeyDown);
            // 
            // problemTextBox
            // 
            this.problemTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.problemTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.problemTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.problemTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.problemTextBox.ForeColor = System.Drawing.Color.White;
            this.problemTextBox.Location = new System.Drawing.Point(1, 3);
            this.problemTextBox.Name = "problemTextBox";
            this.problemTextBox.ReadOnly = true;
            this.problemTextBox.Size = new System.Drawing.Size(577, 148);
            this.problemTextBox.TabIndex = 2;
            this.problemTextBox.Text = "";
            this.problemTextBox.MouseEnter += new System.EventHandler(this.problemTextBox_MouseEnter);
            this.problemTextBox.MouseLeave += new System.EventHandler(this.problemTextBox_MouseLeave);
            // 
            // arrowRight
            // 
            this.arrowRight.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.arrowRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.arrowRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.arrowRight.Image = global::Javapad.Properties.Resources.right_arrow_dark;
            this.arrowRight.Location = new System.Drawing.Point(128, 0);
            this.arrowRight.Name = "arrowRight";
            this.arrowRight.Size = new System.Drawing.Size(15, 22);
            this.arrowRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.arrowRight.TabIndex = 1;
            this.arrowRight.TabStop = false;
            this.arrowRight.Click += new System.EventHandler(this.arrowRight_Click);
            // 
            // arrowLeft
            // 
            this.arrowLeft.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.arrowLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.arrowLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.arrowLeft.Image = global::Javapad.Properties.Resources.left_arrow_dark;
            this.arrowLeft.Location = new System.Drawing.Point(27, 0);
            this.arrowLeft.Name = "arrowLeft";
            this.arrowLeft.Size = new System.Drawing.Size(14, 22);
            this.arrowLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.arrowLeft.TabIndex = 0;
            this.arrowLeft.TabStop = false;
            this.arrowLeft.Click += new System.EventHandler(this.arrowLeft_Click);
            // 
            // pnlBG
            // 
            this.pnlBG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.pnlBG.Controls.Add(this.panel5);
            this.pnlBG.Controls.Add(this.problemTextBox);
            this.pnlBG.Location = new System.Drawing.Point(0, 0);
            this.pnlBG.Name = "pnlBG";
            this.pnlBG.Size = new System.Drawing.Size(581, 222);
            this.pnlBG.TabIndex = 0;
            this.pnlBG.MouseEnter += new System.EventHandler(this.pnlBG_MouseEnter);
            // 
            // lblQestionNum
            // 
            this.lblQestionNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQestionNum.AutoSize = true;
            this.lblQestionNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQestionNum.ForeColor = System.Drawing.Color.Gold;
            this.lblQestionNum.Location = new System.Drawing.Point(84, 0);
            this.lblQestionNum.Name = "lblQestionNum";
            this.lblQestionNum.Size = new System.Drawing.Size(18, 20);
            this.lblQestionNum.TabIndex = 12;
            this.lblQestionNum.Text = "1";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(66, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Q";
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnZoomOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnZoomOut.Image = global::Javapad.Properties.Resources.zoom_out_yellow;
            this.btnZoomOut.Location = new System.Drawing.Point(150, 0);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(20, 20);
            this.btnZoomOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnZoomOut.TabIndex = 10;
            this.btnZoomOut.TabStop = false;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnZoomIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnZoomIn.Image = global::Javapad.Properties.Resources.zoom_in_yellow;
            this.btnZoomIn.Location = new System.Drawing.Point(0, 0);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(20, 20);
            this.btnZoomIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnZoomIn.TabIndex = 9;
            this.btnZoomIn.TabStop = false;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.Controls.Add(this.arrowRight);
            this.panel1.Controls.Add(this.arrowLeft);
            this.panel1.Controls.Add(this.lblQestionNum);
            this.panel1.Controls.Add(this.btnZoomOut);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnZoomIn);
            this.panel1.Location = new System.Drawing.Point(245, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 22);
            this.panel1.TabIndex = 8;
            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlTop.Controls.Add(this.answerTextBox);
            this.pnlTop.Location = new System.Drawing.Point(3, 3);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(226, 27);
            this.pnlTop.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(584, 2);
            this.panel2.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Location = new System.Drawing.Point(235, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 30);
            this.panel3.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Location = new System.Drawing.Point(424, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 30);
            this.panel4.TabIndex = 16;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pnlTop);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.jumptoTextBox);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 189);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(581, 33);
            this.panel5.TabIndex = 17;
            // 
            // ProjectEulerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(581, 222);
            this.Controls.Add(this.pnlBG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProjectEulerView";
            this.Text = "ProjectEuler";
            this.Load += new System.EventHandler(this.ProjectEuler_Load);
            this.MouseEnter += new System.EventHandler(this.ProjectEulerView_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.arrowRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowLeft)).EndInit();
            this.pnlBG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnZoomOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnZoomIn)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox arrowRight;
        private System.Windows.Forms.PictureBox arrowLeft;
        private System.Windows.Forms.TextBox answerTextBox;
        private System.Windows.Forms.RichTextBox problemTextBox;
        private System.Windows.Forms.TextBox jumptoTextBox;
        private System.Windows.Forms.Panel pnlBG;
        private System.Windows.Forms.PictureBox btnZoomIn;
        private System.Windows.Forms.PictureBox btnZoomOut;
        private System.Windows.Forms.Label lblQestionNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
    }
}