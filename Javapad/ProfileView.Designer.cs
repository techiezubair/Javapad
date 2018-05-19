namespace Javapad
{
    partial class ProfileView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBG = new System.Windows.Forms.Panel();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblSolved = new System.Windows.Forms.Label();
            this.Avatar = new CircularPictureBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlMore = new System.Windows.Forms.Panel();
            this.lblMore = new System.Windows.Forms.Label();
            this.pnlCustomize = new System.Windows.Forms.Panel();
            this.lblCustomize = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.solvedGridView = new System.Windows.Forms.DataGridView();
            this.problemNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            this.pnlMore.SuspendLayout();
            this.pnlCustomize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solvedGridView)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBG
            // 
            this.pnlBG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(124)))), ((int)(((byte)(16)))));
            this.pnlBG.Controls.Add(this.lblPoints);
            this.pnlBG.Controls.Add(this.lblSolved);
            this.pnlBG.Controls.Add(this.Avatar);
            this.pnlBG.Controls.Add(this.lblLevel);
            this.pnlBG.Controls.Add(this.label10);
            this.pnlBG.Controls.Add(this.label9);
            this.pnlBG.Controls.Add(this.label8);
            this.pnlBG.Controls.Add(this.pnlMore);
            this.pnlBG.Controls.Add(this.pnlCustomize);
            this.pnlBG.Controls.Add(this.lblUserName);
            this.pnlBG.Controls.Add(this.label7);
            this.pnlBG.Controls.Add(this.lblFullName);
            this.pnlBG.Controls.Add(this.label4);
            this.pnlBG.Controls.Add(this.solvedGridView);
            this.pnlBG.Location = new System.Drawing.Point(0, 0);
            this.pnlBG.Name = "pnlBG";
            this.pnlBG.Size = new System.Drawing.Size(639, 357);
            this.pnlBG.TabIndex = 0;
            this.pnlBG.VisibleChanged += new System.EventHandler(this.pnlBG_VisibleChanged);
            this.pnlBG.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlBG_ControlRemoved);
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("DengXian", 12F);
            this.lblPoints.ForeColor = System.Drawing.Color.Gold;
            this.lblPoints.Location = new System.Drawing.Point(370, 17);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(16, 17);
            this.lblPoints.TabIndex = 3;
            this.lblPoints.Text = "1";
            // 
            // lblSolved
            // 
            this.lblSolved.AutoSize = true;
            this.lblSolved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolved.ForeColor = System.Drawing.Color.Gold;
            this.lblSolved.Location = new System.Drawing.Point(252, 195);
            this.lblSolved.Margin = new System.Windows.Forms.Padding(0);
            this.lblSolved.Name = "lblSolved";
            this.lblSolved.Size = new System.Drawing.Size(19, 20);
            this.lblSolved.TabIndex = 2;
            this.lblSolved.Text = "0";
            // 
            // Avatar
            // 
            this.Avatar.Image = global::Javapad.Properties.Resources.haloavatar1;
            this.Avatar.Location = new System.Drawing.Point(15, 15);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(200, 200);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Avatar.TabIndex = 18;
            this.Avatar.TabStop = false;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("DengXian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.ForeColor = System.Drawing.Color.Gold;
            this.lblLevel.Location = new System.Drawing.Point(417, 198);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(69, 17);
            this.lblLevel.TabIndex = 17;
            this.lblLevel.Text = "Beginner";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("DengXian", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(417, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "Level";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("DengXian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(289, 197);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "/ 476";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("DengXian", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(253, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "ProjectEuler Solved";
            // 
            // pnlMore
            // 
            this.pnlMore.Controls.Add(this.lblMore);
            this.pnlMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMore.Location = new System.Drawing.Point(404, 125);
            this.pnlMore.Name = "pnlMore";
            this.pnlMore.Size = new System.Drawing.Size(150, 30);
            this.pnlMore.TabIndex = 13;
            this.pnlMore.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // lblMore
            // 
            this.lblMore.AutoSize = true;
            this.lblMore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMore.ForeColor = System.Drawing.Color.White;
            this.lblMore.Location = new System.Drawing.Point(52, 4);
            this.lblMore.Name = "lblMore";
            this.lblMore.Size = new System.Drawing.Size(45, 20);
            this.lblMore.TabIndex = 1;
            this.lblMore.Text = "more";
            // 
            // pnlCustomize
            // 
            this.pnlCustomize.Controls.Add(this.lblCustomize);
            this.pnlCustomize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCustomize.Location = new System.Drawing.Point(256, 125);
            this.pnlCustomize.Name = "pnlCustomize";
            this.pnlCustomize.Size = new System.Drawing.Size(150, 30);
            this.pnlCustomize.TabIndex = 12;
            this.pnlCustomize.Click += new System.EventHandler(this.pnlCustomize_Click);
            this.pnlCustomize.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // lblCustomize
            // 
            this.lblCustomize.AutoSize = true;
            this.lblCustomize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomize.ForeColor = System.Drawing.Color.White;
            this.lblCustomize.Location = new System.Drawing.Point(40, 4);
            this.lblCustomize.Name = "lblCustomize";
            this.lblCustomize.Size = new System.Drawing.Size(81, 20);
            this.lblCustomize.TabIndex = 0;
            this.lblCustomize.Text = "customize";
            this.lblCustomize.Click += new System.EventHandler(this.lblCustomize_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("DengXian", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(246, 42);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(320, 55);
            this.lblUserName.TabIndex = 11;
            this.lblUserName.Text = "Tdot Soldier";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("DengXian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(357, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "P";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("DengXian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.Color.White;
            this.lblFullName.Location = new System.Drawing.Point(253, 17);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(62, 17);
            this.lblFullName.TabIndex = 8;
            this.lblFullName.Text = "Zee Safi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(2)))));
            this.label4.Font = new System.Drawing.Font("DengXian", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(422, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "< Problems Solved";
            // 
            // solvedGridView
            // 
            this.solvedGridView.AllowUserToAddRows = false;
            this.solvedGridView.AllowUserToDeleteRows = false;
            this.solvedGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(2)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(150)))), ((int)(((byte)(2)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.solvedGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.solvedGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.solvedGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.solvedGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.solvedGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.solvedGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(2)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(80)))), ((int)(((byte)(2)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.solvedGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.solvedGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.solvedGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.problemNumber,
            this.answer});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(2)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(150)))), ((int)(((byte)(2)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.solvedGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.solvedGridView.EnableHeadersVisualStyles = false;
            this.solvedGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(2)))));
            this.solvedGridView.Location = new System.Drawing.Point(15, 246);
            this.solvedGridView.Name = "solvedGridView";
            this.solvedGridView.ReadOnly = true;
            this.solvedGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.solvedGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.solvedGridView.Size = new System.Drawing.Size(541, 99);
            this.solvedGridView.TabIndex = 6;
            // 
            // problemNumber
            // 
            this.problemNumber.HeaderText = "Problem #";
            this.problemNumber.Name = "problemNumber";
            this.problemNumber.ReadOnly = true;
            // 
            // answer
            // 
            this.answer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.answer.HeaderText = "Answer";
            this.answer.Name = "answer";
            this.answer.ReadOnly = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Controls.Add(this.pnlBG);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(639, 357);
            this.pnlMain.TabIndex = 19;
            this.pnlMain.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlMain_ControlRemoved);
            // 
            // ProfileView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(639, 357);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProfileView";
            this.Text = "Profile";
            this.Load += new System.EventHandler(this.ProfileView_Load);
            this.VisibleChanged += new System.EventHandler(this.ProfileView_VisibleChanged);
            this.pnlBG.ResumeLayout(false);
            this.pnlBG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.pnlMore.ResumeLayout(false);
            this.pnlMore.PerformLayout();
            this.pnlCustomize.ResumeLayout(false);
            this.pnlCustomize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solvedGridView)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBG;
        private System.Windows.Forms.Label lblSolved;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.DataGridView solvedGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn problemNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn answer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlMore;
        private System.Windows.Forms.Panel pnlCustomize;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblFullName;
        private CircularPictureBox Avatar;
        private System.Windows.Forms.Label lblMore;
        private System.Windows.Forms.Label lblCustomize;
        private System.Windows.Forms.Panel pnlMain;
    }
}