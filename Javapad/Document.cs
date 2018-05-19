using System;
using System.IO;
using System.Windows.Forms;

namespace Javapad
{
    public class Document
    {
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private bool isSaved;
        private string filePath = "";
        public Document()
        {
            init();
        }
        private void init()
        {
            // Open file dialog
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Java files (*.java)|*.java|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            // Save file dialog
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Java files (*.java)|*.java|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            isSaved = true;
        }
        public string File
        {
            get { return this.filePath; }
        }
        public void New()
        {
            init();
        }
        public string Open()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                isSaved = true;
                return filePath = openFileDialog.FileName;
            }
            else
            {
                return null;
            }
        }
        public string SaveAs(string text)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = saveFileDialog.FileName;
                if (!String.IsNullOrEmpty(file))
                {
                    using (StreamWriter sw = new StreamWriter(file, false))
                    {
                        sw.WriteLine(text);
                    }
                    isSaved = true;
                }
                return filePath = file;
            }
            else
            {
                return null;
            }
        }
        public void Save(string text)
        {
            if (openFileDialog != null && saveFileDialog != null)
            {
                string file = (!String.IsNullOrEmpty(openFileDialog.FileName)) ? openFileDialog.FileName : saveFileDialog.FileName;
                if (!String.IsNullOrEmpty(file))
                {
                    filePath = file;
                    using (StreamWriter sw = new StreamWriter(file, false))
                    {
                        sw.WriteLine(text);
                    }
                    isSaved = true;
                }
                else
                {
                    SaveAs(text);
                }
            }
        }
        public bool IsSaved
        {
            get { return this.isSaved; }
            set { this.isSaved = value; }
        }
    }
}
