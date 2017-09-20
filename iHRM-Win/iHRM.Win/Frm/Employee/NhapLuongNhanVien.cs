using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using iHRM.Win.Cls;
using System.Data.SqlClient;

namespace iHRM.Win.Frm.Employee
{
    public partial class NhapLuongNhanVien : Form
    {

        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        public NhapLuongNhanVien()
        {
            InitializeComponent();
        }

        private List<string> getMaNV()
        {
            List<string> _l = new List<string>();
            string str = memoMaNhanVien.Text;
            if (str.Trim().Split(',').Count() == 0)
            {
                _l.Add(str.Trim());
                return _l;
            }
            else
                return str.Trim().Split(',').Select(i => i.Trim()).ToList<string>();
        }
        private void btnAddLuongCB_Click(object sender, EventArgs e)
        {
            List<string> _lMaNV = getMaNV();
            int loaiKyHD = rdLoaiKyHD.SelectedIndex;
            double luongCB = Convert.ToDouble(txtLuongCB.Text);
            double phuCap = Convert.ToDouble(txtPhuCap.Text);
            int count = 0;
            string strSuccess = "", strFailed = "", strNoUpdate = "";
            if (loaiKyHD == 0) // Kí hợp đồng Duy Minh / Việt Nam
            {
                foreach (string maNV in _lMaNV)
                {
                    try
                    {
                        var empSalary = db.tblEmpSalaries.Where(p => p.EmployeeID == maNV).OrderBy(p => p.EndDate).AsEnumerable().Last();
                        DateTime endDate = empSalary.EndDate.Value;
                        DateTime beginDate = empSalary.BeginDate.Value;
                        DateTime dateChange = new DateTime(2016, 1, 1);
                        DateTime endDateChange = new DateTime(2016, 12, 31);
                        #region Đã hết hạn hợp đồng
                        if (endDate == dateChange.AddDays(-1))
                        {
                            tblEmpSalary empSalary_New = new tblEmpSalary();  // Gia hạn hđ mới 01/01/2016 - 31/12/2016
                            empSalary_New.id = Guid.NewGuid();
                            empSalary_New.EmployeeID = maNV;
                            empSalary_New.DateChange = dateChange;
                            empSalary_New.BeginDate = dateChange;
                            empSalary_New.EndDate = endDateChange;
                            empSalary_New.BasicSalary = luongCB;
                            empSalary_New.BasicSalary_Ins = phuCap;
                            empSalary_New.PosID = empSalary.PosID;
                            empSalary_New.status = 0;
                            db.tblEmpSalaries.InsertOnSubmit(empSalary_New);
                            db.SubmitChanges();
                            count++;
                            strSuccess += maNV + ",";
                        }
                        if (endDate < dateChange.AddDays(-1))
                        {
                            tblEmpSalary empSalary_New = new tblEmpSalary();  // Thêm 1 row đến 31/12/2015
                            empSalary_New.id = Guid.NewGuid();
                            empSalary_New.EmployeeID = maNV;
                            empSalary_New.DateChange = endDate.AddDays(1);
                            empSalary_New.BeginDate = endDate.AddDays(1);
                            empSalary_New.EndDate = dateChange.AddDays(-1);
                            empSalary_New.PosID = empSalary.PosID;
                            empSalary_New.BasicSalary = empSalary.BasicSalary;
                            empSalary_New.BasicSalary_Ins = empSalary.BasicSalary_Ins;
                            empSalary_New.status = 0;
                            db.tblEmpSalaries.InsertOnSubmit(empSalary_New);
                            db.SubmitChanges();

                            tblEmpSalary empSalary_New_2 = new tblEmpSalary(); // Gia hạn hđ mới 01/01/2016 - 31/12/2016
                            empSalary_New_2.id = Guid.NewGuid();
                            empSalary_New_2.EmployeeID = maNV;
                            empSalary_New_2.DateChange = dateChange;
                            empSalary_New_2.BeginDate = dateChange;
                            empSalary_New_2.EndDate = endDateChange;
                            empSalary_New_2.PosID = empSalary.PosID;
                            empSalary_New_2.BasicSalary = luongCB;
                            empSalary_New_2.BasicSalary_Ins = phuCap;
                            empSalary_New_2.status = 0;
                            db.tblEmpSalaries.InsertOnSubmit(empSalary_New_2);
                            db.SubmitChanges();
                            count++;
                            strSuccess += maNV + ",";
                        }
                        #endregion
                        #region Chưa hết hạn hợp đồng
                        if (endDate > dateChange.AddDays(-1))
                        {
                            if (beginDate >= dateChange)
                            {
                                strNoUpdate += maNV + ",";
                                //bỏ qua.
                            }
                            else
                            {
                                empSalary.EndDate = dateChange.AddDays(-1);

                                tblEmpSalary empSalary_New = new tblEmpSalary();
                                empSalary_New.id = Guid.NewGuid();
                                empSalary_New.EmployeeID = maNV;
                                empSalary_New.DateChange = dateChange;
                                empSalary_New.BeginDate = dateChange;
                                empSalary_New.EndDate = endDateChange;
                                empSalary_New.PosID = empSalary.PosID;
                                empSalary_New.BasicSalary = luongCB;
                                empSalary_New.BasicSalary_Ins = phuCap;
                                empSalary_New.status = 0;
                                db.tblEmpSalaries.InsertOnSubmit(empSalary_New);
                                db.SubmitChanges();
                                count++;
                                strSuccess += maNV + ",";
                            }
                        }
                        #endregion
                    }
                    catch (Exception)
                    {
                        strFailed += maNV + ",";
                    }
                }
            }
            else // Kí hợp đồng với Bảo Minh
            {

                foreach (string maNV in _lMaNV)
                {
                    try
                    {
                        var empSalary = db.tblEmpSalaries.Where(p => p.EmployeeID == maNV).OrderBy(p => p.EndDate).AsEnumerable().Last();
                        DateTime endDate = empSalary.EndDate.Value;
                        DateTime beginDate = empSalary.BeginDate.Value;
                        DateTime dateChange = new DateTime(2016, 1, 1);
                        DateTime endDateChange = new DateTime(2016, 12, 31);
                        #region Đã hết hạn hợp đồng
                        if (endDate <= dateChange.AddDays(-1))
                        {
                            if (endDate == dateChange.AddDays(-1))
                            {
                                tblEmpSalary empSalary_New = new tblEmpSalary();
                                empSalary_New.EmployeeID = maNV;
                                empSalary_New.id = Guid.NewGuid();
                                empSalary_New.DateChange = dateChange;
                                empSalary_New.BeginDate = dateChange;
                                empSalary_New.EndDate = endDateChange;
                                empSalary_New.PosID = empSalary.PosID;
                                empSalary_New.BasicSalary = luongCB;
                                empSalary_New.BasicSalary_Ins = phuCap;
                                empSalary_New.status = 0;
                                db.tblEmpSalaries.InsertOnSubmit(empSalary_New);
                                db.SubmitChanges();
                                count++;
                                strSuccess += maNV + ",";
                            }
                            else
                            {
                                tblEmpSalary empSalary_New = new tblEmpSalary();
                                empSalary_New.EmployeeID = maNV;
                                empSalary_New.id = Guid.NewGuid();
                                empSalary_New.DateChange = empSalary.EndDate.Value.AddDays(1);
                                empSalary_New.BeginDate = empSalary.EndDate.Value.AddDays(1);
                                empSalary_New.EndDate = empSalary.EndDate.Value.AddDays(-1).AddYears(1);
                                empSalary_New.PosID = empSalary.PosID;
                                empSalary_New.BasicSalary = empSalary.BasicSalary;
                                empSalary_New.BasicSalary_Ins = empSalary.BasicSalary_Ins;
                                empSalary_New.status = 0;
                                db.tblEmpSalaries.InsertOnSubmit(empSalary_New);
                                db.SubmitChanges();

                                var empSalary2 = db.tblEmpSalaries.Where(p => p.EmployeeID == maNV).OrderBy(p => p.EndDate).AsEnumerable().Last();

                                empSalary2.EndDate = dateChange.AddDays(-1);

                                tblEmpSalary empSalary_New2 = new tblEmpSalary();
                                empSalary_New2.EmployeeID = maNV;
                                empSalary_New2.id = Guid.NewGuid();
                                empSalary_New2.DateChange = dateChange;
                                empSalary_New2.BeginDate = dateChange;
                                empSalary_New2.EndDate = empSalary2.EndDate;
                                empSalary_New2.PosID = empSalary2.PosID;
                                empSalary_New2.BasicSalary = luongCB;
                                empSalary_New2.BasicSalary_Ins = phuCap;
                                empSalary_New2.status = 0;
                                db.tblEmpSalaries.InsertOnSubmit(empSalary_New2);
                                db.SubmitChanges();
                                count++;
                                strSuccess += maNV + ",";
                            }
                        }
                        //if (endDate < dateChange.AddDays(-1))
                        //{
                        //    tblEmpSalary empSalary_New = new tblEmpSalary();
                        //    empSalary_New.id = Guid.NewGuid();
                        //    empSalary_New.EmployeeID = maNV;
                        //    empSalary_New.DateChange = dateChange;
                        //    empSalary_New.BeginDate = dateChange;
                        //    empSalary_New.EndDate = empSalary.EndDate; // EndDate = time Kết Thúc hợp đồng cũ
                        //    empSalary_New.BasicSalary = luongCB;
                        //    empSalary_New.BasicSalary_Ins = phuCap;
                        //    empSalary_New.status = 0;

                        //    empSalary.EndDate = dateChange.AddDays(-1);

                        //    db.tblEmpSalaries.InsertOnSubmit(empSalary_New);
                        //    db.SubmitChanges();
                        //    count++;
                        //    strSuccess += maNV + ",";
                        //}
                        #endregion

                        #region Chưa hết hạn hợp đồng
                        if (endDate > dateChange.AddDays(-1))
                        {
                            if (beginDate >= dateChange)
                            {
                                strNoUpdate += maNV + ",";
                            }
                            else
                            {
                                tblEmpSalary empSalary_New = new tblEmpSalary();
                                empSalary_New.id = Guid.NewGuid();
                                empSalary_New.EmployeeID = maNV;
                                empSalary_New.DateChange = dateChange;
                                empSalary_New.BeginDate = dateChange;
                                empSalary_New.EndDate = empSalary.EndDate; // EndDate = time Kết Thúc hợp đồng cũ
                                empSalary_New.BasicSalary = luongCB;
                                empSalary_New.BasicSalary_Ins = phuCap;
                                empSalary_New.status = 0;

                                empSalary.EndDate = dateChange.AddDays(-1);

                                db.tblEmpSalaries.InsertOnSubmit(empSalary_New);
                                db.SubmitChanges();
                                count++;
                                strSuccess += maNV + ",";
                            }
                        }
                        #endregion
                    }
                    catch (Exception)
                    {
                        strFailed += maNV + ",";
                    }
                }
            }
            memoSucess.Text = string.Format("Updated success:{0}. Mã NV: {1}", count, strSuccess);
            memoFailed.Text = string.Format("Failed: {0} No update: {1}", strFailed, strNoUpdate);
        }

        class ClassDelegate
        {

            public delegate int DelegateFunction(int a, int b);
            public DelegateFunction calCulationHandler { get; set; }

            public int Add(int a, int b)
            {
                int kq = a + b;
                return kq;
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //Connect to the database
            //    SqlConnection conn = new SqlConnection();
            //    conn.ConnectionString = "Data Source=LONG-PC\\SQLEXPRESS;Initial Catalog=ozeki;User ID=sa;Password=123456a@";
            //    //conn.ConnectionString = "Driver={SQL Server};Server=LONG-PC\\SQLEXPRESS;Database=ozeki;"+
            //    //"Uid=sa;Pwd=123456a@;";
            //    conn.Open();
            //    if (conn.State == ConnectionState.Open)
            //    {
            //        //Send the message
            //        SqlCommand cmd = new SqlCommand();
            //        cmd.Connection = conn;
            //        string SQLInsert =
            //            "INSERT INTO " +
            //            "ozekimessageout (receiver,msg,status) " +
            //            "VALUES " +
            //            "('" + "+84989301105" + "','" + "Long Pro" + "','send')";
            //        cmd.CommandText = SQLInsert;
            //        cmd.ExecuteNonQuery();
            //        MessageBox.Show("Message sent");
            //    }
            //    //Disconnect from the database
            //    conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            List<string> _lMaNV = getMaNV();
            int loaiKyHD = rdLoaiKyHD.SelectedIndex;
            double luongCB = Convert.ToDouble(txtLuongCB.Text);
            double phuCap = Convert.ToDouble(txtPhuCap.Text);
            int count = 0;
            string strSuccess = "", strFailed = "", strNoUpdate = "";
            if (loaiKyHD == 1) // Kí hợp đồng với Bảo Minh
            {
                foreach (string maNV in _lMaNV)
                {
                    try
                    {
                        var empSalary = db.tblEmpSalaries.Where(p => p.EmployeeID == maNV).OrderBy(p => p.EndDate).AsEnumerable().Last();
                        DateTime endDate = empSalary.EndDate.Value;
                        DateTime beginDate = empSalary.BeginDate.Value;
                        DateTime dateChange = new DateTime(2016, 1, 1);
                        DateTime endDateChange = new DateTime(2016, 12, 31);
                        //Hợp đồng cuối cùng đang làm hợp đồng chính thức.
                        if (empSalary.ContractCode.Trim().Substring(0, 2).ToUpper() == "CT")
                        {
                            #region NHỮNG TH HẾT HẠN HĐ CT < 2016	SỬA Ngày kết thúc -> 31/12 thêm cột mới 01/01/2016 và kthuc 31/12
                            if (empSalary.EndDate < new DateTime(2015, 12, 31))
                            {
                                empSalary.EndDate = new DateTime(2015, 12, 31);
                                tblEmpSalary new_EmpSalary = new tblEmpSalary();
                                new_EmpSalary.id = Guid.NewGuid();
                                new_EmpSalary.EmployeeID = empSalary.EmployeeID;
                                new_EmpSalary.DateChange = dateChange;
                                new_EmpSalary.BeginDate = dateChange;
                                new_EmpSalary.EndDate = endDateChange;
                                new_EmpSalary.BasicSalary = luongCB;
                                new_EmpSalary.BasicSalary_Ins = phuCap;
                                new_EmpSalary.status = 0;
                                new_EmpSalary.PosID = empSalary.PosID;

                                db.tblEmpSalaries.InsertOnSubmit(new_EmpSalary);
                                db.SubmitChanges();
                                count++;
                                strSuccess += maNV + ",";
                            }
                            #endregion

                            #region HẾT HẠN HĐ CT >2016. KÍ PHỤ LỤC HĐ, sửa ngày kthuc hđ cũ và thêm cột mới 01/01/2016 kthuc k đổi
                            if (empSalary.EndDate > new DateTime(2016, 01, 01))
                            {

                                tblEmpSalary new_EmpSalary = new tblEmpSalary();
                                new_EmpSalary.id = Guid.NewGuid();
                                new_EmpSalary.EmployeeID = empSalary.EmployeeID;
                                new_EmpSalary.DateChange = dateChange;
                                new_EmpSalary.BeginDate = dateChange;
                                new_EmpSalary.EndDate = empSalary.EndDate;
                                new_EmpSalary.BasicSalary = luongCB;
                                new_EmpSalary.BasicSalary_Ins = phuCap;
                                new_EmpSalary.status = 0;
                                new_EmpSalary.PosID = empSalary.PosID;

                                empSalary.EndDate = new DateTime(2015, 12, 31);

                                db.tblEmpSalaries.InsertOnSubmit(new_EmpSalary);
                                db.SubmitChanges();
                                count++;
                                strSuccess += maNV + ",";
                            }
                            #endregion
                        }
                        // Hợp đồng cuối cùng đang làm hợp đồng thử việc.
                        if (empSalary.ContractCode.Trim().Substring(0, 2).ToUpper() == "TV")
                        {
                            #region HẾT HẠN TV < 2016. 17/12/2015 =< X < 31/12/2015	kéo dài hạn tv 31/12. CT từ 01
                            if (new DateTime(2015, 12, 17) <= empSalary.EndDate && empSalary.EndDate < new DateTime(2015, 12, 31))
                            {
                                tblEmpSalary new_EmpSalary = new tblEmpSalary();
                                new_EmpSalary.id = Guid.NewGuid();
                                new_EmpSalary.EmployeeID = empSalary.EmployeeID;
                                new_EmpSalary.DateChange = dateChange;
                                new_EmpSalary.BeginDate = dateChange;
                                new_EmpSalary.EndDate = empSalary.EndDate.Value.AddYears(1);
                                new_EmpSalary.BasicSalary = luongCB;
                                new_EmpSalary.BasicSalary_Ins = phuCap;
                                new_EmpSalary.status = 0;
                                new_EmpSalary.PosID = empSalary.PosID;
                                new_EmpSalary.ContractCode = "CT" + Convert.ToInt16(maNV);

                                empSalary.EndDate = new DateTime(2015, 12, 31);
                                db.tblEmpSalaries.InsertOnSubmit(new_EmpSalary);
                                db.SubmitChanges();
                                count++;
                                strSuccess += maNV + ",";
                            }
                            #endregion

                            #region X < 17/12/2015. Thêm cột đến 31/12/15 và cột MỚI 01/01/16.
                            if (empSalary.EndDate < new DateTime(2015, 12, 17))
                            {
                                DateTime endDateOld = empSalary.EndDate.Value;
                                tblEmpSalary new_EmpSalary = new tblEmpSalary();
                                new_EmpSalary.id = Guid.NewGuid();
                                new_EmpSalary.EmployeeID = empSalary.EmployeeID;
                                new_EmpSalary.DateChange = empSalary.EndDate.Value.AddDays(1);
                                new_EmpSalary.BeginDate = empSalary.EndDate.Value.AddDays(1);
                                new_EmpSalary.EndDate = new DateTime(2015, 12, 31);
                                new_EmpSalary.BasicSalary = empSalary.BasicSalary;
                                new_EmpSalary.BasicSalary_Ins = empSalary.BasicSalary_Ins;
                                new_EmpSalary.status = 0;
                                new_EmpSalary.PosID = empSalary.PosID;
                                db.tblEmpSalaries.InsertOnSubmit(new_EmpSalary);

                                tblEmpSalary new_EmpSalary2 = new tblEmpSalary();
                                new_EmpSalary2.id = Guid.NewGuid();
                                new_EmpSalary2.EmployeeID = empSalary.EmployeeID;
                                new_EmpSalary2.DateChange = dateChange;
                                new_EmpSalary2.BeginDate = dateChange;
                                new_EmpSalary2.EndDate = endDateOld.AddYears(1);
                                new_EmpSalary2.BasicSalary = luongCB;
                                new_EmpSalary2.BasicSalary_Ins = phuCap;
                                new_EmpSalary2.status = 0;
                                new_EmpSalary2.PosID = empSalary.PosID;
                                new_EmpSalary2.ContractCode = "CT" + Convert.ToInt16(maNV);
                                db.tblEmpSalaries.InsertOnSubmit(new_EmpSalary2);

                                db.SubmitChanges();
                                count++;
                                strSuccess += maNV + ",";
                            }
                            #endregion

                            #region HẾT HẠN TV >2016	NÀY BĐ CT SAU 01/01/2016
                            if (empSalary.EndDate >= new DateTime(2016, 01, 01))
                            {
                                //DateTime endDateOld = empSalary.EndDate.Value;
                                tblEmpSalary new_EmpSalary = new tblEmpSalary();
                                new_EmpSalary.id = Guid.NewGuid();
                                new_EmpSalary.EmployeeID = empSalary.EmployeeID;
                                new_EmpSalary.DateChange = empSalary.EndDate.Value.AddDays(1);
                                new_EmpSalary.BeginDate = empSalary.EndDate.Value.AddDays(1);
                                new_EmpSalary.EndDate = empSalary.EndDate.Value.AddYears(1);
                                new_EmpSalary.BasicSalary = luongCB;
                                new_EmpSalary.BasicSalary_Ins = phuCap;
                                new_EmpSalary.status = 0;
                                new_EmpSalary.PosID = empSalary.PosID;
                                new_EmpSalary.ContractCode = "CT" + Convert.ToInt16(maNV);
                                db.tblEmpSalaries.InsertOnSubmit(new_EmpSalary);

                                db.SubmitChanges();
                                count++;
                                strSuccess += maNV + ",";
                            }
                            #endregion
                        }
                    }
                    catch (Exception)
                    {
                        strFailed += maNV + ",";
                    }
                }
            }
            memoSucess.Text = string.Format("Updated success:{0}. Mã NV: {1}", count, strSuccess);
            memoFailed.Text = string.Format("Failed: {0} No update: {1}", strFailed, strNoUpdate);
        }
    }
}
