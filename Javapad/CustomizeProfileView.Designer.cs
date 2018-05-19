namespace Javapad
{
    partial class CustomizeProfileView
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
            this.pnlBg = new System.Windows.Forms.Panel();
            this.lblChangeColor = new System.Windows.Forms.Label();
            this.pnlCancel = new System.Windows.Forms.Panel();
            this.lblCancel = new System.Windows.Forms.Label();
            this.pnlSave = new System.Windows.Forms.Panel();
            this.lblSave = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.avatar = new CircularPictureBox();
            this.pnlBg.SuspendLayout();
            this.pnlCancel.SuspendLayout();
            this.pnlSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBg
            // 
            this.pnlBg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlBg.Controls.Add(this.lblChangeColor);
            this.pnlBg.Controls.Add(this.pnlCancel);
            this.pnlBg.Controls.Add(this.pnlSave);
            this.pnlBg.Controls.Add(this.txtFullName);
            this.pnlBg.Controls.Add(this.txtUserName);
            this.pnlBg.Controls.Add(this.avatar);
            this.pnlBg.Location = new System.Drawing.Point(0, 0);
            this.pnlBg.Name = "pnlBg";
            this.pnlBg.Size = new System.Drawing.Size(623, 318);
            this.pnlBg.TabIndex = 0;
            this.pnlBg.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblChangeColor
            // 
            this.lblChangeColor.AutoSize = true;
            this.lblChangeColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChangeColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeColor.ForeColor = System.Drawing.Color.White;
            this.lblChangeColor.Location = new System.Drawing.Point(247, 195);
            this.lblChangeColor.Name = "lblChangeColor";
            this.lblChangeColor.Size = new System.Drawing.Size(103, 20);
            this.lblChangeColor.TabIndex = 23;
            this.lblChangeColor.Text = "Change color";
            this.lblChangeColor.Click += new System.EventHandler(this.lblChangeColor_Click);
            // 
            // pnlCancel
            // 
            this.pnlCancel.Controls.Add(this.lblCancel);
            this.pnlCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCancel.Location = new System.Drawing.Point(400, 15);
            this.pnlCancel.Name = "pnlCancel";
            this.pnlCancel.Size = new System.Drawing.Size(150, 30);
            this.pnlCancel.TabIndex = 13;
            this.pnlCancel.Click += new System.EventHandler(this.Cancel_Click);
            this.pnlCancel.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCancel_Paint);
            // 
            // lblCancel
            // 
            this.lblCancel.AutoSize = true;
            this.lblCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancel.ForeColor = System.Drawing.Color.White;
            this.lblCancel.Location = new System.Drawing.Point(40, 4);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(58, 20);
            this.lblCancel.TabIndex = 0;
            this.lblCancel.Text = "Cancel";
            this.lblCancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // pnlSave
            // 
            this.pnlSave.Controls.Add(this.lblSave);
            this.pnlSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlSave.Location = new System.Drawing.Point(251, 15);
            this.pnlSave.Name = "pnlSave";
            this.pnlSave.Size = new System.Drawing.Size(150, 30);
            this.pnlSave.TabIndex = 22;
            this.pnlSave.Click += new System.EventHandler(this.Save_Click);
            this.pnlSave.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSave_Paint);
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSave.ForeColor = System.Drawing.Color.White;
            this.lblSave.Location = new System.Drawing.Point(54, 4);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(45, 20);
            this.lblSave.TabIndex = 0;
            this.lblSave.Text = "Save";
            this.lblSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // txtFullName
            // 
            this.txtFullName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.ForeColor = System.Drawing.Color.White;
            this.txtFullName.Location = new System.Drawing.Point(251, 62);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(299, 31);
            this.txtFullName.TabIndex = 21;
            this.txtFullName.MouseEnter += new System.EventHandler(this.txtFullName_MouseEnter);
            this.txtFullName.MouseLeave += new System.EventHandler(this.txtFullName_MouseLeave);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.Color.White;
            this.txtUserName.Location = new System.Drawing.Point(251, 112);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(299, 60);
            this.txtUserName.TabIndex = 20;
            this.txtUserName.MouseEnter += new System.EventHandler(this.txtUserName_MouseEnter);
            this.txtUserName.MouseLeave += new System.EventHandler(this.txtUserName_MouseLeave);
            // 
            // avatar
            // 
            this.avatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avatar.Location = new System.Drawing.Point(15, 15);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(200, 200);
            this.avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatar.TabIndex = 19;
            this.avatar.TabStop = false;
            this.avatar.Tag = "";
            this.avatar.Click += new System.EventHandler(this.avatar_Click);
            this.avatar.MouseEnter += new System.EventHandler(this.avatar_MouseEnter);
            this.avatar.MouseLeave += new System.EventHandler(this.avatar_MouseLeave);
            // 
            // CustomizeProfileView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 318);
            this.Controls.Add(this.pnlBg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomizeProfileView";
            this.Text = "CustomizeProfileView";
            this.Load += new System.EventHandler(this.CustomizeProfileView_Load);
            this.pnlBg.ResumeLayout(false);
            this.pnlBg.PerformLayout();
            this.pnlCancel.ResumeLayout(false);
            this.pnlCancel.PerformLayout();
            this.pnlSave.ResumeLayout(false);
            this.pnlSave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBg;
        private CircularPictureBox avatar;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Panel pnlCancel;
        private System.Windows.Forms.Label lblCancel;
        private System.Windows.Forms.Panel pnlSave;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.Label lblChangeColor;
    }
}