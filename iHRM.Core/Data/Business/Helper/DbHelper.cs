using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business
{
    public class DbHelper
    {
        public static object DtGetAsDbNull(object obj)
        {
            if (obj == null)
                return DBNull.Value;
            return obj;
        }
        public static object DrGet(DataRow dr, string colName)
        {
            if (dr == null || !dr.Table.Columns.Contains(colName))
                return null;

            return dr[colName] == DBNull.Value ? null : dr[colName];
        }

        public static int DrGetInt(DataRow dr, string colName)
        {
            object v = DrGet(dr, colName);
            if (v == null)
                return 0;

            if (v is int)
                return (int)v;

            try
            {
                return Convert.ToInt32(v);
            }
            catch { }
            return 0;
        }

        public static long DrGetLong(DataRow dr, string colName)
        {
            object v = DrGet(dr, colName);
            if (v == null)
                return 0;

            if (v is long)
                return (long)v;

            try
            {
                return Convert.ToInt64(v);
            }
            catch { }
            return 0;
        }

        public static string DrGetString(DataRow dr, string colName)
        {
            object v = DrGet(dr, colName);

            if (v is string)
                return (string)v;

            try
            {
                return v.ToString();
            }
            catch { }
            return "";
        }

        public static float DrGetFloat(DataRow dr, string colName)
        {
            object v = DrGet(dr, colName);
            if (v == null)
                return 0;

            if (v is float)
                return (float)v;

            try
            {
                return Convert.ToSingle(v);
            }
            catch { }
            return 0;
        }

        public static decimal DrGetDecimal(DataRow dr, string colName)
        {
            object v = DrGet(dr, colName);
            if (v == null)
                return 0;

            if (v is decimal)
                return (decimal)v;

            try
            {
                return Convert.ToDecimal(v);
            }
            catch { }
            return 0;
        }

        public static double DrGetDouble(DataRow dr, string colName)
        {
            object v = DrGet(dr, colName);
            if (v == null)
                return 0;

            if (v is double)
                return (double)v;

            try
            {
                return Convert.ToDouble(v);
            }
            catch { }
            return 0;
        }

        public static bool? DrGetBoolean(DataRow dr, string colName)
        {
            object v = DrGet(dr, colName);
            if (v == null)
                return null;

            if (v is bool?)
                return (bool?)v;
            
            try
            {
                return Convert.ToBoolean(v);
            }
            catch { }
            return null;
        }

        public static DateTime? DrGetDateTime(DataRow dr, string colName)
        {
            object v = DrGet(dr, colName);
            if (v == null)
                return null;

            if (v is DateTime)
                return (DateTime)v;

            try
            {
                return Convert.ToDateTime(v);
            }
            catch { }
            return null;
        }

        public static Guid? DrGetGuid(DataRow dr, string colName)
        {
            object v = DrGet(dr, colName);
            if (v == null)
                return null;

            if (v is Guid?)
                return (Guid?)v;
            
            try
            {
                return new Guid(v.ToString());
            }
            catch { }
            return null;
        }

    }
}
