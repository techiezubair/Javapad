using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Javapad
{
    public static class Prompt
    {
        /// <summary>
        /// Dialog
        /// Save, don't save, cancel
        /// </summary>
        private static int less = 39;
        public static DialogResult ShowDialog(string file, Point location)
        {
            Form prompt = new Form();
            prompt.StartPosition = FormStartPosition.Manual;
            prompt.Location = location;
            prompt.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            prompt.MinimizeBox = false;
            prompt.MaximizeBox = false;
            prompt.Width = 370;
            prompt.Height = 169;
            prompt.Text = "Javapad";
            Panel panel1 = new Panel() { Left = 0, Top = 0 } ;
            panel1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            panel1.BackColor = Color.White;
            panel1.Width = 356;
            panel1.Height = 94;
            Label label1 = new Label() { Left = 15, Top = 13, Width = 350, Text = "Do you want to save changes to" };
            label1.Font = new Font("Courier New", 12);
            label1.ForeColor = Color.Blue;
            panel1.Controls.Add(label1);
            Label fileLabel = new Label() { Left = 14, Top = 41, Width = 350, Height = 45, Text = file };
            fileLabel.Font = new Font("Courier New", 8);
            fileLabel.ForeColor = Color.Blue;
            fileLabel.AutoSize = false;
            panel1.Controls.Add(fileLabel);
            Button save = new Button() { Text = "&Save", Left = 83, Top = 101 };
            Button dont_save = new Button() { Text = "Do&n't Save", Left = 168, Top = 101, Width = 90 };
            Button cancel = new Button() { Text = "Cancel", Left = 268, Top = 101 };
            save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            dont_save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            if (String.IsNullOrEmpty(file))
            {
                panel1.Height = panel1.Height - less;
                prompt.Height = prompt.Height - less;
                save.Location = new Point(save.Location.X, save.Location.Y - less);
                dont_save.Location = new Point(dont_save.Location.X, dont_save.Location.Y - less);
                cancel.Location = new Point(cancel.Location.X, cancel.Location.Y - less);
            }
            save.Click += (sender, e) => { prompt.DialogResult = DialogResult.OK; prompt.Close(); };
            dont_save.Click += (sender, e) => { prompt.DialogResult = DialogResult.Abort; prompt.Close(); };
            cancel.Click += (sender, e) => { prompt.DialogResult = DialogResult.Cancel; prompt.Close(); };
            prompt.Controls.Add(panel1);
            prompt.Controls.Add(save);
            prompt.Controls.Add(dont_save);
            prompt.Controls.Add(cancel);
            prompt.ShowDialog();
            return prompt.DialogResult; 
        }
    }
}
