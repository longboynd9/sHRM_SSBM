using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Configuration;
using System.Xml;
using System.IO;
using System.Net;
using System.Text;
using System.Data;
using System.Linq;
using Ext.Net;
using iHRM.WebPC.Classes;
using System.Data.SqlClient;

namespace iHRM.WebPC.Cpanel.Import
{
    public class importEmployeeHub : Hub
    {
        static bool isPlay = false;
        
        #region cMapping
        public class cMapping
        {
            public string c1 { get; set; }
            public string c1Text { get; set; }
            public string c2 { get; set; }
            public char dataType { get; set; }
        }

        public static List<cMapping> lstEmpMapping = new List<cMapping>()
            {
                new cMapping { c1 = "sID",                  c1Text = "ID",                      dataType = 's' },
                new cMapping { c1 = "sMa",                  c1Text = "Mã NV",                   dataType = 's' },
                new cMapping { c1 = "sHoTen",               c1Text = "Họ và tên",               dataType = 's' },
                new cMapping { c1 = "dNgaySinh",            c1Text = "Ngày sinh",               dataType = 'd' },
                new cMapping { c1 = "iGioiTinh",            c1Text = "Giới tính (Nam/Nữ)",      dataType = 'i' },
                new cMapping { c1 = "sBiDanh",              c1Text = "Bí danh",                 dataType = 's' },
                new cMapping { c1 = "sNguyenQuan",          c1Text = "Nguyên quán",             dataType = 's' },
                new cMapping { c1 = "sThuongTru",           c1Text = "Thường trú",              dataType = 's' },
                new cMapping { c1 = "sTamTru",              c1Text = "Tạm trú",                 dataType = 's' },
                new cMapping { c1 = "sDiDong",              c1Text = "SĐT 2",                   dataType = 's' },
                new cMapping { c1 = "sDienThoai",           c1Text = "Số ĐT",                   dataType = 's' },
                new cMapping { c1 = "sFax",                 c1Text = "Số Fax",                  dataType = 's' },
                new cMapping { c1 = "sEmail",               c1Text = "Email",                   dataType = 's' },
                new cMapping { c1 = "dNgayVao",             c1Text = "Ngày vào",                dataType = 'd' },
                new cMapping { c1 = "dNgayKyHD",            c1Text = "Ngày ký hợp đồng",        dataType = 'd' },
                new cMapping { c1 = "sSoTheDang",           c1Text = "Số thẻ Đảng",             dataType = 's' },
                new cMapping { c1 = "dNgayVaoDang",         c1Text = "Ngày vào Đảng",           dataType = 'd' },
                new cMapping { c1 = "sNoiVaoDang",          c1Text = "Nơi vào Đảng",            dataType = 's' },
                new cMapping { c1 = "sSoTheDoan",           c1Text = "Số thẻ Đoàn",             dataType = 's' },
                new cMapping { c1 = "dNgayVaoDoan",         c1Text = "Ngày vào Đoàn",           dataType = 'd' },
                new cMapping { c1 = "sNoiVaoDoan",          c1Text = "Nơi vào Đoàn",            dataType = 's' },
                new cMapping { c1 = "sMasothue",            c1Text = "Mã số thuế",              dataType = 's' },
                new cMapping { c1 = "sSoTaiKhoan",          c1Text = "Số tài khoản",            dataType = 's' },
                new cMapping { c1 = "sNganHang",            c1Text = "Ngân hàng",               dataType = 's' },
                new cMapping { c1 = "sChiNhanhNN",          c1Text = "Chi nhánh NH",            dataType = 's' },
                new cMapping { c1 = "sNguoiThanLienHe",     c1Text = "Người thân",              dataType = 's' },
                new cMapping { c1 = "sSoDTNguoiThan",       c1Text = "Số ĐT ng thân",           dataType = 's' },
                new cMapping { c1 = "iCMND",                c1Text = "Số CMND",                 dataType = 's' },
                new cMapping { c1 = "sNoiCap",              c1Text = "Nơi cấp CMND",            dataType = 's' },
                new cMapping { c1 = "dNgayCapCMND",         c1Text = "Ngày cấp CMND",           dataType = 'd' },
                new cMapping { c1 = "iSoHoChieu",           c1Text = "Số hộ chiếu",             dataType = 's' },
                new cMapping { c1 = "sNoiCapHC",            c1Text = "Nơi cấp hộ chiếu",        dataType = 's' },
                new cMapping { c1 = "dNgayCapHC",           c1Text = "Ngày cấp hộ chiếu",       dataType = 'd' },
                new cMapping { c1 = "iHesoluong",           c1Text = "Hệ số lương",             dataType = 'f' },
                new cMapping { c1 = "iLuongcoban",          c1Text = "Lương cơ bản",            dataType = 'f' },
                new cMapping { c1 = "sGhiChu",              c1Text = "Ghi chú",                 dataType = 's' },
                new cMapping { c1 = "CardID",               c1Text = "MÃ THẺ QUẸT",             dataType = 's' },
                new cMapping { c1 = "SectionName",          c1Text = "SectionName",             dataType = 's' },
                new cMapping { c1 = "__ChucDanh",           c1Text = "Chức danh",               dataType = 's' },
                new cMapping { c1 = "__DonVi",              c1Text = "Đơn vị",                  dataType = 's' },
                new cMapping { c1 = "__QuocTich",           c1Text = "Quốc tịch",               dataType = 's' }
            };
        #endregion

        public importEmployeeHub()
        {
        }
        
        public void ToClient_Logg(LogItem log)
        {
            Clients.All.broadcastMessage("log", JSON.Serialize(log));
        }
        public void ToClient_Logg(string status, msgStt status_code, string message = "")
        {
            LogItem log = new LogItem()
            {
                id = Guid.NewGuid(),
                message = message,
                status = status,
                status_code = status_code,
                time = DateTime.Now
            };
            Clients.All.broadcastMessage("log", JSON.Serialize(log));
        }
        public void ToClient_SendAction(string action, string data, string data2 = "")
        {
            Clients.All.broadcastMessage(action, data, data2);
        }

        public void SendFromClient(string code, string data)
        {
            try
            {
                switch (code)
                {
                    case "START":
                        RunImport(data);
                        break;
                    case "STOP":
                        isPlay = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                ToClient_SendAction("exec-client-code-false", code, ex.Message);
            }
        }

        List<cMapping> colMapping = new List<cMapping>();

        void RunImport(string code)
        {
            string[] a = code.Split('|');
            string p = HttpContext.Current.Server.MapPath("~/Cpanel/Import/Tempory/" + a[0]);
            if (!File.Exists(p))
            {
                ToClient_Logg("File import not fount", msgStt.danger);
                return;
            }

            DONVIQUANLY_ID = long.Parse(a[1]);

            foreach (string s in a[2].Split(','))
            {
                if (string.IsNullOrWhiteSpace(s))
                    continue;

                int i = s.IndexOf(':');
                if (i == -1)
                    continue;

                var m = lstEmpMapping.SingleOrDefault(it => it.c1 == s.Substring(0, i));
                if (m != null)
                    colMapping.Add(new cMapping() { c1 = m.c1, dataType = m.dataType, c2 = s.Substring(i + 1) });
            }

            //ImportBase importer = null;
            //if (a.Length > 1)
            //{
            //    Type t = Type.GetType("iHRM.WebPC.Cpanel.Import." + a[1]);
            //    importer = Activator.CreateInstance(t) as ImportBase;
            //}

            ExcelExtend excel = new ExcelExtend();
            excel.OpenFile(p);
            var dt = excel.GetAllAvalidData();
            ToClient_Logg("START import", msgStt.info);
            ToClient_SendAction("start-import", dt.Rows.Count.ToString());

            isPlay = true;
            try
            {
                int idx = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    ToClient_Logg(DoImport(dr));
                    idx += 1;
                    ToClient_SendAction("import-prg", idx.ToString());

                    if (!isPlay)
                    {
                        ToClient_Logg("STOP import", msgStt.info);
                        break;
                    }
                }

                ToClient_Logg("Import complete", msgStt.info);
            }
            catch (Exception ex)
            {
                ToClient_Logg("Import fail", msgStt.warning, ex.Message);
            }
        }

        public LogItem DoImport(System.Data.DataRow dr)
        {
            LogItem li = new LogItem();
            try
            {
                var pa = new SqlParameter[colMapping.Count];
                for (int i = 0; i < colMapping.Count; i++)
                {
                    pa[i] = new SqlParameter();
                    pa[i].ParameterName = colMapping[i].c1;

                    if (colMapping[i].c1 == "iGioiTinh")
                    {
                        pa[i].Value = ImportHelper.MakeSureString(dr[colMapping[i].c2]).ToLower() == "nam" ? 1 : 0;
                    }
                    else
                    {
                        switch (colMapping[i].dataType)
                        {
                            case 's':
                                pa[i].Value = ImportHelper.MakeSureString(dr[colMapping[i].c2]);
                                break;
                            case 'i':
                                pa[i].Value = ImportHelper.MakeSureInt(dr[colMapping[i].c2]);
                                break;
                            case 'd':
                                pa[i].Value = ImportHelper.MakeSureDate(dr[colMapping[i].c2]);
                                break;
                            case 'f':
                                pa[i].Value = ImportHelper.MakeSureFloat(dr[colMapping[i].c2]);
                                break;
                            default:
                                pa[i].Value = dr[colMapping[i].c2];
                                break;
                        }
                    }
                }

                var ret = iHRM.WebPC.Business.Provider.ExecuteNonQuery("p_Employee_Import_Excel_sHRM_AllColumn", pa);

                if (ret.ReturnValue == 1)
                {
                    li.status = "Done";
                    li.message = "";
                    li.status_code = msgStt.success;
                }
                else
                {
                    li.status = "Fail";
                    if (ret.ReturnValue == -1)
                        li.message = "NV đã tồn tại";
                    li.status_code = msgStt.warning;
                }
            }
            catch (Exception ex)
            {
                li.status = "Exception thorw";
                li.message = ex.Message;
                li.status_code = msgStt.danger;
            }

            li.id = Guid.NewGuid();
            li.time = DateTime.Now;
            return li;
        }
    }
}