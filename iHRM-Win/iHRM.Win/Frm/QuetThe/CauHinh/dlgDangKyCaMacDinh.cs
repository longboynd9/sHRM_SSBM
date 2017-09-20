using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.QuetThe.CauHinh
{
    public partial class dlgDangKyCaMacDinh : dlgCustomBase
    {
        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();

        public dlgDangKyCaMacDinh()
        {
            InitializeComponent();
        }
        private void dlgDangKyCaLam_Load(object sender, EventArgs e)
        {
            txtCaLam.Properties.DataSource = (new Core.Business.Logic.ChamCong.calam()).GetAllCaLam();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region check control avalid
            errorProvider1.Clear();
            if (ucChonDoiTuong1.SelectedIndex == 0)
            {
                GUIHelper.Notifications("Xin vui lòng chọn đối tượng..", "Đăng ký ca làm", GUIHelper.NotifiType.stop);
                errorProvider1.SetError(ucChonDoiTuong1, "Xin vui lòng chọn đối tượng..");
                return;
            }
            if (txtCaLam.EditValue == null)
            {
                GUIHelper.Notifications("Xin vui lòng chọn ca làm..", "Đăng ký ca làm", GUIHelper.NotifiType.stop);
                errorProvider1.SetError(txtCaLam, "Xin vui lòng chọn ca làm..");
                return;
            }
            #endregion

            //#region create progress
            //mainBase.DoProgress_Item pi = new mainBase.DoProgress_Item();
            //pi.Caption = "Đăng ký ca làm";
            //pi.Desciption = ucChonDoiTuong1.SelectedText;

            ////controller.lp.OnSetTitle += (text) => { pi.SetProgressText(text); };
            ////controller.lp.OnOutMessage += (text) => { pi.OutProgressMessage(text); };
            ////controller.lp.OnSetValue += () => { pi.SetProgressValue(controller.lp.MaxValue == 0 ? 0 : (int)(100.0 * controller.lp.CurrentValue / controller.lp.MaxValue)); };
            //#endregion

            //btnSave.Enabled = false;
            //Core.Controller.LogicResult lr = null; //result
            //pi.OnDoing = (bgw) =>
            //{
            //    pi.SetProgressStatus(mainBase.DoProgress_status.start);
            //    int rowAffect = 0;
            //    switch (ucChonDoiTuong1.SelectedIndex)
            //    {
            //        case 1:
            //            #region dk cá nhân
            //            var db = new Core.Business.DbObject.dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
            //            var emp = db.tblEmployees.SingleOrDefault(i => i.EmployeeID == ucChonDoiTuong1.SelectedValue);
            //            if (emp == null)
            //            {
            //                pi.OutProgressMessage("Không tìm thấy thông tin nhân viên");
            //                return;
            //            }

            //            var dk = db.tbDkCaMacDinhs.FirstOrDefault(i => i.EmployeeID == ucChonDoiTuong1.SelectedValue && i.chuNhat == chkIsSunday.Checked);

            //            if (dk != null)
            //            {
            //                dk.heSoLuong = Convert.ToInt32(txtHsLuong.Value);
            //                dk.idCaLam = (Guid)txtCaLam.EditValue;
            //                dk.CardID = emp.CardID;

            //                db.SubmitChanges();
            //                pi.OutProgressMessage("Cập nhật thành công");
            //            }
            //            else
            //            {
            //                dk = new Core.Business.DbObject.tbDkCaMacDinh();
            //                dk.id = Guid.NewGuid();
            //                dk.EmployeeID = ucChonDoiTuong1.SelectedValue;
            //                dk.CardID = emp.CardID;
            //                dk.heSoLuong = Convert.ToInt32(txtHsLuong.Value);
            //                dk.idCaLam = (Guid)txtCaLam.EditValue;
            //                dk.chuNhat = chkIsSunday.Checked;

            //                db.tbDkCaMacDinhs.InsertOnSubmit(dk);
            //                db.SubmitChanges();
            //                pi.OutProgressMessage("Thêm mới thành công");
            //            }
            //            #endregion
            //            break;
            //        case 2:
            //            rowAffect = logic.DKCaMacDinh_DKnhom1(
            //                Convert.ToInt32(ucChonDoiTuong1.SelectedValue),
            //                (Guid)txtCaLam.EditValue,
            //                Convert.ToInt32(txtHsLuong.Value),
            //                chkIsSunday.Checked
            //            );

            //            pi.OutProgressMessage(string.Format(Lng.QuetThe_DKCaLam.msg_2 + " ({0})", rowAffect));
            //            break;
            //        case 3:
            //            rowAffect = logic.DKCaMacDinh_DKtapThe(
            //                ucChonDoiTuong1.SelectedValue,
            //                (Guid)txtCaLam.EditValue,
            //                Convert.ToInt32(txtHsLuong.Value),
            //                chkIsSunday.Checked
            //            );

            //            pi.OutProgressMessage(string.Format(Lng.QuetThe_DKCaLam.msg_2 + " ({0})", rowAffect));
            //            break;
            //    }

            //    bgw.ReportProgress(1);
            //    pi.SetProgressStatus(mainBase.DoProgress_status.complete);
            //};

            //pi.OnReport = (ps, obj) =>
            //{
            //    if (lr.status == Core.Controller.LogicResultStatus.fail)
            //    {
            //        GUIHelper.MessageError(lr.msg, "Đăng ký ca làm");
            //    }
            //    else
            //    {
            //        GUIHelper.MessageBox(lr.msg, Lng.QuetThe_DKCaLam.msg_2 + " (" + lr.data + ")");
            //    }
            //    btnSave.Enabled = true;
            //};

            //main.Instance.DoProgress_Reg(pi); //reg and run progress
        }

        private void dlgDangKyCaLam_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }
    }
}
