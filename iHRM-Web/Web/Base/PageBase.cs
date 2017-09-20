using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Web;
using iTemplate;
using iHRM.WebPC.Classes;
using iHRM.WebPC.Classes.Helper;
using System.Text.RegularExpressions;
using System.Reflection;
using iHRM.WebPC.WebPart;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using System.IO;

namespace iHRM.WebPC.Base
{
    public class FrontEndPageBase : System.Web.UI.Page
    {
        #region Parser
        protected iTemplateParser Parser = new iTemplateParser();

        protected virtual string PageView() { return ""; }

        #endregion

        #region [ Common Properties ]

        /// <summary>
        /// save current Display Language
        /// </summary>
        public static eLanguage DisplayLanguage
        {
            get
            {
                if (HttpContext.Current.Session["_DisplayLanguage"] == null)
                    HttpContext.Current.Session["_DisplayLanguage"] = eLanguage.EN;
                return (eLanguage)HttpContext.Current.Session["_DisplayLanguage"];
            }
            set
            {
                if (HttpContext.Current == null)
                    return;

                HttpContext.Current.Session["_DisplayLanguage"] = value;
                Cookies.WriteCookie("_DisplayLanguage", value.ToString());
            }
        }

        /// <summary>
        /// hiện thị trên thiết bị nào?
        /// </summary>
        public enum EDeviceView { web, smartphone, mobile }

        /// <summary>
        /// Detect device view
        /// </summary>
        public static EDeviceView DeviceView
        {
            get 
            {
                return EDeviceView.web;
                //return HttpContext.Current.Request.Browser.IsMobileDevice ? EDeviceView.mobile : EDeviceView.web; 
            }
        }

        /// <summary>
        ///  Detect Post method
        /// </summary>
        public bool IsPostMethod
        {
            get { return (HttpContext.Current.Request.HttpMethod == "POST"); }
        }

        /// <summary>
        /// Detect ajact action
        /// </summary>
        public bool IsAjax
        {
            get
            {
                return Page.IsCallback || (Request["X-Requested-With"] == "XMLHttpRequest") || (Request.Headers["X-Requested-With"] == "XMLHttpRequest");
            }
        }

        public static string Assets = "/Assets/";
        public const string AjaxUrl = "/Site/_Sys/ajax.aspx";
        public const string GenUcDirectedUrl = "/Site/_Sys/GetUserControl.aspx";
        
        #endregion

        //Page Init
        protected virtual void Page_Init(object sender, EventArgs e)
        {
            LoadTemplateParser();
        }

        //Page Render
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            IncludeParsing();
            ParseCommonVariables();

            writer.Write(Parser.GetTemplate());
        }

        #region [ Common Functions ]

        public static string GenUserControl(string path)
        {
            return GenUserControl(GetUserControl(path));
        }
        public static WebPartBase GetUserControl(string path)
        {
            if (path.EndsWith(".ascx"))
                path = path.Substring(0, path.Length - 5);

            Dictionary<string, string> pa = null;
            var match = Regex.Match(path, @"\((.*)\)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                string[] a = match.Groups[1].Value.Split(',');
                pa = new Dictionary<string, string>();
                foreach (string s in a)
                {
                    int idx = s.IndexOf('=');
                    if (idx > 0)
                        pa.Add(s.Substring(0, idx), s.Substring(idx + 1));
                }

                path = Regex.Replace(path, @"\((.*)\)", "", RegexOptions.IgnoreCase);
            }

            if (DisplayLanguage != eLanguage.EN)
            {
                if (File.Exists(HttpContext.Current.Server.MapPath("~/WebPart/" + DeviceView.ToString() + "/" + path + "_" + DisplayLanguage + ".ascx")))
                    path += "_" + DisplayLanguage;
            }
            path += ".ascx";

            var uc = new System.Web.UI.UserControl();
            WebPartBase uu = (WebPartBase)uc.LoadControl("~/WebPart/" + DeviceView.ToString() + "/" + path);

            if (pa != null)
            {
                Type type = uu.GetType();

                foreach (var d in pa)
                {
                    PropertyInfo prop = type.GetProperty(d.Key);
                    if (prop == null)
                    {
                        if (globall.indebug)
                            throw new Exception("Không thể truy cập thuộc tính " + d.Key);
                        continue;
                    }
                    prop.SetValue(uu, d.Value, null);
                }
            }

            return uu;
        }
        public static string GenUserControl(WebPartBase uu)
        {
            var sb = new StringBuilder();
            var h = new System.Web.UI.HtmlTextWriter(new System.IO.StringWriter(sb));
            //uu.GetData();
            uu.RenderControl(h);
            return sb.ToString();
        }

        public static string GetLngColumn(string colName)
        {
            if (DisplayLanguage == eLanguage.EN)
                return colName + "_EN";
            return colName;
        }
        #endregion
        
        #region [ Parser Functions ]

        private void LoadTemplateParser()
        {
            string path = PageView();
            if (string.IsNullOrWhiteSpace(path))
                return;

            if (path.EndsWith(".html"))
                path = path.Substring(0, path.Length - 5);

            if (DisplayLanguage != eLanguage.EN)
            {
                if (File.Exists(Server.MapPath("~/View/" + DeviceView.ToString() + "/" + path + "_" + DisplayLanguage + ".html")))
                    path += "_" + DisplayLanguage;
            }
            path += ".html";

            path = Path.Combine(Server.MapPath("~/View"), DeviceView.ToString(), path);
            if (!File.Exists(path))
                throw new FileNotFoundException("Không tìm thấy Template " + PageView());
                
            Parser.SetTemplate(File.ReadAllText(path));
        }

        protected void ParseCommonVariables()
        {
            //Parser.SetVariable("SiteTitle", "Viettel Store");
            //Parser.SetVariable("MetaKeyword", "Viettel Store");
            //Parser.SetVariable("MetaDescription", "Viettel Store");
            //Parser.SetVariable("Keyword", "");

            Parser.Parse("DeviceView", DeviceView.ToString());
            Parser.Parse("Assets", Assets);
            Parser.Parse("AjaxUrl", AjaxUrl);
            Parser.Parse("GenUcUrl", GenUcDirectedUrl);

            //if (!CacheMng.Has(CacheEnums.KeyCache.WebsiteInfomation))
            //    CacheMng.Add(LoadWebsiteInformation(), CacheEnums.KeyCache.WebsiteInfomation);
            //var webInfo = CacheMng.Get(CacheEnums.KeyCache.WebsiteInfomation) as DataRow;
            //Parser.SetVariable("site_title", WebHelper.DbGetString(webInfo, "SiteTitle"));
            //Parser.SetVariable("site_description", WebHelper.DbGetString(webInfo, "MetaDescription"));
            //Parser.SetVariable("site_keywword", WebHelper.DbGetString(webInfo, "MetaKeyword"));
        }

        static string[] IncludeParsing_Keys_CacheAble = new string[] { "CategoryHomeMenus", "ProductList3Col" };
        public void IncludeParsing()
        {
            var idx1 = 0;
            var temp = Parser.GetTemplate();

            while (true)
            {
                idx1 = temp.IndexOf("{{INCLUDE ", idx1, System.StringComparison.Ordinal);
                if (idx1 == -1)
                    break;

                var idx2 = temp.IndexOf("}}", idx1 + 10, System.StringComparison.Ordinal);
                var key = temp.Substring(idx1 + 10, idx2 - idx1 - 10);

                var genTemp = "";
                if (IncludeParsing_Keys_CacheAble.Contains(key)) //neu uccontrol cho phep cache
                {
                    if (!CacheMng.Has(CacheEnums.KeyCache.UserControl, key))
                        CacheMng.Add(GenUserControl(key), CacheEnums.KeyCache.UserControl, key);
                    genTemp = CacheMng.Get(CacheEnums.KeyCache.UserControl, key) as string;
                }
                else
                {
                    genTemp = GenUserControl(key);
                }
                temp = temp.Replace("{{INCLUDE " + key + "}}", genTemp);
            }

            Parser.SetTemplate(temp);
        }

        #endregion

        protected static string GenPathInUploadFolder(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return "/Images/logo1.png";
            return SystemConst.uploadFolder + (path[0] == '/' ? "" : "/") + path;
        }
    }
}
