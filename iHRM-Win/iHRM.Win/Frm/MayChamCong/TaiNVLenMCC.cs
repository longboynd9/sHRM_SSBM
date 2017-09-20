using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iHRM.Core.Business;
using iHRM.Win.Cls;
using zkemkeeper;
using System.Net.NetworkInformation;
using AttMachineCore;
using iHRM.Core.Business.DbObject;
using iHRM.Win.ExtClass;
using AttMachineCore.Model;

namespace iHRM.Win.Frm.MayChamCong
{
    public partial class TaiNVLenMCC : DevExpress.XtraEditors.XtraForm
    {
        public TaiNVLenMCC()
        {
            InitializeComponent();
        }
        AttMachineTools BioMatrix = new AttMachineTools();
        List<tbNhanVien> _lNV = new List<tbNhanVien>();
        List<tbNhanVien> _lNVTaiLen = new List<tbNhanVien>();
        dcDatabaseMCCDataContext db = new dcDatabaseMCCDataContext(Provider.ConnectionString_MCC);
        //Create Standalone SDK class dynamicly.
        private void KhaibaoMCC_Load(object sender, EventArgs e)
        {
            _lNV = db.tbNhanViens.OrderBy(p => p.tenChamCong).ThenBy(p => p.maChamCong).ToList();
            grcNhanVien.DataSource = _lNV;
            lookupMayChamCong.Properties.ValueMember = "id";
            lookupMayChamCong.Properties.DisplayMember = "tenMay";
            lookupMayChamCong.Properties.DataSource = db.tbMayChamCongs.OrderBy(p => p.tenMay).AsEnumerable().ToList<tbMayChamCong>();
            if (db.tbMayChamCongs.Count() > 0)
            {
                lookupMayChamCong.EditValue = db.tbMayChamCongs.OrderBy(p => p.tenMay).First().id;
            }
        }

        #region Action in Form
        private void btnNextAllRight_Click(object sender, EventArgs e)
        {
            _lNVTaiLen.AddRange(_lNV.AsEnumerable());
            _lNV.Clear();
            refreshData();
        }
        private void refreshData()
        {
            grcNhanVien.DataSource = null;
            grcNhanVien.DataSource = _lNV;
            grcNVTaiLen.DataSource = null;
            grcNVTaiLen.DataSource = _lNVTaiLen;
        }

        private void btnNextOneRight_Click(object sender, EventArgs e)
        {
            foreach (int rowhandler in grvNhanVien.GetSelectedRows())
            {
                _lNVTaiLen.Add(grvNhanVien.GetRow(rowhandler) as tbNhanVien);
            }
            foreach (int rowhandler in grvNhanVien.GetSelectedRows().OrderByDescending(p => p))
            {
                _lNV.Remove(grvNhanVien.GetRow(rowhandler) as tbNhanVien);
            }
            refreshData();
        }

        private void btnNextOneLeft_Click(object sender, EventArgs e)
        {
            foreach (int rowhandler in grvNVTaiLen.GetSelectedRows())
            {
                _lNV.Add(grvNVTaiLen.GetRow(rowhandler) as tbNhanVien);
            }
            foreach (int rowhandler in grvNVTaiLen.GetSelectedRows().OrderByDescending(p => p))
            {
                _lNVTaiLen.Remove(grvNVTaiLen.GetRow(rowhandler) as tbNhanVien);
            }
            refreshData();
        }

        private void btnNextAllLeft_Click(object sender, EventArgs e)
        {
            _lNV.AddRange(_lNVTaiLen.AsEnumerable());
            _lNVTaiLen.Clear();
            refreshData();
        }

        private void radioMCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioMCC.SelectedIndex == 0)
            {
                lookupMayChamCong.Enabled = true;
            }
            else
            {
                lookupMayChamCong.Enabled = false;
            }
        }
        #endregion Action in Form
        private void btnTaiLenMCC_Click(object sender, EventArgs e)
        {
            panelControl7.Enabled = false;
            if (!bgrWoker.IsBusy)
                bgrWoker.RunWorkerAsync();
        }
        private bool Connect_MCC(string IP, string Port, string tenMay)
        {
            if (IP.Trim() == "" || Port.Trim() == "")
            {
                bgrWoker.ReportProgress(2, "Máy " + tenMay + " chưa có IP hoặc Port");
                return false;
            }
            bgrWoker.ReportProgress(1, "Kết nối máy " + tenMay + "....");
            bgrWoker.ReportProgress(3, "");
            bgrWoker.ReportProgress(3, "---- Máy chấm công " + tenMay);
            bgrWoker.ReportProgress(2, "");
            bgrWoker.ReportProgress(2, "---- Máy chấm công " + tenMay);
            bool bIsConnected = false;
            bIsConnected = BioMatrix.PingAddress(IP, 3000);
            if (bIsConnected)
            {
                bgrWoker.ReportProgress(3, " Ping thành công máy " + tenMay);
            }
            else
            {
                bgrWoker.ReportProgress(2, " Ping không thành công máy " + tenMay);
                return false;
            }
            bIsConnected = BioMatrix.Connect_Net(IP, Convert.ToInt32(Port));
            if (bIsConnected == true)
            {
                bgrWoker.ReportProgress(3, "Kết nối thành công " + tenMay);
            }
            else
            {
                bgrWoker.ReportProgress(2, " Kết nối không thành công máy " + tenMay);
            }
            return bIsConnected;
        }
        private void btnXoaTrenMCC_Click(object sender, EventArgs e)
        {
            panelControl7.Enabled = false;
            if (!bgr_Xoa.IsBusy)
                bgr_Xoa.RunWorkerAsync();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            db = new dcDatabaseMCCDataContext(Provider.ConnectionString_MCC);
            _lNV.Clear();
            _lNVTaiLen.Clear();
            _lNV = db.tbNhanViens.OrderBy(p => p.tenChamCong).ThenBy(p => p.maChamCong).ToList<tbNhanVien>();

            radioMCC.SelectedIndex = 0;
            lookupMayChamCong.Properties.DataSource = db.tbMayChamCongs.OrderBy(p => p.tenMay).AsEnumerable().ToList<tbMayChamCong>();
            if (db.tbMayChamCongs.Count() > 0)
            {
                lookupMayChamCong.EditValue = db.tbMayChamCongs.OrderBy(p => p.tenMay).First().id;
            }
            refreshData();
        }

        private void bgrWoker_DoWork(object sender, DoWorkEventArgs e)
        {
            taiDuLieuLenMCC();
        }
        private void taiDuLieuLenMCC()
        {
            if (radioMCC.SelectedIndex == 0)// radioMCC.SelectedIndex == 0. Chọn 1 máy chấm công.
            {
                if (Connect_MCC(lookupMayChamCong.GetColumnValue("diaChiIP").ToString(), lookupMayChamCong.GetColumnValue("port").ToString(), lookupMayChamCong.GetColumnValue("tenMay").ToString()))
                {
                    bgrWoker.ReportProgress(1, " Tải nhân viên lên máy " + lookupMayChamCong.GetColumnValue("tenMay") + "....");
                    int count = _lNVTaiLen.Count;
                    progressBar.Properties.Maximum = count;
                    int i = 1;
                    foreach (var item in _lNVTaiLen)
                    {
                       if (BioMatrix.SetCardNumber(item.maThe, item.maChamCong.ToString(), item.tenChamCong, "", item.loaiNhanVien == "3" ? 3 : 0, true))
                            bgrWoker.ReportProgress(3, (" Cập nhật thành công tên, thẻ từ NV " + item.tenChamCong));
                        else
                            bgrWoker.ReportProgress(2, (" Cập nhật không thành công tên, thẻ từ NV " + item.tenChamCong));
                        var nf = db.tbNhanVien_Fingers.Where(p => p.maChamCong == item.maChamCong).ToList();
                        if (nf != null && nf.Count() > 0)
                        {
                            var a = nf.Select(p => new Finger{
                                FingerStr = p.str_Finger,
                                FingerIdx = p.num_Finger
                            }).ToList();
                            if (BioMatrix.setUserTempStr_byLisFinger(item.maChamCong.ToString(), a)) 
                            {
                                bgrWoker.ReportProgress(3, (" Cập nhật thành công vân tay NV " + item.tenChamCong));
                            }
                            else
                            {
                                bgrWoker.ReportProgress(2, (" Cập nhật không thành công vân tay NV " + item.tenChamCong));
                            }
                        }
                        else
                        {
                            if (Interface_Company.useFinger)
                            {
                                bgrWoker.ReportProgress(2, ("NV " + item.tenChamCong + " không có vân tay"));
                            }
                        }
                        db.tbNhanViens.Where(p => p.maChamCong == item.maChamCong).First().trangThai = "Pushed";
                        bgrWoker.ReportProgress(4, i++);
                    }
                }
            }
            else // radioMCC.SelectedIndex == 1. Chọn tất cả các máy chấm công.
            {
                List<tbMayChamCong> a = (List<tbMayChamCong>)lookupMayChamCong.Properties.DataSource;
                foreach (var item2 in a)
                {
                    bgrWoker.ReportProgress(1, " Tải nhân viên lên máy " + item2.tenMay);
                    if (Connect_MCC(item2.diaChiIP, item2.port, item2.tenMay))
                    {
                        int count = _lNVTaiLen.Count;
                        progressBar.Properties.Maximum = count;
                        int i = 1;
                        foreach (var item in _lNVTaiLen)
                        {
                            if (BioMatrix.SetCardNumber(item.maThe, item.maChamCong.ToString(), item.tenChamCong, "", item.loaiNhanVien == "3" ? 3 : 0, true))
                                bgrWoker.ReportProgress(3, (" Cập nhật thành công tên, thẻ từ NV " + item.tenChamCong));
                            else
                                bgrWoker.ReportProgress(2, (" Cập nhật không thành công tên, thẻ từ NV " + item.tenChamCong));
                            var nf = db.tbNhanVien_Fingers.Where(p => p.maChamCong == item.maChamCong).ToList();
                            if (nf != null && nf.Count() > 0)
                            {
                                var a2 = nf.Select(p => new Finger
                                {
                                    FingerStr = p.str_Finger,
                                    FingerIdx = p.num_Finger
                                }).ToList();
                                if (BioMatrix.setUserTempStr_byLisFinger(item.maChamCong.ToString(), a2))
                                {
                                    bgrWoker.ReportProgress(3, (" Cập nhật thành công vân tay NV " + item.tenChamCong));
                                }
                                else
                                {
                                    bgrWoker.ReportProgress(2, (" Cập nhật không thành công NV " + item.tenChamCong));
                                }
                            }
                            else
                            {
                                if (Interface_Company.useFinger)
                                {
                                    bgrWoker.ReportProgress(2, ("NV " + item.tenChamCong + " không có vân tay"));
                                }
                            }
                        }
                    }
                }

            }
            bgrWoker.ReportProgress(1, "Kết thúc");
        }
        private void bgrWoker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1 && e.UserState != null) // 1: Hiển thị process bằng label.
            {
                lbProcess.Text = e.UserState.ToString();
            }
            else if (e.ProgressPercentage == 2 && e.UserState != null) // 2: Nếu lỗi. Lưu vào listBoxError.
            {
                listBoxError.Items.Add(e.UserState.ToString());
            }
            else if (e.ProgressPercentage == 3 && e.UserState != null) // 3: Nếu thành công. Lưu vào listBoxResult.
            {
                listBoxResult.Items.Add(e.UserState.ToString());
            }
            else if (e.ProgressPercentage == 4 && e.UserState != null)
            {
                progressBar.EditValue = Convert.ToInt16(e.UserState);
            }
        }

        private void bgrWoker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panelControl7.Enabled = true;
        }

        private void bgr_Xoa_DoWork(object sender, DoWorkEventArgs e)
        {
            if (radioMCC.SelectedIndex == 0)
            {
                if (Connect_MCC(lookupMayChamCong.GetColumnValue("diaChiIP").ToString(), lookupMayChamCong.GetColumnValue("port").ToString(), lookupMayChamCong.GetColumnValue("tenMay").ToString()))
                {
                    bgrWoker.ReportProgress(1, " Xóa nhân viên ở máy " + lookupMayChamCong.GetColumnValue("tenMay") + "....");
                    progressBar.Properties.Maximum = _lNVTaiLen.Count;
                    int i = 1;
                    foreach (var item in _lNVTaiLen)
                    {
                        if (BioMatrix.DeleteUser(item.maChamCong.ToString()))
                        {
                            bgr_Xoa.ReportProgress(3, " Xóa thành công NV " + item.tenChamCong);
                        }
                        else
                        {
                            bgr_Xoa.ReportProgress(2, " Không xóa được NV " + item.tenChamCong);
                        }
                        bgr_Xoa.ReportProgress(4, i++);
                    }
                }
            }
            else
            {
                List<tbMayChamCong> a = (List<tbMayChamCong>)lookupMayChamCong.Properties.DataSource;
                foreach (var item in a)
                {
                    if (Connect_MCC(item.diaChiIP, item.port, item.tenMay))
                    {
                        bgrWoker.ReportProgress(1, " Xóa nhân viên ở máy " + item.tenMay + "....");
                        int count = _lNVTaiLen.Count;
                        progressBar.Properties.Maximum = count;
                        int i = 1;
                        foreach (var nv in _lNVTaiLen)
                        {
                            if (BioMatrix.DeleteUser(nv.maChamCong.ToString()))
                            {
                                bgr_Xoa.ReportProgress(3, " Xóa thành công NV " + nv.tenChamCong);
                            }
                            else
                            {
                                bgr_Xoa.ReportProgress(2, " Không xóa được NV " + nv.tenChamCong);
                            }
                            bgr_Xoa.ReportProgress(4, i++);
                        }
                    }
                }
            }
            bgr_Xoa.ReportProgress(1, "Kết thúc");
        }

        private void bgr_Xoa_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panelControl7.Enabled = true;
        }

        private void bgr_Xoa_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1 && e.UserState != null) // 1: Hiển thị process bằng label.
            {
                lbProcess.Text = e.UserState.ToString();
            }
            else if (e.ProgressPercentage == 2 && e.UserState != null) // 2: Nếu lỗi. Lưu vào listBoxError.
            {
                listBoxError.Items.Add(e.UserState.ToString());
            }
            else if (e.ProgressPercentage == 3 && e.UserState != null) // 3: Nếu thành công. Lưu vào listBoxResult.
            {
                listBoxResult.Items.Add(e.UserState.ToString());
            }
            else if (e.ProgressPercentage == 4 && e.UserState != null)
            {
                progressBar.EditValue = Convert.ToInt16(e.UserState);
            }
        }
        //#region RealTime Events

        ////When you have enrolled a new user,this event will be triggered.
        //private void axCZKEM1_OnNewUser(int iEnrollNumber)
        //{
        //    lbRTShow.Items.Add("RTEvent OnNewUser Has been Triggered...");
        //    lbRTShow.Items.Add("...NewUserID=" + iEnrollNumber.ToString());
        //}

        ////When you swipe a card to the device, this event will be triggered to show you the number of the card.
        //private void axCZKEM1_OnHIDNum(int iCardNumber)
        //{
        //    lbRTShow.Items.Add("RTEvent OnHIDNum Has been Triggered...");
        //    lbRTShow.Items.Add("...Cardnumber=" + iCardNumber.ToString());
        //}

        ////When you have emptyed the Mifare card,this event will be triggered.
        //private void axCZKEM1_OnEmptyCard(int iActionResult)
        //{
        //    lbRTShow.Items.Add("RTEvent OnEmptyCard Has been Triggered...");
        //    if (iActionResult == 0)
        //    {
        //        lbRTShow.Items.Add("...Empty Mifare Card OK");
        //    }
        //    else
        //    {
        //        lbRTShow.Items.Add("...Empty Failed");
        //    }
        //}

        ////When you have written into the Mifare card ,this event will be triggered.
        //private void axCZKEM1_OnWriteCard(int iEnrollNumber, int iActionResult, int iLength)
        //{
        //    lbRTShow.Items.Add("RTEvent OnWriteCard Has been Triggered...");
        //    if (iActionResult == 0)
        //    {
        //        lbRTShow.Items.Add("...Write Mifare Card OK");
        //        lbRTShow.Items.Add("...EnrollNumber=" + iEnrollNumber.ToString());
        //        lbRTShow.Items.Add("...TmpLength=" + iLength.ToString());
        //    }
        //    else
        //    {
        //        lbRTShow.Items.Add("...Write Failed");
        //    }
        //}

        ////After you swipe your card to the device,this event will be triggered.
        ////If your card passes the verification,the return value  will be user id, or else the value will be -1
        //private void axCZKEM1_OnVerify(int iUserID)
        //{
        //    lbRTShow.Items.Add("RTEvent OnVerify Has been Triggered,Verifying...");
        //    if (iUserID != -1)
        //    {
        //        lbRTShow.Items.Add("Verified OK,the UserID is " + iUserID.ToString());
        //    }
        //    else
        //    {
        //        lbRTShow.Items.Add("Verified Failed... ");
        //    }
        //}

        ////If your card passes the verification,this event will be triggered
        //private void axCZKEM1_OnAttTransactionEx(string sEnrollNumber, int iIsInValid, int iAttState, int iVerifyMethod, int iYear, int iMonth, int iDay, int iHour, int iMinute, int iSecond, int iWorkCode)
        //{
        //    lbRTShow.Items.Add("RTEvent OnAttTrasactionEx Has been Triggered,Verified OK");
        //    lbRTShow.Items.Add("...UserID:" + sEnrollNumber);
        //    lbRTShow.Items.Add("...isInvalid:" + iIsInValid.ToString());
        //    lbRTShow.Items.Add("...attState:" + iAttState.ToString());
        //    lbRTShow.Items.Add("...VerifyMethod:" + iVerifyMethod.ToString());
        //    lbRTShow.Items.Add("...Workcode:" + iWorkCode.ToString());//the difference between the event OnAttTransaction and OnAttTransactionEx
        //    lbRTShow.Items.Add("...Time:" + iYear.ToString() + "-" + iMonth.ToString() + "-" + iDay.ToString() + " " + iHour.ToString() + ":" + iMinute.ToString() + ":" + iSecond.ToString());

        //    string sName = "";
        //    string sPassword = "";
        //    int iPrivilege = 0;
        //    bool bEnabled = false;
        //    string sCardnumber = "";

        //    while (axCZKEM1.SSR_GetUserInfo(iMachineNumber, sEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))//get user information from memory
        //    {
        //        if (axCZKEM1.GetStrCardNumber(out sCardnumber))//get the card number from the memory
        //        {
        //            lbRTShow.Items.Add("...Cardnumber:" + sCardnumber);
        //            return;
        //        }
        //    }
        //}

        ////After function GetRTLog() is called ,RealTime Events will be triggered. 
        ////When you are using these two functions, it will request data from the device forwardly.
        //private void rtTimer_Tick(object sender, EventArgs e)
        //{
        //    if (axCZKEM1.ReadRTLog(iMachineNumber))
        //    {
        //        while (axCZKEM1.GetRTLog(iMachineNumber))
        //        {
        //            ;
        //        }
        //    }
        //}

        //#endregion

    }
}