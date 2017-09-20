using Ext.Net;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.sHRM
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LoginHelper.isLogin)
                Response.Redirect("/Cpanel/Login.aspx?ref=" + Server.UrlDecode(Request.Url.ToString()));

            if (!IsPostBack && !X.IsAjaxRequest)
            {
                //load top menu                
                stoTopMenu.DataSource = LoginHelper.user.w5sysRole.w5sysRules
                    .Where(i => i.w5sysFunction.parentId == const1.functionRootTreeID)
                    .OrderBy( i => i.w5sysFunction.order1)
                    .Select(i => new 
                    {
                        name = Lng.Web_Language.CurrentLng == "vi" ? i.w5sysFunction.caption : i.w5sysFunction.caption_EN,
                        url = "#" + i.functionID
                    });
                stoTopMenu.DataBind();

                btnUser.Text = LoginHelper.user.caption;

                Ext.Net.TreeNode root = new Ext.Net.TreeNode();
                root.Href = "";
                root.NodeID = "a";
                root.Text = "root";
                root.Qtip = "";
                TreePanel1.Root.Add(root);

                if (Lng.Web_Language.CurrentLng == "vi")
                {
                    statusbar1_lng.Icon = Icon.FlagVn;
                    statusbar1_lng.Text = "Tiếng việt";
                    tenDoanhNghiep.Html = "Chi nhánh: <b>" + DbHelper.DrGet(LoginHelper.Dept, "caption") + "</b>";
                }
                else
                {
                    statusbar1_lng.Icon = Icon.FlagUs;
                    statusbar1_lng.Text = "English";
                    tenDoanhNghiep.Html = "Dempartment: <b>" + DbHelper.DrGet(LoginHelper.Dept, "caption_EN") + "</b>";
                }
                idLogo.Src = DbHelper.DrGetString(LoginHelper.Dept, "logo");
                if (string.IsNullOrWhiteSpace(idLogo.Src))
                    idLogo.Src = "/sHRM/Styles/img/Logo_129.png";
                statusbar1_ip.Text = GetClientIP();
                statusbar1_db.Text = LoginHelper.dbUsed;

                Lng.Web_Language.Lng_SetControlTexts(this);
                meSetLanguage();

                LoadNotices();
            }
        }

        private void LoadNotices()
        {
            Core.Business.Logic.Report.BaoCao logic = new Core.Business.Logic.Report.BaoCao();
            int countNotices = 0;

            int a = logic.GetReportNVSapHetHopDong_Count(DateTime.Now.Date, "", true);
            if (a > 0)
            {
                countNotices += 1;
                var mi = new Ext.Net.MenuItem()
                {
                    Text = "Nhân viên sắp hết hạn hợp đồng (" + a + ")",
                    Icon = Icon.NoteGo,
                    Href = "javascript:CreateWin('Notice1', '/Cpanel/Report/ReportHopDongHetHan.aspx', 'Nhân viên sắp hết hạn hợp đồng')"
                };
                btnNotices_menu.Items.Add(mi);
            }
            a = logic.GetReportNVHetHanNghiThaiSan_Count(DateTime.Now, "", 7);
            if (a > 0)
            {
                countNotices += 1;
                var mi = new Ext.Net.MenuItem()
                {
                    Text = "Nhân viên hết hạn nghỉ thai sản (" + a + ")",
                    Icon = Icon.NoteGo,
                    Href = "javascript:CreateWin('Notice2', '/Cpanel/Report/ReportNhanVienHetHanThaiSan.aspx', 'Nhân viên hết hạn nghỉ thai sản')"
                };
                btnNotices_menu.Items.Add(mi);
            }

            if (countNotices > 0)
            {
                btnNotices.Text = string.Format("Notices ({0})", countNotices);
            }
            else
            {
                btnNotices.Visible = false;
            }
        }

        private void meSetLanguage()
        {
            if (Lng.Web_Language.CurrentLng == "en")
            {
                //wEx.Html = "<p>Error has throw<br />Please contact adminitrator...</p><div id='wEx_msg' style='display: none'></div>";
                lblTerms.Text = "Terms";
                lblPrivacy.Text = "Privacy";
                pnlLeft.Title = "Functions";
                sHRM_logo.Src = "/sHRM/Styles/img/Quantri_EN.png";
                wLng.Title = "Language";
            }
        }

        [DirectMethod]
        public string RefreshLeftMenu(string funcID)
        {
            if (funcID.StartsWith("#"))
                funcID = funcID.Substring(1);
            long pID = 0;
            if (!long.TryParse(funcID, out pID))
                return "";
            
            Ext.Net.TreeNodeCollection nodes = new Ext.Net.TreeNodeCollection();
            Ext.Net.TreeNode root = new Ext.Net.TreeNode();
            root.Text = "Root";
            nodes.Add(root);
            RefreshLeftMenu_Add(root, pID);
            return nodes.ToJson();
        }
        void RefreshLeftMenu_Add(Ext.Net.TreeNode node, long pID)
        {
            //var db = new dcDatabaseDataContext(iHRM.Core.Business.Provider.ConnectionString);
            //var lstChild = db.w5sysRules
            var lstChild = LoginHelper.user.w5sysRole.w5sysRules
                .Where(i => i.w5sysFunction.parentId == pID)
                .OrderBy(i => i.w5sysFunction.order1);

            foreach (var it in lstChild)
            {
                Ext.Net.TreeNode n = new Ext.Net.TreeNode();
                n.Href = it.w5sysFunction.asemblyPath; // + (string.IsNullOrWhiteSpace(it.w5sysFunction.asemblyInherits) ? "" : ("?" + it.w5sysFunction.asemblyInherits));
                n.NodeID = "f" + it.w5sysFunction.id;
                n.Text = Lng.Web_Language.CurrentLng == "vi" ? it.w5sysFunction.caption : it.w5sysFunction.caption_EN;
                Icon ico = Icon.Blank;
                if (!string.IsNullOrWhiteSpace(it.w5sysFunction.icon))
                    Enum.TryParse<Icon>(it.w5sysFunction.icon, out ico);
                n.Icon = ico;
                n.Cls = "funcClass";
                if (n.Text == "-")
                    n.Cls += " treeSpacer";
                n.CustomAttributes.Add(new ConfigItem("modal", it.w5sysFunction.modal.ToString(), ParameterMode.Value));

                RefreshLeftMenu_Add(n, it.w5sysFunction.id);
                node.Nodes.Add(n);
            }

            node.Cls += lstChild.Count() > 0 ? " hasChild" : "";
        }

        protected void btnLogout_Click(object sender, DirectEventArgs e)
        {
            LoginHelper.logout();
            Response.Redirect("/Cpanel/Login.aspx?autoLog=0");
        }

        protected void wLng_DirectClick(object sender, DirectEventArgs e)
        {
            var btn = sender as Ext.Net.Button;
            Lng.Web_Language.Load(btn.CommandArgument);

            statusbar1_lng.Text = btn.Text;
            statusbar1_lng.Icon = btn.Icon;
            wLng.Hide();
            Response.Redirect("/sHRM");
        }

        public static string GetClientIP()
        {
            string ip = "";
            string ipList = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipList))
                ip = ipList.Split(',')[0];

            if (string.IsNullOrWhiteSpace(ip))
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (string.IsNullOrWhiteSpace(ip))
                ip = HttpContext.Current.Request.UserHostAddress;

            return ip;
        }

        protected void btnCreateWin_DirectClick(object sender, DirectEventArgs e)
        {
            int w = 800, h = 500;
            int.TryParse(e.ExtraParams["width"], out w);
            int.TryParse(e.ExtraParams["height"], out h);

            var win = new Window
            {
                ID = e.ExtraParams["key"],
                Title = e.ExtraParams["title"],
                Height = h,
                Width = w,
                Frame = true
            };
            win.AutoLoad.Url = e.ExtraParams["url"];
            win.AutoLoad.Mode = LoadMode.IFrame;
            win.AutoLoad.ShowMask = true;

            win.Render(this.Form);
        }

    }
}