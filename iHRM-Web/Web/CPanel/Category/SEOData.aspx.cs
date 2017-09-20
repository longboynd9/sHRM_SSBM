using Ext.Net;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iHRM.Core.Business;
using System.Data;

namespace iHRM.WebPC.Cpanel.Category
{
    public partial class SEOData : System.Web.UI.Page
    {
        global::iHRM.Core.Business.Logic.News.SEOData logic = new global::iHRM.Core.Business.Logic.News.SEOData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Guid? id = null;
                DataRow item = null;

                if (Request["id"] == null)
                {
                    id = createNew();
                }
                else
                {
                    id = new Guid(Request["id"]);
                    if (id != null)
                    {
                        item = logic.GetById(id.Value);

                        if (item == null)
                        {
                            id = createNew();
                            if (id != null)
                                item = logic.GetById(id.Value);
                        }
                    }
                }

                if (id != null)
                {
                    hId.Value = id.ToString();
                    BackEndPageBase.FormSetDataRow(formCT, item);
                }
                Lng.Language.Lng_SetControlTexts(this);
            }
        }

        Guid? createNew()
        {
            Guid? id = null;
            if (Request["catid"] != null)
            {
                id = logic.CreateNew();
                logic.UpdateSEO4DanhMucBaiViet(new Guid(Request["catid"]), id.Value);
            }

            return id;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                var item = logic.GetById(new Guid(hId.Value as string));
                BackEndPageBase.FormGetDataRow(formCT, item);
                var g = logic.InsertOrUpdate(item);

                if (g != null)
                {
                    Tools.messageConfirmSuccess(Lng.common_msg.Edit_Success);
                }
                else
                {
                    Tools.messageConfirmSuccess(Lng.common_msg.Edit_Fail);
                }
            }
            catch (Exception ex)
            {
                Tools.messageConfirmErr(string.Format(Lng.common_msg.Error_While_Exec, ex));
            }
        }

    }
}