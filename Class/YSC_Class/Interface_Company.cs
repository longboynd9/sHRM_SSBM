using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHRM.Win.ExtClass
{
    public class Interface_Company
    {
        Core.Business.DbObject.dcDatabaseDataContext db;
        public static string strLuuDataQuetThe = "E:\\Data Quet The";
        public static bool RegistableALWhenSmaller0 = false;
        public static bool AnyUserEditLeftDate = true;
        public static bool isNeedKey = false;
        public static bool useFinger = false;
        public static string companyName = "YSC";
        public static int ngayBatDauChuKy = 17;
        public Interface_Company()
        {
            db = new Core.Business.DbObject.dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
        }
        public string getEmployeeID()
        {
            int empIDLast = 0;
            if (db.tblEmployees.Count() > 0)
            {
                var lstEmp = db.tblEmployees.Select(p => p.EmployeeID.Substring(1, p.EmployeeID.Length - 1));
                empIDLast = lstEmp.Select(s => Convert.ToInt32(s)).Max();
            }
            int empID = empIDLast + 1;

            return string.Format("{0:C#}", empID);
        }
        public double getAnnualLeave(DateTime AppliedDate, int totalAL) 
        {
            double AnnualLeave = 0;
            AnnualLeave += (new DateTime(DateTime.Now.Year, 12, 31) - (AppliedDate.Year < DateTime.Now.Year ? new DateTime(DateTime.Now.Year,1,1) : AppliedDate)).TotalDays/365*totalAL;
            AnnualLeave = (int)AnnualLeave + ((AnnualLeave - (int)AnnualLeave) > 0.5 ? 0.5 : 0); 
            return AnnualLeave;
        }
        public int getNumberEmpID(string EmpID) 
        {
            return Convert.ToInt32(EmpID.Substring(1,EmpID.Length-1));
        }
    }
}
