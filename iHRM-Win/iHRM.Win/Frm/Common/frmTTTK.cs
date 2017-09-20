using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Common
{
    public partial class frmTTTK : DevExpress.XtraEditors.XtraForm
    {
        public frmTTTK()
        {
            InitializeComponent();
        }

        private void frmTTTK_Load(object sender, EventArgs e)
        {
            txtCaption.Text = LoginHelper.user.caption;
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                LoginHelper.user.caption = txtCaption.Text;

                if (!string.IsNullOrWhiteSpace(txtNewPW.Text))
                {
                    if (txtOldPW.Text != LoginHelper.user.loginPW)
                    {
                        GUIHelper.MessageBox("Mật khẩu cũ không chính xác!");
                        return;
                    }

                    if (txtNewPW.Text != txtNewPW2.Text)
                    {
                        GUIHelper.MessageBox("Mật khẩu xác nhận không trùng nhau");
                        return;
                    }

                    LoginHelper.user.loginPW = txtNewPW.Text;
                }

                LoginHelper.db.SubmitChanges();
                GUIHelper.Notifications("Cập nhật thành công", type: GUIHelper.NotifiType.tick);
            }
            catch(Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
        }

    }
}
