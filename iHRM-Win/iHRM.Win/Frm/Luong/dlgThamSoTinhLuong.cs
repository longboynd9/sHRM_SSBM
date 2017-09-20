using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong
{
    public partial class dlgThamSoTinhLuong : dlgCustomBase
    {
        Core.Business.Logic.Luong.TinhLuong logic = new Core.Business.Logic.Luong.TinhLuong();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
        DataTable dtAllowance = new DataTable();
        DateTime month = DateTime.Now.Date;
        String empID = "";

        public dlgThamSoTinhLuong()
        {
            InitializeComponent();
        }
        public dlgThamSoTinhLuong(DataTable dt,DateTime thang, string empID)
        {
            InitializeComponent();
            dtAllowance = dt;
            month = thang;
            this.empID = empID;
        }
        private void dlgDangKyCaLam_Load(object sender, EventArgs e)
        {
            LoadAllowance();
        }

        private void LoadAllowance()
        {
            if (dtAllowance.Rows.Count == 0)
            {
                dtAllowance.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("AllowanceID"),
                    new DataColumn("AllowanceName"),
                    new DataColumn("Value")
                });
                foreach (DataRow dr in CacheDataTable.GetCacheDataTable(TableConst.tblRef_Allowance.TableName).Rows)
                {
                    var dr1 = dtAllowance.NewRow();
                    dr1["AllowanceID"] = dr[TableConst.tblRef_Allowance.AllowanceID];
                    dr1["AllowanceName"] = dr[TableConst.tblRef_Allowance.AllowanceName];
                    dr1["Value"] = 0;

                    dtAllowance.Rows.Add(dr1);
                }

            }
            else
            {
                txtThang.EditValue = month;
                ucChonDoiTuong1.SelectedIndex = 1;
                ucChonDoiTuong1.SelectedValue = empID;
            }

            grd.DataSource = dtAllowance;

        }

        /// <summary>
        /// Lấy data để import
        /// </summary>
        /// <param name="dtData">Datatable mapping</param>
        /// <param name="colID">Cột ID của Allowance</param>
        /// <param name="colValue">Cột giá trị (cột mapping)</param>
        /// <returns></returns>
        public static DataTable GetAllowanceImport(DataTable dtData, string colID = "AllowanceID", string colValue = "Value")
        {
            DataTable dtAllowance4Import = new DataTable("dtAllowance4Import");
            dtAllowance4Import.Columns.AddRange(new DataColumn[]{
                new DataColumn("employeeID"),
                new DataColumn("PC1", typeof(double)),
                new DataColumn("PC2", typeof(double)),
                new DataColumn("PC3", typeof(double)),
                new DataColumn("PC4", typeof(double)),
                new DataColumn("PC5", typeof(double)),
                new DataColumn("PC6", typeof(double)),
                new DataColumn("PC7", typeof(double)),
                new DataColumn("PC8", typeof(double)),
                new DataColumn("PC9", typeof(double)),
                new DataColumn("PC10", typeof(double)),
                new DataColumn("PC11", typeof(double)),
                new DataColumn("PC12", typeof(double)),
                new DataColumn("PC13", typeof(double)),
                new DataColumn("PC14", typeof(double)),
                new DataColumn("PC15", typeof(double)),
                new DataColumn("PC16", typeof(double)),
                new DataColumn("PC17", typeof(double)),
                new DataColumn("PC18", typeof(double)),
                new DataColumn("PC19", typeof(double)),
                new DataColumn("PC20", typeof(double))
            });

            return dtAllowance4Import;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region check control avalid
            errorProvider1.Clear();
            if (ucChonDoiTuong1.SelectedIndex == 0)
            {
                GUIHelper.Notifications("Xin vui lòng chọn đối tượng..", "Nhập tham số tính lương", GUIHelper.NotifiType.stop);
                errorProvider1.SetError(ucChonDoiTuong1, "Xin vui lòng chọn đối tượng..");
                return;
            }

            DataTable dtAllowanceMapping = GetAllowanceImport(dtAllowance);
            if (dtAllowanceMapping.Rows.Count == 0)
            {
                dtAllowanceMapping.Rows.Add(dtAllowanceMapping.NewRow());
                for (int i = 1; i <= 20; i++)
                {
                    dtAllowanceMapping.Rows[0]["PC" + i] = 0;
                }
                for (int i = 0; i < grv.RowCount; i++)
                {
                    dtAllowanceMapping.Rows[0][grv.GetRowCellValue(i, "AllowanceID").ToString()] = grv.GetRowCellValue(i, "Value");
                }
            }
            #endregion

            DateTime thang = new DateTime(txtThang.DateTime.Year, txtThang.DateTime.Month, 1);
            try
            {
                if (ucChonDoiTuong1.SelectedIndex == 1)
                {
                    dtAllowanceMapping.Rows[0]["employeeID"] = ucChonDoiTuong1.SelectedValue;
                    var ret = logic.ImportAllowance(thang, dtAllowanceMapping);
                    GUIHelper.MessageBox(string.Format(Lng.Luong_ImportTsTinhLuong.msg_js5 + " ({0})", ret.NumberOfRowAffected), "Nhập tham số tính lương");
                }
                else if (ucChonDoiTuong1.SelectedIndex == 2)
                {
                    var ret = logic.ImportAllowance_WithDep(ucChonDoiTuong1.SelectedValue, thang, dtAllowanceMapping);
                    GUIHelper.MessageBox(string.Format(Lng.Luong_ImportTsTinhLuong.msg_js5 + " ({0})", ret.NumberOfRowAffected), "Nhập tham số tính lương");
                }
                else if (ucChonDoiTuong1.SelectedIndex == 3)
                {
                    var ret = logic.ImportAllowance_WithGroup1(Convert.ToInt32(ucChonDoiTuong1.SelectedValue), thang, dtAllowanceMapping);
                    GUIHelper.MessageBox(string.Format(Lng.Luong_ImportTsTinhLuong.msg_js5 + " ({0})", ret.NumberOfRowAffected), "Nhập tham số tính lương");
                }
                
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
        }

        private void dlgDangKyCaLam_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }
    }
}
