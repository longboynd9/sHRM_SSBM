using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using System.IO;

namespace iHRM.Win.Frm.Common
{
    public partial class SplashScreen1 : SplashScreen
    {
        public string StatusText
        {
            get { return labelControl2.Text; }
            set { labelControl2.Text = value; }
        }

        public SplashScreen1()
        {
            InitializeComponent();
        }
        private void SplashScreen1_Load(object sender, EventArgs e)
        {
            try
            {
                //MemoryStream mem = new MemoryStream(LoginHelper.Dept[Core.Business.TableConst.tbCty.logo] as byte[]);
                //Image img = Image.FromStream(mem);
                //if (img != null)
                //    pictureEdit2.Image = img;
            }
            catch { }
        }

        public enum SplashScreenCommand { }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            
        }

    }
}