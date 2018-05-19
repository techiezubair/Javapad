using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Javapad
{
    public partial class ProjectEulerView : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private int problemNumber = 1;
        ProjectEuler pe;
        private BackgroundWorker PEWorker = new BackgroundWorker();
        Label solvedAnswer = new Label();
        private float fontSize;
        public ProjectEulerView()
        {
            InitializeComponent();
        }

        private void ProjectEuler_Load(object sender, EventArgs e)
        {
            fontSize = problemTextBox.Font.Size;
            SendMessage(answerTextBox.Handle, 0x1501, 1, "Enter your answer here...");
            SendMessage(jumptoTextBox.Handle, 0x1501, 1, "Go to...");
            PEWorker.WorkerReportsProgress = true;
            PEWorker.DoWork += PEWorker_DoWork;
            PEWorker.RunWorkerCompleted += PEWorker_RunWorkerCompleted;
            PEWorker.ProgressChanged += PEWorker_ProgressChanged;
            PEWorker.RunWorkerAsync();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
        }
        private void PEWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            problemTextBox.Text = e.ProgressPercentage + "";
        }
        private void ShowAnswer(bool show)
        {
            if (show)
            {
                pnlTop.Controls.Clear();
                solvedAnswer.Text = "Solved - Answer: " + ProjectEulerProgress.SolvedDictionary[problemNumber.ToString()];
                pnlTop.Controls.Add(solvedAnswer);
                solvedAnswer.Location = new Point(3, 9);
                solvedAnswer.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
                solvedAnswer.AutoSize = true;
                solvedAnswer.ForeColor = Color.Gold;
                solvedAnswer.Show();
            }else
            {
                pnlTop.Controls.Clear();
                pnlTop.Controls.Add(answerTextBox);
            }
        }
        private void PEWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ProjectEulerProgress.GetSolved(problemNumber))
            {
                ShowAnswer(true);
            }
            problemTextBox.Text = pe.Question(problemNumber);
        }

        private void PEWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            pe = new ProjectEuler();
        }

        private void arrowRight_Click(object sender, EventArgs e)
        {
            problemNumber = problemNumber + 1;
            if (problemNumber >= ProjectEuler.TotalQuestions)
                problemNumber = 1;
            problemTextBox.Text = pe.Question(problemNumber);
            lblQestionNum.Text = problemNumber.ToString();
            if (ProjectEulerProgress.GetSolved(problemNumber))
            {
                ShowAnswer(true);
            }else
            {
                ShowAnswer(false);
            }
        }

        private void arrowLeft_Click(object sender, EventArgs e)
        {
            problemNumber = problemNumber - 1;
            if (problemNumber < 1)
                problemNumber = ProjectEuler.TotalQuestions-1;
            problemTextBox.Text = pe.Question(problemNumber);
            lblQestionNum.Text = problemNumber.ToString();
            if (ProjectEulerProgress.GetSolved(problemNumber))
            {
                ShowAnswer(true);
            }else
            {
                ShowAnswer(false);
            }
        }

        private void jumptoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(jumptoTextBox.Text, out problemNumber))
                {
                    if (problemNumber < ProjectEuler.TotalQuestions && problemNumber > 0)
                        problemTextBox.Text = pe.Question(problemNumber);
                    lblQestionNum.Text = problemNumber.ToString(); 
                }else
                {
                    problemNumber = 1;
                    problemTextBox.Text = pe.Question(problemNumber);
                    lblQestionNum.Text = problemNumber.ToString();
                }
                e.SuppressKeyPress = true;
            }
        }
        private void ShowArrows(bool show)
        {
            arrowLeft.Visible = show;
            arrowRight.Visible = show;
        }
        private void pnlBG_MouseEnter(object sender, EventArgs e)
        {
        }

        private void problemTextBox_MouseEnter(object sender, EventArgs e)
        {
        }

        private void ProjectEulerView_MouseEnter(object sender, EventArgs e)
        {
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            fontSize += 2;
            problemTextBox.Font = new Font("Microsoft Sans Serif", fontSize, FontStyle.Regular);  
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            fontSize -= 2;
            problemTextBox.Font = new Font("Microsoft Sans Serif", fontSize, FontStyle.Regular);
        }

        private void problemTextBox_MouseLeave(object sender, EventArgs e)
        {

        }

        private void answerTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string userAnswer = answerTextBox.Text;
                bool correct = false;
                if (!ProjectEulerProgress.GetSolved(problemNumber))
                    correct = ProjectEuler.CheckAnswer(problemNumber, pe.Answer(problemNumber), userAnswer, Points.CORRECTPOINTS);
                //label4.Text = ProjectEulerProgress.SolvedDictionary.Count + "";
                //label2.Text = Points.UserPoints.ToString();
                if (correct) { ShowAnswer(true); answerTextBox.Text = ""; }
                e.SuppressKeyPress = true;
            }
            
        }
    }
}
