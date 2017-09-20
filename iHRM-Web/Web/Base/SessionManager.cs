using System.Web;

namespace iHRM.WebPC.Base
{
    /// <summary>
    /// Class SessionManager
    /// </summary>
    public static class SessionManager
    {
        public static int MemberId
        {
            get
            {
                var value = HttpContext.Current.Session["MemberId"];
                return value == null ? -1 : (int)value;
            }
            set
            {
                HttpContext.Current.Session["MemberId"] = value;
            }
        }
        
        public static string MemberName
        {
            get
            {
                var value = HttpContext.Current.Session["MemberName"];
                return value == null ? string.Empty : value.ToString();
            }
            set
            {
                HttpContext.Current.Session["MemberName"] = value;
            }
        }
    }
}