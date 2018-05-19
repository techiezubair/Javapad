using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Javapad
{
    public partial class ProfileView : Form
    {
        private int solved = 0;
        private double percentage = 0;
        public ProfileView()
        {
            InitializeComponent();
        }

        private void ProfileView_Load(object sender, EventArgs e)
        {
            solved = ProjectEulerProgress.SolvedDictionary.Count;
            //percentage = ((double)solved / (double)476) * 100;
            // fill the gridView
            foreach(KeyValuePair<string, string> solved in ProjectEulerProgress.SolvedDictionary)
            {
                solvedGridView.Rows.Add(solved.Key, solved.Value);
            }
            LoadProfile();
            //pnlBG.BackColor = Color.FromArgb((int)uint.Parse(Profile.BgColor));
            //Console.WriteLine("bgColor: " + pnlBG.BackColor.ToArgb().ToString());
            //Console.WriteLine(Properties.Resources.ResourceManager.GetObject(Profile.Avatar).ToString());
            //GraphicsPath gp = new GraphicsPath();
            //gp.AddEllipse(pictureBox1.DisplayRectangle);
            //pictureBox1.Region = new Region(gp);
        }
        private void LoadProfile()
        {
            lblPoints.Text = Points.UserPoints.ToString();
            lblSolved.Text = solved.ToString();

            lblFullName.Text = Profile.FullName;
            lblUserName.Text = Profile.UserName;
            if (Profile.CustomAvatar)
                Avatar.Image = new Bitmap(Profile.CustomAvatarPath);
            else
                Avatar.Image = (Image)Properties.Resources.ResourceManager.GetObject(Profile.Avatar);
            pnlBG.BackColor = Color.FromArgb(Profile.Arbg()[0], Profile.Arbg()[1], Profile.Arbg()[2]);
        }
        private void ProfileView_VisibleChanged(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pnlCustomize.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pnlMore.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }
        CustomizeProfileView cpv;
        private void ShowCustomizeView()
        {
            cpv = new CustomizeProfileView();
            cpv.TopLevel = false;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(cpv);
            cpv.Size = this.Size;
            cpv.Show();
        }
        private void pnlCustomize_Click(object sender, EventArgs e)
        {
            ShowCustomizeView();
        }

        private void lblCustomize_Click(object sender, EventArgs e)
        {
            ShowCustomizeView();
        }

        private void pnlBG_ControlRemoved(object sender, ControlEventArgs e)
        {
            
        }

        private void pnlMain_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control.Name.Equals(cpv.Name))
            {
                pnlMain.Controls.Add(pnlBG);
                pnlBG.Show();
            }
        }

        private void pnlBG_VisibleChanged(object sender, EventArgs e)
        {
            LoadProfile();
        }
    }
}
