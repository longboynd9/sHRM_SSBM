using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace iHRM.Core.Controller.Import
{
    public enum msgStt { info, success, warning, danger }
    public class LogItem
    {
        public Guid id;
        public string status;
        public DateTime time;
        public msgStt status_code;
        public string message;
    }
        
    public class ImportHelper
    {
        public static string ButifullDateText(object s)
        {
            return s.ToString().Replace("'", "").Trim(' ', '\r', '\n', '\t').Replace("  ", " ");
        }

        static string[] dateFormat = { "d/M/yyyy H:m", "d/M/yy H:m", "d/M/yyyy", "d/M/yy" };
        public static DateTime? MakeSureDate(object data)
        {
            if (data == DBNull.Value || data == null)
                return null;

            if (data is DateTime)
            {
                return data as DateTime?;
            }

            DateTime d;
            if (DateTime.TryParseExact(data.ToString(), dateFormat, null, System.Globalization.DateTimeStyles.None, out d))
                return d;

            return null;
        }
        public static string MakeSureString(object data)
        {
            if (data == DBNull.Value || data == null)
                return null;

            if (data is string)
            {
                return data as string;
            }

            try
            {
                return Convert.ToString(data);
            }
            catch { }

            return null;
        }
        public static int? MakeSureInt(object data)
        {
            if (data == DBNull.Value || data == null)
                return null;

            if (data is int)
            {
                return data as int?;
            }

            try
            {
                return Convert.ToInt32(data);
            }
            catch { }

            return null;
        }
        public static double? MakeSureFloat(object data)
        {
            if (data == DBNull.Value || data == null)
                return null;

            if (data is double)
            {
                return data as double?;
            }

            try
            {
                return Convert.ToDouble(data);
            }
            catch { }

            return null;
        }
    }
}