using Ext.Net;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.Cpanel
{
    public partial class Login : System.Web.UI.Page
    {
        global::iHRM.Core.Business.Logic.Common.login logic = new global::iHRM.Core.Business.Logic.Common.login();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //reset base connection
                Core.Business.Provider.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

                this.Store1.DataSource = new object[]
                {
                    new { iconCls = ResourceManager.GetIconClassName(Icon.FlagVn), name = "Tiếng việt", value = "vi"},
                    new { iconCls = ResourceManager.GetIconClassName(Icon.FlagUs), name = "English", value = "en"}
                };
                Store1.DataBind();

                string lng = global::iHRM.WebPC.Classes.Helper.Cookies.ReadCookie("_currentLng");
                if (lng == "vi" || lng == "en")
                {
                    Lng.Web_Language.Load(lng);
                    cmbLng.Value = lng;
                    cmbLng.Icon = lng == "vi" ? Icon.FlagVn : Icon.FlagUs;
                }

                txtUsername.Focus(true, 100);

                stoDb.DataSource = logic.GetAllConnection();
                stoDb.DataBind();

                Lng.Web_Language.Lng_SetControlTexts(this);

                ResourceManager1.RegisterIcon(Icon.FlagVn);
                ResourceManager1.RegisterIcon(Icon.FlagUs);

                body1.Attributes["class"] = (Request["ref"] == null) ? "hasBg" : "";
                h_autoLog.Value = Request["autoLog"];
            }
        }

        protected void btnLogin_Click(object sender, DirectEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbDb.Value as string))
            {
                GUIHelper.message(Lng.Login.msg_Please_Choose_DB);
                return;
            }
            
            var dr = logic.GetAllConnection().Select("code='" + cmbDb.Value + "'").FirstOrDefault();
            if (dr == null)
            {
                GUIHelper.message(Lng.Login.msg_Please_Choose_DB);
                return;
            }
            LoginHelper.Dept = dr;
            global::iHRM.Core.Business.Provider.ConnectionString = dr["strcnn"].ToString();


            if (LoginHelper.loginin(txtUsername.Text, txtPassword.Text))
            {
                Lng.Web_Language.Load(cmbLng.SelectedIndex == 0 ? "vi" : "en");

                LoginHelper.dbUsed = cmbDb.Text;
                if (string.IsNullOrWhiteSpace(Request["ref"]))
                {
                    Response.Redirect("~/sHRM");
                }
                else
                {
                    string urlRef = Request["ref"];
                    urlRef = urlRef.Replace("default.aspx", "");
                    urlRef = urlRef.Replace("Default.aspx", "");
                    Response.Redirect(urlRef);
                }
            }
            else
            {
                GUIHelper.message(Lng.Login.msg_Login_Fail);
            }
        }
    }
}