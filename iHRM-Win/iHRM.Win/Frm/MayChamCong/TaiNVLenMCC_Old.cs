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
using iHRM.Core.Business.DbObject;

namespace iHRM.Win.Frm.MayChamCong
{
    public partial class TaiNVLenMCC_Old : DevExpress.XtraEditors.XtraForm
    {
        public TaiNVLenMCC_Old()
        {
            InitializeComponent();
        }
        List<tbNhanVien> _lNV = new List<tbNhanVien>();
        List<tbNhanVien> _lNVTaiLen = new List<tbNhanVien>();
        dcDatabaseMCCDataContext db = new dcDatabaseMCCDataContext(Provider.ConnectionString_MCC);
        //Create Standalone SDK class dynamicly.
        public zkemkeeper.CZKEMClass axCZKEM1;
        int iMachineNumber = 1;
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
        private bool pingAddress(string IP, int miliSecond)
        {
            Ping ping = new Ping();
            if (ping.Send(IP, miliSecond).Status == IPStatus.Success)
                return true;
            else
                return false;
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
            int idwErrorCode = 0;
            bool bIsConnected = false;
            bIsConnected = pingAddress(IP, 3000);
            if (bIsConnected)
            {
                bgrWoker.ReportProgress(3, " Ping thành công máy " + tenMay);
            }
            else
            {
                bgrWoker.ReportProgress(2, " Ping không thành công máy " + tenMay);
                return false;
            }
            bIsConnected = axCZKEM1.Connect_Net(IP, Convert.ToInt32(Port));
            if (bIsConnected == true)
            {
                bgrWoker.ReportProgress(3, "Kết nối thành công " + tenMay);
                iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                axCZKEM1.RegEvent(iMachineNumber, 65535);
                //if (axCZKEM1.RegEvent(iMachineNumber, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                //{
                //    this.axCZKEM1.OnVerify += new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);
                //    this.axCZKEM1.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
                //    this.axCZKEM1.OnNewUser += new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
                //    this.axCZKEM1.OnHIDNum += new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
                //    this.axCZKEM1.OnWriteCard += new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(axCZKEM1_OnWriteCard);
                //    this.axCZKEM1.OnEmptyCard += new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(axCZKEM1_OnEmptyCard);
                //}
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
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
        private void deleteUser(long sdwEnrollNumber, string usname)
        {
            int idwErrorCode = 0;
            //axCZKEM1.EnableDevice(iMachineNumber, false);
            //12: device deletes the user (include all fingerprints, cardnumber, password and password of user).
            if (axCZKEM1.SSR_DeleteEnrollDataExt(iMachineNumber, sdwEnrollNumber.ToString(), 12))
            {
                bgr_Xoa.ReportProgress(3," Xóa thành công NV " + usname);
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                bgr_Xoa.ReportProgress(2, " Không xóa được NV " + usname);
            }
            axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
            axCZKEM1.EnableDevice(iMachineNumber, true);
        }
        // Tải nhân viên lên máy chấm công
        //Upload the cardnumber as part of the user information.
        private void setCardNumber(string sCardnumber, string sdwEnrollNumber, string sName, string sPassword, int iPrivilege, bool bEnabled)
        {
            int idwErrorCode = 0;

            axCZKEM1.EnableDevice(iMachineNumber, false);
            axCZKEM1.SetStrCardNumber(sCardnumber);//Before you using function SetUserInfo,set the card number to make sure you can upload it to the device
            if (axCZKEM1.SSR_SetUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled))//upload the user's information(card number included)
            {
                bgrWoker.ReportProgress(3, (" Cập nhật thành công NV " + sName));
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                bgrWoker.ReportProgress(2, (" Cập nhật không thành công NV " + sName));
            }
            axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
            axCZKEM1.EnableDevice(iMachineNumber, true);
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
            axCZKEM1 = new zkemkeeper.CZKEMClass();
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
                        setCardNumber(item.maThe, item.maChamCong.ToString(), item.tenChamCong, "", item.loaiNhanVien == "3" ? 3 : 0, true);
                        db.tbNhanViens.Where(p => p.maChamCong == item.maChamCong).First().trangThai = "Pushed";
                        bgrWoker.ReportProgress(4, i++);
                    }
                }
            }
            else // radioMCC.SelectedIndex == 1. Chọn tất cả các máy chấm công.
            {
                List<tbMayChamCong> a = (List<tbMayChamCong>)lookupMayChamCong.Properties.DataSource;
                foreach (var item in a)
                {
                    bgrWoker.ReportProgress(1, " Tải nhân viên lên máy " + item.tenMay);
                    if (Connect_MCC(item.diaChiIP, item.port, item.tenMay))
                    {
                        int count = _lNVTaiLen.Count;
                        progressBar.Properties.Maximum = count;
                        int i = 1;
                        foreach (var nv in _lNVTaiLen)
                        {
                            //0 : common user, 1:enroller, 2: Administrator, 3: Super administrator.
                            setCardNumber(nv.maThe, nv.maChamCong.ToString(), nv.tenChamCong, "", nv.loaiNhanVien == "3" ? 3 : 0, true);
                            db.tbNhanViens.Where(p => p.maChamCong == nv.maChamCong).First().trangThai = "Pushed";
                            bgrWoker.ReportProgress(4, i++);
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
            axCZKEM1 = new zkemkeeper.CZKEMClass();
            if (radioMCC.SelectedIndex == 0)
            {
                if (Connect_MCC(lookupMayChamCong.GetColumnValue("diaChiIP").ToString(), lookupMayChamCong.GetColumnValue("port").ToString(), lookupMayChamCong.GetColumnValue("tenMay").ToString()))
                {
                    bgrWoker.ReportProgress(1, " Xóa nhân viên ở máy " + lookupMayChamCong.GetColumnValue("tenMay") + "....");
                    progressBar.Properties.Maximum = _lNVTaiLen.Count;
                    int i = 1;
                    foreach (var item in _lNVTaiLen)
                    {
                        deleteUser(item.maChamCong, item.tenChamCong);
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
                            deleteUser(nv.maChamCong, nv.tenChamCong);
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