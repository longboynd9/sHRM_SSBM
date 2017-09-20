using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using System.Data.SqlClient;
using System.Data;


namespace iHRM.WebPC
{
    public static class WebHelper
    {
        public static object DbGet(DataRow dr, string colName)
        {
            if (dr == null || !dr.Table.Columns.Contains(colName))
                return null;

            if (dr[colName] == DBNull.Value)
                return null;

            return dr[colName];
        }
        public static string DbGetString(DataRow dr, string colName)
        {
            var v = DbGet(dr, colName);
            if (v is string)
                return v as string;
            return (v == null ? "" : v.ToString());
        }
        public static Guid? DbGetGuid(DataRow dr, string colName)
        {
            var v = DbGet(dr, colName);
            if (v == null) return null;
            if (v is Guid?) return v as Guid?;
            try { return new Guid(v.ToString()); }
            catch { }
            return null;
        }
        public static int DbGetInt(DataRow dr, string colName)
        {
            var v = DbGet(dr, colName);
            if (v is int)
                return (v as int?) ?? 0;
            try
            {
                return Convert.ToInt32(v);
            }
            catch { }
            return 0;
        }
        public static bool DbGetBool(DataRow dr, string colName)
        {
            var v = DbGet(dr, colName);
            if (v is bool?)
                return (v as bool?) ?? false;
            try
            {
                return Convert.ToBoolean(v);
            }
            catch { }
            return false;
        }
        public static long DbGetLong(DataRow dr, string colName)
        {
            var v = DbGet(dr, colName);
            if (v is long)
                return (v as long?) ?? 0;
            try
            {
                return Convert.ToInt64(v);
            }
            catch { }
            return 0;
        }
        public static float DbGetFloat(DataRow dr, string colName)
        {
            var v = DbGet(dr, colName);
            if (v is float)
                return (v as float?) ?? 0;
            try
            {
                return Convert.ToSingle(v);
            }
            catch { }
            return 0;
        }
        public static DateTime? DbGetDate(DataRow dr, string colName)
        {
            var v = DbGet(dr, colName);
            if (v is DateTime)
                return v as DateTime?;
            try
            {
                return Convert.ToDateTime(v);
            }
            catch { }
            return null;
        }

        public static object DbGet(SqlDataReader dr, string colName)
        {
            if (dr == null)
                return null;

            try
            {
                if (dr[colName] == DBNull.Value)
                    return null;

                return dr[colName];
            }
            catch
            {
                return null;
            }
        }
        public static string DbGetString(SqlDataReader dr, string colName)
        {
            var v = DbGet(dr, colName);
            if (v is string)
                return v as string;
            return (v == null ? "" : v.ToString());
        }
        public static int DbGetInt(SqlDataReader dr, string colName)
        {
            var v = DbGet(dr, colName);
            if (v is int)
                return (v as int?) ?? 0;
            try
            {
                return Convert.ToInt32(v);
            }
            catch { }
            return 0;
        }
        public static bool DbGetBool(SqlDataReader dr, string colName)
        {
            var v = DbGet(dr, colName);
            if (v is int)
                return (v as bool?) ?? false;
            try
            {
                return Convert.ToBoolean(v);
            }
            catch { }
            return false;
        }
        public static long DbGetLong(SqlDataReader dr, string colName)
        {
            var v = DbGet(dr, colName);
            if (v is long)
                return (v as long?) ?? 0;
            try
            {
                return Convert.ToInt64(v);
            }
            catch { }
            return 0;
        }
        public static float DbGetFloat(SqlDataReader dr, string colName)
        {
            var v = DbGet(dr, colName);
            if (v is float)
                return (v as float?) ?? 0;
            try
            {
                return Convert.ToSingle(v);
            }
            catch { }
            return 0;
        }
        public static DateTime? DbGetDate(SqlDataReader dr, string colName)
        {
            var v = DbGet(dr, colName);
            if (v is DateTime)
                return v as DateTime?;
            try
            {
                return Convert.ToDateTime(v);
            }
            catch { }
            return null;
        }
    }
}