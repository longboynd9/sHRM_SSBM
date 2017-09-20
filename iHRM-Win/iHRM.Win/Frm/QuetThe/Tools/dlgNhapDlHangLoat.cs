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
using System.Threading;
using System.Windows.Forms;

namespace iHRM.Win.Frm.QuetThe.Tools
{
    public partial class dlgNhapDlHangLoat : dlgCustomBase
    {
        global::iHRM.Core.Business.Logic.Employee.Emp logic_Emp = new global::iHRM.Core.Business.Logic.Employee.Emp();
        //Common.dlgChonDoiTuong chonDT = new Common.dlgChonDoiTuong();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

        public dlgNhapDlHangLoat()
        {
            InitializeComponent();
        }
        private void dlgDangKyCaLam_Load(object sender, EventArgs e)
        {
            txtTuNgay.EditValue = txtDenNgay.EditValue = DateTime.Today;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region check control avalid
            var lNv = ucChonDoiTuong_DS1.GetValue().ToList();
            if (lNv.Count == 0)
            {
                MessageBox.Show("Chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
            ucProgress1.start(1, lNv.Count);
            #endregion
            mainBase.Dowork_Item dw = new mainBase.Dowork_Item();
            btnSave.Enabled = false;
            dw.OnDoing = (s, ev) =>
            {
                int idx = 0;
                TimeSpan TuGio = txtTuGio_Start.TimeSpan;
                TimeSpan DenGio = txtDenGio_Start.TimeSpan;

                foreach (var item in lNv)
                {
                    TuGio = GetRandomTime(txtTuGio_Start.TimeSpan, txtTuGio_End.TimeSpan);
                    DenGio = GetRandomTime(txtDenGio_Start.TimeSpan, txtDenGio_End.TimeSpan);
                    Thread.Sleep(7);
                    dw.bw.ReportProgress(1, "Đăng ký cho nhân viên " + item);
                    for (DateTime i = txtTuNgay.DateTime.Date; i <= txtDenNgay.DateTime.Date;)
                    {
                        var a = db.tbKetQuaQuetThes.Where(p => p.EmployeeID == item && p.ngay == i);
                        if (a.Count() > 0)
                        {
                            Guid id = a.First().id;
                            iHRM.Win.ExtClass.QuetThe.QuetThe.SetTimeQT(id, TuGio, DenGio, false, force: true, userLoginin: LoginHelper.user);
                            i = i.AddDays(1);
                        }
                        else
                        {
                            dw.bw.ReportProgress(2, "Chưa đăng ký ca làm cho nhân viên " + item + " ngày " + i.ToShortDateString());
                        }
                    }
                    dw.bw.ReportProgress(2, "Đăng ký thành công nhân viên " + item);
                    idx++;
                    dw.bw.ReportProgress(3, idx);
                }
                dw.bw.ReportProgress(1, "Đăng ký thành công!");
                dw.bw.ReportProgress(2, "Đăng ký hoàn tất!");
                //pi.SetProgressStatus(mainBase.DoProgress_status.complete);
            };
            dw.OnProcessing = (ps, obj) =>
            {
                if (obj.ProgressPercentage == 1)
                {
                    ucProgress1.Status = obj.UserState.ToString();
                }
                else if (obj.ProgressPercentage == 2)
                {
                    ucProgress1.Message = ucProgress1.Message + "\r\n" + obj.UserState.ToString();
                }
                else if (obj.ProgressPercentage == 3)
                {
                    ucProgress1.CurrentValue = Convert.ToInt16(obj.UserState);
                }
            };
            btnSave.Enabled = true;
            main.Instance.DoworkItem_Reg(dw); //reg and run progress
        }

        TimeSpan GetRandomTime(TimeSpan tugio, TimeSpan dengio)
        {
            TimeSpan tgRandom = tugio;
            Random rand = new Random();
            int minuteDistance = (dengio - tugio).Minutes;
            int minuteRand = rand.Next(1, minuteDistance);
            int hour = minuteRand / 60;
            int minute = minuteRand - hour * 60;

            tgRandom = tgRandom.Add(new TimeSpan(hour, minute, 0));
            return tgRandom;
        }

        //int regNV(string maNV, DateTime ngay1, DateTime denNgay, TimeSpan tugio, TimeSpan dengio, bool OnlyNoData)
        //{
        //    var nv = db.tblEmployees.SingleOrDefault(p => p.EmployeeID == maNV);
        //    if (nv == null)
        //    {
        //        pi.OutProgressMessage("Không tìm thấy nhân viên [" + maNV + "]!");
        //        return 0;
        //    }

        //    int day = Convert.ToInt32((denNgay - ngay1).TotalDays);
        //    int totalRecord = 0;

        //    //đăng ký từng ngày
        //    for (int i = 0; i <= day; i++)
        //    {
        //        DateTime ngay = ngay1.AddDays(i);

        //        try
        //        {
        //            var ketQuaQT = db.tbKetQuaQuetThes.SingleOrDefault(p => p.EmployeeID == maNV && p.ngay == ngay);
        //            if (ketQuaQT != null) // Nếu đã đăng ký ca làm
        //            {
        //                totalRecord += iHRM.Win.ExtClass.QuetThe.QuetThe.SetTimeQT(ketQuaQT.id, tugio, dengio, OnlyNoData, userLoginin: LoginHelper.user);
        //                Thread.Sleep(3);
        //            }
        //            else
        //            {
        //                pi.OutProgressMessage(string.Format("Ngày {0:dd/MM/yyyy} Chưa đăng ký ca làm! cho nhân viên {1}", ngay, maNV));
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            pi.OutProgressMessage(string.Format("emp [{1}] date {1:dd/MM/yyyy} error: {2}", maNV, ngay, ex.Message));
        //            return -1;
        //        }
        //    }

        //    //pi.OutProgressMessage(Lng.QuetThe_DKVangMat.msg_2 + " (" + totalRecord + ")");
        //    return totalRecord;
        //}

        private void dlgDangKyCaLam_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }
    }
}
