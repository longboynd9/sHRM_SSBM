using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.i_Report;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Report
{
    public partial class BaoCaoConTho : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        public BaoCaoConTho()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string empID = txtEmpID.Text;
            DateTime mocTG = DateMocTG.DateTime;
            DataTable data = Provider.ExecuteDataTableReader("p_BaoCao_GetReportConTho",
                new SqlParameter("@empID", empID),
                new SqlParameter("@depID", chonPhongBan1.SelectedValue),
                new SqlParameter("@MocTG", DateMocTG.DateTime)
                );
            //data.Columns.Add("SoCon<=6T", typeof(int));
            //data.Columns.Add("SoCon>6T", typeof(int));
            //data.Columns.Add("TongCon", typeof(int));
            //try
            //{
            //    foreach (DataRow row in data.Rows)
            //    {
            //        maNV = row["EmployeeID"].ToString();
            //        DateTime ngaysinhCon = Convert.ToDateTime(row["ChildBirthday"]);
            //        var q = data.Select(string.Format("ChildBirthday <= '{0}' AND EmployeeID = '{1}'", mocTG.AddYears(-6), maNV)).Count();
            //        var q2 = data.Select(string.Format("ChildBirthday > '{0}' AND EmployeeID = '{1}'", mocTG.AddYears(-6),maNV)).Count();
            //        row["SoCon<=6T"] = q;
            //        row["SoCon>6T"] = q2;
            //        row["TongCon"] = q + q2;
            //    }
            //}
            //catch (Exception)
            //{
            //    GUIHelper.MessageError("Mã nhân viên: " + maNV + "Ngày sinh của con bị sai");
            //    return;
            //}
            grd.DataSource = data;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportGrid(grd);
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
            DateMocTG.DateTime = DateTime.Now;
        }
    }
}
