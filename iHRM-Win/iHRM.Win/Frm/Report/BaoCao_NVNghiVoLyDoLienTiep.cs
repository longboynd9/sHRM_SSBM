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
    public partial class BaoCao_NVNghiVoLyDoLienTiep : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        public BaoCao_NVNghiVoLyDoLienTiep()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                var a = Convert.ToInt16(txtSoNgay.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Số ngày nhập sai", "Nhập sai dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime fromDate = chonKyLuong1.TuNgay;
            DateTime toDate = chonKyLuong1.DenNgay;
            DataTable data = Provider.ExecuteDataTableReader("p_getNVNghiVoLyDoLienTiep",
                new SqlParameter("@fromDate", fromDate),
                new SqlParameter("@toDate", toDate),
                new SqlParameter("@soNgay", Convert.ToInt16(txtSoNgay.Text))
                );
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
        }
    }
}
