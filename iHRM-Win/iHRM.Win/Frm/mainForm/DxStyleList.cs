using DevExpress.Skins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.mainForm
{
    public partial class DxStyleList : DevExpress.XtraEditors.XtraForm
    {
        string selectedStyles = "";
        public string SelectedStyle
        {
            get { return selectedStyles; }
        }

        public DxStyleList()
        {
            InitializeComponent();
        }

        private void DxStyleList_Load(object sender, EventArgs e)
        {
            foreach (SkinContainer it in SkinManager.Default.Skins)
            {
                listView1.Items.Add(it.SkinName);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            selectedStyles = listView1.SelectedItems[0].Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
