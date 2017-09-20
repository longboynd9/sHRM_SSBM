using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.Employee
{
    public class Emp : LogicBase
    {        
        public VirtualPagingInfo VirtualPaging
        {
            get { return _VirtualPaging; }
            set { _VirtualPaging = value; }
        }

        public Emp()
            : base("tblEmployee")
        {
            _VirtualPaging = new VirtualPagingInfo();
        }

        public bool EmployeeCode_Validate(string code)
        {
            return !((Provider.ExecuteScalar("p_emp_validateCode", new SqlParameter("code", code)) as int?) > 0);
        }



        public virtual DataTable GetStoreData(string tableName, string employeeID)
        {
            return Provider.ExecuteDataTable("p_emp_getStoreData",
                new SqlParameter("tableName", tableName),
                new SqlParameter("employeeID", employeeID)
            );
        }
        public virtual DataTable getEmployeeByDepID(string depID = null)
        {
            return Provider.ExecuteDataTable("p_getEmployeebyDepID",
                new SqlParameter("depID", depID)
            );
        }
        public iHRM.Core.Business.Base.ExecuteResult ImportSTKNganHang(DataTable dtSTKNganHang)
        {
            var pa = new SqlParameter("dtSTKNganHang", SqlDbType.Structured);
            pa.TypeName = "dtSTKNganHang";
            pa.Value = dtSTKNganHang;

            return Provider.ExecuteNonQuery("p_Employee_ImportSTKNganHang",
                pa
            );
        }

    }
}
