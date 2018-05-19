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
    public partial class CustomizeProfileAvatarView : Form
    {
        private bool move = false;
        private Point offset;

        public CustomizeProfileAvatarView()
        {
            InitializeComponent();
        }

        private void CustomizeProfileAvatarView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                move = true;
                Point pointStartPosition = this.PointToScreen(new Point(e.X, e.Y));
                offset = new Point();
                offset.X = this.Location.X - pointStartPosition.X;
                offset.Y = this.Location.Y - pointStartPosition.Y;
            }
        }

        private void CustomizeProfileAvatarView_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                if (WindowState != FormWindowState.Maximized)
                {
                    Point newPoint = this.PointToScreen(new Point(e.X, e.Y));
                    newPoint.Offset(offset);
                    this.Location = newPoint;
                }
            }
        }

        private void CustomizeProfileAvatarView_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void lblDone_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lblDone_MouseEnter(object sender, EventArgs e)
        {
            lblDone.BackColor = Color.FromArgb(60, 60, 60);
        }

        private void lblDone_MouseLeave(object sender, EventArgs e)
        {
            lblDone.BackColor = Color.FromArgb(40, 40, 40);
        }
        private void SelectAvatar(object sender, EventArgs e)
        {
            CircularPictureBox pictureBox = (CircularPictureBox)sender;
            string picName = pictureBox.Tag.ToString().Substring(pictureBox.Tag.ToString().LastIndexOf(".") + 1);
            CustomizeProfileView.Avatar().Image = pictureBox.Image;
            CustomizeProfileView.Avatar().Tag = picName+"1111";
            Profile.Avatar = picName;
            Profile.CustomAvatar = false;
        }

        private void lblChoosePicture_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                CustomizeProfileView.Avatar().Image = new Bitmap(open.FileName);
                CustomizeProfileView.Avatar().Tag = open.FileName;
                //Profile.Avatar = open.FileName;
                Profile.CustomAvatar = true;
                Profile.CustomAvatarPath = open.FileName;
                // image file path  
                //textBox1.Text = open.FileName;
            }
        }
    }
}
