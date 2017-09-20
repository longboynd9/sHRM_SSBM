using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace iHRM.Win.ExtClass.General
{
    public partial class GiayRaCong : DevExpress.XtraReports.UI.XtraReport
    {
        public GiayRaCong()
        {
            InitializeComponent();
        }

        public void DataBindings(object datasource)
        {
            bindingSource1.DataSource = datasource;
        }
    }
}
