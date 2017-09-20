using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iHRM.Win.Frm.MayChamCong
{
    public partial class QuanLyMCC : Form
    {
        public QuanLyMCC()
        {
            InitializeComponent();
        }

        private void radioMCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioMCC.SelectedIndex == 0)
            {
                lookupMayChamCong.Enabled = true;
            }
            else
            {
                lookupMayChamCong.Enabled = false;
            }
        }
    }
}
