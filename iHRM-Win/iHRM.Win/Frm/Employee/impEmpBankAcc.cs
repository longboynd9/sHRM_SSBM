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

namespace iHRM.Win.Frm.Employee
{
    public partial class impEmpBankAcc : i_Import.Importer
    {
        //Core.Business.DbObject.dcDatabaseDataContext db = new Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);

        public impEmpBankAcc()
        {
            InitializeComponent();
        }

        private void impDataTinhLuong_Load(object sender, EventArgs e)
        {
            this.InitializeComponent();

            foreach (var it in Core.Controller.Employee.impEmployee.listSTKNganHang)
                DtDataImport.DtColumn_AddData(it.c1, it.c1Text);

            this.OnPreData += impDataTinhLuong_OnPreData;
            this.OnImportData += impDataTinhLuong_OnImportData;
        }

        Dictionary<string, string> colMapping;
        private void impDataTinhLuong_OnPreData()
        {
            colMapping = DtDataImport.DtColumn_GetData();
            if (!colMapping.ContainsKey("EmployeeID"))
                throw new Exception("Chưa chọn cột mapping [Mã NV]");
        }

        private void impDataTinhLuong_OnImportData(DataTable obj)
        {
            DataTable table_STK = new DataTable();
            table_STK.Columns.AddRange(colMapping.Select(i => new DataColumn(i.Key, typeof(string))).ToArray());
            
            foreach (DataRow dr in dtDataExcelImported.Rows)
            {
                var r = table_STK.NewRow();
                foreach (var item in colMapping)
                    r[item.Key] = dr[item.Value];

                table_STK.Rows.Add(r);
            }

            try
            {
                Core.Business.Logic.Employee.Emp logic = new Core.Business.Logic.Employee.Emp();
                var ret = logic.ImportSTKNganHang(table_STK);
                OutLog_DuringImport("Import thành công (" + ret.NumberOfRowAffected + ")");
            }
            catch (Exception ex)
            {
                OutLog_DuringImport("Import không thành công: " + ex.Message);
            }
        }

        private void impNhapBaoHiem_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }
    }
}
