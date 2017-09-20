using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace iHRM.Win.ExtClass.General
{
    public partial class GiayXinNghi : DevExpress.XtraReports.UI.XtraReport
    {
        public GiayXinNghi()
        {
            InitializeComponent();
        }
        public void DataBindings(object datasource) 
        {
            bindingSource1.DataSource = datasource;
        }
    }
}
