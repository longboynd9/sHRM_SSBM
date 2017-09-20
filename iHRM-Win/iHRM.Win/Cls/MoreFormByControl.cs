using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Cls
{
    public class MoreFormByControl
    {
        bool isMouseDown;
        int xLast;
        int yLast;

        Form frm;

        public MoreFormByControl(Form frm, Control control2More, Control control2Close = null)
        {
            this.frm = frm;

            control2More.DoubleClick += panel1_DoubleClick;
            control2More.MouseDown += panel1_MouseDown;
            control2More.MouseMove += panel1_MouseMove;
            control2More.MouseUp += panel1_MouseUp;

            if (control2Close != null)
                control2Close.Click += labelControl1_Click;
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            frm.WindowState = (frm.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                xLast = e.X;
                yLast = e.Y;
            }
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                int newY = frm.Top + (e.Y - yLast);
                int newX = frm.Left + (e.X - xLast);

                frm.Location = new System.Drawing.Point(newX, newY);
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            frm.Close();
        }

    }
}
