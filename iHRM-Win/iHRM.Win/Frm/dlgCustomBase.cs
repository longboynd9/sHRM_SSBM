using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win
{
    public partial class dlgCustomBase : Form
    {
        public string Form_Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public string Form_Description
        {
            get { return labelControl2.Text; }
            set { labelControl2.Text = value; }
        }

        public Image Form_Image
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        private Image form_ImageBg = Properties.Resources.bg_add;
        public Image Form_ImageBg
        {
            get { return form_ImageBg; }
            set { form_ImageBg = value; }
        }

        Cls.MoreFormByControl mf;
        public dlgCustomBase()
        {
            InitializeComponent();

            mf = new MoreFormByControl(this, panel1, labelControl1);
        }
        private void dlgCustomBase_Load(object sender, EventArgs e)
        {
            labelControl1.Left = this.Width - labelControl1.Width - 9 - (this.FormBorderStyle == FormBorderStyle.None ? 0 : 6);
        }

        private void labelControl2_Resize(object sender, EventArgs e)
        {
            labelControl2.Top = panel1.Height - labelControl2.Height - 6;
        }
        
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            var rc = new Rectangle(this.ClientSize.Width - form_ImageBg.Width,
                this.ClientSize.Height - form_ImageBg.Height,
                form_ImageBg.Width, form_ImageBg.Height);

            e.Graphics.DrawImage(form_ImageBg, rc);
        }

    }
}
