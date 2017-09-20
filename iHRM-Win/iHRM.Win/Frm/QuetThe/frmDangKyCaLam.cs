using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class frmDangKyCaLam : frmBase
    {
        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();
        //dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
        Core.Controller.QuetThe.DkCalam controller = new Core.Controller.QuetThe.DkCalam();

        public frmDangKyCaLam()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
            txtTuNgay.EditValue = txtDenNgay.EditValue = DateTime.Today;
            txtCaLam.Properties.DataSource = (new Core.Business.Logic.ChamCong.calam()).GetAllCaLam();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu đăng ký ca làm...";
            dw_it.OnDoing = (s, ev) =>
            {
                var dt = logic.GetDataDangKyCaLam(
                    txtSearchKey.Text == "" ? null : txtSearchKey.Text,
                    chonKyLuong1.TuNgay,
                    chonKyLuong1.DenNgay,
                    chonPhongBan1.SelectedValue
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
            SaveGrvLayout(grv);
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
                var db = new dcDatabaseDataContext(Provider.ConnectionString);
                var emp = db.tbKetQuaQuetThes.SingleOrDefault(i => i.id == (dr[TableConst.tbKetQuaQuetThe.id] as Guid?));

                if (emp == null)
                {
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                }
                else
                {
                    try
                    {
                        db.tbKetQuaQuetThes.DeleteOnSubmit(emp);
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

            var db = new dcDatabaseDataContext(Provider.ConnectionString);
            var lst = db.tbKetQuaQuetThes.Where(i => drs.Select(j => j[TableConst.tbKetQuaQuetThe.id] as Guid?).Contains(i.id));

            if (lst == null || lst.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                return;
            }

            try
            {
                db.tbKetQuaQuetThes.DeleteAllOnSubmit(lst);
                db.SubmitChanges();

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                grv.DeleteSelectedRows();
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> _lEmp = new List<string>();
            _lEmp = ucChonDoiTuong_DS1.GetValue();

            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            btnSave.Enabled = false;
            dw_it.OnDoing = (s, ev) =>
            {
                DateTime tuNgay = txtTuNgay.DateTime;
                DateTime denNgay = txtDenNgay.DateTime;
                Guid idCaLam = (Guid)txtCaLam.EditValue;
                bool isRegSunday = chkRegSunday.Checked;
                int hsLuong = Convert.ToInt16(cmbHeSoLuong.Text);
                var count_day = (denNgay - tuNgay).TotalDays;
                if (count_day < 0)
                {
                    dw_it.bw.ReportProgress(1, "Từ ngày nhỏ hơn đến ngày");
                    return;
                }
                string WeekHoliday = "," + iHRM.Core.Business.Logic.AllLogic.SysPa_Get("WeekHoliday") + ",";
                int rowAffect = 0;
                string msg = "";
                dw_it.bw.ReportProgress(2, "Đang đăng ký..");
                dw_it.bw.ReportProgress(0, _lEmp.Count);
                DateTime d;
                int count = 0;
                foreach (string empID in _lEmp)
                {
                    count++;
                    dw_it.bw.ReportProgress(3, count); //report progress
                    for (int i = 0; i <= count_day; i++)
                    {
                        dw_it.bw.ReportProgress(2, "Đang đăng ký nhân viên " + empID);
                        
                        d = tuNgay.AddDays(i);
                        Core.Business.Base.ExecuteResult ii = null;
                        if (WeekHoliday.IndexOf("," + (int)d.DayOfWeek + ",") >= 0) //nếu vào ngày nghỉ
                        {
                            if (isRegSunday)
                                ii = logic.DangKyCaLam(empID, d, idCaLam, 1, hsLuong);
                        }
                        else
                        {
                            ii = logic.DangKyCaLam(empID, d, idCaLam, null, hsLuong);
                        }

                        if (ii != null)
                        {
                            rowAffect += ii.NumberOfRowAffected < 0 ? 0 : ii.NumberOfRowAffected;
                            //report progress Cho ẩn vì làm máy bị treo
                            //if (!string.IsNullOrWhiteSpace(ii.Message))
                            //{
                            //    string str = string.Format("Ngày {0:dd/MM}: {1}", d, ii.Message);
                            //    msg += str;
                            //    // dw_it.bw.ReportProgress(1, str); //report progress Cho ẩn vì làm máy bị treo
                            //}
                        }
                    }
                }
                dw_it.bw.ReportProgress(2, string.Format("Đăng ký thành công {0} record!", rowAffect)); //report progress  
            };     
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 0)
                {
                    ucProgress1.start(0, Convert.ToInt32(data.UserState.ToString()));
                }
                else if (data.ProgressPercentage == 1)
                {
                    ucProgress1.Message = ucProgress1.Message+"\n" + data.UserState;
                }
                else if (data.ProgressPercentage == 2)
                {
                    ucProgress1.Status = data.UserState.ToString();
                }
                else if (data.ProgressPercentage == 3)
                {
                    ucProgress1.CurrentValue=(int)data.UserState;
                }
            };
            dw_it.OnCompleting = (ps, obj) =>
            {
                btnSave.Enabled = true;
            };
            main.Instance.DoworkItem_Reg(dw_it); //reg and run progress
        }
        private void txtTuNgay_Leave(object sender, EventArgs e)
        {
            txtDenNgay.DateTime = txtTuNgay.DateTime;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ucProgress1.start(1, 100);
        }
        private void bgw_doWork_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        private void bgw_doWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void bgw_doWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
