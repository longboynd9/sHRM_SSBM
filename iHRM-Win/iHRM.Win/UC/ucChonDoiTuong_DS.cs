using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;

namespace iHRM.Win.UC
{
    public partial class ucChonDoiTuong_DS : UserControl
    {
        public ucChonDoiTuong_DS()
        {
            InitializeComponent();
        }

        public List<string> GetValue()
        {
            dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
            List<string> _lStr = new List<string>();
            if (rdLoaiDK.SelectedIndex == 0)
            {
                string str = mmMaNV.Text.ToUpper().Trim();
                foreach (string item in str.Split(','))
                {
                    string maNV = item.Trim();
                    if (maNV != "")
                    {
                        _lStr.Add(maNV);
                    }
                }
            }
            else if (rdLoaiDK.SelectedIndex == 1)
            {
                if (checkEdit1.Checked)
                {
                    _lStr.Add(txtMaNV.Text);
                }
                else if (checkEdit2.Checked)
                {
                    string str = chonPhongBan1.SelectedValue;
                    string PathOfStr = db.tblRef_Departments.Where(p => p.DepID == str).First().Path;
                    _lStr = (from e in db.tblEmployees
                             join p in db.tblRef_Departments on e.DepID_Final equals p.DepID
                             select new
                             {
                                 e.EmployeeID,
                                 p.Path
                             }).ToList().Where(p => p.Path.Contains(PathOfStr)).Select(p => p.EmployeeID).ToList<string>();
                }
                else if (checkEdit3.Checked)
                {
                    _lStr = db.tblEmployees.Where(p => p.InGroup1 != null && p.InGroup1.Value == (int)textEdit2.EditValue).Select(p => p.EmployeeID).ToList<string>();
                }
            }
            return _lStr;
        }
        public int radioSelected
        {
            get
            {
                return rdLoaiDK.SelectedIndex;
            }
            set
            {
                rdLoaiDK.SelectedIndex = value;
            }
        }
        private void ucChonDoiTuong_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                checkEdit1.Checked = true;
                textEdit2.Properties.DataSource = Cls.CacheDataTable.GetCacheDataTable(TableConst.tblEmp_Group1.TableName);
            }
        }

        private void lookUpEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            txtTenNV.ShowPopup();
        }

        public void txtMaNV_KeyDown(object sender, KeyEventArgs e)
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

        private void rdLoaiDK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdLoaiDK.SelectedIndex == 0)
            {
                panelDanhSach.Visible = true;
                panelCheck.Visible = false;
            }
            else
            {
                panelDanhSach.Visible = false;
                panelCheck.Visible = true;
            }
        }
    }
}
