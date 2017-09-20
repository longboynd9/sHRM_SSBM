using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using iHRM.Win.Cls;
using iHRM.Win.ExtClass;

namespace iHRM.Win.Frm.Employee
{
    public partial class dlgEmployee : dlgBase
    {
        string _empID = "";
        DataTable dtEmployee;
        List<Sex> arrSex = new List<Sex>();
        List<DIS> arrDis = new List<DIS>();
        List<Company> arrComp = new List<Company>();
        public dlgEmployee()
        {
            InitializeComponent();
            dlgData.IdColumnName = TableConst.tblEmployee.EmployeeID;
            dlgData.CaptionColumnName = TableConst.tblEmployee.EmployeeName;
            dlgData.FormCaption = "Thông tin nhân viên ";
            AddControlBinding();
            if (!Interface_Company.AnyUserEditLeftDate && LoginHelper.user.loginID != "thutrang")
            {
                dateNgayNghiViec.Enabled = false;
                lookupLyDoNghiViec.Enabled = false;
            }
        }
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        private void dlgEmployee_Load(object sender, EventArgs e)
        {
            LoadPreData();
        }

        private void LoadPreData()
        {
            lookupTinhTrangGD.Properties.DataSource = db.tblRef_MaritalStatus;
            lookupNganHang.Properties.DataSource = db.tblRef_Banks;
            tblEmp_Group1 a = new tblEmp_Group1() { id = 0, gName = "" };
            var lstGroup = db.tblEmp_Group1s.ToList();
            lstGroup.Add(a);
            lookupNhom.Properties.DataSource = lstGroup;

            lookupLoaiNV.DataSource = db.tblRef_EmployeeTypes;
            lookupContract.DataSource = db.tblRef_ContractTypes;
            TreeListLookUpPB_PB.DataSource = db.tblRef_Departments;
            TreeListLookUpPB_PB_Team.DataSource = db.tblRef_Departments;
            TreeListLookUpPB_PB_Line.DataSource = db.tblRef_Departments;
            lookupChucDanh.DataSource = db.tblRef_Positions;
            lookupTrinhDoHocVan.Properties.DataSource = db.tblRef_Educations;
            lookupQuocTich.Properties.DataSource = db.tblRef_Nationalities;

            lookupLyDoNghiViec.Properties.DataSource = db.tblRef_LeftTypes;
            // Lookup DIS
            arrDis = new List<DIS>();
            arrDis.Add(new DIS { DisName = "Direct", dis = "Direct" });
            arrDis.Add(new DIS { DisName = "Indirect", dis = "Indirect" });
            arrDis.Add(new DIS { DisName = "Staff", dis = "Staff" });
            lookupDIS.Properties.DataSource = arrDis;
            // Lookup Company
            arrComp = new List<Company>();
            arrComp.Add(new Company { CompanyName = "YS2" });
            arrComp.Add(new Company { CompanyName = "YS3" });
            lookupCongTy.Properties.DataSource = arrComp;
            // Giới tính
            arrSex = new List<Sex>();
            arrSex.Add(new Sex { SexName = "Nam", SexID = "Nam" });
            arrSex.Add(new Sex { SexName = "Nữ", SexID = "Nữ" });
            lookupGioitinh.Properties.DataSource = arrSex;
        }
        private class Company
        {
            public string CompanyName { get; set; }
        }
        private class Sex
        {
            public string SexName { get; set; }
            public string SexID { get; set; }
        }
        private class DIS
        {
            public string DisName { get; set; }
            public string dis { get; set; }
        }
        protected override void FormSetData()
        {
            base.FormSetData();
            _empID = myID as string;
            lbNotifyIDCard.Text = "";
            menuRefresh_LoaiNV_Click(null, null);
            tabControlThongTinKhac.SelectedTabPage = tabLoaiNV;
            dtEmployee = Provider.ExecuteDataTableReader_SQL("SELECT * FROM tblEmployee WHERE EmployeeID ='" + _empID + "'");
        }
        private void GetAllDataInTaBle_ByEmpID(string EmpID, string TableName, GridControl grc)
        {
            grc.DataSource = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * FROM {0} WHERE EmployeeID = '{1}'", TableName, EmpID));
        }

        private void groupControl3_MouseHover(object sender, EventArgs e)
        {
            txtLuong.Visible = true;
            txtPhuCap.Visible = true;
        }

        private void groupControl3_MouseLeave(object sender, EventArgs e)
        {
            txtLuong.Visible = false;
            txtPhuCap.Visible = false;
        }

        public void AddControlBinding()
        {
            //Start thông tin cơ bản
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.EmployeeID, txtMaNV, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.OldEmployeeID, txtMaNVCu, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.FirstName, txtHo, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.LastName, txtTen, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.EmployeeName, txtHoTen, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.MaritalStatusID, lookupTinhTrangGD, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.MaritalStatusName, lookupTinhTrangGD, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.Birthday, dateNgaySinh, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.SexID, lookupGioitinh, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.Phone, txtSDT, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.CardID, txtSoThe, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.AppliedDate, dateNgayVaoLam, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.SubmitDate, dateNgayNopHoSo, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.ContractDate, dateNgayKyHopDong, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.InGroup1, lookupNhom, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.EducationID, lookupTrinhDoHocVan, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.NationalityID, lookupQuocTich, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("truongDH", txtTruongDH, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("chuyenNganh", txtChuyenNganh, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("isTinhChuyenCan", chkTinhChuyenCan, ControlBinding_DataType.Bool));
            //dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.NationalityName, lookupQuocTich, ControlBinding_DataType.String));

            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.mailCongTy, txtMailCongTy, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.mailNgoai, txtMailNgoai, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.dis, lookupDIS, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.CompanyName, lookupCongTy, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.SoNguoiPhuThuoc, txtSoNguoiPhuThuoc, ControlBinding_DataType.Int));
            // Start CMND:
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.IDCard, txtSoCMND, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.IssuePlace, txtNoiCap, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.Address, txtQueQuan, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.IssueDate, dateNgayCap, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.NativeCountry, txtDiaChi, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.PermanentAddress, txtDiaChiThuongTru, ControlBinding_DataType.String));

            // Start Tài Khoản Ngân Hàng
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.BankAccount, txtSoTaiKhoan, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.BankNameAcount, txtTenTaiKhoan, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.BankID, lookupNganHang, ControlBinding_DataType.String));

            //Lương 
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.BasicSalary, txtLuong, ControlBinding_DataType.Float));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.RegularAllowance, txtPhuCap, ControlBinding_DataType.Float));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.AnnualLeave, txtSoNgayNghi, ControlBinding_DataType.Float));

            //Bảo hiểm sổ lao động
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.LeftDate, dateNgayNghiViec, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.LeftTypeID, lookupLyDoNghiViec, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.FinalPaymentDate, dateNgayTraLuongCuoi, ControlBinding_DataType.DateTime));
            
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.LeftDateReg, dateNgayNopDon, ControlBinding_DataType.DateTime));
            //dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.LeftTypeID, chkDaThoiViec, ControlBinding_DataType.String));
        }

        #region menuDelete

        private void menuDelete_LoaiNV_Click(object sender, EventArgs e)
        {
            deleteRecord(grvLoaiNV);
            menuSave_LoaiNV_Click(null, null);
        }
        private void menuDelete_PB_Click(object sender, EventArgs e)
        {
            deleteRecord(grvPhongBan);
            menuSave_PB_Click(null, null);
        }

        private void menuDelete_LuongCB_Click(object sender, EventArgs e)
        {
            deleteRecord(grvLuongCB);
            menuSave_LuongCB_Click(null, null);
        }

        private void menuDelete_PhuCapHT_Click(object sender, EventArgs e)
        {
            deleteRecord(grvPhuCapHangThang);
            menuSave_PhuCapHT_Click(null, null);
        }

        private void menuDelete_HopDong_Click(object sender, EventArgs e)
        {
            deleteRecord(grvHopDong);
            menuSave_HopDong_Click(null, null);
        }
        private void menuDelete_ConTho_Click(object sender, EventArgs e)
        {
            deleteRecord(grvConTho);
            menuSave_ConTho_Click(null, null);
        }
        private void menuDelete_GioiThieu_Click(object sender, EventArgs e)
        {
            deleteRecord(grvGioiThieu);
            menuSave_GioiThieu_Click(null, null);
        }

        private void deleteRecord(GridView grv)
        {
            //lay thong tin cac dong dc chon
            int[] idx = grv.GetSelectedRows();//GetSelectedRows tra lai index cua row dc chon
            if (idx.Length == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }
            var rows = idx.Select(i => grv.GetDataRow(i)); // GetDataRow tra lai dataarow cua datatable
            if (GUIHelper.ConfirmBox(string.Format("Bạn muốn xóa {0} bản ghi đã chọn?", rows.Count()), "Xác nhận lại"))
            {
                foreach (DataRow r in rows)
                    r.Delete();
                //r.Table.Rows.Remove(r);
            }
        }
        #endregion

        #region menuFresh

        private void menuRefresh_LoaiNV_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_empID, "tblEmpType", grcLoaiNV); //load du lieu ve dt
            (grcLoaiNV.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }
        private void menuRefresh_PB_Click(object sender, EventArgs e)
        {
            DataTable dt = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * FROM tblEmpDep WHERE EmployeeID = '{0}'", _empID));
            foreach (DataRow row in dt.Rows)
            {
                if (row["TeamID"].ToString() != "")
                {
                    row["DepID"] = row["TeamID"];
                }
                else
                {
                    if (row["LineID"].ToString() != "")
                    {
                        row["DepID"] = row["LineID"];
                    }
                }

            }
            grcPhongBan.DataSource = dt;
            (grcPhongBan.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }

        private void menuRefresh_LuongCB_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_empID, "tblEmpSalary", grcLuongCB); //load du lieu ve dt
            (grcLuongCB.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }

        private void menuRefresh_PhuCapHT_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_empID, "tblEmpAllowanceFix", grcPhuCapHangThang); //load du lieu ve dt
            (grcPhuCapHangThang.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }

        private void menuRefresh_HopDong_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_empID, "tblEmpContract", grcHopDong);
            (grcHopDong.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }

        private void menuRefresh_ConTho_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_empID, "tblEmpChild", grcConTho);
            (grcConTho.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }
        private void menuRefresh_GioiThieu_Click(object sender, EventArgs e)
        {
            grcGioiThieu.DataSource = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT gt.*,e.DepName_Final,e.EmployeeName FROM tbGioiThieuCongNhan gt  left join tblEmployee e on gt.EmployeeID_New = e.EmployeeID WHERE gt.EmployeeID = '{0}'", _empID));
            (grcGioiThieu.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }
        #endregion

        #region menuSave

        private void menuSave_LoaiNV_Click(object sender, EventArgs e)
        {
            Provider.UpdateData((grcLoaiNV.DataSource as DataTable), "tblEmpType"); //cap nhat tat ca nhung gi thay doi tren dt toi db (them,sua,xoa)
            (grcLoaiNV.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (lan sau luu ko cap nhat lai nhung dong da cap nhat)
            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }
        private void menuSave_PB_Click(object sender, EventArgs e)
        {
            var dt = (grcPhongBan.DataSource as DataTable);
            foreach (DataRow row in dt.Rows)
            {
                if (!(row.RowState == DataRowState.Deleted))
                {
                    var dp = db.tblRef_Departments.Where(p => p.DepID == row["DepID"].ToString()).FirstOrDefault();
                    if (dp != null)
                    {
                        if (dp.DepTypeID != "2")
                        {
                            if (dp.DepTypeID == "3")
                            {
                                row["LineID"] = dp.DepID;
                                row["DepID"] = dp.DepParent;
                                row["TeamID"] = null;
                            }
                            if (dp.DepTypeID == "4")
                            {
                                row["TeamID"] = dp.DepID;
                                row["LineID"] = dp.DepParent;
                                row["DepID"] = db.tblRef_Departments.Where(p => p.DepID == dp.DepParent).FirstOrDefault().DepParent;
                            }
                        }
                        else
                        {
                            row["DepID"] = dp.DepID;
                            var line = db.tblRef_Departments.Where(p => p.DepID == row["LineID"].ToString()).FirstOrDefault();
                            if (line != null)
                            {
                                if (line.DepParent != dp.DepID)
                                {
                                    row["LineID"] = null;
                                    row["TeamID"] = null;
                                }
                                else
                                {
                                    row["LineID"] = line.DepID;
                                    var team = db.tblRef_Departments.Where(p => p.DepID == row["TeamID"].ToString()).FirstOrDefault();
                                    if (team != null)
                                    {
                                        if (team.DepParent != line.DepID)
                                        {
                                            row["TeamID"] = null;
                                        }
                                        else
                                        {
                                            row["TeamID"] = team.DepID;
                                        }
                                    }
                                    else
                                    {
                                        row["TeamID"] = null;
                                    }
                                }
                            }
                            else
                            {
                                row["LineID"] = null;
                                row["TeamID"] = null;
                            }
                        }
                    }
                }
            }
            Provider.UpdateData(dt, "tblEmpDep");
            (grcPhongBan.DataSource as DataTable).AcceptChanges();
            if (dt.Rows.Count > 0)
            {
                db = new dcDatabaseDataContext(Provider.ConnectionString);
                var empDep = db.tblEmpDeps.Where(p => p.EmployeeID == dt.Rows[0]["EmployeeID"].ToString()).OrderByDescending(p => p.DateChange).First();
                string DepID_Final = string.IsNullOrEmpty(empDep.TeamID) ? (string.IsNullOrEmpty(empDep.LineID) ? empDep.DepID : empDep.LineID) : empDep.TeamID;
                var emp = db.tblEmployees.Where(p => p.EmployeeID == dt.Rows[0]["EmployeeID"].ToString()).First();
                emp.DepID_Final = DepID_Final;
                emp.DepName_Final = db.tblRef_Departments.Where(p => p.DepID == DepID_Final).First().DepName;
            }
            else
            {
                var emp = db.tblEmployees.Where(p => p.EmployeeID == _empID).First();
                emp.DepID_Final = null;
                emp.DepName_Final = null;
            }
            db.SubmitChanges();

            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }

        private void menuSave_LuongCB_Click(object sender, EventArgs e)
        {
            Provider.UpdateData((grcLuongCB.DataSource as DataTable), "tblEmpSalary");
            (grcLuongCB.DataSource as DataTable).AcceptChanges();
            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }

        private void menuSave_PhuCapHT_Click(object sender, EventArgs e)
        {
            Provider.UpdateData((grcPhuCapHangThang.DataSource as DataTable), "tblEmpAllowanceFix");
            (grcPhuCapHangThang.DataSource as DataTable).AcceptChanges();
            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }

        private void menuSave_HopDong_Click(object sender, EventArgs e)
        {
            Provider.UpdateData((grcHopDong.DataSource as DataTable), "tblEmpContract");
            (grcHopDong.DataSource as DataTable).AcceptChanges();
            db = new dcDatabaseDataContext(Provider.ConnectionString);
            var a = db.tblEmpContracts.Where(p => p.EmployeeID == _empID && p.ContractID.Substring(0, 2).ToUpper() == "CT");
            if (a.Count() == 1)
            {
                var emp = db.tblEmployees.Where(p => p.EmployeeID == _empID).FirstOrDefault();
                if (emp != null && (emp.AnnualLeave == null || emp.AnnualLeave == 0))
                {
                    emp.AnnualLeave = LoginHelper.Context.getAnnualLeave(emp.AppliedDate.Value, emp.EmpTypeName == "Worker" ? 14 : 12);
                    txtSoNgayNghi.Text = emp.AnnualLeave.Value.ToString();
                    db.SubmitChanges();
                }
            }
            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }

        private void menuSave_ConTho_Click(object sender, EventArgs e)
        {
            Provider.UpdateData((grcConTho.DataSource as DataTable), "tblEmpChild");
            (grcConTho.DataSource as DataTable).AcceptChanges();
            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }

        private void menuSave_GioiThieu_Click(object sender, EventArgs e)
        {
            Provider.UpdateData((grcGioiThieu.DataSource as DataTable), "tbGioiThieuCongNhan"); //cap nhat tat ca nhung gi thay doi tren dt toi db (them,sua,xoa)
            (grcGioiThieu.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (lan sau luu ko cap nhat lai nhung dong da cap nhat)
            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }
        #endregion

        //Load dữ liệu khi chọn tabPage con Thông tin khác
        private void tabControlThongTinKhac_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            string namePage = e.Page.Name;
            switch (namePage)
            {
                case "tabLoaiNV":
                    if (grcLoaiNV.DataSource == null)
                    {
                        menuRefresh_LoaiNV_Click(null, null);
                    }
                    break;
                case "tabLuongCoBan":
                    if (grcLuongCB.DataSource == null)
                    {
                        menuRefresh_LuongCB_Click(null, null);
                    }
                    break;
                case "tabPhuCap":
                    if (grcPhuCapHangThang.DataSource == null)
                    {
                        menuRefresh_PhuCapHT_Click(null, null);
                    }
                    break;
                case "tabHopDong":
                    if (grcHopDong.DataSource == null)
                    {
                        menuRefresh_HopDong_Click(null, null);
                    }
                    break;
                case "tabPhongBan":
                    if (grcPhongBan.DataSource == null)
                    {
                        menuRefresh_PB_Click(null, null);
                    }
                    break;
                case "tabConTho":
                    if (grcConTho.DataSource == null)
                    {
                        menuRefresh_ConTho_Click(null, null);
                    }
                    break;
                case "tabGioiThieu":
                    if (grcGioiThieu.DataSource == null)
                    {
                        menuRefresh_GioiThieu_Click(null, null);
                    }
                    break;
                default: break;
            }
        }

        private void dlgEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            grcLoaiNV.DataSource = null;
            grcPhongBan.DataSource = null;
            grcLuongCB.DataSource = null;
            grcHopDong.DataSource = null;
            grcPhuCapHangThang.DataSource = null;
            grcConTho.DataSource = null;
        }

        #region Điền tự động thứ tự column GridView
        private void grvLoaiNV_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT)
                    e.Value = e.ListSourceRowIndex + 1;
            }
        }
        private void grvPhongBan_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_PB)
                    e.Value = e.ListSourceRowIndex + 1;
            }
        }
        private void grvLuongCB_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_Luong)
                    e.Value = e.ListSourceRowIndex + 1;
            }
        }
        private void grvPhuCapHangThang_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_PhuCapHT)
                    e.Value = e.ListSourceRowIndex + 1;
            }
        }
        private void grvHopDong_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_HĐ)
                    e.Value = e.ListSourceRowIndex + 1;
            }
        }
        private void grvConTho_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_ConTho)
                    e.Value = e.ListSourceRowIndex + 1;
            }
        }
        private void grvGioiThieu_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_GioiThieu)
                    e.Value = e.ListSourceRowIndex + 1;
            }
        }
        #endregion

        #region setID EmpID For event InitNewRow

        private void grvLoaiNV_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            setID_EmpID_For_InitNewRow(grvLoaiNV, e.RowHandle, TableConst.tblEmpType.id, TableConst.tblEmpType.EmployeeID);
        }

        private void grvPhongBan_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            setID_EmpID_For_InitNewRow(grvPhongBan, e.RowHandle, TableConst.tblEmpDep.id, TableConst.tblEmpDep.EmployeeID);
        }

        private void grvLuongCB_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            setID_EmpID_For_InitNewRow(grvLuongCB, e.RowHandle, TableConst.tblEmpSalary.id, TableConst.tblEmpSalary.EmployeeID);
            DataRow dr = grvLuongCB.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["status"] = 0;
            }
        }

        private void grvPhuCapHangThang_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            setID_EmpID_For_InitNewRow(grvPhuCapHangThang, e.RowHandle, TableConst.tblEmpAllowanceFix.id, TableConst.tblEmpAllowanceFix.EmployeeID);
        }

        private void grvHopDong_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            setID_EmpID_For_InitNewRow(grvHopDong, e.RowHandle, TableConst.tblEmpContract.id, TableConst.tblEmpContract.EmployeeID);
        }
        private void grvConTho_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            setID_EmpID_For_InitNewRow(grvConTho, e.RowHandle, TableConst.tblEmpChild.id, TableConst.tblEmpChild.EmployeeID);
        }
        private void grvGioiThieu_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var dr = grvGioiThieu.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["id"] = Guid.NewGuid();
                dr["EmployeeID"] = _empID;
                dr["Sotien"] = 0;
            }
        }
        private void setID_EmpID_For_InitNewRow(GridView grv, int rowHandle, string id, string empID)
        {
            var dr = grv.GetDataRow(rowHandle);
            if (dr != null)
            {
                dr[id] = Guid.NewGuid();
                dr[empID] = _empID;
            }
        }
        #endregion

        private void txtHo_Leave(object sender, EventArgs e)
        {
            txtHoTen.Text = string.Format("{0} {1}", txtHo.Text.Trim(), txtTen.Text.Trim());
        }

        private void txtTen_Leave(object sender, EventArgs e)
        {
            txtHoTen.Text = string.Format("{0} {1}", txtHo.Text.Trim(), txtTen.Text.Trim());
        }

        private void txtSoThe_Leave(object sender, EventArgs e)
        {
            var countEmp = db.tblEmployees.Where(p => p.LeftDate == null && p.CardID == txtSoThe.Text);
            if (countEmp.Count() > 0)
            {
                GUIHelper.MessageBox("Số thẻ này đã có nhân viên(" + countEmp.First().EmployeeID + ") sử dụng!");
            }
        }

        private void txtSoCMND_Leave(object sender, EventArgs e)
        {
            var em = db.tblEmployees.Where(i => i.EmployeeID == txtMaNV.Text && i.IDCard == txtSoCMND.Text);
            if (em.Count() > 0)
            {
                return;
            }
            else
            {
                if (Employee.strFunction == "add")
                {
                    var emp = db.tblEmployees.Where(p => p.IDCard == txtSoCMND.Text);
                    if (emp.Count() > 0 && emp.First().LeftDate == null)
                    {
                        lbNotifyIDCard.Text = string.Format("* Nhân viên {0} đang sử dụng số CMND này", emp.First().EmployeeID);
                    }
                    else if (emp.Count() > 0 && emp.First().LeftDate != null)
                    {
                        lbNotifyIDCard.Text = string.Format("* Nhân viên {0} có CMND này đã nghỉ việc ngày {1:dd/MM/yyyy} ", emp.First().EmployeeID, emp.First().LeftDate);
                    }
                }
                if (Employee.strFunction == "edit")
                {
                    var emp = db.tblEmployees.Where(i => i.IDCard == txtSoCMND.Text && i.LeftDate == null && i.EmployeeID != txtMaNV.Text);
                    if (emp.Count() > 0)
                    {
                        lbNotifyIDCard.Text = string.Format("* Nhân viên {0} đang sử dụng số CMND này", emp.First().EmployeeID);
                    }
                    else
                        lbNotifyIDCard.Text = "";
                }
            }
        }

        private void dateNgayVaoLam_Leave(object sender, EventArgs e)
        {
            try
            {
                DateTime ngayvao = Convert.ToDateTime(dateNgayVaoLam.Text);
                dateNgayNopHoSo.DateTime = dateNgayKyHopDong.DateTime = ngayvao.Date;
            }
            catch (Exception)
            {

            }
        }
    }
}