using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using iHRM.Core.Business.DbObject;

namespace iHRM.WebPC.Cpanel
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LoginHelper.isLogin)
                Response.Redirect("/Cpanel/Login.aspx?ref=" + Server.UrlDecode(Request.Url.ToString()));

            if (!X.IsAjaxRequest)
            {
                LoadAllItem();

                MyDesktop.StartMenu.Title = LoginHelper.user.caption;

                if (LoginHelper.user.isAdmin)
                {
                    if (Lng.Web_Language.CurrentLng == "vi")
                    {
                        MyDesktop.Shortcuts.Insert(0, new DesktopShortcut() { ShortcutID = "#folder/admin", Text = "Công cụ quản trị", IconCls = "shortcut-icon icon-window48" });
                        MyDesktop.Shortcuts.Insert(1, new DesktopShortcut() { ShortcutID = "#folder/account", Text = "Quản lý người dùng", IconCls = "shortcut-icon icon-user48" });
                        MyDesktop.Shortcuts.Insert(2, new DesktopShortcut() { ShortcutID = "#folder/report", Text = "Các báo cáo", IconCls = "shortcut-icon icon-report48" });
                    }
                    else
                    {
                        MyDesktop.Shortcuts.Insert(0, new DesktopShortcut() { ShortcutID = "#folder/admin", Text = "Admin tools", IconCls = "shortcut-icon icon-window48" });
                        MyDesktop.Shortcuts.Insert(1, new DesktopShortcut() { ShortcutID = "#folder/account", Text = "Users manager", IconCls = "shortcut-icon icon-user48" });
                        MyDesktop.Shortcuts.Insert(2, new DesktopShortcut() { ShortcutID = "#folder/report", Text = "Reports", IconCls = "shortcut-icon icon-report48" });
                    }
                }

                if (Lng.Web_Language.CurrentLng == "vi")
                {
                    statusbar1_lng.Icon = Icon.FlagVn;
                    statusbar1_lng.Text = "Tiếng việt";
                }
                else
                {
                    statusbar1_lng.Icon = Icon.FlagUs;
                    statusbar1_lng.Text = "English";
                }
                statusbar1_ip.InnerText = GetClientIP();
                statusbar1_db.InnerText = LoginHelper.dbUsed;

                Lng.Web_Language.Lng_SetControlTexts(this);
                meSetLanguage();
            }
        }

        private void meSetLanguage()
        {
            if (Lng.Web_Language.CurrentLng == "en")
            {
                wEx.Html = "<p>Error has throw<br />Please contact adminitrator...</p><div id='wEx_msg' style='display: none'></div>";
            }

            foreach (var it in MyDesktop.StartMenu.ToolItems)
            {
                if (it is Ext.Net.MenuItem)
                    Lng.Web_Language.Lng_SetControlTexts(it);
            }
            foreach (var it in MyDesktop.StartMenu.Items)
            {
                if (it is Ext.Net.MenuItem)
                    Lng.Web_Language.Lng_SetControlTexts(it);
            }
        }

        protected void Logout_Click(object sender, DirectEventArgs e)
        {
            LoginHelper.logout();
            Response.Redirect("/Cpanel/Login.aspx?autoLog=0");
        }

        #region 4folder

        string fCaptionLng(w5sysFunction f)
        {
            return Lng.Web_Language.CurrentLng == "vi" ? f.caption : f.caption_EN;
        }
        protected void wFolderViewer_EnterFolder(long id, string code = "")
        {
            using (var db = new dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString))
            {
                w5sysFunction func = null;
                if (!string.IsNullOrWhiteSpace(code))
                    func = db.w5sysFunctions.SingleOrDefault(i => i.code == code);
                else
                    func = db.w5sysFunctions.SingleOrDefault(i => i.id == id);

                wFolderViewer.Title = fCaptionLng(func);
                if (func.w5sysFunction1 != null)
                {
                    wFolderViewer_btnBack.Disabled = false;
                    wFolderViewer_backId.Value = func.w5sysFunction1.id.ToString();

                    string s = "/" + fCaptionLng(func);
                    var f = func.w5sysFunction1;
                    while (f != null)
                    {
                        if (f.parentId == const1.functionRootID)
                        {
                            s = "/Home" + s;
                            break;
                        }
                        else
                        {
                            s = "/" + fCaptionLng(f) + s;
                        }
                        f = f.w5sysFunction1;
                    }
                    wFolderViewer_address.Text = s;
                }
                else
                {
                    wFolderViewer_btnBack.Disabled = true;
                    wFolderViewer_address.Text = "Home";
                }

                var lst = db.w5sysFunctions.Where(i => i.parentId == func.id).OrderBy(i => i.order1).ToList();
                foreach (var f in lst)
                {
                    f.type = (f.w5sysFunctions.Count() > 0) ? 2 : 1;
                    f.asemblyPath = BuildFunctionPath(f);
                }

                var dt = lst.Where(i => i.type == 1);
                if (Lng.Web_Language.CurrentLng == "en")
                {
                    foreach (var r in dt)
                        r.caption = r.caption_EN;
                }
                stoFolderViewer.DataSource = dt;
                stoFolderViewer.DataBind();
                wFolderViewer.Show();

                wFolderViewer_treeF.SelectNode(func.id.ToString());
            }
        }

        protected void wFolderViewer_adressGo(object sender, DirectEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(wFolderViewer_address.Text))
                return;

            try
            {
                string[] a = wFolderViewer_address.Text.Split('/');
                if (a.Length < 2)
                    throw new Exception();

                long idd = 0;
                using (var db = new dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString))
                {
                    w5sysFunction f = db.w5sysFunctions.FirstOrDefault(i => i.id == const1.functionRootID);
                    if (f == null || a[1] != fCaptionLng(f))
                        throw new Exception();
                    idd = f.id;
                    for (int i = 2; i < a.Length; i++)
                    {
                        f = f.w5sysFunctions.FirstOrDefault(x => fCaptionLng(x).ToLower() == a[i].ToLower());
                        if (f == null)
                            throw new Exception();

                        idd = f.id;
                    }
                }

                wFolderViewer_EnterFolder(idd);
            }
            catch
            {
                Tools.message("Thư mục không tồn tại");
            }
        }

        protected void wFolderViewer_btnEnterFolder_DirectClick(object sender, DirectEventArgs e)
        {
            int idd;
            int.TryParse(wFolderViewer_btnEnterFolder_folderid.Value.ToString(), out idd);
            wFolderViewer_EnterFolder(idd, wFolderViewer_btnEnterFolder_foldercode.Value.ToString().Trim());
        }

        protected void wFolderViewer_btnBack_DirectClick(object sender, DirectEventArgs e)
        {
            int idd;
            if (int.TryParse(wFolderViewer_backId.Value.ToString(), out idd))
                wFolderViewer_EnterFolder(idd);
        }

        private string BuildFunctionPath(w5sysFunction f)
        {
            if (f == null || string.IsNullOrWhiteSpace(f.asemblyPath))
                return "/Cpanel/SYS/building-construction.aspx";

            if (f.asemblyPath.StartsWith("#"))
            {
                string key = f.asemblyPath.Substring(1, f.asemblyPath.IndexOf("/") - 1);
                string value = f.asemblyPath.Substring(f.asemblyPath.IndexOf("/") + 1);
                switch (key)
                {
                    case "table":
                        return string.Format("/Cpanel/DanhMuc/Default.aspx?fid={0}&tableName={1}", f.id, value);
                    case "report":
                        return string.Format("/Cpanel/BaoCao/Default.aspx?fid={0}&reportName={1}", f.id, value);
                }
            }
            if (f.asemblyPath.StartsWith("/"))
            {
                return f.asemblyPath;
            }

            if (f.asemblyPath == ".")
                return "/Cpanel/SYS/building-construction.aspx";

            return f.asemblyPath;
        }
        
        protected void wFolderViewer_treeF_Click(object sender, DirectEventArgs e)
        {
            wFolderViewer_EnterFolder(long.Parse(e.ExtraParams["id"]));
        }

        #endregion





        private void LoadAllItem()
        {
            using (var db = new dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString))
            {
                Ext.Net.Menu mm = new Ext.Net.Menu();
                mm.ContextMenuID = "cm_StartMenuAllItem";

                var tn = new Ext.Net.TreeNode("HOME");

                var f = db.w5sysFunctions.SingleOrDefault(i => i.code == "functiontree");
                if (f != null)
                {
                    foreach (var ff in f.w5sysFunctions.OrderBy(c => c.order1))
                        LoadAllItem2(mm, tn, ff);
                }

                //MyDesktop.StartMenu.Items.AddRange(mm.Items);
                StartMenu_mAllitem.Menu.Add(mm);

                wFolderViewer_treeF.Root.Add(tn);
            }
        }
        void LoadAllItem2(Ext.Net.Menu m, Ext.Net.TreeNode n, w5sysFunction f)
        {
            long Rule = LoginHelper.getRightAccess(f.id);
            if (Rule == 0 || !BitHelper.Has(Rule, (int)Enums.eFunction.Find))
                return;

            Ext.Net.MenuItem mii = new Ext.Net.MenuItem();
            mii.Text = fCaptionLng(f);

            if (f.w5sysFunctions.Count > 0)
            {
                Ext.Net.TreeNode nn = new Ext.Net.TreeNode();
                nn.Leaf = false;
                nn.NodeID = f.id.ToString();
                nn.Text = fCaptionLng(f);
                nn.Icon = Icon.Folder;

                mii.Icon = Icon.Folder;
                Ext.Net.Menu mm = new Ext.Net.Menu();
                mm.ContextMenuID = "cm_StartMenuAllItem";

                foreach (var ff in f.w5sysFunctions.OrderBy(i => i.order1))
                    LoadAllItem2(mm, nn, ff);
                
                mii.HideOnClick = false;
                mii.Menu.Add(mm);
                n.Nodes.Add(nn);
            }
            else
            {
                mii.Icon = Icon.TableRow;
                mii.Listeners.Click.Handler = string.Format("CreateWin('{0}', '{1}', '{2}');", f.id, BuildFunctionPath(f), fCaptionLng(f));
            }

            m.Items.Add(mii);
        }



        [DirectMethod]
        public string GetFuncPath(string code)
        {
            using (var db = new dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString))
            {
                w5sysFunction func = db.w5sysFunctions.SingleOrDefault(i => i.code == code);
                string path = BuildFunctionPath(func);
                if (func == null)
                {
                    return JSON.Serialize(new
                    {
                        id = 0,
                        path = path,
                        title = "? - " + code
                    });
                }
                return JSON.Serialize(new
                {
                    id = func.id,
                    path = path,
                    title = (Lng.Web_Language.CurrentLng == "vi" ? func.caption : func.caption_EN)
                });
            }
        }



        protected void wLng_DirectClick(object sender, DirectEventArgs e)
        {
            var btn = sender as Ext.Net.Button;
            Lng.Web_Language.Load(btn.CommandArgument);

            statusbar1_lng.Text = btn.Text;
            statusbar1_lng.Icon = btn.Icon;
            wLng.Hide();
            Response.Redirect("/Cpanel");
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

    }

}