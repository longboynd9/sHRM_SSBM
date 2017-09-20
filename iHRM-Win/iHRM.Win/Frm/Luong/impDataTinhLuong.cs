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
    public partial class impDataTinhLuong : i_Import.Importer
    {
        //Core.Business.DbObject.dcDatabaseDataContext db = new Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);

        public impDataTinhLuong()
        {
            InitializeComponent();
        }

        private void impDataTinhLuong_Load(object sender, EventArgs e)
        {
            this.InitializeComponent();

            DtDataImport.DtColumn_AddData("manv", "Mã NV");
            for (int i = 1; i < 11; i++)
                DtDataImport.DtColumn_AddData("DataCalc" + i, "DataCalc" + i);

            this.OnPreData += impDataTinhLuong_OnPreData;
            this.OnImportData += impDataTinhLuong_OnImportData;
        }

        Dictionary<string, string> colMapping;
        private void impDataTinhLuong_OnPreData()
        {
            colMapping = DtDataImport.DtColumn_GetData();
            if (!colMapping.ContainsKey("manv"))
                throw new Exception("Chưa chọn cột mapping [Mã NV]");
        }

        private void impDataTinhLuong_OnImportData(DataTable obj)
        {
            DataTable dtDataCalc4Import = new DataTable("dtDataCalc4Import");
            dtDataCalc4Import.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("employeeID", typeof(string)),
                new DataColumn("DataCalc1", typeof(float)),
                new DataColumn("DataCalc2", typeof(float)),
                new DataColumn("DataCalc3", typeof(float)),
                new DataColumn("DataCalc4", typeof(float)),
                new DataColumn("DataCalc5", typeof(float)),
                new DataColumn("DataCalc6", typeof(float)),
                new DataColumn("DataCalc7", typeof(float)),
                new DataColumn("DataCalc8", typeof(float)),
                new DataColumn("DataCalc9", typeof(float)),
                new DataColumn("DataCalc10", typeof(float))
            });

            var cmEmpID = colMapping["manv"];
            colMapping.Remove("manv");

            foreach (DataRow dr in dtDataExcelImported.Rows)
            {
                var r = dtDataCalc4Import.NewRow();
                for (int i = 1; i < 11; i++)
                    r["DataCalc" + i] = 0;

                r["employeeID"] = Core.Controller.Import.ImportHelper.MakeSureString(dr[cmEmpID]);
                foreach (var c in colMapping)
                    r[c.Key] = dr[c.Value];

                dtDataCalc4Import.Rows.Add(r);
            }

            Core.Business.Logic.Luong.TinhLuong logic = new Core.Business.Logic.Luong.TinhLuong();
            var ret = logic.ImportDataCalc(txtThang.DateTime, dtDataCalc4Import);

            OutLog_DuringImport("Import thành công (" + ret.NumberOfRowAffected + ")");
        }

        private void impNhapBaoHiem_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }
    }
}
