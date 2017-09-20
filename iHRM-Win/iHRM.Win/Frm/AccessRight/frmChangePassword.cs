using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.AccessRight
{
    public partial class frmChangePassword : dlgBase
    {
        //-> ko cần thiết
        ///// <summary>
        ///// Hành động đang thêm (0) hay sửa (1)
        ///// </summary>
        //public int CustomFormAction = -1;
        //string Iduser = Config.appConfig.frmLogin_saveId;
        //dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        public frmChangePassword()
        {
            InitializeComponent();


            //txtTen.Text = Iduser;
            txtTen.Text = LoginHelper.user.loginID; //-> lấy từ đối tượng đang login

            txtTen.ReadOnly = true; //readonly

            buttonPanel1.OnSave += buttonPanel1_OnSave;
            //buttonPanel1.OnExit += buttonPanel1_OnExit; --> ko cần tự động đóng rồi

        }
        
        //void buttonPanel1_OnExit(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        void buttonPanel1_OnSave(object sender, EventArgs e)
        {
            if(!myValidate())
            {
                //var p = db.w5sysUsers.FirstOrDefault(i => i.loginID == Iduser);
                //p.loginPW = txtMatKhauNew.Text;
                //db.SubmitChanges();
                LoginHelper.user.loginPW = txtMatKhauNew.Text; //xử lý từ đối tượng đang login
                LoginHelper.db.SubmitChanges();
                Cls.GUIHelper.Notifications_msg(Cls.GUIHelper.Notifications_msgType.EditSuccess);
                this.Close();
            }
        }
        public bool myValidate()
        {
            //if (txtPassword.Text == string.Empty)
            if (string.IsNullOrWhiteSpace(txtPassword.Text)) //kiểm tra đc cả khoảng trắng
            {
                GUIHelper.MessageBox("Chưa nhập mật khẩu cũ?");
                txtPassword.Focus();
                return true;
            }
            //if (txtPassword.Text != (db.w5sysUsers.FirstOrDefault(j => j.loginID == Iduser).loginPW))
            if (txtPassword.Text != LoginHelper.user.loginPW) //lấy từ đối tượng đang login
            {
                GUIHelper.MessageBox("Mật khẩu cũ không đúng!");
                txtPassword.Focus();
                return true;
            }
            //if(txtMatKhauNew.Text == string.Empty)
            if (string.IsNullOrWhiteSpace(txtMatKhauNew.Text)) //kiểm tra đc cả khoảng trắng
            {
                GUIHelper.MessageBox("Chưa nhập mật khẩu mới?");
                txtMatKhauNew.Focus();
                return true;
            }
            if(txtEnterPassword.Text != txtMatKhauNew.Text)
            {
                GUIHelper.MessageBox("Mật khẩu mới nhập lại không trùng?");
                txtEnterPassword.Focus();
                return true;
            }
            
            return false;
        }
    }
}
