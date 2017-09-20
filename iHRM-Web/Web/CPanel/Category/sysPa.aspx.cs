using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using Ext.Net;
using System.IO;
using iHRM.Core.Business.Logic;
using System.Data;
using System.Xml;

namespace iHRM.WebPC.Cpanel.Category
{
    public partial class sysPa : BackEndPageBase
    {
        global::iHRM.Core.Business.Logic.sys.sysPa logic = new global::iHRM.Core.Business.Logic.sys.sysPa();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !X.IsAjaxRequest)
            {
                Store1.DataSource = logic.GetAll();
                Store1.DataBind();
                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }

        protected void btnsave_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
        }
        protected void Store1_BeforeChanged(object sender, BeforeStoreChangedEventArgs e)
        {
            XmlDocument doc = e.DataHandler.XmlData;
            //<records><Updated><record><id>1</id><ten>ftpAccount</ten><mota>tài khoản FTP úp ảnh</mota><giatri>52.74.100.4@LHT_ftp@12345667.</giatri><Id>-1</Id></record></Updated></records>
            foreach (XmlNode updated in doc.SelectNodes("/records/Updated/record"))
            {
                logic.Update(int.Parse(updated.SelectSingleNode("id").InnerText), updated.SelectSingleNode("value").InnerText);
            }
            e.Cancel = true;
            
            Tools.message(Lng.common_msg.Edit_Success);
        }
    }
}