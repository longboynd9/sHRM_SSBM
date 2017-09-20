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
    public partial class impNhapLuongSP : i_Import.Importer
    {
        Core.Business.DbObject.dcDatabaseDataContext db = new Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);

        public impNhapLuongSP()
        {
            InitializeComponent();
        }

        private void impThamSoTinhLuong_Load(object sender, EventArgs e)
        {
            this.InitializeComponent();

            DtDataImport.DtColumn_AddData("manv", "Mã NV");
            DtDataImport.DtColumn_AddData("luongSP", "Lương SP");
            txtThang.DateTime = DateTime.Now;

            this.OnPreData += ImpThamSoTinhLuong_OnPreData;
            this.OnImportRow += ImpLuongSP_OnImportRow;
        }

        Dictionary<string, string> colMapping;
        private void ImpThamSoTinhLuong_OnPreData()
        {
            colMapping = DtDataImport.DtColumn_GetData();
            if (!colMapping.ContainsKey("manv"))
                throw new Exception("Chưa chọn cột mapping [Mã NV]");
            if (!colMapping.ContainsKey("luongSP"))
                throw new Exception("Chưa chọn cột mapping [Lương SP]");

            db = new Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
        }

        private void ImpLuongSP_OnImportRow(DataRow r)
        {
            if (db.tblEmployees.SingleOrDefault(i => i.EmployeeID == r[colMapping["manv"]].ToString()) != null)
            {
                var emp = db.tbThamSoTinhLuongs.SingleOrDefault(i => i.employeeID == r[colMapping["manv"]].ToString() && i.thang == new DateTime(txtThang.DateTime.Year, txtThang.DateTime.Month, 1));
                if (emp != null)
                {
                    emp.LuongSP = r[colMapping["luongSP"]] == null ? 0 : Convert.ToDouble(r[colMapping["luongSP"]]);
                    db.SubmitChanges();
                    OutLog_DuringImport(string.Format("Import lương SP thành công NV [{0}]", emp.employeeID));
                }
                else
                {
                    tbThamSoTinhLuong tstl = new tbThamSoTinhLuong();
                    tstl.employeeID = r[colMapping["manv"]].ToString();
                    tstl.id = Guid.NewGuid();
                    tstl.thang = new DateTime(txtThang.DateTime.Year, txtThang.DateTime.Month, 1);
                    tstl.LuongSP = r[colMapping["luongSP"]] == null ? 0 : Convert.ToDouble(r[colMapping["luongSP"]]);
                    db.tbThamSoTinhLuongs.InsertOnSubmit(tstl);
                    db.SubmitChanges();
                }
            }
            else
            {
                OutLog_DuringImport(string.Format("Không có nhân viên mã {0} để import Lương SP", r[colMapping["manv"]].ToString()));
            }
        }
    }
}
