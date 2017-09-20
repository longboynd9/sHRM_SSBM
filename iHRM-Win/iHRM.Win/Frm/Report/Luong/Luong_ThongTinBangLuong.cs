using iHRM.Core.i_Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;
using DevExpress.XtraEditors;
using iHRM.Core.Business;
using iHRM.Win.Cls;

namespace iHRM.Win.Frm.Report
{
    public partial class Luong_ThongTinBangLuong : frmBase
    {
        dcDatabaseDataContext db;
        string sqlWhere = "";
        List<ItemWhere> _lItemWhere = new List<ItemWhere>();

        public Luong_ThongTinBangLuong()
        {
            InitializeComponent();
            db = new dcDatabaseDataContext(iHRM.Core.Business.Provider.ConnectionString);
            _lItemWhere.Add(new ItemWhere { columnName = "BH105", nameCombobox = "cbBaoHiem" });
            _lItemWhere.Add(new ItemWhere { columnName = "Calc3", nameCombobox = "cbCongDoan" });
            _lItemWhere.Add(new ItemWhere { columnName = "isLuongSP", nameCombobox = "cbAnLuongSP" });
            _lItemWhere.Add(new ItemWhere { columnName = "Calc1", nameCombobox = "cbChuyenCan" });
            _lItemWhere.Add(new ItemWhere { columnName = "phiCongDoan", nameCombobox = "cbPhiCongDoan" });
        }

        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            sqlWhere = "";
            getWhereCombobox();
            getWhereLuong();
            string sqlSelect = "SELECT EmployeeID,actualBankTransfer,EmployeeName,IDCard,DepName,PosName,isLuongSP, BH105, phiCongDoan, Calc1, Calc3  FROM dbo.tbBangLuongThang INNER JOIN dbo.tblEmployee ON dbo.tbBangLuongThang.empoyeeID = dbo.tblEmployee.EmployeeID WHERE laBangLuongCu = 0";
            sqlSelect += string.Format(" AND thang = '{0}'", chonKyLuong1.TuNgay.Year + "-" + string.Format("{0:00}", chonKyLuong1.TuNgay.Month) + "-01");
            if (txtMaNV.Text != "")
            {
                sqlSelect += string.Format(" AND EmployeeID = '{0}'", txtMaNV.Text);
            }
            else
            {
                if (chonPhongBan1.SelectedValue != null)
                {
                    sqlSelect += string.Format(" AND DepID = '{0}'", chonPhongBan1.SelectedValue.ToString());
                }
            }
            sqlSelect += sqlWhere;
            DataTable data = Provider.ExecuteDataTableReader_SQL(sqlSelect);
            grc.DataSource = data;
        }

        private void getWhereLuong()
        {
            double LuongStart = 0, LuongEnd = 0;
            if (txtLuongStart.Text != "")
            {
                try
                {
                    LuongStart = Convert.ToDouble(txtLuongStart.Text.Trim() == "" ? "0" : txtLuongStart.Text.Trim());
                }
                catch (Exception)
                {
                    GUIHelper.MessageError("Nhập lương sai!");
                    return;
                }
            }
            if (txtLuongEnd.Text != "")
            {
                try
                {
                    LuongEnd = Convert.ToDouble(txtLuongEnd.Text.Trim() == "" ? "0" : txtLuongEnd.Text.Trim());
                }
                catch (Exception)
                {
                    GUIHelper.MessageError("Nhập lương sai!");
                    return;
                }
            }
            if (LuongEnd >= LuongStart)
            {
                if (LuongEnd == 0 && LuongStart == 0)
                {
                    
                }
                else
                    sqlWhere += string.Format(" AND actualBankTransfer >= {0} AND actualBankTransfer <= {1}", LuongStart, LuongEnd);
            }
            else
            {
                GUIHelper.MessageError("Nhập lương sai!");
            }
        }

        private void getWhereCombobox()
        {
            foreach (var item in groupControl1.Controls)
            {
                if (item is ComboBoxEdit)
                {
                    ComboBoxEdit combo = (ComboBoxEdit)item;
                    var cb = _lItemWhere.Where(p => p.nameCombobox == combo.Name);
                    if (cb.Count() > 0 && combo.EditValue.ToString() != "All")
                    {
                        if (combo.EditValue.ToString() == "Yes")
                        {
                            sqlWhere += string.Format(" AND ISNULL({0},0) > 0 ", cb.First().columnName);
                        }
                        else
                        {
                            sqlWhere += string.Format(" AND ISNULL({0},0) = 0 ", cb.First().columnName);
                        }
                    }
                }
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ExportGrid(grc);
        }
    }
    public class ItemWhere
    {
        public string nameCombobox { get; set; }
        public string columnName { get; set; }
    }
}
