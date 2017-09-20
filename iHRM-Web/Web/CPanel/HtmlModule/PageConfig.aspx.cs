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

namespace iHRM.WebPC.Cpanel.HtmlModule
{
    public partial class PageConfig : BackEndPageBase
    {
        #region static

        [Serializable]
        public class _pageInfo
        {
            public string Title { get; set; }
            public string Meta_keywords { get; set; }
            public string Meta_description { get; set; }
            public string Home_logo { get; set; }
        }

        static _pageInfo _pi = null;
        public static _pageInfo PageInfo
        {
            get
            {
                if (_pi == null)
                    ReloadPageInfo();
                return _pi;
            }
        }

        public static void ReloadPageInfo()
        {
            if (_pi == null)
                _pi = new _pageInfo();
            try
            {
                //_pi = XMLSerializer.DeserializeF<_pageInfo>(HttpContext.Current.Server.MapPath("~/Site/HtmlModule/PageConfig.xml"));

                _pi.Title = AllLogic.SysPa_Get("pageInfo_Title");
                _pi.Meta_keywords = AllLogic.SysPa_Get("pageInfo_Meta_keywords");
                _pi.Meta_description = AllLogic.SysPa_Get("pageInfo_Meta_description");
                _pi.Home_logo = AllLogic.SysPa_Get("pageInfo_Home_logo");
            }
            catch { throw; }
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !X.IsAjaxRequest)
            {
                ReloadPageInfo();

                ImageUploader1.imgUrl = _pi.Home_logo;
                txttitle.Text = _pi.Title;
                txtkeyword.Text = _pi.Meta_keywords;
                txtdescription.Text = _pi.Meta_description;
            }
        }

        public void SavePageInfo()
        {
            try
            {
                //XMLSerializer.SerializeF<_pageInfo>(_pi, HttpContext.Current.Server.MapPath("~/Site/HtmlModule/PageConfig.xml"));

                AllLogic.SysPa_Set("pageInfo_Title", _pi.Title);
                AllLogic.SysPa_Set("pageInfo_Meta_keywords", _pi.Meta_keywords);
                AllLogic.SysPa_Set("pageInfo_Meta_description", _pi.Meta_description);
                AllLogic.SysPa_Set("pageInfo_Home_logo", _pi.Home_logo);
            }
            catch { }
        }

        protected void btnsave_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            try
            {
                if (ImageUploader1.hasFile)
                    _pi.Home_logo = ImageUploader1.save("~/Site/Images");
                _pi.Title = txttitle.Text;
                _pi.Meta_keywords = txtkeyword.Text;
                _pi.Meta_description = txtdescription.Text;

                SavePageInfo();
                Tools.messageConfirmSuccess("Cập nhật thành công.");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}