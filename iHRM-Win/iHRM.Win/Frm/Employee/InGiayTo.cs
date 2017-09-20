using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iHRM.Core.Business.Logic.Luong;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using iHRM.Win.Frm.Employee;
using iHRM.Win.ExtClass.Contract;
using DevExpress.XtraReports.UI;
using iHRM.Win.ExtClass.General;

namespace iHRM.Win.Frm.Employee
{
    public partial class InGiayTo : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        DataTable Data = new DataTable();
        List<GiayTo> _lGiayTo = new List<GiayTo>();
        public InGiayTo()
        {
            InitializeComponent();
            for (int i = 1; i <= 100; i++)
            {
                cbSoTo.Properties.Items.Add(i);
            }
        }
        private class GiayTo
        {
            public string Name { get; set; }
            public XtraReport ReportName { get; set; }
        }

        private void InGiayTo_Load(object sender, EventArgs e)
        {
            _lGiayTo.Add(new GiayTo { Name = "Giấy ra cổng", ReportName = new GiayRaCong() });
            _lGiayTo.Add(new GiayTo { Name = "Giấy xin nghỉ", ReportName = new GiayXinNghi() });
            listBoxGiayTo.Items.AddRange(_lGiayTo.Select(p => p.Name).ToArray());
        }

        private void btnInThe_Click(object sender, EventArgs e)
        {
            var a = _lGiayTo.Where(p => p.Name == listBoxGiayTo.Text).First().ReportName;
            a.DataSource = _lGiayTo;
        }

    }
}