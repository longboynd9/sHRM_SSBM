using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Category
{
    public partial class CompanyInfo : dlgCustomBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        tblRef_Company cty;

        public CompanyInfo()
        {
            InitializeComponent();
        }

        private void CompanyInfo_Load(object sender, EventArgs e)
        {
            cty = db.tblRef_Companies.FirstOrDefault();

            textEdit1.DataBindings.Add("Text", cty, "CompanyCode");
            textEdit2.DataBindings.Add("Text", cty, "CompanyName");
            textEdit3.DataBindings.Add("Text", cty, "Address");
            textEdit4.DataBindings.Add("Text", cty, "Phone");
            textEdit5.DataBindings.Add("Text", cty, "Fax");
            textEdit6.DataBindings.Add("Text", cty, "VATCode");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                db.SubmitChanges();
                Cls.GUIHelper.Notifications_msg(Cls.GUIHelper.Notifications_msgType.EditSuccess);
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }
    }
}
