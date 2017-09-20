using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.IO;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using iHRM.Core.Business;

namespace iHRM.WebPC.Cpanel.Category
{
    public partial class Company : BackEndPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack && !X.IsAjaxRequest)
            {
                var db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
                var cty = db.tblRef_Companies.FirstOrDefault();

                FormSetDataContext(frm1, cty); //frm1.SetValues(cty);     
                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }

        protected void btnSave_DirectClick(object sender, DirectEventArgs e)
        {
            try
            {
                var db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
                var cty = db.tblRef_Companies.FirstOrDefault();
                FormGetDataContext(frm1, cty);
                db.SubmitChanges();
                Tools.message(Lng.common_msg.Save_Success);
            }
            catch
            {
                Tools.message(Lng.common_msg.Save_Fail);
            }
        }

    }
}