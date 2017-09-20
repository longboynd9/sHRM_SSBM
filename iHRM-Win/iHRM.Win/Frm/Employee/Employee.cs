using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Helper;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Win.Frm.Report;
using iHRM.Win.Frm.QuetThe;
using DevExpress.Skins;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Win.ExtClass;
namespace iHRM.Win.Frm.Employee
{
    public partial class Employee : frmBase
    {
        global::iHRM.Core.Business.Logic.Employee.Emp logic = new global::iHRM.Core.Business.Logic.Employee.Emp();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        DataTable dtData = new DataTable();
        DataRow CRow;
        dlgEmployee dlgEditor;
        public static string strFunction = "";
        public Employee()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            btnFind_Click(null, null);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu nhân viên...";
            dw_it.OnDoing = (s,ev) =>
            {
                logic.VirtualPaging.PageSize = pageNavigator1.PageSize;
                logic.VirtualPaging.Page = pageNavigator1.CurrentPage;
                if (!string.IsNullOrEmpty(chonPhongBan1.SelectedValue))
                    dtData = logic.GetAll(new System.Data.SqlClient.SqlParameter("SearchKey", txtSearchKey.Text), new System.Data.SqlClient.SqlParameter("phongban", chonPhongBan1.SelectedValue));
                else
                    dtData = logic.GetAll(new System.Data.SqlClient.SqlParameter("SearchKey", txtSearchKey.Text));
                dw_it.bw.ReportProgress(1, dtData);
                dw_it.bw.ReportProgress(2, logic.VirtualPaging.RecordCount);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    grd.DataSource = data.UserState; btnFind.Enabled = true;
                }
                else if (data.ProgressPercentage == 2)
                {
                    pageNavigator1.RecordCount = (int)data.UserState;
                }
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportGrid(grd);
        }

        //private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        //{
        //    var dr = grv.GetFocusedDataRow();
        //    if (dr != null)
        //    {
        //        var emp = db.tblEmployees.SingleOrDefault(i => i.EmployeeID == (dr[TableConst.tblEmployee.EmployeeID] as string));

        //        if (emp == null)
        //        {
        //            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
        //        }
        //        else
        //        {
        //            try
        //            {
        //                db.tblEmployees.DeleteOnSubmit(emp);
        //                db.SubmitChanges();

        //                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
        //                dr.Delete();
        //            }
        //            catch (Exception ex)
        //            {
        //                win_globall.ExecCatch(ex);
        //            }
        //        }
        //    }
        //}

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var drs = grv.GetSelectedRows().Select(i => grv.GetDataRow(i));
            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }
            else
            {
                if (GUIHelper.ConfirmBox("Bạn có chắc chắn muốn xóa nhân viên đã chọn " + drs.First()["EmployeeID"]))
                {
                    db = new dcDatabaseDataContext(Provider.ConnectionString);
                    var lst = db.tblEmployees.Where(i => drs.Select(j => j[TableConst.tblEmployee.EmployeeID] as string).Contains(i.EmployeeID));

                    if (lst == null || lst.Count() == 0)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                        return;
                    }
                    try
                    {
                        db.tblEmployees.DeleteAllOnSubmit(lst);
                        db.SubmitChanges();

                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                        grv.DeleteSelectedRows();
                    }
                    catch (Exception ex)
                    {
                        win_globall.ExecCatch(ex);
                    }
                }
            }
        }

        void ShowEditor()
        {
            if (dlgEditor == null)
            {
                dlgEditor = new dlgEmployee();
                dlgEditor.Owner = this;
                dlgEditor.OnSave += dlgEditor_OnSave;
            }
            dlgEditor.Show();
        }

        void dlgEditor_OnSave(object sender, EventArgs e)
        {
            try
            {
                if (dlgEditor.MyValue["AppliedDate"] == null)
                {
                    GUIHelper.Notifications("Bạn chưa nhập ngày vào.", "Không thể lưu", GUIHelper.NotifiType.none);
                }
                else
                {
                    db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
                    dcDatabaseMCCDataContext dbMCC = new dcDatabaseMCCDataContext(Provider.ConnectionString_MCC);
                    tblEmployee emp_new;
                    int maChamCong = 0;
                    if (strFunction == "add")
                    {
                        emp_new = new tblEmployee();
                        emp_new.EmployeeID = dlgEditor.MyValue["EmployeeID"] as string;
                        emp_new.EmployeeCode = dlgEditor.MyValue["EmployeeID"] as string;
                        maChamCong = LoginHelper.Context.getNumberEmpID(emp_new.EmployeeID);
                    }
                    else
                    {
                        emp_new = db.tblEmployees.Where(p => p.EmployeeID == dlgEditor.myID.ToString()).Single();
                        emp_new.EmployeeID = dlgEditor.myID.ToString();
                        emp_new.statePushServer = "edited";
                        maChamCong = LoginHelper.Context.getNumberEmpID(emp_new.EmployeeID);
                    }

                    // Thông tin chung:
                    emp_new.OldEmployeeID = dlgEditor.MyValue["OldEmployeeID"] as string;
                    emp_new.isTinhChuyenCan = dlgEditor.MyValue["isTinhChuyenCan"] as bool?; // isTinhChuyenCan
                    emp_new.NameSearch = ConvertUnicode.RemoveUnicode(dlgEditor.MyValue["EmployeeName"] as string).ToUpper();
                    emp_new.FirstName = dlgEditor.MyValue["FirstName"] as string;
                    emp_new.LastName = dlgEditor.MyValue["LastName"] as string;
                    emp_new.Birthday = dlgEditor.MyValue["Birthday"] as DateTime?;
                    emp_new.EmployeeName = dlgEditor.MyValue["EmployeeName"] as string;
                    emp_new.MaritalStatusID = dlgEditor.MyValue["MaritalStatusID"] as string;
                    emp_new.MaritalStatusName = dlgEditor.MyValue["MaritalStatusName"] as string;
                    emp_new.SexID = dlgEditor.MyValue["SexID"] as string;
                    emp_new.Phone = dlgEditor.MyValue["Phone"] as string;
                    emp_new.CardID = dlgEditor.MyValue["CardID"] as string;
                    emp_new.AppliedDate = dlgEditor.MyValue["AppliedDate"] as DateTime?;

                    emp_new.SubmitDate = dlgEditor.MyValue["SubmitDate"] as DateTime?;
                    emp_new.ContractDate = dlgEditor.MyValue["ContractDate"] as DateTime?;
                    emp_new.NationalityID = dlgEditor.MyValue["NationalityID"] as string;
                    emp_new.mailCongTy = dlgEditor.MyValue["mailCongTy"] as string;
                    emp_new.mailNgoai = dlgEditor.MyValue["mailNgoai"] as string;
                    emp_new.dis = dlgEditor.MyValue["dis"] as string;

                    emp_new.chuyenNganh = dlgEditor.MyValue["chuyenNganh"] as string;
                    emp_new.truongDH = dlgEditor.MyValue["truongDH"] as string;
                    emp_new.SoNguoiPhuThuoc = Convert.ToInt16(dlgEditor.MyValue["SoNguoiPhuThuoc"]);

                    if (!string.IsNullOrEmpty(emp_new.NationalityID))
                    {
                        var q = db.tblRef_Nationalities.Where(p => p.NationalityID == emp_new.NationalityID);
                        if (q.Count() > 0)
                        {
                            emp_new.NationalityName = q.First().NationalityName;
                            emp_new.NationalityName_VIE = q.First().NationalityName_VIE;
                        }
                    }
                    //emp_new.NationalityName = dlgEditor.MyValue["NationalityName"] as string;
                    emp_new.EducationID = dlgEditor.MyValue["EducationID"] as string;
                    if (!string.IsNullOrEmpty(emp_new.EducationID))
                    {
                        var q = db.tblRef_Educations.Where(p => p.EducationID == emp_new.EducationID);
                        if (q.Count() > 0)
                        {
                            emp_new.EducationType = q.First().EducationType;
                        }
                    }
                    if (dlgEditor.MyValue["InGroup1"] == null || dlgEditor.MyValue["InGroup1"].ToString() == "" || dlgEditor.MyValue["InGroup1"].ToString() == "0")
                    {
                        emp_new.InGroup1 = null;
                    }
                    else
                    {
                        emp_new.InGroup1 = Convert.ToInt16(dlgEditor.MyValue["InGroup1"]);
                    }
                    // Start CMND:
                    emp_new.IDCard = dlgEditor.MyValue["IDCard"] as string;
                    emp_new.IssuePlace = dlgEditor.MyValue["IssuePlace"] as string;
                    emp_new.Address = dlgEditor.MyValue["Address"] as string;
                    emp_new.IssueDate = dlgEditor.MyValue["IssueDate"] as DateTime?;
                    emp_new.NativeCountry = dlgEditor.MyValue["NativeCountry"] as string;
                    emp_new.PermanentAddress = dlgEditor.MyValue["PermanentAddress"] as string;
                    emp_new.CompanyName = dlgEditor.MyValue["CompanyName"] as string;
                    // Start Tài Khoản Ngân Hàng
                    emp_new.BankAccount = dlgEditor.MyValue["BankAccount"] as string;
                    emp_new.BankNameAcount = dlgEditor.MyValue["BankNameAcount"] as string;
                    emp_new.BankID = dlgEditor.MyValue["BankID"] as string;
                    if (!string.IsNullOrEmpty(emp_new.BankID))
                    {
                        var a = db.tblRef_Banks.Where(p => p.BankID == emp_new.BankID).ToList();
                        if (a.Count > 0)
                            emp_new.BankName = a.First().BankName;
                        else
                            emp_new.BankName = null;
                    }
                    // Lương
                    emp_new.AnnualLeave = dlgEditor.MyValue["AnnualLeave"] as double?;

                    // Bảo hiểm sổ lao động
                    emp_new.LeftDate = dlgEditor.MyValue["LeftDate"] as DateTime?;
                    emp_new.LeftTypeID = dlgEditor.MyValue["LeftTypeID"] as string;
                    emp_new.LeftTypeName = dlgEditor.MyValue["LeftTypeName"] as string;
                    emp_new.FinalPaymentDate = dlgEditor.MyValue["FinalPaymentDate"] as DateTime?; 
                    emp_new.LeftDateReg = dlgEditor.MyValue["LeftDateReg"] as DateTime?; 
                    if (strFunction == "add")
                    {
                        var aa = db.tblEmployees.Where(p => p.EmployeeID == dlgEditor.MyValue["EmployeeID"].ToString()).ToList();
                        if (aa.Count == 0)
                        {
                            db.tblEmployees.InsertOnSubmit(emp_new);
                            db.SubmitChanges();
                            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                        }
                        else
                        {
                            db.SubmitChanges();
                            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                        }
                    }
                    else
                    {
                        // Sửa thì chuyển trạng thái thành edited
                        db.SubmitChanges();
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                    }
                    // Update thông tin vào db máy chấm công.
                    var nvCC = dbMCC.tbNhanViens.Where(p => p.maChamCong == maChamCong).FirstOrDefault();
                    if (nvCC != null)
                    {
                        nvCC.loaiNhanVien = "0";
                        nvCC.tenChamCong = ConvertUnicode.RemoveUnicode(emp_new.EmployeeName);
                        nvCC.maThesHRM = nvCC.maThe = emp_new.CardID;
                        nvCC.trangThai = "Edited";
                    }
                    else
                    {
                        nvCC = new tbNhanVien();
                        nvCC.maChamCong = maChamCong;
                        nvCC.loaiNhanVien = "0";
                        nvCC.maNV = emp_new.EmployeeID;
                        nvCC.tenChamCong = ConvertUnicode.RemoveUnicode(emp_new.EmployeeName);
                        nvCC.maThesHRM = nvCC.maThe = emp_new.CardID;
                        nvCC.trangThai = "No push";
                        dbMCC.tbNhanViens.InsertOnSubmit(nvCC);
                    }
                    dbMCC.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }
        private void btnThemNV_Click_Click(object sender, EventArgs e)
        {
            strFunction = "add";
            ShowEditor();
            var r = dtData.NewRow();
            r["EmployeeID"] = LoginHelper.Context.getEmployeeID(); // Thêm dlg khi bấm add.
            r["isTinhChuyenCan"] = true;
            dlgEditor.MyValue = r;
        }
        private void grv_DoubleClick(object sender, EventArgs e)
        {
            if (grv.FocusedRowHandle != -1)
            {
                CRow = grv.GetFocusedDataRow();
                strFunction = "edit";
                ShowEditor();
                dlgEditor.MyValue = CRow;
            }
        }

        private void grd_DataSourceChanged(object sender, EventArgs e)
        {
            CRow = grv.GetFocusedDataRow();
        }

        private void pageNavigator1_OnPageChange(object sender, EventArgs e)
        {
            btnFind_Click(null, null);
        }

        private void txtSearchKey_Leave(object sender, EventArgs e)
        {
            btnFind_Click(sender, e);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            new NhapLuongNhanVien().ShowDialog();
        }

        private void toolStripInThe_Click(object sender, EventArgs e)
        {
            new InTheNhanVien("the").ShowDialog();
        }

        private void toolStripInHoSo_Click(object sender, EventArgs e)
        {
            new InTheNhanVien("hoso").ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            new InTheNhanVien("hopdong").ShowDialog();
        }

        private void grv_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0 && !string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "leftdate").ToString()))
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            new InTheNhanVien("thucanhcao").ShowDialog();
        }

        private void toolStripGiayTo_Click(object sender, EventArgs e)
        {
            new InGiayTo().ShowDialog();
        }

        private void btnInQuyetDinh_Click(object sender, EventArgs e)
        {
            new InTheNhanVien("quyetdinhthoiviec").ShowDialog();
        }

    }
}
