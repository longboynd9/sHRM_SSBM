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

namespace iHRM.Win.Frm.QuetThe
{
    public partial class dlgDangKyLamThem : dlgCustomBase
    {
        Core.Controller.QuetThe.DkCalam controller = new Core.Controller.QuetThe.DkCalam();

        public dlgDangKyLamThem()
        {
            InitializeComponent();
        }
        private void dlgDangKyCaLam_Load(object sender, EventArgs e)
        {
            txtTuNgay.EditValue = txtDenNgay.EditValue = DateTime.Today;
            txtCaLam.Properties.DataSource = (new Core.Business.Logic.ChamCong.calam()).GetAllCaLam();
            txtLyDoLamThem.Properties.DataSource = CacheDataTable.GetCacheDataTable(TableConst.tbLoaiNgayLamThem.TableName);
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
            if (txtLyDoLamThem.EditValue == null)
            {
                GUIHelper.Notifications("Xin vui lòng chọn lý do..", "Đăng ký ca làm", GUIHelper.NotifiType.stop);
                errorProvider1.SetError(txtLyDoLamThem, "Xin vui lòng chọn lý do..");
                return;
            }
            #endregion

            //#region create progress
            //mainBase.DoProgress_Item pi = new mainBase.DoProgress_Item();
            //pi.Caption = "Đăng ký làm thêm";
            //pi.Desciption = ucChonDoiTuong1.SelectedText;

            //controller.lp.OnOutMessage += (text) => { pi.OutProgressMessage(text); };
            //controller.lp.OnSetTitle += (text) => { pi.SetProgressText(text); };
            //controller.lp.OnSetValue += () => { pi.SetProgressValue(controller.lp.MaxValue == 0 ? 0 : (int)(100.0 * controller.lp.CurrentValue / controller.lp.MaxValue)); };
            //#endregion

            //btnSave.Enabled = false;
            //Core.Controller.LogicResult lr = null; //result
            //pi.OnDoing = (bgw) =>
            //{
            //    pi.SetProgressStatus(mainBase.DoProgress_status.start);
            //    switch (ucChonDoiTuong1.SelectedIndex)
            //    {
            //        case 1:
            //            lr = controller.DkCaNhan(ucChonDoiTuong1.SelectedValue, txtTuNgay.DateTime, txtDenNgay.DateTime, (Guid)txtCaLam.EditValue, chkRegSunday.Checked, txtLyDoLamThem.EditValue as int?, txtHSL.EditValue == null ? null : (int?)txtHSL.Value);
            //            break;
            //        case 2:
            //            lr = controller.DkTapThe(ucChonDoiTuong1.SelectedValue, txtTuNgay.DateTime, txtDenNgay.DateTime, (Guid)txtCaLam.EditValue, chkRegSunday.Checked, txtLyDoLamThem.EditValue as int?, txtHSL.EditValue == null ? null : (int?)txtHSL.Value);
            //            break;
            //        case 3:
            //            lr = controller.DkNhom1(Convert.ToInt32(ucChonDoiTuong1.SelectedValue), txtTuNgay.DateTime, txtDenNgay.DateTime, (Guid)txtCaLam.EditValue, chkRegSunday.Checked, txtLyDoLamThem.EditValue as int?, txtHSL.EditValue == null ? null : (int?)txtHSL.Value);
            //            break;
            //    }

            //    bgw.ReportProgress(1);
            //    pi.SetProgressStatus(mainBase.DoProgress_status.complete);
            //};

            //pi.OnReport = (ps, obj) =>
            //{
            //    if (lr.status == Core.Controller.LogicResultStatus.fail)
            //    {
            //        GUIHelper.MessageError(lr.msg, "Đăng ký làm thêm");
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

        private void txtLyDoLamThem_EditValueChanged(object sender, EventArgs e)
        {
            var r = txtLyDoLamThem.GetSelectedDataRow() as DataRowView;
            txtHSL.EditValue = r == null ? 0 : DbHelper.DrGet(r.Row, "heSoLuong");
        }
    }
}
