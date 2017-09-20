using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iHRM.WebPC.Code; using iHRM.Common.Code;

namespace iHRM.WebPC.Cpanel.HtmlModule
{
    public partial class Default : System.Web.UI.Page
    {
        const string HTMLModulePath = "~/Cpanel/HtmlModule";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    DirectoryInfo di = new DirectoryInfo(Server.MapPath(HTMLModulePath));
                    foreach (FileInfo fi in di.GetFiles("*.html"))
                        cmbChoose.Items.Add(new Ext.Net.ListItem(fi.Name.Substring(0, fi.Name.Length - 5), fi.Name));
                }
                catch (Exception ex) { Tools.messageEx(ex); }
            }
        }

        protected void btnLoad_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            if (cmbChoose.SelectedIndex == -1)
            {
                Tools.message("Xin vui lòng chọn module...");
                return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(Path.Combine(Server.MapPath(HTMLModulePath), cmbChoose.Value.ToString())))
                {
                    txtDesign.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch (Exception ex) { Tools.messageEx(ex); }
        }

        protected void btnSave_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            if (cmbChoose.SelectedIndex == -1)
            {
                Tools.message("Xin vui lòng chọn module...");
                return;
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(Server.MapPath(HTMLModulePath), cmbChoose.Value.ToString())))
                {
                    sw.Write(txtDesign.Text);
                    sw.Close();
                }
                Tools.message("Đã lưu thành công");
            }
            catch (Exception ex) { Tools.messageEx(ex); }
        }
    }
}