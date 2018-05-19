using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Javapad
{
    public partial class ConsoleView : Form
    {
        private static ConsoleView cv = null;
        private static RichTextBox staticTextBox = null;
        private delegate void TextDelegate(string text, bool append);
        private delegate RichTextBox Box();
        public ConsoleView()
        {
            InitializeComponent();

        }
        public RichTextBox ConsoleBox
        {
            get { return this.richTextBox1; }
        }
        private void ConsoleView_Load(object sender, EventArgs e)
        {
            cv = this;
            staticTextBox = richTextBox1;
        }
        public static RichTextBox TextBox()
        {
            return staticTextBox;
        }
        private RichTextBox UpdateTextBox()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Box(UpdateTextBox));
                return staticTextBox;
            }
            return staticTextBox;
        }
        public static void SetText(string text, bool append)
        {
            if (cv != null)
                cv.UpdateText(text, append);
        }
        private void UpdateText(string text, bool append)
        {
            // If this returns true, it means it was called from an external thread.
            if (InvokeRequired)
            {
                // Create a delegate of this method and let the form run it.
                this.Invoke(new TextDelegate(UpdateText), new object[] { text, append });
                return;
            }
            // Set textBox
            if (append)
            {
                richTextBox1.AppendText(text);
            }
            else
            {
                richTextBox1.Text = text;
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int index = richTextBox1.SelectionStart;
                int line = richTextBox1.GetLineFromCharIndex(index);
                string text = richTextBox1.Lines[line];
                int firstChar = richTextBox1.GetFirstCharIndexFromLine(line);
                // delegate 
                if (!Javapad.InterProcDelegate().HasExited)
                {
                    Javapad.InterProcDelegate().StandardInput.WriteLine(text);
                }
            }
        }

    }

}
