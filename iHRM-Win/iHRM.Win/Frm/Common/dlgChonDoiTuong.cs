using iHRM.Core.Business;
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
    public partial class dlgChonDoiTuong : dlgCustomBase
    {
        public int SelectedIndex
        {
            get
            {
                if (checkEdit1.Checked)
                    return 1;
                if (checkEdit2.Checked)
                    return 2;
                if (checkEdit3.Checked)
                    return 3;
                return 0;
            }
            set
            {
                checkEdit1.Checked = (value == 1);
                checkEdit2.Checked = (value == 2);
                checkEdit3.Checked = (value == 3);
            }
        }

        public string SelectedText
        {
            get
            {
                if (checkEdit1.Checked)
                    return string.Format("Nhân viên [{0}] {1}", txtMaNV.Text, txtTenNV.Text);
                if (checkEdit2.Checked)
                    return string.Format("Phòng [{0}] {1}", chonPhongBan1.SelectedValue, DbHelper.DrGet(chonPhongBan1.SelectedRow, TableConst.tblRef_Department.DepName));
                if (checkEdit3.Checked)
                    return string.Format("Nhóm NV 1 [{0}]", textEdit2.SelectedText);
                return "";
            }
        }

        public string SelectedValue
        {
            get
            {
                if (checkEdit1.Checked)
                    return txtMaNV.Text;
                if (checkEdit2.Checked)
                    return chonPhongBan1.SelectedValue;
                if (checkEdit3.Checked)
                    return textEdit2.EditValue.ToString();
                return "";
            }
            set
            {
                if (checkEdit1.Checked)
                    txtMaNV.Text = value;
                else if (checkEdit2.Checked)
                    chonPhongBan1.SelectedValue = value;
                else if (checkEdit3.Checked)
                    textEdit2.EditValue = value;
            }
        }

        public dlgChonDoiTuong()
        {
            InitializeComponent();
        }
        private void dlgChonDoiTuong_Load(object sender, EventArgs e)
        {
            textEdit2.Properties.DataSource = Cls.CacheDataTable.GetCacheDataTable(Core.Business.TableConst.tblEmp_Group1.TableName);
        }

        private void lookUpEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            txtTenNV.ShowPopup();
        }

        private void txtMaNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();
                var dr = logic.checkNV(txtMaNV.Text);
                if (dr == null)
                {
                    txtMaNV.Text = "";
                }
                else
                {
                    txtMaNV.Text = DbHelper.DrGetString(dr, "EmployeeID");
                    txtTenNV.Text = string.Format("{0} [{1}]", DbHelper.DrGet(dr, "EmployeeName"), DbHelper.DrGet(dr, "IDCard"));

                    checkEdit1.Checked = true;
                }
            }
        }

        private void chonPhongBan1_OnSelected(object sender, EventArgs e)
        {
            checkEdit2.Checked = true;
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            checkEdit3.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dlgChonDoiTuong_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }

    }
}
