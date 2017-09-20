using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using System.Data.SqlClient;

namespace iHRM.Win.Frm.Report
{
    public partial class ReportDanhSachHopDong : frmBase
    {
        public ReportDanhSachHopDong()
        {
            InitializeComponent();
        }

        private void BaoCaoDSHopDong_Load(object sender, EventArgs e)
        {
            dcDatabaseDataContext db;
            db = new dcDatabaseDataContext(iHRM.Core.Business.Provider.ConnectionString);
            lookupHopDong.Properties.DataSource = db.tblRef_ContractTypes.ToList();
            LoadGrvLayout(grv);
        }

        private void BaoCaoDSHopDong_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            var a = Provider.ExecuteDataTable("p_BaoCaoDSHopDong",
                  Provider.CreateParameter_StringList("EmployeeID", ucChonDoiTuong_DS1.GetValue()),
                 new SqlParameter("loaiHD", lookupHopDong.EditValue),
                 new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                 new SqlParameter("denNgay", chonKyLuong1.DenNgay)
             );
            grcBaoCaoDSHopDong.DataSource = a;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportGrid(grcBaoCaoDSHopDong);
        }
    }
}