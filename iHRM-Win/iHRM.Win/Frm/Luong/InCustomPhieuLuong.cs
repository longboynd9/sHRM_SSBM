using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iHRM.Core.Business.Logic.Luong;
using iHRM.Core.Business.DbObject;
using iHRM.Win.ExtClass;
using iHRM.Core.Business;
using iHRM.Win.ExtClass.Luong;
using iHRM.Common.DungChung;

namespace iHRM.Win.Frm.Luong
{
    public partial class InCustomPhieuLuong : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        public InCustomPhieuLuong()
        {
            InitializeComponent();
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            string strNhanVien = "";
            if (textStrNhanVien.Text == "")
            {
                strNhanVien = getEmpID();
            }
            else
            {
                strNhanVien = textStrNhanVien.Text;
            }
            Core.Controller.Luong.InPhieuLuong controller = new Core.Controller.Luong.InPhieuLuong();

            var dtData = controller.GetDataByLstEmp(new DateTime(chonKyLuong1.TuNgay.Year, chonKyLuong1.TuNgay.Month, 1),
                                                    Ham.DemNgayCong(chonKyLuong1.TuNgay, chonKyLuong1.DenNgay), 
                                                    strNhanVien,
                                                    chonKyLuong1.TuNgay,
                                                    chonKyLuong1.DenNgay
            );
            string tenCty = db.w5Systems.Where(p => p.Ma == "TitlePhieuLuong").FirstOrDefault().TitleEN;
            var rp = new InPhieuLuong();
            string strPhieuLuong = string.Format("PHIẾU LƯƠNG THÁNG {0}", chonKyLuong1.DenNgay.ToString("MM/yyyy"));
            string strChuKyLuong = string.Format("CHU KỲ LƯƠNG: {0} ~ {1}", chonKyLuong1.TuNgay.ToString("dd/MM/yyyy"), chonKyLuong1.DenNgay.ToString("dd/MM/yyyy"));
            rp.setTitle(tenCty, strPhieuLuong, strChuKyLuong);
            rp.DataBinding(dtData);
            ReportViewer rv = new ReportViewer();
            rv.ViewReport(rp);
        }

        private string getEmpID()
        {
            string strEmpID = "";
            for (int i = 0; i < grvEmployee.RowCount; i++)
            {
                if (grvEmployee.GetRowCellValue(i, colCheck).ToString() == "True")
                {
                    strEmpID += "," + grvEmployee.GetRowCellValue(i, colEmpID).ToString();
                }
            }
            return strEmpID.Remove(0, 1);
        }

        private void InCustomPhieuLuong_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grvEmployee);
            List<Employee> _lObject = new List<Employee>();
            DataTable dt = iHRM.Core.Business.Provider.ExecuteDataTableReader_SQL(
               "SELECT DISTINCT e.EmployeeID,e.EmployeeName, e.AppliedDate,e.Birthday, e.IDCard, e.DepName"
               + " FROM dbo.tbBangLuongThang b"
               + " INNER JOIN dbo.tblEmployee e ON b.empoyeeID = e.EmployeeID  ");
            foreach (DataRow row in dt.Rows)
            {
                Employee newEmp = new Employee();
                newEmp.chkEmp = false;
                newEmp.EmployeeID = row["EmployeeID"].ToString();
                newEmp.EmployeeName = row["EmployeeName"].ToString();
                newEmp.IDCard = row["IDCard"].ToString();
                newEmp.DepName = row["DepName"].ToString();
                newEmp.AppliedDate = row["AppliedDate"] as DateTime?;
                newEmp.Birthday = row["Birthday"] as DateTime?;
                _lObject.Add(newEmp);
            }
            grcEmployee.DataSource = _lObject;
        }
        private class Employee
        {
            public bool chkEmp { get; set; }
            public string EmployeeID { get; set; }
            public string EmployeeName { get; set; }
            public string IDCard { get; set; }
            public string DepName { get; set; }
            public DateTime? AppliedDate { get; set; }
            public DateTime? Birthday { get; set; }
        }

        private void InCustomPhieuLuong_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grvEmployee);
        }

        private void btnInPhieu1Dong_Click(object sender, EventArgs e)
        {
            string strNhanVien = "";
            if (textStrNhanVien.Text == "")
            {
                strNhanVien = getEmpID();
            }
            else
            {
                strNhanVien = textStrNhanVien.Text;
            }
            Core.Controller.Luong.InPhieuLuong controller = new Core.Controller.Luong.InPhieuLuong();

            var dtData = controller.GetData_1dong_ByLstEmp(new DateTime(chonKyLuong1.TuNgay.Year, chonKyLuong1.TuNgay.Month, 1),
                                                    Ham.DemNgayCong(chonKyLuong1.TuNgay, chonKyLuong1.DenNgay),
                                                    strNhanVien,
                                                    chonKyLuong1.TuNgay,
                                                    chonKyLuong1.DenNgay
            );
            string tenCty = db.w5Systems.Where(p => p.Ma == "TitlePhieuLuong").FirstOrDefault().TitleEN;
            var rp = new InPhieuLuong_1dong();
            string strPhieuLuong = string.Format("PHIẾU LƯƠNG THÁNG {0}", chonKyLuong1.DenNgay.ToString("MM/yyyy"));
            string strChuKyLuong = string.Format("CHU KỲ LƯƠNG: {0} ~ {1}", chonKyLuong1.TuNgay.ToString("dd/MM/yyyy"), chonKyLuong1.DenNgay.ToString("dd/MM/yyyy"));
            rp.setTitle(tenCty, strPhieuLuong, strChuKyLuong);
            rp.DataBinding(dtData);
            ReportViewer rv = new ReportViewer();
            rv.ViewReport(rp);
        }
    }
}