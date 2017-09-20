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
using System.Threading;
using System.Net.NetworkInformation;
using iHRM.Core.Business.DbObject;

namespace iHRM.Win.Frm.MayChamCong
{
    public partial class TaiDuLieuMayChamCong_Old : DevExpress.XtraEditors.XtraForm
    {
        public TaiDuLieuMayChamCong_Old()
        {
            InitializeComponent();
        }
        zkemkeeper.CZKEMClass axCZKEM1;
        dcDatabaseMCCDataContext db = new dcDatabaseMCCDataContext(Provider.ConnectionString_MCC);
        int iMachineNumber = 1;
        List<tbNhanVien> _lTTNV = new List<tbNhanVien>();
        List<tbCheckInOut> _lTAttendance = new List<tbCheckInOut>();

        private void KhaibaoMCC_Load(object sender, EventArgs e)
        {
            //groupDuLieuQuetThe.Width = this.Width / 2;
            dateTuNgay.DateTime = dateDenNgay.DateTime = DateTime.Now;
            lookupMayChamCong.Properties.ValueMember = "id";
            lookupMayChamCong.Properties.DisplayMember = "tenMay";
            lookupMayChamCong.Properties.DataSource = db.tbMayChamCongs.OrderBy(p => p.tenMay).AsEnumerable().ToList<tbMayChamCong>();
            if (db.tbMayChamCongs.Count() > 0)
            {
                lookupMayChamCong.EditValue = db.tbMayChamCongs.OrderBy(p => p.tenMay).First().id;
            }
        }
        private bool pingAddress(string IP, int miliSecond)
        {
            Ping ping = new Ping();
            if (ping.Send(IP, miliSecond).Status == IPStatus.Success)
                return true;
            else
                return false;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (!bgr_Download.IsBusy)
                bgr_Download.RunWorkerAsync();
        }

        private void SaveDataToDataBase()
        {
            try
            {
                if (chkLuu.Checked)
                {
                    bgr_Download.ReportProgress(1, " Lưu dữ liệu quẹt thẻ vào database....");
                    foreach (tbCheckInOut item in _lTAttendance)
                    {
                        if (db.tbCheckInOuts.Where(p => p.tgQuet == item.tgQuet && p.maChamCong == item.maChamCong).Count() == 0)
                        {
                            db.tbCheckInOuts.InsertOnSubmit(item);
                        }
                    }
                    db.SubmitChanges();
                    bgr_Download.ReportProgress(3, " Lưu dữ liệu quẹt thẻ vào database thành công.");
                }


            }
            catch (Exception ex)
            {
                bgr_Download.ReportProgress(2, " Lưu dữ liệu quẹt thẻ không thành công.");
            }
        }
        private object downDuLieuQuetThe()
        {
            //Tạo class của kết nối máy CC
            axCZKEM1 = new zkemkeeper.CZKEMClass();
            string sdwEnrollNumber = "";
            int soMay = 0;
            if (radioMCC.SelectedIndex == 0)// radioMCC.SelectedIndex == 0. Chọn 1 máy chấm công.
            {
                if (Connect_MCC(lookupMayChamCong.GetColumnValue("diaChiIP").ToString(), lookupMayChamCong.GetColumnValue("port").ToString(), lookupMayChamCong.GetColumnValue("tenMay").ToString()))
                {
                    int idwVerifyMode = 0;
                    int idwInOutMode = 0;
                    int idwYear = 0;
                    int idwMonth = 0;
                    int idwDay = 0;
                    int idwHour = 0;
                    int idwMinute = 0;
                    int idwSecond = 0;
                    int idwWorkcode = 0;
                    soMay = Convert.ToInt16(lookupMayChamCong.GetColumnValue("soMay"));

                    DateTime tuNgay = new DateTime(dateTuNgay.DateTime.Year, dateTuNgay.DateTime.Month, dateTuNgay.DateTime.Day, 0, 0, 0);
                    DateTime denNgay = new DateTime(dateDenNgay.DateTime.Year, dateDenNgay.DateTime.Month, dateDenNgay.DateTime.Day, 23, 59, 59);

                    axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device
                    //if (axCZKEM1.ReadGeneralLogData(iMachineNumber))//read all the attendance records to the memory
                    //{
                    bgr_Download.ReportProgress(1, "Bắt đầu tải dữ liệu quẹt thẻ....");
                    while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
                               out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                    {

                        DateTime tgQuet = new DateTime(idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond);
                        if (tuNgay <= tgQuet && tgQuet <= denNgay)
                        {
                            _lTAttendance.Add(new tbCheckInOut
                            {
                                maChamCong = sdwEnrollNumber,
                                soMay = soMay,
                                tgQuet = tgQuet,
                                ngayQuet = tgQuet.Date
                            });
                        }
                    }
                    bgr_Download.ReportProgress(3, "Tải thành công " + _lTAttendance.Count + " record.");
                    //}
                    //else
                    //{
                    //    listBoxError.Items.Add("*LỖI: Không lấy được dữ liệu");
                    //}
                    //axCZKEM1.ClearGLog(iMachineNumber);
                    axCZKEM1.EnableDevice(iMachineNumber, true);
                }
            }
            else // radioMCC.SelectedIndex == 1. Chọn tất cả các máy chấm công.
            {
                List<tbMayChamCong> a = (List<tbMayChamCong>)lookupMayChamCong.Properties.DataSource;
                int idwVerifyMode = 0;
                int idwInOutMode = 0;
                int idwYear = 0;
                int idwMonth = 0;
                int idwDay = 0;
                int idwHour = 0;
                int idwMinute = 0;
                int idwSecond = 0;
                int idwWorkcode = 0;
                DateTime tuNgay = new DateTime(dateTuNgay.DateTime.Year, dateTuNgay.DateTime.Month, dateTuNgay.DateTime.Day, 0, 0, 0);
                DateTime denNgay = new DateTime(dateDenNgay.DateTime.Year, dateDenNgay.DateTime.Month, dateDenNgay.DateTime.Day, 23, 59, 59);

                soMay = Convert.ToInt16(lookupMayChamCong.GetColumnValue("soMay"));

                foreach (var item in a)
                {
                    int count = _lTAttendance.Count;
                    if (Connect_MCC(item.diaChiIP, item.port, item.tenMay))
                    {
                        soMay = item.soMay;
                        axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device

                        //if (axCZKEM1.ReadGeneralLogData(iMachineNumber))//read all the attendance records to the memory
                        //{
                        bgr_Download.ReportProgress(1, "Bắt đầu tải dữ liệu quẹt thẻ....");
                        // Đây là hàm lấy dữ liệu quẹt thẻ SSR_GetGeneralLogData. K còn hàm khác lấy theo điều kiện. E tìm mãi rồi
                        while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
                                   out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                        {
                            DateTime tgQuet = new DateTime(idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond);
                            // Hàm này nó lấy tất cả dữ liệu..Mình phải lọc ra để lấy dữ liệu theo điều kiện của mình..
                            if (tuNgay <= tgQuet && tgQuet <= denNgay)
                            {
                                _lTAttendance.Add(new tbCheckInOut
                                {
                                    maChamCong = sdwEnrollNumber,
                                    soMay = soMay,
                                    tgQuet = tgQuet,
                                    ngayQuet = tgQuet.Date
                                });
                            }
                        }
                        bgr_Download.ReportProgress(3, "Tải thành công " + (_lTAttendance.Count - count) + " record.");
                        //}
                        //else
                        //{
                        //    listBoxError.Items.Add("*LỖI: Không lấy được dữ liệu");
                        //}
                        //axCZKEM1.ClearGLog(iMachineNumber);
                        axCZKEM1.EnableDevice(iMachineNumber, true);// Enable máy chấm công lên
                    }
                }
            }
            //grcQuetThe.DataSource = null;
            //grcQuetThe.DataSource = _lTAttendance;
            ////grcTTNV.DataSource = _lTTNV;


            return _lTAttendance;
        }
        //void checkConnection(string IP, string Port)
        //{
        //   axCZKEM1.Connect_Net(IP, Convert.ToInt32(Port));
        //}
        //void LongRunningMethod(object monitorSync)
        //{
        //    //do stuff    
        //    lock (monitorSync)
        //    {
        //        Monitor.Pulse(monitorSync);
        //    }
        //}

        //void ImpatientMethod()
        //{
        //    Action<object> longMethod = LongRunningMethod;
        //    object monitorSync = new object();
        //    bool timedOut;
        //    lock (monitorSync)
        //    {
        //        longMethod.BeginInvoke(monitorSync, null, null);
        //        timedOut = !Monitor.Wait(monitorSync, TimeSpan.FromSeconds(30)); // waiting 30 secs
        //    }
        //    if (timedOut)
        //    {
        //        // it timed out.
        //    }
        //}
        private object downThongTinNV()
        {
            axCZKEM1 = new zkemkeeper.CZKEMClass();
            string sdwEnrollNumber = "";
            string sName = "";
            string sPassword = "";
            int iPrivilege = 0;
            bool bEnabled = false;
            string cardNumber = "";

            if (radioMCC.SelectedIndex == 0)// radioMCC.SelectedIndex == 0. Chọn 1 máy chấm công.
            {
                if (Connect_MCC(lookupMayChamCong.GetColumnValue("diaChiIP").ToString(), lookupMayChamCong.GetColumnValue("port").ToString(), lookupMayChamCong.GetColumnValue("tenMay").ToString()))
                {
                    axCZKEM1.EnableDevice(iMachineNumber, false);

                    axCZKEM1.ReadAllUserID(iMachineNumber);//read all the user information to the memory
                    //axCZKEM1.ReadAllTemplate(1);//read all the users' fingerprint templates to the memory
                    bgr_Download.ReportProgress(1, "Bắt đầu tải dữ liệu nhân viên....");
                    while (axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))//get all the users' information from the memory
                    {
                        axCZKEM1.GetStrCardNumber(out cardNumber);
                        _lTTNV.Add(new tbNhanVien { maChamCong = Convert.ToInt64(sdwEnrollNumber), tenChamCong = sName, maThe = cardNumber });
                    }
                    bgr_Download.ReportProgress(3, " Tải thành công " + _lTTNV.Count + " nhân viên.");
                    axCZKEM1.EnableDevice(iMachineNumber, true);
                }
            }
            else // radioMCC.SelectedIndex == 1. Chọn tất cả các máy chấm công.
            {
                List<tbMayChamCong> a = (List<tbMayChamCong>)lookupMayChamCong.Properties.DataSource;
                foreach (var item in a)
                {
                    int count = _lTTNV.Count;
                    if (Connect_MCC(item.diaChiIP, item.port, item.tenMay))
                    {
                        axCZKEM1.EnableDevice(iMachineNumber, false);

                        axCZKEM1.ReadAllUserID(iMachineNumber);//read all the user information to the memory
                        //axCZKEM1.ReadAllTemplate(1);//read all the users' fingerprint templates to the memory
                        bgr_Download.ReportProgress(1, "Bắt đầu tải dữ liệu nhân viên....");
                        while (axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))//get all the users' information from the memory
                        {
                            axCZKEM1.GetStrCardNumber(out cardNumber);
                            _lTTNV.Add(new tbNhanVien { maChamCong = Convert.ToInt64(sdwEnrollNumber), tenChamCong = sName, maThe = cardNumber });
                        }
                        bgr_Download.ReportProgress(3, " Tải thành công " + (_lTTNV.Count - count) + " nhân viên.");
                        axCZKEM1.EnableDevice(iMachineNumber, true);
                    }
                }
            }
            return _lTTNV;
        }
        private bool Connect_MCC(string IP, string Port, string tenMay)
        {
            if (IP.Trim() == "" || Port.Trim() == "")
            {
                bgr_Download.ReportProgress(2, "Máy " + tenMay + " chưa có IP hoặc Port");
                return false;
            }
            bgr_Download.ReportProgress(3, "");
            bgr_Download.ReportProgress(3, "---- Máy chấm công" + tenMay);
            bgr_Download.ReportProgress(2, "");
            bgr_Download.ReportProgress(2, "---- Máy chấm công" + tenMay);
            bgr_Download.ReportProgress(1, "Ping máy " + tenMay + " ...");
            int idwErrorCode = 0;
            bool bIsConnected = false;
            if (pingAddress(IP, 3000))
            {
                bIsConnected = true;
                bgr_Download.ReportProgress(3, " Ping thành công máy " + tenMay);
            }
            else
            {
                bgr_Download.ReportProgress(2, " Không ping được máy " + tenMay);
                return false;
            }

            bIsConnected = axCZKEM1.Connect_Net(IP, Convert.ToInt32(Port));
            if (bIsConnected == true)
            {
                bgr_Download.ReportProgress(3, " Kết nối thành công máy " + tenMay);
                iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                //axCZKEM1.RegEvent(iMachineNumber, 65535);
                //if (axCZKEM1.RegEvent(iMachineNumber, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                //{
                //this.axCZKEM1.OnVerify += new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);
                //this.axCZKEM1.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
                //this.axCZKEM1.OnNewUser += new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
                //this.axCZKEM1.OnHIDNum += new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
                //this.axCZKEM1.OnWriteCard += new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(axCZKEM1_OnWriteCard);
                //this.axCZKEM1.OnEmptyCard += new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(axCZKEM1_OnEmptyCard);
                //}
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                bgr_Download.ReportProgress(2, " Không thể kết nối máy " + tenMay);
            }
            return bIsConnected;
        }

        private void radioMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioMethod.SelectedIndex == 1)
            {
                radioMCC.SelectedIndex = 0;
                dateDenNgay.Enabled = dateTuNgay.Enabled = false;
            }
            else
            {
                dateDenNgay.Enabled = dateTuNgay.Enabled = true;
            }

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

        private void bgr_Download_DoWork(object sender, DoWorkEventArgs e)
        {
            // Bấm click download
            progressBar.Properties.Paused = false;
            if (radioMethod.SelectedIndex == 0) // Tải dữ liệu quẹt trên máy
            {
                _lTAttendance.Clear();
                var d = downDuLieuQuetThe();
                bgr_Download.ReportProgress(4, d);

                SaveDataToDataBase();
                bgr_Download.ReportProgress(1, "Kết thúc!");
            }
            else // Tải dữ liệu thông tin nhân viên trên máy
            {
                _lTTNV.Clear();
                var a = downThongTinNV();
                bgr_Download.ReportProgress(5, a);
            }
        }

        private void bgr_Download_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1) // 1: Hiển thị process bằng label.
            {
                lbProcess.Text = e.UserState.ToString();
            }
            else if (e.ProgressPercentage == 2) // 2: Nếu lỗi. Lưu vào listBoxError.
            {
                listBoxError.Items.Add(e.UserState.ToString());
            }
            else if (e.ProgressPercentage == 3) // 3: Nếu thành công. Lưu vào listBoxResult.
            {
                listBoxResult.Items.Add(e.UserState.ToString());
            }
            else if (e.ProgressPercentage == 4) // 3: Nếu thành công. Lưu vào listBoxResult.
            {
                grcQuetThe.DataSource = null;
                grcQuetThe.DataSource = e.UserState;
            }
            else if (true)
            {
                grcTTNV.DataSource = null;
                grcTTNV.DataSource = e.UserState;
            }

        }

        private void bgr_Download_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panelControl7.Enabled = true;
            progressBar.Properties.Paused = true;
        }

    }
}