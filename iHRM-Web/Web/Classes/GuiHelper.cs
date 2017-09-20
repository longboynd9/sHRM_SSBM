using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iHRM.WebPC
{
    public class GuiHelper
    {
        public enum msgType_bootstrap { success, info, warning, danger }
        public static void ShowMessage_bootstrap(System.Web.UI.WebControls.Literal lit, string msg, msgType_bootstrap type, string hiddenMsg = "")
        {
            lit.Text = string.Format("<div class='alert alert-{0}' role='alert' onclick='$(this).hide()'>{1}<div class='hiddenMsg'>{2}</div></div>", type, msg, hiddenMsg);
        }
    }
}