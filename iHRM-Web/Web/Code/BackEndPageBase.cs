using Ext.Net;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace iHRM.WebPC.Code
{
    public class BackEndPageBase : System.Web.UI.Page
    {
        protected long adm_FuncID = 0;
        protected bool adm_RequiredAdmin = false;
        protected long UserRule = 0;

        protected virtual void initRight() { }

        protected override void OnLoad(EventArgs e)
        {
            initRight();

            if (!LoginHelper.isLogin)
                Response.Redirect("/Cpanel/Login.aspx?ref=" + Server.UrlDecode(Request.Url.ToString()));
            if (adm_RequiredAdmin && !LoginHelper.user.isAdmin)
                Response.Redirect("~/Cpanel/SYS/error-right.aspx", true);

            if (Request["fid"] != null)
            {
                long l = 0;
                if (long.TryParse(Request["fid"], out l))
                    adm_FuncID = l;
            }

            if (adm_FuncID == 0)
            {
                string path = Page.AppRelativeVirtualPath.Replace("~", "").ToLower();
                var f = LoginHelper.user.w5sysRole.w5sysRules.Select(i => i.w5sysFunction).SingleOrDefault(i => i.asemblyPath.ToLower() == path);
                if (f != null)
                    adm_FuncID = f.id;
            }

            if (adm_FuncID == 0)
                Response.Redirect("~/Cpanel/SYS/error-right.aspx", true);

            UserRule = LoginHelper.getRightAccess(adm_FuncID);
            if ((UserRule == 0 || !BitHelper.Has(UserRule, (int)Enums.eFunction.Find)) && !LoginHelper.user.isAdmin)
                Response.Redirect("~/Cpanel/SYS/error-right.aspx", true);

            base.OnLoad(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Ext.Net.ResourceManager rm = null;
                rm = Page.FindControl("ResourceManager1") as Ext.Net.ResourceManager;

                if (rm != null)
                {
                    rm.ShowWarningOnAjaxFailure = false;
                    rm.Listeners.AjaxRequestException.Fn = "function(req, ex) { if (parent.requestEx == undefined) { console.log(req, ex); } parent.requestEx(req, ex); }";
                }
            }

            base.OnPreRender(e);
        }

        protected bool HasRight(Enums.eFunction right)
        {
            return BitHelper.Has(UserRule, (int)right);
        }
        public static void FormSetDataRow(Control frm, System.Data.DataRow r)
        {
            foreach (Control it in frm.Controls)
            {
                if (it is Ext.Net.Field)
                {
                    var f = it as Ext.Net.Field;
                    if (r.Table.Columns.Contains(f.DataIndex))
                        f.Value = r[f.DataIndex];
                }

                FormSetDataRow(it, r);
            }
        }
        public static void FormGetDataRow(Control frm, System.Data.DataRow r)
        {
            foreach (Control it in frm.Controls)
            {
                if (it is Ext.Net.Field)
                {
                    var f = it as Ext.Net.Field;
                    if (r.Table.Columns.Contains(f.DataIndex))
                        r[f.DataIndex] = (f.IsEmpty || f.Value == null) ? DBNull.Value : f.Value;
                }

                FormGetDataRow(it, r);
            }
        }
        public static void FormSetDataContext(Control frm, object r)
        {
            foreach (Control it in frm.Controls)
            {
                if (it is Ext.Net.Field)
                {
                    var f = it as Ext.Net.Field;
                    if (!string.IsNullOrWhiteSpace(f.DataIndex))
                    {
                        var v = PropertyExtension1.GetPropValue(r, f.DataIndex);
                        if (v == null)
                        {
                            if (f is Ext.Net.TimeField || f is Ext.Net.DateField)
                            {
                                f.Reset();
                                continue;
                            }
                        }
                        f.SetValue(v);
                    }
                }

                FormSetDataContext(it, r);
            }
        }
        public static void FormGetDataContext(Control frm, object r)
        {
            foreach (Control it in frm.Controls)
            {
                if (it is Ext.Net.Field )
                {
                    var f = it as Ext.Net.Field;
                    PropertyExtension1.SetPropValue(r, f.DataIndex, f.IsEmpty ? null : f.Value);
                }
                else 
                {
                    FormGetDataContext(it, r);
                   
                }
                FormGetDataContext(it, r);
            }
        }
        protected void ExportExcel4extGridOnSubmitData(XmlNode xml)
        {
            this.Response.Clear();
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=BaoCao.xls");
            System.Xml.Xsl.XslCompiledTransform xtExcel = new System.Xml.Xsl.XslCompiledTransform();
            xtExcel.Load(Server.MapPath("~/Code/Excel.xslt"));
            xtExcel.Transform(xml, null, Response.OutputStream);
            this.Response.End();
        }
    }
}