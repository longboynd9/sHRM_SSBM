using iHRM.Core.Business;
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
    public partial class impThamSoTinhLuong : i_Import.Importer
    {
        public impThamSoTinhLuong()
        {
            InitializeComponent();
        }

        private void impThamSoTinhLuong_Load(object sender, EventArgs e)
        {
            this.InitializeComponent();

            DtDataImport.DtColumn_AddData("EmployeeID", Lng.Luong_ImportTsTinhLuong.maNV);
            foreach (DataRow r in CacheDataTable.GetCacheDataTable(TableConst.tblRef_Allowance.TableName).Rows)
                DtDataImport.DtColumn_AddData(r[TableConst.tblRef_Allowance.AllowanceID].ToString(), r[TableConst.tblRef_Allowance.AllowanceName].ToString());

            this.OnPreData += ImpThamSoTinhLuong_OnPreData;
            this.OnImportData += ImpThamSoTinhLuong_OnImportData;
        }

        Dictionary<string, string> colMapping;
        private void ImpThamSoTinhLuong_OnPreData()
        {
            colMapping = DtDataImport.DtColumn_GetData();
            if (!colMapping.ContainsKey("EmployeeID"))
                throw new Exception("Chưa chọn cột mapping EmployeeID");
        }

        private void ImpThamSoTinhLuong_OnImportData(DataTable obj)
        {
            DataTable dtAllowance4Import = dlgThamSoTinhLuong.GetAllowanceImport(DtDataImport.DtColumn, "c1", "c2");

            var cmEmpID = colMapping["EmployeeID"];
            colMapping.Remove("EmployeeID");

            foreach (DataRow dr in dtDataExcelImported.Rows)
            {
                var r = dtAllowance4Import.NewRow();
                for (int i = 1; i < 21; i++)
                    r["PC" + i] = 0;

                r["employeeID"] = Core.Controller.Import.ImportHelper.MakeSureString(dr[cmEmpID]);
                foreach (var c in colMapping)
                    r[c.Key] = dr[c.Value];

                dtAllowance4Import.Rows.Add(r);
            }

            Core.Business.Logic.Luong.TinhLuong logic = new Core.Business.Logic.Luong.TinhLuong();
            var ret = logic.ImportAllowance(txtThang.EditValue as DateTime?, dtAllowance4Import);

            OutLog_DuringImport("Import thành công (" + ret.NumberOfRowAffected + ")");
        }

        private void impThamSoTinhLuong_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }
    }
}
