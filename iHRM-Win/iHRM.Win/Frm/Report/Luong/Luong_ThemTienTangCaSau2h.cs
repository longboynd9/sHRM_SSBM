using iHRM.Core.i_Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;
namespace iHRM.Win.Frm.Report
{
    public partial class Luong_ThemTienTangCaSau2h : frmBase
    {
        dcDatabaseDataContext db;
        public Luong_ThemTienTangCaSau2h()
        {
            InitializeComponent();
            db = new dcDatabaseDataContext(iHRM.Core.Business.Provider.ConnectionString);
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data.Columns.AddRange(new DataColumn[]{
                                    new DataColumn("EmployeeID"),
                                    new DataColumn("EmployeeName"),
                                    new DataColumn("IDCard"),
                                    new DataColumn("DepName"),
                                    new DataColumn("ThemTgTangCa")
                                });

            string depID = chonPhongBan1.SelectedValue;
            List<tbKetQuaQuetThe> _lEmpID = (from k in db.tbKetQuaQuetThes
                                             where k.ngay >= chonKyLuong1.TuNgay && k.ngay <= chonKyLuong1.DenNgay && k.tgTinhTangCa >= 2
                                             select k).ToList<tbKetQuaQuetThe>();
            foreach (var item in _lEmpID.Select(p => p.EmployeeID).Distinct().Join(db.tblEmployees,i=>i.ToString(),p=>p.EmployeeID,(i,p) => new {p.EmployeeID,p.EmployeeName, p.DepName,p.IDCard }))
            {
                DataRow row = data.NewRow();
                row["EmployeeID"] = item.EmployeeID;
                row["EmployeeName"] = item.EmployeeName;
                row["IDCard"] = item.IDCard;
                row["DepName"] = item.DepName;
                data.Rows.Add(row);
            }

            foreach (DataRow row in data.Rows)
            {
                int songayTangCaHon2H = db.tbKetQuaQuetThes.Where(p => p.EmployeeID == row["EmployeeID"].ToString() && p.tgTinhTangCa != null && p.tgTinhTangCa.Value >= 2 && p.ngay >= chonKyLuong1.TuNgay && p.ngay <= chonKyLuong1.DenNgay).Count();
                DataRow rowEmp = data.Select("EmployeeID = '" + row["EmployeeID"] + "'").FirstOrDefault(); 
                if (rowEmp != null)
                {
                    rowEmp["ThemTgTangCa"] = songayTangCaHon2H * 0.5;
                }
            }
            grcNVLamCa.DataSource = data;
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportGrid(grcNVLamCa);
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
    }
}
