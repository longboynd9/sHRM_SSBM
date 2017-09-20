using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace iHRM.Win.ExtClass.General
{
    public partial class QuyetDinhThoiViec : DevExpress.XtraReports.UI.XtraReport
    {
        public QuyetDinhThoiViec()
        {
            InitializeComponent();
        }

        public void DataBindings(object datasource)
        {
            bindingSource1.DataSource = datasource;
            lbNVDieu1.DataBindings.Add("Text", bindingSource1, "EmployeeName");
            lbNVDieu2.DataBindings.Add("Text", bindingSource1, "EmployeeName");
            lbNVDieu3.DataBindings.Add("Text", bindingSource1, "EmployeeName");
            lbNVDieu4.DataBindings.Add("Text", bindingSource1, "EmployeeName");
            lbNgayTheoDon.DataBindings.Add("Text", bindingSource1, "ngaytheodon");
            lbCMND.DataBindings.Add("Text", bindingSource1, "IDCard");
            lbQDNV.DataBindings.Add("Text", bindingSource1, "SoQDNV");
            lbKeTuNgay.DataBindings.Add("Text", bindingSource1, "LeftDate","{0:dd/MM/yyyy}");
            lbNgaySinh.DataBindings.Add("Text", bindingSource1, "Birthday","{0:dd/MM/yyyy}");
            lbCMND.DataBindings.Add("Text", bindingSource1, "IDCard");
            lbBoPhan.DataBindings.Add("Text", bindingSource1, "DepName");
            lbThongTinNgay.DataBindings.Add("Text", bindingSource1, "thongtinngay");
        }
    }
}
