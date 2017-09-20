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
    public partial class impNhapBaoHiem : i_Import.Importer
    {
        Core.Business.DbObject.dcDatabaseDataContext db = new Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);

        public impNhapBaoHiem()
        {
            InitializeComponent();
        }

        private void impThamSoTinhLuong_Load(object sender, EventArgs e)
        {
            this.InitializeComponent();

            DtDataImport.DtColumn_AddData("manv", "Mã NV");
            DtDataImport.DtColumn_AddData("ngay", "Ngày bắt đầu");

            this.OnPreData += ImpThamSoTinhLuong_OnPreData;
            this.OnImportRow += ImpNhapBaoHiem_OnImportRow;
        }

        Dictionary<string, string> colMapping;
        private void ImpThamSoTinhLuong_OnPreData()
        {
            colMapping = DtDataImport.DtColumn_GetData();
            if (!colMapping.ContainsKey("manv"))
                throw new Exception("Chưa chọn cột mapping [Mã NV]");
            if (!colMapping.ContainsKey("ngay"))
                throw new Exception("Chưa chọn cột mapping [Ngày bắt đầu]");
            Provider.ExecuteNonQuery_SQL("UPDATE dbo.tblEmployee SET coBH = 0");
            db = new Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
        }

        private void ImpNhapBaoHiem_OnImportRow(DataRow r)
        {
            var emp = db.tblEmployees.SingleOrDefault(i => i.EmployeeID == r[colMapping["manv"]].ToString());
            if (emp != null)
            {
                emp.coBH = true;
                emp.coBH_ngay = r[colMapping["ngay"]] as DateTime?;
                db.SubmitChanges();

                //GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                OutLog_DuringImport(string.Format("Import thành công NV [{0}] {1} >> ngày BH: {2:dd/MM/yyyy} \n", emp.EmployeeID, emp.EmployeeName, emp.coBH_ngay));
            }
        }

        private void impNhapBaoHiem_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }
    }
}
