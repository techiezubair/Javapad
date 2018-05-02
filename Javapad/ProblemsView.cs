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
    public partial class ProblemsView : Form
    {
        private static ProblemsView pv = null;
        private static RichTextBox staticTextBox = null;
        //private delegate void TextDelegate(string text, bool append);
        //private delegate void TextSelection();
        //private delegate void TextScroll();
        private delegate RichTextBox Box();

        public ProblemsView()
        {
            InitializeComponent();
        }
        private void ProblemsView_Load(object sender, EventArgs e)
        {
            pv = this;
            staticTextBox = richTextBox1;
        }
        /*
        public static void SetText(string text, bool append)
        {
            if (pv != null)
                pv.UpdateText(text, append);
        }
        private void UpdateText(string text, bool append)
        {
            // If this returns true, it means it was called from an external thread.
            if (InvokeRequired)
            {
                // Create a delegate of this method and let the form run it.
                // this.Invoke(new TextDelegate(UpdateText), new object[] { text }, new object[] { append } ); ????
                this.Invoke(new TextDelegate(UpdateText), new object[] { text, append });
                return; // Important
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
        public static void SelectionStart()
        {
            if (pv != null)
                pv.UpdateSelectionStart();
        }
        private void UpdateSelectionStart()
        {
            if (InvokeRequired)
            {
                this.Invoke(new TextSelection(UpdateSelectionStart));
                return;
            }
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
        }
        public static void ScrollToCaret()
        {
            if (pv != null)
                pv.UpdateScrollToCaret();    
        }
        private void UpdateScrollToCaret()
        {
            if (InvokeRequired)
            {
                this.Invoke(new TextScroll(UpdateScrollToCaret));
                return;
            }
            richTextBox1.ScrollToCaret();
        }*/
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

        public RichTextBox ProblemsBox
        {
            get { return this.richTextBox1; }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

    }
}
