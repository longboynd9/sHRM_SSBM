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
    public partial class BaoCao_Tong_NhanVienLamCa : frmBase
    {
        dcDatabaseDataContext db;
        public BaoCao_Tong_NhanVienLamCa()
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
            string depID = chonPhongBan1.SelectedValue;
            DataTable dt_Reuslt = new DataTable();
            var dt = Core.Business.Provider.ExecuteDataTableReader("p_BaoCao_Tong_NhanVienLamCa",
                        new SqlParameter("maNV", txtMaNV.Text),
                        new SqlParameter("depID", depID),
                        new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                        new SqlParameter("denNgay", chonKyLuong1.DenNgay)
                    );
            var dt_Emp = (from data in dt.AsEnumerable()
                     select new
                     {
                         EmployeeID = data["EmployeeID"],
                         EmployeeName = data["EmployeeName"],
                         PosName = data["PosName"],
                         IDCard = data["IDCard"],
                         AppliedDate = data["AppliedDate"],
                         LeftDate = data["LeftDate"],
                         DepName = data["DepName"]
                     }).ToList();
            dt_Reuslt = new DataTable();
            dt_Reuslt.Columns.Add("EmployeeID");
            dt_Reuslt.Columns.Add("EmployeeName");
            dt_Reuslt.Columns.Add("PosName");
            dt_Reuslt.Columns.Add("IDCard");
            dt_Reuslt.Columns.Add("AppliedDate");
            dt_Reuslt.Columns.Add("LeftDate");
            dt_Reuslt.Columns.Add("DepName");
            foreach (var item in dt_Emp)
            {
                if (dt_Reuslt.Select("EmployeeID='" + item.EmployeeID + "'").Count() == 0)
                {
                    DataRow row = dt_Reuslt.NewRow();
                    row["EmployeeID"] = item.EmployeeID;
                    row["EmployeeName"] = item.EmployeeName;
                    row["PosName"] = item.PosName;
                    row["IDCard"] = item.IDCard;
                    row["AppliedDate"] = item.AppliedDate;
                    row["LeftDate"] = item.LeftDate;
                    dt_Reuslt.Rows.Add(row);
                }
            }
            var tb_Ca = db.tbCaLamViecs.ToList();
            foreach (var item in tb_Ca)
            {
                dt_Reuslt.Columns.Add(item.id.ToString(), typeof(string));

                #region Add Column ca làm
                DevExpress.XtraGrid.Columns.GridColumn newCol = grv.Columns.Add();
                newCol.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
                newCol.AppearanceCell.Options.UseFont = true;
                newCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                newCol.AppearanceHeader.Options.UseFont = true;
                newCol.Visible = true;
                newCol.FieldName = item.id.ToString();
                newCol.Caption = item.ten;
                grv.BestFitColumns(true);
                #endregion
                
            }
            foreach (var item in dt_Emp)
            {
                foreach (var ca in tb_Ca)
                {
                    DataRow dr = dt_Reuslt.Select("EmployeeID = " + item.EmployeeID).First();
                    dr[ca.id.ToString()] = dt.Select("EmployeeID = '" + item.EmployeeID + "' AND idCaLam = '" + ca.id+"'").Count();
                }
            }
            
            

            grcNVLamCa.DataSource = dt_Reuslt;

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
