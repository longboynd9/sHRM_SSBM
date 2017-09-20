using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Controller.Report
{
    public class GetData
    {
        global::iHRM.Core.Business.Logic.Report.BaoCao logic = new global::iHRM.Core.Business.Logic.Report.BaoCao();
        public DataTable getDataReportChamCong(string EmpID, string DepID, DateTime TuNgay, DateTime DenNgay)
        {
            //DateTime day;
            //DateTime today;
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("EmployeeID",typeof(string)),
                new DataColumn("AppliedDate",typeof(DateTime)),
                new DataColumn("IDCard",typeof(string)),
                new DataColumn("tenNV",typeof(string)),
                new DataColumn("DepName",typeof(string)),
                new DataColumn("NgayCong",typeof(double) ),
                new DataColumn("NghiLe",typeof(double) ),
                new DataColumn("NghiPhepNam",typeof(double)),
                new DataColumn("NghiCoLuong",typeof(double)),
                new DataColumn("NghiKhongLuong",typeof(double)),
                new DataColumn("TangCa",typeof(double)),
                new DataColumn("ChuNhat",typeof(double)),
                new DataColumn("DNgayCong",typeof(double)),
                new DataColumn("DTangCa",typeof(double)),
                new DataColumn("DChuNhat",typeof(double)),
                new DataColumn("TangCaLe",typeof(double)),
                new DataColumn("NghiKhongPhep",typeof(double))
            });
            var data = new DataTable();
            data = logic.GetReportMonth(TuNgay, DenNgay, EmpID, DepID);
            foreach (DataRow dr in data.Rows)
            {
                DataRow r = null;
                var r1 = dt.Select("EmployeeID=" + dr["EmployeeID"]);
                if (r1 == null || r1.Length == 0)
                {
                    r = dt.NewRow();
                    r["EmployeeID"] = dr["EmployeeID"];
                    r["tenNV"] = dr["EmployeeName"];
                    r["AppliedDate"] = dr["AppliedDate"];
                    r["IDCard"] = dr["IDCard"];
                    r["DepName"] = dr["DepName"];
                    if (!Convert.ToBoolean(dr["tt_chuNhat"]))
                    {
                        r["TangCa"] = dr["tgTinhTangCa"];
                    }
                    else
                    {
                        r["TangCa"] = "0";
                    }
                    if (dr["tt_ok"].ToString() != "0" && dr["tt_leTet"].ToString() == "0" && dr["tt_chuNhat"].ToString() == "0")
                    {
                        if (!DBNull.Value.Equals(dr["kqNgayCong"]))
                        {
                            if (dr["kqNgayCong"].ToString() != "")
                            {
                                r["NgayCong"] = Convert.ToDouble(dr["kqNgayCong"].ToString());
                            }
                            else
                            {
                                r["NgayCong"] = 0;
                            }
                        }
                        else
                        {
                            r["NgayCong"] = "0";
                        }
                    }
                    else
                    {
                        r["NgayCong"] = "0";
                    }
                    if (Convert.ToBoolean(dr["tt_chuNhat"]))
                    {
                        r["ChuNhat"] = Convert.ToDouble(dr["kqNgayCong"].ToString() != "" ? dr["kqNgayCong"].ToString() : "0") + Convert.ToDouble(dr["tgTinhTangCa"].ToString() != "" ? dr["tgTinhTangCa"].ToString() : "0");
                    }
                    else
                    {
                        r["ChuNhat"] = "0";
                    }

                    if (dr["tt_leTet"].ToString() != "0")
                    {
                        r["NghiLe"] = "1";
                    }
                    else
                    {
                        r["NghiLe"] = "0";
                    }
                    // Nghỉ không phép
                    if (dr["tt_nghiPhep_Alias"].ToString() == "KP")
                    {
                        r["NghiKhongPhep"] = "1";
                    }
                    else
                    {
                        r["NghiKhongPhep"] = "0";
                    }
                    // Làm lễ tết
                    if (dr["tt_leTet"].ToString() == "1" && dr["kqNgayCong"].ToString() != "0")
                    {
                        r["TangCaLe"] = Convert.ToDouble(dr["kqNgayCong"].ToString()) / 3 * 8;
                    }
                    else
                    {
                        r["TangCaLe"] = "0";
                    }
                    if (dr["coHuongLuong"].ToString() == "1" && dr["tt_nghiPhep_Alias"].ToString() != "AL")
                    {
                        r["NghiCoLuong"] = "1";
                    }
                    else
                    {
                        r["NghiCoLuong"] = "0";
                    }
                    if (dr["coHuongLuong"].ToString() == "1" && dr["tt_nghiPhep_Alias"].ToString() == "AL")
                    {
                        r["NghiPhepNam"] = "1";
                    }
                    else
                    {
                        r["NghiPhepNam"] = "0";
                    }
                    if (dr["tt_nghiPhep"].ToString() == "2" || dr["coHuongLuong"].ToString() == "0")
                    {
                        r["NghiKhongLuong"] = "1";
                    }
                    else
                    {
                        r["NghiKhongLuong"] = "0";
                    }
                    dt.Rows.Add(r);
                }
                else
                {
                    if (dr["tt_ok"].ToString() != "0" && dr["tt_leTet"].ToString() == "0" && dr["tt_chuNhat"].ToString() == "0")
                    {
                        if (dr["kqNgayCong"].ToString() != "" && !DBNull.Value.Equals(dr["kqNgayCong"].ToString()))
                        {
                            string A = "" + Convert.ToDouble(r1[0]["NgayCong"].ToString());
                            r1[0]["NgayCong"] = Math.Round(Convert.ToDouble(r1[0]["NgayCong"].ToString()) + Convert.ToDouble(dr["kqNgayCong"].ToString()), 2);
                            double a = Math.Round(Convert.ToDouble(r1[0]["NgayCong"].ToString()) + Convert.ToDouble(dr["kqNgayCong"].ToString()), 2);
                        }
                    }
                    // Làm lễ tết
                    if (dr["tt_leTet"].ToString() == "1" && dr["kqNgayCong"].ToString() != "0")
                    {
                        r1[0]["TangCaLe"] = Convert.ToDouble(r1[0]["TangCaLe"]) + (Convert.ToDouble(dr["kqNgayCong"].ToString()) / 3 * 8);
                    }
                    if (dr["tt_leTet"].ToString() != "0")
                    {
                        r1[0]["NghiLe"] = (Convert.ToInt32(r1[0]["NghiLe"].ToString()) + 1);
                    }

                    if (dr["coHuongLuong"].ToString() == "1" && dr["tt_nghiPhep_Alias"].ToString() != "AL")
                    {
                        r1[0]["NghiCoLuong"] = (Convert.ToInt32(r1[0]["NghiCoLuong"].ToString()) + 1);
                    }
                    if (dr["coHuongLuong"].ToString() == "1" && dr["tt_nghiPhep_Alias"].ToString() == "AL")
                    {
                        r1[0]["NghiPhepNam"] = (Convert.ToInt32(r1[0]["NghiPhepNam"].ToString()) + 1);
                    }

                    if (dr["tt_nghiPhep_Alias"].ToString() == "KP")
                    {
                        r1[0]["NghiKhongPhep"] = (Convert.ToInt32(r1[0]["NghiKhongPhep"].ToString()) + 1);
                    }

                    if (dr["tt_nghiPhep"].ToString() == "2" || dr["coHuongLuong"].ToString() == "0")
                    {
                        r1[0]["NghiKhongLuong"] = (Convert.ToInt32(r1[0]["NghiKhongLuong"].ToString()) + 1);
                    }
                    if (r1[0]["TangCa"].ToString() != "" && dr["tgTinhTangCa"].ToString() != "" && !Convert.ToBoolean(dr["tt_chuNhat"]))
                        r1[0]["TangCa"] = (Convert.ToDouble(r1[0]["TangCa"].ToString()) + Convert.ToDouble(dr["tgTinhTangCa"].ToString()));
                    else
                    { r1[0]["TangCa"] = 0; }
                    if (Convert.ToBoolean(dr["tt_chuNhat"]))
                    {
                        r1[0]["ChuNhat"] = Convert.ToDouble(r1[0]["ChuNhat"].ToString())
                                         + Convert.ToDouble(dr["kqNgayCong"].ToString() != "" ? dr["kqNgayCong"].ToString() : "0")
                                         + Convert.ToDouble(dr["tgTinhTangCa"].ToString() != "" ? dr["tgTinhTangCa"].ToString() : "0");
                    }
                    r = r1[0];
                }
            }
            return dt;
        }
        public DataTable getDataDSHopDong(string EmpID, string DepID, DateTime TuNgay, DateTime DenNgay, string strHopDong)
        {
            DataTable data = new DataTable();
            data = logic.getDataDSHopDong(EmpID, DepID, TuNgay, DenNgay, strHopDong);
            return data;
        }
        public string getPhongBan(string DepID, dcDatabaseDataContext db)
        {
            string strDep = "";
            List<tblRef_Department> child = (from c in db.tblRef_Departments where c.DepParent == DepID select c).ToList<tblRef_Department>();
            if (child != null)
            {
                if (child.Count > 0)
                {
                    string list = "";
                    foreach (tblRef_Department item in child)
                    {
                        list += item.DepID + ",";
                    }
                    strDep = list;
                }
                else
                {
                    strDep = DepID;
                }
            }
            return strDep;
        }

        public DataTable GetDataReportMonthExcel(string typeSearch, string Value, DateTime day, DateTime todates)
        {
            DataTable dt = new DataTable();
            #region add datacolumn
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("EmployeeID"),
                new DataColumn("tenNV"),
                new DataColumn("TeamName"),
                new DataColumn("LineName"),
                new DataColumn("DepName"),
                new DataColumn("IDCard"),
                new DataColumn("SoNgayCong", typeof(Double)),
                new DataColumn("NghiLe" ),
                new DataColumn("NghiKhongPhep"),
                new DataColumn("NghiKhongLuong"),
                new DataColumn("kqNgayCong"),
                new DataColumn("DNgayCong"),
                new DataColumn("DTangCa"),
                new DataColumn("DChuNhat"),
                new DataColumn("TangCa"),
                new DataColumn("tgTinhTangCa"),
                new DataColumn("PosName"),
                new DataColumn("AppliedDate"),
                new DataColumn("NghiOm"),
                new DataColumn("NghiThaiSan"),
                new DataColumn("NghiKhac"),
                new DataColumn("NghiCheDo"),
                new DataColumn("NghiMaChay"),
                new DataColumn("NghiKetHon"),
                new DataColumn("NghiVangMat"),
                new DataColumn("NghiPhepNam"),
                new DataColumn("NghiKhongLuongVM"),
                new DataColumn("D1"),
                new DataColumn("D2"),
                new DataColumn("D3"),
                new DataColumn("D4"),
                new DataColumn("D5"),
                new DataColumn("D6"),
                new DataColumn("D7"),
                new DataColumn("D8"),
                new DataColumn("D9"),
                new DataColumn("D10"),
                new DataColumn("D11"),
                new DataColumn("D12"),
                new DataColumn("D13"),
                new DataColumn("D14"),
                new DataColumn("D15"),
                new DataColumn("D16"),
                new DataColumn("D17"),
                new DataColumn("D18"),
                new DataColumn("D19"),
                new DataColumn("D20"),
                new DataColumn("D21"),
                new DataColumn("D22"),
                new DataColumn("D23"),
                new DataColumn("D24"),
                new DataColumn("D25"),
                new DataColumn("D26"),
                new DataColumn("D27"),
                new DataColumn("D28"),
                new DataColumn("D29"),
                new DataColumn("D30"),
                new DataColumn("D31"),
                new DataColumn("T1"),
                new DataColumn("T2"),
                new DataColumn("T3"),
                new DataColumn("T4"),
                new DataColumn("T5"),
                new DataColumn("T6"),
                new DataColumn("T7"),
                new DataColumn("T8"),
                new DataColumn("T9"),
                new DataColumn("T10"),
                new DataColumn("T11"),
                new DataColumn("T12"),
                new DataColumn("T13"),
                new DataColumn("T14"),
                new DataColumn("T15"),
                new DataColumn("T16"),
                new DataColumn("T17"),
                new DataColumn("T18"),
                new DataColumn("T19"),
                new DataColumn("T20"),
                new DataColumn("T21"),
                new DataColumn("T22"),
                new DataColumn("T23"),
                new DataColumn("T24"),
                new DataColumn("T25"),
                new DataColumn("T26"),
                new DataColumn("T27"),
                new DataColumn("T28"),
                new DataColumn("T29"),
                new DataColumn("T30"),
                new DataColumn("T31"),
                new DataColumn("vitri"),
            });
            #endregion
            //logic.VirtualPaging.PageSize = e.Limit;
            //logic.VirtualPaging.Page = (int)(e.Start / e.Limit) + 1;
            DataTable data = new DataTable();
            data = logic.GetReportMonth(day, todates, typeSearch, Value);

            List<string> list = new List<string>();

            if (data != null && data.Rows.Count > 0)
            {
                DataRow[] _rowlist = data.Select("", "ngay ASC");
                foreach (DataRow dr in _rowlist)
                {
                    DataRow r = null;
                    r = dt.NewRow();
                    r["T" + ((DateTime)dr["ngay"]).Day] = dr["tgTinhTangCa"];
                    if (!DBNull.Value.Equals(dr["kqNgayCong"]))
                    {
                        if (dr["kqNgayCong"].ToString() != "" && !DBNull.Value.Equals(dr["kqNgayCong"].ToString()))
                            r["D" + ((DateTime)dr["ngay"]).Day] = Math.Round(Convert.ToDouble(dr["kqNgayCong"]), 2);
                    }
                    else
                    {
                        r["D" + ((DateTime)dr["ngay"]).Day] = dr["kqNgayCong"];
                    }
                    if (!list.Contains(dr["EmployeeID"].ToString()))
                    {
                        list.Add(dr["EmployeeID"].ToString());
                        System.Data.DataView view = new System.Data.DataView(dt);
                        view.Sort = "EmployeeID";
                        r["EmployeeID"] = dr["EmployeeID"];
                        r["tenNV"] = dr["EmployeeName"];
                        r["DepName"] = dr["DepName"];
                        r["TeamName"] = dr["TeamName"];
                        r["LineName"] = dr["LineName"];
                        r["tgTinhTangCa"] = dr["tgTinhTangCa"];
                        r["PosName"] = dr["PosName"];
                        r["IDCard"] = dr["IDCard"];

                        if (dr["AppliedDate"] != null && dr["AppliedDate"].ToString() != "")
                        {
                            r["AppliedDate"] = Convert.ToDateTime(dr["AppliedDate"].ToString()).ToShortDateString();
                        }
                        //  r["kqNgayCong"] = dr["kqNgayCong"];
                        r["NghiOm"] = "0";
                        r["NghiThaiSan"] = "0";
                        r["NghiKhac"] = "0";
                        r["NghiCheDo"] = "0";
                        r["NghiMaChay"] = "0";
                        r["NghiKetHon"] = "0";
                        r["NghiPhepNam"] = "0";
                        r["NghiVangMat"] = "0";
                        r["NghiKhongLuong"] = "0";
                        r["NghiKhongLuongVM"] = "0";
                        r["SoNgayCong"] = "0";
                        if (dr["tt_leTet"].ToString() != "0")
                        {
                            r["NghiLe"] = "1";
                            r["D" + ((DateTime)dr["ngay"]).Day] = "LT";
                        }
                        else
                        {
                            r["NghiLe"] = "0";

                        }
                        if (Convert.ToBoolean(dr["tt_chuNhat"].ToString()) == true)
                        {
                            r["T" + ((DateTime)dr["ngay"]).Day] = "";
                            r["DChuNhat"] = Math.Round((Convert.ToDouble(dr["kqNgayCong"].ToString()) * 8) + (dr["tgTinhTangCa"] == DBNull.Value ? 0 : Convert.ToDouble(dr["tgTinhTangCa"].ToString())), 2);
                            r["D" + ((DateTime)dr["ngay"]).Day] = Math.Round((Convert.ToDouble(dr["kqNgayCong"].ToString()) * 8) + Convert.ToDouble(dr["tgTinhTangCa"].ToString()), 2) + "h";
                        }
                        else
                        {
                            r["DChuNhat"] = "0";
                            //  r["SoNgayCong"] = (dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"].ToString())) + (dr["tt_leTet"].ToString() == "1" ? 1 : 0);
                        }
                        if ((dr["tt_nghiPhep_Alias"] != null && dr["tt_nghiPhep_Alias"].ToString() == "KP"))
                        {
                            r["NghiKhongPhep"] = "1";
                            r["D" + ((DateTime)dr["ngay"]).Day] = "KP";
                        }
                        else
                        {
                            r["NghiKhongPhep"] = "0";
                        }
                        if (dr["tgTinhTangCa"].ToString() != "" && Convert.ToBoolean(dr["tt_chuNhat"].ToString()) != true)
                            r["TangCa"] = Convert.ToDouble(dr["tgTinhTangCa"].ToString());
                        if (!DBNull.Value.Equals(dr["lydo"]))
                        {
                            double ketquathat = 0;
                            double ketquaphep = 0;
                            double numOfNghiPhep = 0;
                            if (dr["kqNgayCong"] != null)
                            {
                                ketquathat = Math.Round(Convert.ToDouble(dr["kqNgayCong"].ToString()), 2);
                            }
                            if ((dr["tt_nghiPhep_Alias"] == null || dr["tt_nghiPhep_Alias"].ToString() == ""))
                            {
                                numOfNghiPhep = 0;
                            }
                            else
                            {
                                numOfNghiPhep = Convert.ToDouble(dr["tt_nghiPhep"].ToString()) == 3 ? 1 : 0.5;
                            }
                            ketquaphep = numOfNghiPhep;
                            r["NghiOm"] = "0";
                            r["NghiThaiSan"] = "0";
                            r["NghiKhac"] = "0";
                            r["NghiCheDo"] = "0";
                            r["NghiMaChay"] = "0";
                            r["NghiKetHon"] = "0";
                            r["NghiPhepNam"] = "0";
                            r["NghiVangMat"] = "0";
                            r["NghiKhongLuong"] = "0";
                            r["NghiKhongLuongVM"] = "0";
                            if (dr["lydo"].ToString() == ((int)Enums.eLyDoNghi.KhongLuong).ToString())
                            {
                                r["D" + ((DateTime)dr["ngay"]).Day] = ketquathat + "LWP";
                                r["NghiKhongLuong"] = numOfNghiPhep;
                            }
                            else if (dr["lydo"].ToString() == ((int)Enums.eLyDoNghi.Om).ToString())
                            {
                                r["NghiOm"] = numOfNghiPhep;
                                r["NghiKhac"] = numOfNghiPhep;
                                r["D" + ((DateTime)dr["ngay"]).Day] = ketquathat + "SL";
                            }

                            else if (dr["lydo"].ToString() == ((int)Enums.eLyDoNghi.VangMat).ToString())
                            {
                                r["NghiVangMat"] = numOfNghiPhep;
                                r["NghiKhac"] = numOfNghiPhep;
                                r["D" + ((DateTime)dr["ngay"]).Day] = ketquathat + "VM";
                            }
                            else if (dr["lydo"].ToString() == ((int)Enums.eLyDoNghi.NghiPhepNam).ToString())
                            {
                                r["NghiPhepNam"] = numOfNghiPhep;
                                r["D" + ((DateTime)dr["ngay"]).Day] = ketquathat + " AL";
                            }
                            else if (dr["lydo"].ToString() == ((int)Enums.eLyDoNghi.KetHon).ToString())
                            {
                                r["NghiKetHon"] = numOfNghiPhep;
                                r["NghiCheDo"] = numOfNghiPhep;
                                r["D" + ((DateTime)dr["ngay"]).Day] = ketquathat + "WL";
                            }
                            else if (dr["lydo"].ToString() == ((int)Enums.eLyDoNghi.MaChay).ToString())
                            {
                                r["NghiMaChay"] = numOfNghiPhep;
                                r["NghiCheDo"] = numOfNghiPhep;
                            }
                            else if (dr["lydo"].ToString() == ((int)Enums.eLyDoNghi.ThaiSan).ToString())
                            {
                                r["NghiThaiSan"] = numOfNghiPhep;
                                r["D" + ((DateTime)dr["ngay"]).Day] = ketquathat + "ML";
                            }
                            else if (dr["lydo"].ToString() == ((int)Enums.eLyDoNghi.Khac).ToString())
                            {
                                r["NghiKhac"] = numOfNghiPhep;
                                r["D" + ((DateTime)dr["ngay"]).Day] = ketquathat + "#";
                            }
                            else if (dr["lydo"].ToString() == ((int)Enums.eLyDoNghi.CheDo).ToString())
                            {
                                r["NghiCheDo"] = numOfNghiPhep;
                                r["D" + ((DateTime)dr["ngay"]).Day] = ketquathat + "CD";
                            }
                        }
                        else
                        {
                            r["NghiOm"] = "0";
                            r["NghiThaiSan"] = "0";
                            r["NghiKhac"] = "0";
                            r["NghiCheDo"] = "0";
                            r["NghiMaChay"] = "0";
                            r["NghiKetHon"] = "0";
                            r["NghiPhepNam"] = "0";
                            r["NghiVangMat"] = "0";
                            r["NghiKhongLuongVM"] = "0";
                        }
                        if (Convert.ToBoolean(dr["tt_chuNhat"].ToString()) == false)
                        {
                            r["SoNgayCong"] = (dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"].ToString()));
                        }
                        dt.Rows.Add(r);
                    }
                    else// Nếu có nhân viên trong danh sách rồi thì add thêm vào.
                    {
                        var r1 = dt.Select("EmployeeID='" + dr["EmployeeID"].ToString() + "' ");
                        r1[0]["T" + ((DateTime)dr["ngay"]).Day] = dr["tgTinhTangCa"];
                        DataRow rtemp = r1[0];

                        if (!DBNull.Value.Equals(dr["kqNgayCong"]))
                        {
                            if (dr["kqNgayCong"].ToString() != "" && !DBNull.Value.Equals(dr["kqNgayCong"].ToString()))
                                r1[0]["D" + ((DateTime)dr["ngay"]).Day] = Math.Round(Convert.ToDouble(dr["kqNgayCong"]), 2);
                        }
                        else
                        {
                            r1[0]["D" + ((DateTime)dr["ngay"]).Day] = dr["kqNgayCong"];
                        }
                        if (dr["tt_leTet"].ToString() != "0")
                        {
                            r1[0]["NghiLe"] = (Convert.ToInt32(r1[0]["NghiLe"].ToString()) + 1);
                            r1[0]["D" + ((DateTime)dr["ngay"]).Day] = "LT";
                        }
                        if (Convert.ToBoolean(dr["tt_chuNhat"].ToString()) == true)
                        {
                            r["T" + ((DateTime)dr["ngay"]).Day] = "";
                            r1[0]["D" + ((DateTime)dr["ngay"]).Day] = Math.Round((Convert.ToDouble(dr["kqNgayCong"].ToString()) * 8) + (dr["tgTinhTangCa"] == DBNull.Value ? 0 : Convert.ToDouble(dr["tgTinhTangCa"].ToString())), 2) + "h";
                            r1[0]["DChuNhat"] = (r1[0]["DChuNhat"] == DBNull.Value ? 0 : Convert.ToDouble(r1[0]["DChuNhat"].ToString())) + Math.Round((Convert.ToDouble(dr["kqNgayCong"].ToString()) * 8) + (dr["tgTinhTangCa"] == DBNull.Value ? 0 : Convert.ToDouble(dr["tgTinhTangCa"].ToString())), 2);

                        }
                        if ((dr["tt_nghiPhep_Alias"] != null && dr["tt_nghiPhep_Alias"].ToString() == "KP"))
                        {
                            r1[0]["NghiKhongPhep"] = (Convert.ToInt32(r1[0]["NghiKhongPhep"].ToString()) + 1);
                            r1[0]["D" + ((DateTime)dr["ngay"]).Day] = "KP";

                        }
                        if (r1[0]["TangCa"].ToString() == "")
                        {
                            r1[0]["TangCa"] = 0; // Phải có điều kiện này
                        }
                        if (dr["tgTinhTangCa"].ToString() != "" && Convert.ToBoolean(dr["tt_chuNhat"].ToString()) != true)
                            r1[0]["TangCa"] = Math.Round((Convert.ToDouble(r1[0]["TangCa"].ToString()) + Convert.ToDouble(dr["tgTinhTangCa"].ToString())), 2);

                        if (!DBNull.Value.Equals(dr["lydo"]))
                        {
                            double ketuquathuc = 0;
                            double ketquaphep = 0;
                            double numOfNghiPhep = 0;
                            if (dr["kqNgayCong"] != null && dr["kqNgayCong"].ToString() != "")
                            {
                                ketuquathuc = Math.Round(Convert.ToDouble(dr["kqNgayCong"].ToString()), 2);
                            }
                            if ((dr["tt_nghiPhep"] == null || dr["tt_nghiPhep"].ToString() == "0"))
                            {
                                numOfNghiPhep = 0;
                            }
                            else
                            {
                                numOfNghiPhep = Convert.ToDouble(dr["tt_nghiPhep"].ToString()) == 3 ? 1 : 0.5;
                            }
                            ketquaphep = numOfNghiPhep;
                            if (dr["lydo"].ToString() == ((int)Enums.eLyDoNghi.Om).ToString())
                            {
                                r1[0]["NghiOm"] = (Convert.ToDouble(r1[0]["NghiOm"].ToString()) + ketquaphep);
                                r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + "SL";
                                r1[0]["NghiKhac"] = Convert.ToDouble(r1[0]["NghiKhac"]) + ketquaphep;
                            }
                            else if (dr["lydo"].ToString() == ((int)Enums.eLyDoNghi.VangMat).ToString())
                            {
                                r1[0]["NghiVangMat"] = (Convert.ToDouble(r1[0]["NghiVangMat"].ToString()) + ketquaphep);
                                r1[0]["NghiKhac"] = (Convert.ToDouble(r1[0]["NghiKhac"].ToString()) + ketquaphep);
                                r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + "VM";

                            }
                            else if (dr["lydo"].ToString() == ((int)Enums.eLyDoNghi.NghiPhepNam).ToString())
                            {
                                r1[0]["NghiPhepNam"] = Convert.ToDouble(r1[0]["NghiPhepNam"].ToString()) + Convert.ToDouble(ketquaphep);
                                r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + " AL";
                            }
                            else if (dr["lydo"].ToString() == ((int)Enums.eLyDoNghi.KetHon).ToString())
                            {
                                r1[0]["NghiKetHon"] = (Convert.ToDouble(r1[0]["NghiKetHon"].ToString()) + ketquaphep);
                                r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + "WL";
                                r1[0]["NghiCheDo"] = (Convert.ToDouble(r1[0]["NghiCheDo"].ToString()) + ketquaphep);

                            }
                            else if (dr["lydo"].ToString() == ((int)Enums.eLyDoNghi.MaChay).ToString())
                            {
                                r1[0]["NghiMaChay"] = (Convert.ToDouble(r1[0]["NghiMaChay"].ToString()) + ketquaphep);
                                r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + "FL";
                                r1[0]["NghiCheDo"] = (Convert.ToDouble(r1[0]["NghiCheDo"].ToString()) + ketquaphep);

                            }
                            else if (dr["lydo"].ToString() == ((int)Enums.eLyDoNghi.ThaiSan).ToString())
                            {
                                r1[0]["NghiThaiSan"] = (Convert.ToDouble(r1[0]["NghiThaiSan"].ToString()) + ketquaphep);
                                r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + "ML";

                            }
                            else if (dr["lydo"].ToString() == ((int)Enums.eLyDoNghi.Khac).ToString())
                            {
                                r1[0]["NghiKhac"] = (Convert.ToDouble(r1[0]["NghiKhac"].ToString()) + ketquaphep);
                                r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + "#";

                            }
                            else if (dr["lydo"].ToString() == ((int)Enums.eLyDoNghi.CheDo).ToString())
                            {
                                r1[0]["NghiCheDo"] = (Convert.ToDouble(r1[0]["NghiCheDo"].ToString()) + ketquaphep);
                                r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + "CD";
                            }
                            else if (dr["lydo"].ToString() == ((int)Enums.eLyDoNghi.KhongLuong).ToString())
                            {
                                r1[0]["NghiKhongLuong"] = Convert.ToDouble(r1[0]["NghiKhongLuong"]) + ketquaphep;

                                r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + "LWP";
                            }
                        }
                        if (Convert.ToBoolean(dr["tt_chuNhat"].ToString()) == false)
                        {
                            r1[0]["SoNgayCong"] = (r1[0]["SoNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(r1[0]["SoNgayCong"])) + ((dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"].ToString())) );
                        }
                        r = r1[0];
                    }
                }
            }
            return dt;
        }
        public DataTable GetDataReportMonthForm(string typeSearch, string Value, DateTime day, DateTime todates)
        {
            DataTable dt = new DataTable();
            #region add datacolumn
            //dt.Columns.AddRange(new DataColumn[] {
            //    new DataColumn("EmployeeID"),
            //    new DataColumn("tenNV"),
            //    new DataColumn("DepName"),
            //    new DataColumn("TeamName"),
            //    new DataColumn("LineName"),
            //    new DataColumn("IDCard"),
            //    new DataColumn("SoNgayCong", typeof(Double)),
            //    new DataColumn("NghiLe"),
            //    new DataColumn("NghiKhongPhep"),
            //    new DataColumn("NghiKhongLuong"),
            //    new DataColumn("TangCa"),
            //    new DataColumn("kqNgayCong"),
            //    new DataColumn("DNgayCong"),
            //    new DataColumn("DTangCa"),
            //    new DataColumn("DChuNhat"),
            //    new DataColumn("tgTinhTangCa"),
            //    new DataColumn("PosName"),
            //    new DataColumn("AppliedDate"),
            //    new DataColumn("NghiOm"),
            //    new DataColumn("NghiThaiSan"),
            //    new DataColumn("NghiKhac"),
            //    new DataColumn("NghiCheDo"),
            //    new DataColumn("NghiMaChay"),
            //    new DataColumn("NghiKetHon"),
            //    new DataColumn("NghiVangMat"),
            //    new DataColumn("NghiPhepNam"),
            //    new DataColumn("NghiKhongLuongVM"),
            //    new DataColumn("D1"),
            //    new DataColumn("D2"),
            //    new DataColumn("D3"),
            //    new DataColumn("D4"),
            //    new DataColumn("D5"),
            //    new DataColumn("D6"),
            //    new DataColumn("D7"),
            //    new DataColumn("D8"),
            //    new DataColumn("D9"),
            //    new DataColumn("D10"),
            //    new DataColumn("D11"),
            //    new DataColumn("D12"),
            //    new DataColumn("D13"),
            //    new DataColumn("D14"),
            //    new DataColumn("D15"),
            //    new DataColumn("D16"),
            //    new DataColumn("D17"),
            //    new DataColumn("D18"),
            //    new DataColumn("D19"),
            //    new DataColumn("D20"),
            //    new DataColumn("D21"),
            //    new DataColumn("D22"),
            //    new DataColumn("D23"),
            //    new DataColumn("D24"),
            //    new DataColumn("D25"),
            //    new DataColumn("D26"),
            //    new DataColumn("D27"),
            //    new DataColumn("D28"),
            //    new DataColumn("D29"),
            //    new DataColumn("D30"),
            //    new DataColumn("D31"),
            //    new DataColumn("T1"),
            //    new DataColumn("T2"),
            //    new DataColumn("T3"),
            //    new DataColumn("T4"),
            //    new DataColumn("T5"),
            //    new DataColumn("T6"),
            //    new DataColumn("T7"),
            //    new DataColumn("T8"),
            //    new DataColumn("T9"),
            //    new DataColumn("T10"),
            //    new DataColumn("T11"),
            //    new DataColumn("T12"),
            //    new DataColumn("T13"),
            //    new DataColumn("T14"),
            //    new DataColumn("T15"),
            //    new DataColumn("T16"),
            //    new DataColumn("T17"),
            //    new DataColumn("T18"),
            //    new DataColumn("T19"),
            //    new DataColumn("T20"),
            //    new DataColumn("T21"),
            //    new DataColumn("T22"),
            //    new DataColumn("T23"),
            //    new DataColumn("T24"),
            //    new DataColumn("T25"),
            //    new DataColumn("T26"),
            //    new DataColumn("T27"),
            //    new DataColumn("T28"),
            //    new DataColumn("T29"),
            //    new DataColumn("T30"),
            //    new DataColumn("T31"),
            //    new DataColumn("vitri")
            //});
            #endregion
            //logic.VirtualPaging.PageSize = e.Limit;
            //logic.VirtualPaging.Page = (int)(e.Start / e.Limit) + 1;
            //DataTable data = new DataTable();
            //data = logic.GetReportMonth(day, todates, typeSearch, Value);

            List<string> list = new List<string>();
            #region Cũ_14/03/2017
            //if (data != null && data.Rows.Count > 0)
            //{
            //    DataRow[] _rowlist = data.Select("", "ngay ASC");
            //    foreach (DataRow dr in _rowlist)
            //    {
            //        DataRow r = null;
            //        r = dt.NewRow();
            //        r["T" + ((DateTime)dr["ngay"]).Day] = dr["tgTinhTangCa"];
            //        if (!DBNull.Value.Equals(dr["kqNgayCong"]))
            //        {
            //            if (dr["kqNgayCong"].ToString() != "" && !DBNull.Value.Equals(dr["kqNgayCong"].ToString()))
            //                r["D" + ((DateTime)dr["ngay"]).Day] = Math.Round(Convert.ToDouble(dr["kqNgayCong"]), 2);
            //        }
            //        else
            //        {
            //            r["D" + ((DateTime)dr["ngay"]).Day] = dr["kqNgayCong"];
            //        }
            //        if (!list.Contains(dr["EmployeeID"].ToString()))
            //        {
            //            list.Add(dr["EmployeeID"].ToString());
            //            System.Data.DataView view = new System.Data.DataView(dt);
            //            view.Sort = "EmployeeID";
            //            r["EmployeeID"] = dr["EmployeeID"];
            //            r["tenNV"] = dr["EmployeeName"];
            //            r["DepName"] = dr["DepName"];
            //            r["TeamName"] = dr["TeamName"];
            //            r["LineName"] = dr["LineName"];
            //            r["tgTinhTangCa"] = dr["tgTinhTangCa"];
            //            r["PosName"] = dr["PosName"];
            //            r["IDCard"] = dr["IDCard"];
            //            r["vitri"] = "1";

            //            if (dr["AppliedDate"] != null && dr["AppliedDate"].ToString() != "")
            //            {
            //                r["AppliedDate"] = Convert.ToDateTime(dr["AppliedDate"].ToString()).ToShortDateString();
            //            }
            //            //  r["kqNgayCong"] = dr["kqNgayCong"];
            //            r["NghiOm"] = "0";
            //            r["NghiThaiSan"] = "0";
            //            r["NghiKhac"] = "0";
            //            r["NghiCheDo"] = "0";
            //            r["NghiMaChay"] = "0";
            //            r["NghiKetHon"] = "0";
            //            r["NghiPhepNam"] = "0";
            //            r["NghiVangMat"] = "0";
            //            r["NghiKhongLuong"] = "0";
            //            r["NghiPhep"] = "0";
            //            r["NghiKhongLuongVM"] = "0";
            //            r["SoNgayCong"] = "0";
            //            if (dr["tt_leTet"].ToString() != "0")
            //            {
            //                r["NghiLe"] = "1";
            //                r["D" + ((DateTime)dr["ngay"]).Day] = "NL";
            //            }
            //            else
            //            {
            //                r["NghiLe"] = "0";

            //            }
            //            if (Convert.ToBoolean(dr["tt_chuNhat"].ToString()) != false)
            //            {

            //                r["TangCa"] = "0";
            //                r["T" + ((DateTime)dr["ngay"]).Day] = "";

            //                if (!DBNull.Value.Equals(dr["tgTinhTangCa"]))
            //                {
            //                    if (dr["kqNgayCong"].ToString() == "1")
            //                    {
            //                        r["DChuNhat"] = Math.Round(8 + (dr["tgTinhTangCa"] == DBNull.Value ? 0 : Convert.ToDouble(dr["tgTinhTangCa"].ToString())), 2);
            //                        r["D" + ((DateTime)dr["ngay"]).Day] = Math.Round(8 + Convert.ToDouble(dr["tgTinhTangCa"].ToString()), 2) + "H";
            //                        //  r["DChuNhat"] = "1";
            //                    }
            //                    else
            //                    {
            //                        r["DChuNhat"] = Math.Round((Convert.ToDouble(dr["kqNgayCong"].ToString()) * 10) + (dr["tgTinhTangCa"] == DBNull.Value ? 0 : Convert.ToDouble(dr["tgTinhTangCa"].ToString())), 2);
            //                        r["D" + ((DateTime)dr["ngay"]).Day] = Math.Round((Convert.ToDouble(dr["kqNgayCong"].ToString()) * 10) + Convert.ToDouble(dr["tgTinhTangCa"].ToString()), 2) + "H";
            //                    }
            //                }
            //                else
            //                {
            //                    if (dr["kqNgayCong"].ToString() == "1")
            //                    {
            //                        r["D" + ((DateTime)dr["ngay"]).Day] = "8H";
            //                        r["DChuNhat"] = 8;

            //                    }
            //                    else
            //                    {

            //                        r["D" + ((DateTime)dr["ngay"]).Day] = (Math.Round((dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"].ToString())), 2) * 10) + "H";
            //                        r["DChuNhat"] = (Math.Round(Convert.ToDouble(dr["kqNgayCong"].ToString()), 2) * 10);
            //                    }
            //                }
            //                // r["D" + ((DateTime)dr["ngay"]).Day] = "LCN";
            //            }
            //            else
            //            {
            //                r["DChuNhat"] = "0";
            //                r["TangCa"] = dr["tgTinhTangCa"];
            //                //  r["SoNgayCong"] = (dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"].ToString())) + (dr["tt_leTet"].ToString() == "1" ? 1 : 0);
            //            }
            //            if ((dr["tt_nghiPhep_Alias"] != null && dr["tt_nghiPhep_Alias"].ToString() == "KP"))
            //            {
            //                r["NghiKhongPhep"] = "1";
            //                r["D" + ((DateTime)dr["ngay"]).Day] = "KP";
            //            }
            //            else
            //            {
            //                r["NghiKhongPhep"] = "0";
            //            }
            //            if (!DBNull.Value.Equals(dr["lydo"]))
            //            {
            //                string ketquathat = "";
            //                string ketquaphep = "";
            //                if (dr["tuGio"] != DBNull.Value && dr["denGio"] != DBNull.Value && dr["soTiengTinhCa"] != DBNull.Value)
            //                {
            //                    if (dr["kqNgayCong"] != DBNull.Value && Convert.ToInt32(dr["tt_coQuetTay"]) > 0 && Convert.ToDouble(dr["kqNgayCong"]) > 0)
            //                    {
            //                        TimeSpan a = Convert.ToDateTime(dr["denGio"].ToString()) - Convert.ToDateTime(dr["tuGio"].ToString());
            //                        double h = (a.TotalHours > Convert.ToDouble((dr["soTiengTinhCa"].ToString()))) ? 1 : a.TotalHours / Convert.ToDouble((dr["soTiengTinhCa"].ToString()));
            //                        //   r["SoNgayCong"] = Convert.ToDouble(r["SoNgayCong"]) + ((dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"].ToString())) - h);
            //                        r["SoNgayCong"] = (r["SoNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(r["SoNgayCong"])) + ((dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"].ToString())));
            //                        ketquathat = Math.Round(Math.Abs(((dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"].ToString())))), 2) + "";
            //                        // ketquaphep =h.ToString();
            //                        if (h < 1)
            //                        {
            //                            ketquaphep = "0.5";
            //                        }
            //                        else
            //                        {
            //                            ketquaphep = "1";
            //                        }
            //                    }
            //                    else
            //                    {

            //                        TimeSpan a = Convert.ToDateTime(dr["denGio"].ToString()) - Convert.ToDateTime(dr["tuGio"].ToString());
            //                        double h = (a.TotalHours > Convert.ToDouble((dr["soTiengTinhCa"].ToString()))) ? 1 : a.TotalHours / Convert.ToDouble((dr["soTiengTinhCa"].ToString()));
            //                        ketquathat = Convert.ToDouble(dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"].ToString())) + "";
            //                        if (h < 1)
            //                        {
            //                            ketquaphep = "0.5";
            //                        }
            //                        else
            //                        {
            //                            ketquaphep = "1";
            //                        }

            //                    }
            //                }
            //                if (dr["lydo"].ToString() == "11")
            //                {
            //                    r["NghiOm"] = "0";
            //                    r["NghiThaiSan"] = "0";
            //                    r["NghiKhac"] = "0";
            //                    r["NghiCheDo"] = "0";
            //                    r["NghiMaChay"] = "0";
            //                    r["NghiKetHon"] = "0";
            //                    r["NghiPhepNam"] = "0";
            //                    r["NghiVangMat"] = "0";
            //                    r["NghiKhongLuongVM"] = "1";
            //                    r["D" + ((DateTime)dr["ngay"]).Day] = ketquathat + "LWP";
            //                    r["NghiKhongLuong"] = Convert.ToInt32(r["NghiKhongLuong"]) + 1;
            //                }
            //                if (dr["lydo"].ToString() == "12")
            //                {
            //                    r["NghiOm"] = "1";
            //                    r["NghiThaiSan"] = "0";
            //                    r["NghiKhac"] = "0";
            //                    r["NghiCheDo"] = "0";
            //                    r["NghiMaChay"] = "0";
            //                    r["NghiKetHon"] = "0";
            //                    r["NghiPhepNam"] = "0";
            //                    r["NghiVangMat"] = "0";
            //                    r["NghiKhongLuongVM"] = Convert.ToInt32(r["NghiKhongLuongVM"]) + 1;
            //                    r["D" + ((DateTime)dr["ngay"]).Day] = ketquathat + "SL";
            //                    r["NghiKhongLuong"] = Convert.ToInt32(r["NghiKhongLuong"]) + 1;
            //                }

            //                else if (dr["lydo"].ToString() == "14")
            //                {
            //                    r["NghiOm"] = "0";
            //                    r["NghiThaiSan"] = "0";
            //                    r["NghiKhac"] = "0";
            //                    r["NghiCheDo"] = "0";
            //                    r["NghiMaChay"] = "0";
            //                    r["NghiKetHon"] = "0";
            //                    r["NghiPhepNam"] = "0";
            //                    r["NghiVangMat"] = "1";
            //                    r["NghiKhongLuongVM"] = "0";
            //                    r["D" + ((DateTime)dr["ngay"]).Day] = ketquathat + "VM";
            //                }
            //                else if (dr["lydo"].ToString() == "4")
            //                {
            //                    r["NghiOm"] = "0";
            //                    r["NghiThaiSan"] = "0";
            //                    r["NghiKhac"] = "0";
            //                    r["NghiCheDo"] = "0";
            //                    r["NghiMaChay"] = "0";
            //                    r["NghiKetHon"] = "0";
            //                    r["NghiPhepNam"] = "1";
            //                    r["NghiVangMat"] = "0";
            //                    r["NghiKhongLuongVM"] = "0";
            //                    if (dr["kqNgayCong"].ToString() != "0" && dr["kqNgayCong"].ToString() != "1")
            //                    {

            //                        r["NghiPhepNam"] = Math.Round(Convert.ToDouble(ketquaphep), 2);
            //                        r["D" + ((DateTime)dr["ngay"]).Day] = ketquathat + " AL";
            //                    }
            //                    else
            //                    {
            //                        r["NghiPhepNam"] = ketquaphep;
            //                        r["D" + ((DateTime)dr["ngay"]).Day] = ketquathat + " AL";
            //                    }
            //                }
            //                else if (dr["lydo"].ToString() == "5")
            //                {
            //                    r["NghiOm"] = "0";
            //                    r["NghiThaiSan"] = "0";
            //                    r["NghiKhac"] = "0";
            //                    r["NghiCheDo"] = "0";
            //                    r["NghiMaChay"] = "0";
            //                    r["NghiKetHon"] = "1";
            //                    r["NghiPhepNam"] = "0";
            //                    r["NghiVangMat"] = "0";
            //                    r["NghiKhongLuongVM"] = "0";
            //                    r["D" + ((DateTime)dr["ngay"]).Day] = ketquathat + "WL";
            //                }
            //                else if (dr["lydo"].ToString() == "6")
            //                {
            //                    r["NghiOm"] = "0";
            //                    r["NghiThaiSan"] = "0";
            //                    r["NghiKhac"] = "0";
            //                    r["NghiCheDo"] = "0";
            //                    r["NghiMaChay"] = "1";
            //                    r["NghiKetHon"] = "0";
            //                    r["NghiPhepNam"] = "0";
            //                    r["NghiVangMat"] = "0";
            //                    r["NghiKhongLuongVM"] = "0";
            //                }
            //                else if (dr["lydo"].ToString() == "15")
            //                {
            //                    r["NghiOm"] = "0";
            //                    r["NghiThaiSan"] = "1";
            //                    r["NghiKhac"] = "0";
            //                    r["NghiCheDo"] = "0";
            //                    r["NghiMaChay"] = "0";
            //                    r["NghiKetHon"] = "0";
            //                    r["NghiPhepNam"] = "0";
            //                    r["NghiVangMat"] = "0";
            //                    r["NghiKhongLuongVM"] = "0";
            //                    r["D" + ((DateTime)dr["ngay"]).Day] = ketquathat + "ML";
            //                }
            //                else if (dr["lydo"].ToString() == "13")
            //                {
            //                    r["NghiOm"] = "0";
            //                    r["NghiThaiSan"] = "0";
            //                    r["NghiKhac"] = "1";
            //                    r["NghiCheDo"] = "0";
            //                    r["NghiMaChay"] = "0";
            //                    r["NghiKetHon"] = "0";
            //                    r["NghiPhepNam"] = "0";
            //                    r["NghiVangMat"] = "0";
            //                    r["NghiKhongLuongVM"] = "0";
            //                    r["D" + ((DateTime)dr["ngay"]).Day] = ketquathat + "#";
            //                    r["NghiKhongLuong"] = Convert.ToInt32(r["NghiKhongLuong"]) + 1;
            //                }
            //                else if (dr["lydo"].ToString() == "8")
            //                {
            //                    r["NghiOm"] = "0";
            //                    r["NghiThaiSan"] = "0";
            //                    r["NghiKhac"] = "0";
            //                    r["NghiCheDo"] = "1";
            //                    r["NghiMaChay"] = "0";
            //                    r["NghiKetHon"] = "0";
            //                    r["NghiPhepNam"] = "0";
            //                    r["NghiVangMat"] = "0";
            //                    r["NghiKhongLuongVM"] = "0";
            //                    r["D" + ((DateTime)dr["ngay"]).Day] = ketquathat + "CD";
            //                }

            //            }
            //            else
            //            {
            //                r["SoNgayCong"] = (dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"].ToString()));
            //                r["NghiOm"] = "0";
            //                r["NghiThaiSan"] = "0";
            //                r["NghiKhac"] = "0";
            //                r["NghiCheDo"] = "0";
            //                r["NghiMaChay"] = "0";
            //                r["NghiKetHon"] = "0";
            //                r["NghiPhepNam"] = "0";
            //                r["NghiVangMat"] = "0";
            //                r["NghiKhongLuongVM"] = "0";
            //            }
            //            dt.Rows.Add(r);
            //        }
            //        else
            //        {
            //            var r1 = dt.Select("EmployeeID='" + dr["EmployeeID"].ToString() + "' ");
            //            r1[0]["T" + ((DateTime)dr["ngay"]).Day] = dr["tgTinhTangCa"];
            //            DataRow rtemp = r1[0];

            //            if (!DBNull.Value.Equals(dr["kqNgayCong"]))
            //            {
            //                if (dr["kqNgayCong"].ToString() != "" && !DBNull.Value.Equals(dr["kqNgayCong"].ToString()))
            //                    r1[0]["D" + ((DateTime)dr["ngay"]).Day] = Math.Round(Convert.ToDouble(dr["kqNgayCong"]), 2);
            //            }
            //            else
            //            {
            //                r1[0]["D" + ((DateTime)dr["ngay"]).Day] = dr["kqNgayCong"];
            //            }
            //            if (dr["tt_leTet"].ToString() != "0")
            //            {
            //                r1[0]["NghiLe"] = (Convert.ToInt32(r1[0]["NghiLe"].ToString()) + 1);
            //                r1[0]["D" + ((DateTime)dr["ngay"]).Day] = "NL";
            //            }
            //            if (Convert.ToBoolean(dr["tt_chuNhat"].ToString()) == true)
            //            {
            //                if (!DBNull.Value.Equals(dr["tgTinhTangCa"]))
            //                {
            //                    if (dr["kqNgayCong"].ToString() == "1")
            //                    {
            //                        r1[0]["D" + ((DateTime)dr["ngay"]).Day] = Math.Round(8 + (dr["tgTinhTangCa"] == DBNull.Value ? 0 : Convert.ToDouble(dr["tgTinhTangCa"].ToString())), 2) + "H";
            //                        r1[0]["DChuNhat"] = (r1[0]["DChuNhat"] == DBNull.Value ? 0 : Convert.ToDouble(r1[0]["DChuNhat"].ToString())) + Math.Round(8 + (dr["tgTinhTangCa"] == DBNull.Value ? 0 : Convert.ToDouble(dr["tgTinhTangCa"].ToString())), 2);

            //                    }
            //                    else
            //                    {
            //                        r1[0]["D" + ((DateTime)dr["ngay"]).Day] = Math.Round((Convert.ToDouble(dr["kqNgayCong"].ToString()) * 8) + (dr["tgTinhTangCa"] == DBNull.Value ? 0 : Convert.ToDouble(dr["tgTinhTangCa"].ToString())), 2) + "H";
            //                        r1[0]["DChuNhat"] = (r1[0]["DChuNhat"] == DBNull.Value ? 0 : Convert.ToDouble(r1[0]["DChuNhat"].ToString())) + Math.Round((Convert.ToDouble(dr["kqNgayCong"].ToString()) * 8) + (dr["tgTinhTangCa"] == DBNull.Value ? 0 : Convert.ToDouble(dr["tgTinhTangCa"].ToString())), 2);
            //                    }
            //                }
            //                else
            //                {
            //                    if (dr["kqNgayCong"].ToString() == "1")
            //                    {
            //                        r1[0]["D" + ((DateTime)dr["ngay"]).Day] = "8H";
            //                        r1[0]["DChuNhat"] = (r1[0]["DChuNhat"] == DBNull.Value ? 0 : Convert.ToDouble(r1[0]["DChuNhat"].ToString())) + 8;
            //                    }
            //                    else
            //                    {
            //                        r1[0]["DChuNhat"] = (r1[0]["DChuNhat"] == DBNull.Value ? 0 : Convert.ToDouble(r1[0]["DChuNhat"].ToString())) + (Math.Round((dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"].ToString())), 2) * 8);
            //                        r1[0]["D" + ((DateTime)dr["ngay"]).Day] = (Math.Round(Convert.ToDouble(dr["kqNgayCong"].ToString()), 2) * 10) + "H";
            //                    }
            //                }
            //                r1[0]["T" + ((DateTime)dr["ngay"]).Day] = "";
            //            }

            //            if ((dr["tt_nghiPhep_Alias"] != null && dr["tt_nghiPhep_Alias"].ToString() == "KP"))
            //            {
            //                r["NghiKhongPhep"] = "1";
            //                r["D" + ((DateTime)dr["ngay"]).Day] = "KP";
            //            }
            //            else
            //            {
            //                r["NghiKhongPhep"] = "0";
            //            }

            //            if (r1[0]["TangCa"].ToString() != "" && dr["tgTinhTangCa"].ToString() != "" && Convert.ToBoolean(dr["tt_chuNhat"].ToString()) != true)
            //                r1[0]["TangCa"] = Math.Round((Convert.ToDouble(r1[0]["TangCa"].ToString()) + Convert.ToDouble(dr["tgTinhTangCa"].ToString())), 2);

            //            if (!DBNull.Value.Equals(dr["lydo"]))
            //            {
            //                string ketuquathuc = "0";
            //                string ketquaphep = "0";
            //                if (dr["tuGio"] != DBNull.Value && dr["denGio"] != DBNull.Value && dr["soTiengTinhCa"] != DBNull.Value)
            //                {
            //                    if (dr["kqNgayCong"] != DBNull.Value && Convert.ToInt32(dr["tt_coQuetTay"]) > 0 && Convert.ToDouble(dr["kqNgayCong"]) > 0)
            //                    {

            //                        TimeSpan a = Convert.ToDateTime(dr["denGio"].ToString()) - Convert.ToDateTime(dr["tuGio"].ToString());
            //                        double h = (a.TotalHours > Convert.ToDouble((dr["soTiengTinhCa"].ToString()))) ? 1 : a.TotalHours / Convert.ToDouble((dr["soTiengTinhCa"].ToString()));
            //                        r1[0]["SoNgayCong"] = (r1[0]["SoNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(r1[0]["SoNgayCong"])) + ((dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"].ToString())));
            //                        // r1[0]["SoNgayCong"] = Convert.ToDouble(r1[0]["SoNgayCong"]) + h;
            //                        // if (Convert.ToInt32(dr["tt_coQuetTay"]) >= 3)
            //                        // {
            //                        //      ketuquathuc = Math.Round(Math.Abs(((dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"].ToString())) - h)), 2) + "";
            //                        //   }
            //                        //  else
            //                        // {
            //                        //  ketuquathuc = "0";
            //                        //  }
            //                        // ketuquathuc = Math.Round(Math.Abs((Convert.ToDouble((dr["soTiengTinhCa"].ToString())) / 8 - h)), 2) + "";
            //                        ketuquathuc = Math.Round(Math.Abs(((dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"].ToString())))), 2) + "";
            //                        //   ketquaphep = h.ToString();
            //                        if (h < 1)
            //                        {
            //                            ketquaphep = "0.5";
            //                        }
            //                        else
            //                        {
            //                            ketquaphep = "1";
            //                        }
            //                    }
            //                    else
            //                    {
            //                        TimeSpan a = Convert.ToDateTime(dr["denGio"].ToString()) - Convert.ToDateTime(dr["tuGio"].ToString());
            //                        double h = (a.TotalHours > Convert.ToDouble((dr["soTiengTinhCa"].ToString()))) ? 1 : a.TotalHours / Convert.ToDouble((dr["soTiengTinhCa"].ToString()));
            //                        //  r1[0]["SoNgayCong"] = Convert.ToDouble(r1[0]["SoNgayCong"]) + ((dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"].ToString())) - h);
            //                        ketuquathuc = Convert.ToDouble(dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"].ToString())) + "";
            //                        //  ketquaphep = h.ToString();
            //                        if (h < 1)
            //                        {
            //                            ketquaphep = "0.5";
            //                        }
            //                        else
            //                        {
            //                            ketquaphep = "1";
            //                        }
            //                    }
            //                }
            //                if (dr["lydo"].ToString() == "12")
            //                {
            //                    r1[0]["NghiOm"] = (Convert.ToInt32(r1[0]["NghiOm"].ToString()) + 1);
            //                    r1[0]["NghiKhongLuong"] = Convert.ToInt32(r1[0]["NghiKhongLuong"]) + 1;
            //                    r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + "SL";
            //                    r1[0]["NghiKhongLuongVM"] = Convert.ToInt32(r1[0]["NghiKhongLuongVM"]) + 1;

            //                }
            //                else if (dr["lydo"].ToString() == "14")
            //                {
            //                    r1[0]["NghiVangMat"] = (Convert.ToInt32(r1[0]["NghiVangMat"].ToString()) + 1);
            //                    r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + "VM";

            //                }
            //                else if (dr["lydo"].ToString() == "4")
            //                {
            //                    if (!DBNull.Value.Equals(dr["kqNgayCong"]) && dr["kqNgayCong"].ToString() != "0" && dr["kqNgayCong"].ToString() != "1")
            //                    {
            //                        r1[0]["NghiPhepNam"] = (Math.Round(Convert.ToDouble(r1[0]["NghiPhepNam"].ToString()), 2) + Math.Round(Convert.ToDouble(ketquaphep), 2));
            //                        r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + " AL";
            //                    }
            //                    else
            //                    {
            //                        r1[0]["NghiPhepNam"] = (Convert.ToDouble(r1[0]["NghiPhepNam"].ToString()) + Math.Round(Convert.ToDouble(ketquaphep), 2));
            //                        r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + " AL";
            //                    }

            //                }
            //                else if (dr["lydo"].ToString() == "5")
            //                {
            //                    r1[0]["NghiKetHon"] = (Convert.ToInt32(r1[0]["NghiKetHon"].ToString()) + 1);
            //                    r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + "WL";
            //                    r1[0]["NghiCheDo"] = (Convert.ToInt32(r1[0]["NghiCheDo"].ToString()) + 1);

            //                }
            //                else if (dr["lydo"].ToString() == "6")
            //                {
            //                    r1[0]["NghiMaChay"] = (Convert.ToInt32(r1[0]["NghiMaChay"].ToString()) + 1);
            //                    r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + "FL";
            //                    r1[0]["NghiCheDo"] = (Convert.ToInt32(r1[0]["NghiCheDo"].ToString()) + 1);

            //                }
            //                else if (dr["lydo"].ToString() == "15")
            //                {
            //                    r1[0]["NghiThaiSan"] = (Convert.ToInt32(r1[0]["NghiThaiSan"].ToString()) + 1);
            //                    r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + "ML";

            //                }
            //                else if (dr["lydo"].ToString() == "13")
            //                {
            //                    r1[0]["NghiKhac"] = (Convert.ToInt32(r1[0]["NghiKhac"].ToString()) + 1);
            //                    r1[0]["NghiKhongLuong"] = Convert.ToInt32(r1[0]["NghiKhongLuong"]) + 1;
            //                    r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + "#";

            //                }
            //                else if (dr["lydo"].ToString() == "8")
            //                {
            //                    r1[0]["NghiCheDo"] = (Convert.ToInt32(r1[0]["NghiCheDo"].ToString()) + 1);
            //                    r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + "CD";
            //                }
            //                else if (dr["lydo"].ToString() == "11")
            //                {
            //                    r1[0]["NghiKhongLuong"] = Convert.ToInt32(r1[0]["NghiKhongLuong"]) + 1;
            //                    r1[0]["NghiKhongLuongVM"] = (Convert.ToInt32(r1[0]["NghiKhongLuongVM"].ToString()) + 1);

            //                    r1[0]["D" + ((DateTime)dr["ngay"]).Day] = ketuquathuc + "LWP";
            //                }
            //            }
            //            else
            //            {
            //                if (Convert.ToBoolean(dr["tt_chuNhat"].ToString()) != true)
            //                {
            //                    r1[0]["SoNgayCong"] = (r1[0]["SoNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(r1[0]["SoNgayCong"])) + (dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"].ToString()));
            //                }
            //            }

            //            r = r1[0];
            //        }
            //    }
            //}
            #endregion
            dt = GetDataReportMonthExcel(typeSearch, Value, day, todates);
            DataTable dtResult = dt.Copy();
            foreach (DataRow row in dt.Rows)
            {
                DataRow newRow = dtResult.NewRow();
                newRow["EmployeeID"] = row["EmployeeID"];
                newRow["tenNV"] = row["tenNV"];
                newRow["vitri"] = "2";
                for (int i = 1; i <= 31; i++)
                {
                    newRow["D" + i] = row["T" + i];
                }
                dtResult.Rows.Add(newRow);
            }
            return dtResult.Select("", "EmployeeID,vitri ASC").CopyToDataTable();
        }

        public DataTable GetReportNhanVienVangMat(DateTime day, DateTime todates, int fieldSearch, string DepID)
        {
            DataTable data = logic.GetReportNhanVienVangMat(day, todates, fieldSearch, DepID);
            data.Columns.Add("loainghi");
            data.Columns.Add("songay");
            foreach (DataRow row in data.Rows)
            {
                row["songay"] = (((TimeSpan)row["denGio"] - (TimeSpan)row["tuGio"]).TotalHours > 8 ? 1 : (((TimeSpan)row["denGio"] - (TimeSpan)row["tuGio"]).TotalHours / 8)).ToString("0.0");
            }
            return data;
        }

        //public class Cong_item
        //{
        //    public double N1, N2, n3;//.....
        //}

        //public class bc_item
        //{


        //    public double luong;
        //    public string name;
        //    //...

        //    public Cong_item cong, tangca;

        //    public bc_item(DataRow dr)
        //    {
        //        luong = DbHelper.DrGetDouble(dr, "luong");
        //        name = DbHelper.DrGetString(dr, "ten");
        //        //..
        //    }

        //    public void TINHTOAN()
        //    {
        //        //tinh toan va gan luong
        //    }


        //    void write2exxcel(ExcelExportHelper ex, int x, int y)
        //    {
        //        //ex.write...
        //    }
        //}




        //public void GetBaoCao()
        //{
        //    DataTable dt = Provider.ExecuteDataTableReader("");

        //    var lst = new List<bc_item>();
        //    foreach (DataRow dr in dt.Rows)
        //        lst.Add(new bc_item(dr));

        //    ExcelExportHelper ex = new ExcelExportHelper();
        //    foreach (bc_item it in lst)
        //        it.write2exxcel(ex);

        //    //ex.Flush...
        //}









    }
}
