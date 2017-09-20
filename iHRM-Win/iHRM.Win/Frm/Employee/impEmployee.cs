using iHRM.Core.Business;
using iHRM.Core.Controller.Import;
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

namespace iHRM.Win.Frm.Employee
{
    public partial class impEmployee : i_Import.Importer
    {
        public impEmployee()
        {
            InitializeComponent();
        }

        private void impEmployee_Load(object sender, EventArgs e)
        {
            this.InitializeComponent();

            foreach(var it in Core.Controller.Employee.impEmployee.lstEmpMapping)
                DtDataImport.DtColumn_AddData(it.c1, it.c1Text);

            this.OnPreData += impEmployee_OnPreData;
            this.OnImportRow += impEmployee_OnImportRow;
        }

        Dictionary<string, string> colMapping;
        private void impEmployee_OnPreData()
        {
            colMapping = DtDataImport.DtColumn_GetData();
            if (!colMapping.ContainsKey("EmployeeID"))
                throw new Exception("Chưa chọn cột mapping [Mã NV]");
        }

        private void impEmployee_OnImportRow(DataRow dr)
        {
            try
            {
                var pas = new List<SqlParameter>();
                foreach (var it in colMapping)
                {
                    var pa = new SqlParameter();
                    pa.ParameterName = it.Key;

                    char dataType = Core.Controller.Employee.impEmployee.lstEmpMapping.SingleOrDefault(i => i.c1 == it.Key).dataType;
                    switch (dataType)
                    {
                        case 's':
                            pa.Value = ImportHelper.MakeSureString(dr[it.Value]);
                            break;
                        case 'i':
                            pa.Value = ImportHelper.MakeSureInt(dr[it.Value]);
                            break;
                        case 'd':
                            pa.Value = ImportHelper.MakeSureDate(dr[it.Value]);
                            break;
                        case 'f':
                            pa.Value = ImportHelper.MakeSureFloat(dr[it.Value]);
                            break;
                        default:
                            pa.Value = dr[it.Value];
                            break;
                    }

                    pas.Add(pa);
                }

                var ret = Provider.ExecuteNonQuery("p_Employee_Import_Excel_AllColumn", pas.ToArray());

                if (ret.ReturnValue == 1)
                {
                    OutLog_DuringImport(string.Format("Emp: {0}: Done", dr["EmployeeID"]));
                }
                else
                {
                    OutLog_DuringImport(string.Format("Emp: {0}: Fail{1}", dr["EmployeeID"], 
                        ret.ReturnValue == -1 ? ", NV đã tồn tại" : ""
                    ));
                }
            }
            catch (Exception ex)
            {
                //GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.ExceptionThrow);
                OutLog_DuringImport(ex.Message);
            }
        }

    }
}
