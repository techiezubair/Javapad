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
    public partial class CustomizeProfileView : Form
    {
        private static CustomizeProfileView cpv = null;
        private static Panel staticPanel = null;
        private delegate Panel delegatePanel();
        private static TextBox staticFullName = null;
        private static TextBox staticUserName = null;
        private static CircularPictureBox staticAvatar = null;
        private delegate CircularPictureBox delegateAvatar();
        private delegate TextBox delegateFullName();
        private delegate TextBox delegateUserName();

        private CustomizeProfileColorView cpcv = null;
        private CustomizeProfileAvatarView cpav = null;

        private Image AvatarImage;

        public CustomizeProfileView()
        {
            InitializeComponent();
            cpv = this;
            staticPanel = pnlBg;
            staticFullName = txtFullName;
            staticUserName = txtUserName;
            staticAvatar = avatar;
        }

        private void CustomizeProfileView_Load(object sender, EventArgs e)
        {
            txtFullName.Text = Profile.FullName;
            txtUserName.Text = Profile.UserName;
            if (Profile.CustomAvatar)
            {
                AvatarImage = new Bitmap(Profile.CustomAvatarPath);
                avatar.Image = new Bitmap(Profile.CustomAvatarPath);
            }
            else
            {
                AvatarImage = (Image)Properties.Resources.ResourceManager.GetObject(Profile.Avatar);
                avatar.Image = (Image)Properties.Resources.ResourceManager.GetObject(Profile.Avatar);
            }
            pnlBg.BackColor = Color.FromArgb(Profile.Arbg()[0], Profile.Arbg()[1], Profile.Arbg()[2]);
            txtFullName.BackColor = pnlBg.BackColor;
            txtUserName.BackColor = pnlBg.BackColor;
        }

        public static TextBox FullName()
        {
            return staticFullName;
        }
        private TextBox UpdateFullName()
        {
            if (InvokeRequired)
            {
                this.Invoke(new delegateUserName(UpdateFullName));
                return staticFullName;
            }
            return staticFullName;
        }
        public static TextBox UserName()
        {
            return staticUserName;
        }
        private TextBox UpdateUserName()
        {
            if (InvokeRequired)
            {
                this.Invoke(new delegateUserName(UpdateUserName));
                return staticUserName;
            }
            return staticUserName;
        }
        public static Panel FormPanel()
        {
            return staticPanel;
        }
        private Panel UpdateFormPanel()
        {
            if (InvokeRequired)
            {
                this.Invoke(new delegatePanel(UpdateFormPanel));
                return staticPanel;
            }
            return staticPanel;
        }
        public static CircularPictureBox Avatar()
        {
            return staticAvatar;
        }
        private CircularPictureBox UpdateAvatar()
        {
            if (InvokeRequired)
            {
                this.Invoke(new delegateAvatar(UpdateAvatar));
                return staticAvatar;
            }
            return staticAvatar;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Rectangle rect = new Rectangle(txtUserName.Location.X, txtUserName.Location.Y, txtUserName.ClientSize.Width, txtUserName.ClientSize.Height);

            rect.Inflate(1, 1); // border thickness
            System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, rect, Color.White, ButtonBorderStyle.Solid);

            System.Drawing.Rectangle rect2 = new Rectangle(txtFullName.Location.X, txtFullName.Location.Y, txtFullName.ClientSize.Width, txtFullName.ClientSize.Height);

            rect2.Inflate(1, 1); // border thickness
            System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, rect2, Color.White, ButtonBorderStyle.Solid);
        }

        private void txtFullName_MouseEnter(object sender, EventArgs e)
        {
            txtFullName.BackColor = Color.FromArgb(4, 110, 7);
        }

        private void txtFullName_MouseLeave(object sender, EventArgs e)
        {
            txtFullName.BackColor = pnlBg.BackColor;
        }

        private void txtUserName_MouseEnter(object sender, EventArgs e)
        {
            txtUserName.BackColor = Color.FromArgb(4, 110, 7);
        }

        private void txtUserName_MouseLeave(object sender, EventArgs e)
        {
            txtUserName.BackColor = pnlBg.BackColor;
        }

        private void pnlSave_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pnlSave.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void pnlCancel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pnlCancel.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void AvatarOpacity(int opacity)
        {
           
            if (opacity == 100)
            {
                if (Profile.CustomAvatar)
                    avatar.Image = new Bitmap(Profile.CustomAvatarPath);
                else
                    avatar.Image = (Image)Properties.Resources.ResourceManager.GetObject(Profile.Avatar);
            }
            else
            {
                Image img = avatar.Image;
                using (Graphics g = Graphics.FromImage(img))
                {
                    Pen pen = new Pen(Color.FromArgb(opacity, 255, 255, 255), img.Width);
                    g.DrawLine(pen, -1, -1, img.Width, img.Height);
                    g.Save();
                }
                avatar.Image = img;
            }
        }

        private void avatar_MouseEnter(object sender, EventArgs e)
        {
            AvatarOpacity(75);
        }
        
        private void avatar_MouseLeave(object sender, EventArgs e)
        {
            AvatarOpacity(100);
        }

        private void lblChangeColor_Click(object sender, EventArgs e)
        {
            
            Point jPadLocation = Javapad.location;
            // display only one instance
            if (cpcv != null && cpcv.Visible != true)
            {
                cpcv.Show();

            }
            else if (cpcv != null)
            {
                cpcv.BringToFront();
            }
            else
            {
                cpcv = new CustomizeProfileColorView();
                cpcv.Show();
                cpcv.Location = new Point(jPadLocation.X + 150, jPadLocation.Y + 50);
            }
        }
        private void avatar_Click(object sender, EventArgs e)
        {
            Point jPadLocation = Javapad.location;
            // display only one instance
            if (cpav != null && cpav.Visible != true)
            {
                cpav.Show();
                
            }else if(cpav != null)
            {
                cpav.BringToFront();
            }
            else
            {
                cpav = new CustomizeProfileAvatarView();
                cpav.Show();
                cpav.Location = new Point(jPadLocation.X + 150, jPadLocation.Y + 50);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("avatar!: " + Profile.Avatar + " tag: " + Profile.Tag);
            if (Profile.CustomAvatar)
            {
                RegistryManager.UpdateProfile(true, Profile.CustomAvatarPath, Profile.Avatar, Profile.Tag, txtFullName.Text, txtUserName.Text, pnlBg.BackColor.R + ", " + pnlBg.BackColor.G + ", " + pnlBg.BackColor.B);
            }
            else
            {
                if (String.IsNullOrEmpty(avatar.Tag.ToString()))
                    RegistryManager.UpdateProfile(false, "", Profile.Avatar, Profile.Tag, txtFullName.Text, txtUserName.Text, pnlBg.BackColor.R + ", " + pnlBg.BackColor.G + ", " + pnlBg.BackColor.B);
                else
                    RegistryManager.UpdateProfile(false, "", Profile.Avatar, avatar.Tag.ToString(), txtFullName.Text, txtUserName.Text, pnlBg.BackColor.R + ", " + pnlBg.BackColor.G + ", " + pnlBg.BackColor.B);
            }
            this.Close();
        }

    }
}
