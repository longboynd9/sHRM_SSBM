using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace iHRM.Win.ExtClass
{
    public partial class rep_InTheNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        public rep_InTheNhanVien()
        {
            InitializeComponent();
        }
        public void DataBindings(object dtSource) 
        {
            bindingSource1.DataSource = dtSource;
             //THÔNG TIN CHUNG.
            lbMaNV.DataBindings.Add("Text", bindingSource1, "EmployeeID");
            lbTenNV.DataBindings.Add("Text", bindingSource1, "EmployeeName");
            lbCMND.DataBindings.Add("Text", bindingSource1, "IDCard");
            lbBoPhan.DataBindings.Add("Text", bindingSource1, "DepName");
            lbNgayVao.DataBindings.Add("Text", bindingSource1, "AppliedDate","{0:dd/MM/yyyy}");
        }

    }
}
