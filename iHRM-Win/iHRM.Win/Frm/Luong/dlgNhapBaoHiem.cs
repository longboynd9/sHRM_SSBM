using iHRM.Core.Business;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong
{
    public partial class dlgNhapBaoHiem : dlgCustomBase
    {
        Core.Business.Logic.Luong.TinhLuong logic = new Core.Business.Logic.Luong.TinhLuong();

        public dlgNhapBaoHiem()
        {
            InitializeComponent();
        }
        private void dlgNhapBaoHiem_Load(object sender, EventArgs e)
        {
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region check control avalid
            errorProvider1.Clear();
            if (ucChonDoiTuong1.SelectedIndex == 0)
            {
                GUIHelper.Notifications("Xin vui lòng chọn đối tượng..", this.Form_Title, GUIHelper.NotifiType.stop);
                errorProvider1.SetError(ucChonDoiTuong1, "Xin vui lòng chọn đối tượng..");
                return;
            }

            if (textEdit1.EditValue == null)
            {
                GUIHelper.Notifications("Xin vui lòng chọn ngày bắt đầu bảo hiểm..", this.Form_Title, GUIHelper.NotifiType.stop);
                errorProvider1.SetError(textEdit1, "Xin vui lòng chọn ngày bắt đầu bảo hiểm..");
                return;
            }
            #endregion

            try
            {
                if (ucChonDoiTuong1.SelectedIndex == 1)
                {
                    var db = new Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
                    var emp = db.tblEmployees.SingleOrDefault(i => i.EmployeeID == ucChonDoiTuong1.SelectedValue);
                    if (emp != null)
                    {
                        emp.coBH = true;
                        emp.coBH_ngay = textEdit1.DateTime;
                        db.SubmitChanges();

                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                    }
                    else
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                    }
                }
                else if (ucChonDoiTuong1.SelectedIndex == 2)
                {
                    int rowAffect = logic.InsertCoHh_withDep(ucChonDoiTuong1.SelectedValue, textEdit1.DateTime);
                    GUIHelper.MessageBox(string.Format(Lng.Luong_ImportPhuCapCoDinh.msg_js4 + " ({0})", rowAffect));
                }
                else if (ucChonDoiTuong1.SelectedIndex == 3)
                {
                    int rowAffect = logic.InsertCoHh_withGroup1(Convert.ToInt32(ucChonDoiTuong1.SelectedValue), textEdit1.DateTime);
                    GUIHelper.MessageBox(string.Format(Lng.Luong_ImportPhuCapCoDinh.msg_js4 + " ({0})", rowAffect));
                }
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
        }

        private void dlgDangKyCaLam_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }
    }
}
