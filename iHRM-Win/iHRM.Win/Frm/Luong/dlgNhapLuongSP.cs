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

namespace iHRM.Win.Frm.Luong
{
    public partial class dlgNhapLuongSP : dlgCustomBase
    {
        Core.Business.Logic.Luong.TinhLuong logic = new Core.Business.Logic.Luong.TinhLuong();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        public dlgNhapLuongSP()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (dateThang.DateTime == null || dateThang.Text == "")
                {
                    errorProvider1.SetError(dateThang, "Bạn chưa nhập tháng...");
                    GUIHelper.Notifications("Bạn chưa nhập tháng...", this.Form_Title, GUIHelper.NotifiType.error);
                    return;
                }
                try
                {
                    double luongsp = Convert.ToDouble(txtLuongSP.Text);
                }
                catch (Exception)
                {
                    errorProvider1.SetError(txtLuongSP, "Bạn nhập sai lương SP...");
                    GUIHelper.Notifications("Bạn nhập sai lương SP...", this.Form_Title, GUIHelper.NotifiType.error);
                    return;
                }
                if (txtMaNV.Text == "")
                {
                    errorProvider1.SetError(txtTenNV, "Bạn nhập sai mã nhân viên...");
                    GUIHelper.Notifications("Bạn nhập sai mã nhân viên...", this.Form_Title, GUIHelper.NotifiType.error);
                    return;
                }
                else
                {
                    var tstl = db.tbThamSoTinhLuongs.Where(p => p.employeeID == txtMaNV.Text && p.thang == dateThang.DateTime);
                    if (tstl.Count() > 0)
                    {
                        tstl.First().LuongSP = Convert.ToDouble(txtLuongSP.Text);
                    }
                    else
                    {
                        tbThamSoTinhLuong new_tstl = new tbThamSoTinhLuong();
                        new_tstl.id = Guid.NewGuid();
                        new_tstl.employeeID = txtMaNV.Text;
                        new_tstl.thang = dateThang.DateTime;
                        new_tstl.LuongSP = Convert.ToDouble(txtLuongSP.Text);
                        db.tbThamSoTinhLuongs.InsertOnSubmit(new_tstl);
                    }
                    db.SubmitChanges();
                    GUIHelper.Notifications("Đăng ký thành công!", this.Form_Title, GUIHelper.NotifiType.none);
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

        private void txtMaNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var emp = db.tblEmployees.Where(p => p.EmployeeID == txtMaNV.Text);
                if (emp.Count() > 0)
                {
                    txtTenNV.Text = emp.First().EmployeeName;
                }
            }
        }

        private void txtMaNV_Leave(object sender, EventArgs e)
        {
            var emp = db.tblEmployees.Where(p => p.EmployeeID == txtMaNV.Text);
            if (emp.Count() > 0)
            {
                txtTenNV.Text = emp.First().EmployeeName;
            }
        }
    }
}
