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
    public partial class CustomizeProfileColorView : Form
    {
        private bool move = false;
        private Point offset;

        public CustomizeProfileColorView()
        {
            InitializeComponent();
            this.LostFocus += new EventHandler(CustomizeProfileColorView_LostFocus);
        }
        private void CustomizeProfileColorView_LostFocus(object sender, EventArgs e)
        {
            this.Hide();
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
        private void SelectColor(Panel panel)
        {
            /*
            TableLayoutPanelCellPosition pos = tableLayoutPanel1.GetCellPosition(panel);
            int width = tableLayoutPanel1.GetColumnWidths()[pos.Column];
            int height = tableLayoutPanel1.GetRowHeights()[pos.Row];
            width = width + tableLayoutPanel1.Location.X + panel.Margin.All;
            height = height + tableLayoutPanel1.Location.Y + panel.Margin.All;
            System.Drawing.Rectangle rect = new Rectangle(width, height, panel.ClientSize.Width + 1, panel.ClientSize.Height + 1);
            rect.Inflate(1, 1);
            var g = CreateGraphics();
            ControlPaint.DrawBorder(g, rect, Color.White, ButtonBorderStyle.Solid);
            */
            panel.BackColor = Color.FromArgb(90, panel.BackColor);
        }

        private void colorVidaLoca_Click(object sender, EventArgs e)
        {
            SelectColor((Panel)sender);
        }
        private void Works()
        {
            /*
            var c = (Control)sender;

            //var rect = c.Bounds;
            TableLayoutPanelCellPosition pos = tableLayoutPanel1.GetCellPosition(colorBilbao);
            int width = tableLayoutPanel1.GetColumnWidths()[pos.Column];
            int height = tableLayoutPanel1.GetRowHeights()[pos.Row];
            width = width + tableLayoutPanel1.Location.X + colorBilbao.Margin.All;
            //height = height + tableLayoutPanel1.Location.Y;
            Console.WriteLine("h: " + height);
            System.Drawing.Rectangle rect = new Rectangle(width, height - 40, colorBilbao.ClientSize.Width + 1, colorBilbao.ClientSize.Height + 1);
            rect.Inflate(1, 1);
            var g = CreateGraphics();
            ControlPaint.DrawBorder(g, rect, Color.White, ButtonBorderStyle.Solid);
            */
        }
        private void colorPanel_Click(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            //SelectColor(p);
            CustomizeProfileView.FormPanel().BackColor = p.BackColor;
            CustomizeProfileView.FullName().BackColor = p.BackColor;
            CustomizeProfileView.UserName().BackColor = p.BackColor;
            //this.BackColor = p.BackColor;
        }
        private void CustomizeProfileColorView_MouseDown(object sender, MouseEventArgs e)
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

        private void CustomizeProfileColorView_MouseMove(object sender, MouseEventArgs e)
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

        private void CustomizeProfileColorView_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
    }
}
