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
        public static bool AnyUserEditLeftDate = false;
        public static bool isNeedKey = false;
        public static bool useFinger = false;
        public static string companyName = "SK3";
        public static int ngayBatDauChuKy = 17;
        public Interface_Company()
        {
            db = new Core.Business.DbObject.dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
        }
        public string getEmployeeID()
        {
            string empIDLast = db.tblEmployees.OrderByDescending(p => p.EmployeeID).First().EmployeeID;
            int empID_Last = Convert.ToInt16(empIDLast);
            int empID = empID_Last + 1;

            return string.Format("{0:00000}", empID);
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
            return Convert.ToInt32(EmpID);
        }
    }
}
