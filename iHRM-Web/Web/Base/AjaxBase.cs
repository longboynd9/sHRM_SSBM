using System;
using iHRM.WebPC.Classes.Helper;

namespace iHRM.WebPC.Base
{
    /// <summary>
    /// Tang hieu qua lam nhom
    /// Moi nguoi co the tu viet ajax action cua rieng minh
    /// </summary>
    public class AjaxBase : FrontEndPageBase
    {
        public string ActionType = "";

        /// <summary>
        /// Page Init
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Page_Init(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Page_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
    }
}