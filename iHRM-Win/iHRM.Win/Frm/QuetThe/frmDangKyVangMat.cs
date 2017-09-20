using iHRM.Common.Code;
using iHRM.Common.DungChung;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using iHRM.Win.ExtClass;
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
    public partial class frmDangKyVangMat : frmBase
    {
        private int coHuongLuong = 1;
        public string CoHuongLuong { get { return coHuongLuong.ToString(); } set { coHuongLuong = int.Parse(value); } }
        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();
        iHRM.Core.Controller.Report.GetData control = new Core.Controller.Report.GetData();
        Core.Controller.QuetThe.DkVangMat controller = new Core.Controller.QuetThe.DkVangMat();

        public frmDangKyVangMat()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            if (coHuongLuong == 1)
                bsLyDo.DataSource = CacheDataTable.DtLyDoVangMat_coHL;
            if (coHuongLuong == 0)
                bsLyDo.DataSource = CacheDataTable.DtLyDoVangMat_koHL;

            this.Text = "Đăng ký nghỉ " + (coHuongLuong == 0 ? "không lương" : "có lương");
            txtTuNgay.DateTime = txtDenNgay.DateTime = DateTime.Now.Date;
            LoadGrvLayout(grv, CoHuongLuong);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu đăng ký vắng mặt...";
            dw_it.OnDoing = (s, ev) =>
            {
                var dt = logic.GetDataDangKyVangMat(
                    txtSearchKey.Text == "" ? null : txtSearchKey.Text,
                    chonKyLuong1.TuNgay,
                    chonKyLuong1.DenNgay,
                    coHuongLuong
                );
                dw_it.bw.ReportProgress(1, dt);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                grd.DataSource = data.UserState; btnFind.Enabled = true;
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void frmDangKyCaLam_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv, CoHuongLuong);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportGrid(grd);
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            var dr = grv.GetFocusedDataRow();
            if (dr != null)
            {
                if (!GUIHelper.ConfirmBox("Bạn chắc chắn muốn xóa?"))
                    return;

                var db = new dcDatabaseDataContext(Provider.ConnectionString);
                var emp = db.tbDangKyVangMats.SingleOrDefault(i => i.id == (dr[TableConst.tbKetQuaQuetThe.id] as Guid?));

                if (emp == null)
                {
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                }
                else
                {
                    try
                    {
                        db.tbDangKyVangMats.DeleteOnSubmit(emp);
                        db.SubmitChanges();

                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                        dr.Delete();
                    }
                    catch (Exception ex)
                    {
                        win_globall.ExecCatch(ex);
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var drs = grv.GetSelectedRows().Select(i => grv.GetDataRow(i));
            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            if (!GUIHelper.ConfirmBox("Bạn chắc chắn muốn xóa?"))
                return;

            var db = new dcDatabaseDataContext(Provider.ConnectionString);
            var lst = db.tbDangKyVangMats.Where(i => drs.Select(j => j[TableConst.tbDangKyVangMat.id] as Guid?).Contains(i.id));

            if (lst == null || lst.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                return;
            }

            try
            {
                foreach (var item in lst)
                {
                    db.tbDangKyVangMats.DeleteOnSubmit(item);
                    if (item.lydo == (int)Enums.eLyDoNghi.NghiPhepNam)
                    {
                        double soNgaynghi = item.nghiCaNgay == 3 ? 1 : 0.5;
                        var emp = db.tblEmployees.Where(p => p.EmployeeID == item.EmployeeID);
                        if (emp.Count() > 0)
                        {
                            emp.First().AnnualLeave += soNgaynghi;
                        }
                    }
                    
                }
                db.SubmitChanges();

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                grv.DeleteSelectedRows();
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }

        string[] col_XinNghi_Data = new string[] { "-", "Buổi sáng", "Buổi chiều", "Cả ngày" };
        private void grv_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                var r = e.Row as DataRowView;
                if (r == null)
                    return;

                if (e.Column == gridColumn3)
                {
                    e.Value = col_XinNghi_Data[DbHelper.DrGetInt(r.Row, TableConst.tbDangKyVangMat.nghiCaNgay)];
                }
                if (e.Column == gridColumn12)
                {
                    e.Value = DbHelper.DrGetBoolean(r.Row, TableConst.tbDangKyVangMat.coHuongLuong) == true ? "Có" : "";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var db = new dcDatabaseDataContext(Provider.ConnectionString);
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            btnSave.Enabled = false;

            List<string> _lEmp = ucChonDoiTuong_DS1.GetValue();
            DateTime tuNgay = txtTuNgay.DateTime;
            DateTime denNgay = txtDenNgay.DateTime;
            int caXinNghi = cmbXinNghi.SelectedIndex + 1;
            int lyDo = (int)txtLyDo.EditValue;
            bool coTinhChuyenCan = chkCoTinhChuyenCan.Checked;
            int count = 0;


            dw_it.OnDoing = (s, ev) =>
            {
                dw_it.bw.ReportProgress(1, "Đang đăng ký...");
                dw_it.bw.ReportProgress(0, _lEmp.Count);
                foreach (string empID in _lEmp)
                {
                    count++;
                    dw_it.bw.ReportProgress(1, "Đang đăng ký nhân viên " + empID);
                    dw_it.bw.ReportProgress(3, count);
                    var nv = db.tblEmployees.SingleOrDefault(p => p.EmployeeID == empID);
                    if (nv == null)
                    {
                        dw_it.bw.ReportProgress(2, string.Format("Mã nhân viên không đúng! ({0})", empID));
                        return;
                    }

                    int day = Convert.ToInt32((denNgay - tuNgay).TotalDays);
                    int totalRecord = 0;

                    //check phép năm
                    if (lyDo == (int)iHRM.Common.Code.Enums.eLyDoNghi.NghiPhepNam && !Interface_Company.RegistableALWhenSmaller0)
                    {
                        int soNgayDangKy = Ham.DemNgayCong(tuNgay, denNgay);
                        double c1 = (soNgayDangKy * (caXinNghi == 3 ? 1 : 0.5));

                        if (nv.AnnualLeave < c1 || nv.AnnualLeave == null)
                        {
                            dw_it.bw.ReportProgress(2, string.Format("Nhân viên [{2}], Không đủ phép năm! \nPhép năm hiện tại: {0}, Phép đăng ký: {1}", nv.AnnualLeave, c1, nv.EmployeeID));
                            continue;
                        }
                    }
                    for (int i = 0; i <= day; i++)
                    {
                        DateTime ngay = tuNgay.AddDays(i);
                        var ketQuaQT = db.tbKetQuaQuetThes.SingleOrDefault(p => p.EmployeeID == empID && p.ngay == ngay);
                        var empLeft = db.tblEmployees.Where(p => p.EmployeeID == empID).FirstOrDefault();
                        if (empLeft != null && (empLeft.LeftDate == null || (empLeft.LeftDate != null && empLeft.LeftDate.Value > ngay)))
                        {
                            if (ketQuaQT != null) // Nếu đã đăng ký ca làm
                            {
                                var vm = db.tbDangKyVangMats.Where(p => p.EmployeeID == empID && p.ngay == ngay);
                                if (vm.Count() > 0 && vm.First().lydo.Value == (int)iHRM.Common.Code.Enums.eLyDoNghi.NghiPhepNam)
                                {
                                    var emp = db.tblEmployees.Where(p => p.EmployeeID == vm.First().EmployeeID);
                                    if (emp.Count() > 0)
                                    {
                                        emp.First().AnnualLeave += vm.First().nghiCaNgay == 3 ? 1 : 0.5;
                                        db.SubmitChanges();
                                    }
                                }

                                var ret = logic.DangKyVangMat2(empID,
                                    ngay,
                                    caXinNghi,
                                    lyDo,
                                    txtGhiCHu.Text,
                                    coHuongLuong,
                                    coTinhChuyenCan: coTinhChuyenCan
                                );
                                if (ret.ReturnValue == 1 && lyDo == (int)iHRM.Common.Code.Enums.eLyDoNghi.NghiPhepNam)
                                {
                                    var emp = db.tblEmployees.Where(p => p.EmployeeID == vm.First().EmployeeID);
                                    if (emp.Count() > 0)
                                    {
                                        emp.First().AnnualLeave -= caXinNghi == 3 ? 1 : 0.5;
                                        db.SubmitChanges();
                                    }
                                }
                                totalRecord += ret.ReturnValue;

                                dw_it.bw.ReportProgress(2, ret.Message);
                            }
                            else
                            {
                                dw_it.bw.ReportProgress(2, string.Format("Ngày {0:dd/MM/yyyy} Nhân viên [{1}] chưa đăng ký ca làm!", ngay, empID));
                            }
                        }
                    }
                }
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 0)
                {
                    ucProgress1.start(0, (int)data.UserState);
                }
                else if (data.ProgressPercentage == 1)
                {
                    ucProgress1.Status = data.UserState.ToString();
                }
                else if (data.ProgressPercentage == 2)
                {
                    ucProgress1.Message = ucProgress1.Message + "\n" + data.UserState;
                }
                else if (data.ProgressPercentage == 3)
                {
                    ucProgress1.CurrentValue = (int)data.UserState;
                }
            };
            dw_it.OnCompleting = (ps, obj) =>
            {
                ucProgress1.Status = "Đăng ký thành công!";
                btnSave.Enabled = true;
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }
        private void txtTuNgay_Leave(object sender, EventArgs e)
        {
            txtDenNgay.DateTime = txtTuNgay.DateTime;
        }

        private void txtDenNgay_Leave(object sender, EventArgs e)
        {
            labelControl5.Text = "(" + (txtDenNgay.DateTime - txtTuNgay.DateTime).TotalDays + " ngày)";
        }
    }
}
