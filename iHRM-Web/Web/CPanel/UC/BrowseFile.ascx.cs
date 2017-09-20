using Ext.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.Cpanel.UC
{
    public partial class BrowseFile : System.Web.UI.UserControl
    {
        BrowseFileHelper helper = new BrowseFileHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grdFolder.DataBind();
            }
        }

        protected void stoFolder_RefreshData(object sender, Ext.Net.StoreRefreshDataEventArgs e)
        {
            stoFolder.DataSource = helper.BrowseHostImage_GetFolder();
            stoFolder.DataBind();
        }
        protected void stoFile_RefreshData(object sender, Ext.Net.StoreRefreshDataEventArgs e)
        {
            string path = e.Parameters["path"];
            stoFile.DataSource = helper.BrowseHostImage_GetFiles(path).Select(i => new { name = i });
            stoFile.DataBind();
        }

    }
}