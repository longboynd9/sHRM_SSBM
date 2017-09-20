using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace iHRM.Win.UC
{
    public partial class long_ChonKyLuong : DevExpress.XtraEditors.XtraUserControl
    {
        public event EventHandler OnSelected;
        public long_ChonKyLuong()
        {
            InitializeComponent();
            //setNgayThang();
        }
        public DateTime TuNgay
        {
            get { return dateTuNgay.DateTime; }
            set { dateTuNgay.DateTime = value;}
        }
        public DateTime DenNgay
        {
            get { return dateDenNgay.DateTime; }
            set { dateDenNgay.DateTime = value;}
        }
        private void setNgayThang()
        {
            dateTuNgay.DateTime = new DateTime(2015, 11, 17);
            dateDenNgay.DateTime = new DateTime(2015, 12, 16);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Alo! Tôi là long.");
        }
        public void click_Click() {
            MessageBox.Show("");
        }

        private void dateDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (OnSelected != null)
            {
                OnSelected(dateDenNgay, null);
            }
        }

    }
}
