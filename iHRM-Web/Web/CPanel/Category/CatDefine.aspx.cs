using Ext.Net;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace iHRM.WebPC.Cpanel.Category
{
    public partial class CatDefine : BackEndPageBase
    {
        global::iHRM.Core.Business.Logic.Category.CatDefine logic = new global::iHRM.Core.Business.Logic.Category.CatDefine();

        protected void Page_Load(object sender, EventArgs e)
        {
            stoCatDef_RefreshData(null, null);
        }

        protected void stoCatDef_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            stoCatDef.DataSource = logic.GetAllCatDefine();
            stoCatDef.DataBind();
        }

    }
}












