using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

using Ext.Net;
using System.Data;
using iHRM.WebPC.Code;
using iHRM.Common.Code;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic.Luong;
using iHRM.Core.Business;
using System.Data.SqlClient;
using iHRM.WebPC.Classes;
using iHRM.Core.Business.Logic;
using iHRM.Win.ExtClass.Luong;

namespace iHRM.WebPC.Cpanel.Luong
{
    public partial class ReportMonth : global::iHRM.WebPC.Code.BackEndPageBase
    {
        global::iHRM.Core.Business.DbObject.dcDatabaseDataContext db;
        global::iHRM.Core.Business.Logic.Luong.TinhLuong logic = new global::iHRM.Core.Business.Logic.Luong.TinhLuong();

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
            if (!IsPostBack)
            {
                txtDate1.SelectedDate = Core.Controller.QuetThe.Helper.GetStartDateSalaryCycle;
                txtDate2.SelectedDate = txtDate1.SelectedDate.AddMonths(1).AddDays(-1);

                LoadTreeData();

                wSendApproved_sendTo.Text = AllLogic.SysPa_Get("mail_send_approved");
                //wSendApproved_subject.Text = AllLogic.SysPa_Get("mail_send_approved");
                //wSendApproved_body.Text = AllLogic.SysPa_Get("mail_send_approved");
                Lng.Web_Language.Lng_SetControlTexts(this);

                StoInGroup1.DataSource = db.tblEmp_Group1s;
                StoInGroup1.DataBind();
            }
        }

        protected void btnView_DirectClick(object sender, DirectEventArgs e)
        {
            if (txtMaNVSearch.IsEmpty && cmbNhom1.SelectedIndex == -1 && h_depSelected.IsEmpty)
            {
                Tools.message(Lng.QuetThe_ReportMonth.msg_1);
                return;
            }
            DateTime tuNgay = txtDate1.SelectedDate;
            DateTime denNgay = txtDate2.SelectedDate;
            DataTable dtData;
            if (!txtMaNVSearch.IsEmpty)
            {
                dtData = logic.GetBangLuongByEmp(new DateTime(txtDate1.SelectedDate.Year, txtDate1.SelectedDate.Month, 1),
                                                txtMaNVSearch.Text.Trim('\n', '\r', '\t', ' '),
                                                tuNgay,
                                                denNgay,
                                                iHRM.Win.ExtClass.Luong.TinhLuongHelper.DemNgayCong(txtDate1.SelectedDate, txtDate2.SelectedDate));
            }
            else if (cmbNhom1.SelectedIndex > -1)
            {
                dtData = logic.GetBangLuongByGroup1(new DateTime(txtDate1.SelectedDate.Year, txtDate1.SelectedDate.Month, 1),
                                                    Convert.ToInt32(cmbNhom1.Value),
                                                    tuNgay,
                                                    denNgay,
                                                    TinhLuongHelper.DemNgayCong(txtDate1.SelectedDate, txtDate2.SelectedDate));
            }
            else
            {
                dtData = logic.GetBangLuong(new DateTime(txtDate1.SelectedDate.Year, txtDate1.SelectedDate.Month, 1),
                                            tuNgay,
                                            denNgay,
                                            h_depSelected.Value as string,
                                            TinhLuongHelper.DemNgayCong(txtDate1.SelectedDate, txtDate2.SelectedDate));
            }

            if (dtData == null || dtData.Rows.Count == 0)
            {
                Tools.message(Lng.Luong_ReportMonth.msg_1 + txtDate1.SelectedDate.Month + Lng.Luong_ReportMonth.nam + txtDate1.SelectedDate.Year);
                return;
            }

            sto1.DataSource = dtData;
            sto1.DataBind();
        }

        protected void grd_OnCommand(object sender, DirectEventArgs e)
        {
            try
            {
                string commandId = e.ExtraParams["id"];
                string commandName = e.ExtraParams["command"];

                switch (commandName)
                {
                    case "detail_NgayCong":
                        showDetail_NgayCong(e.ExtraParams["empoyeeID"]);
                        break;
                    case "detail_TangCa":
                        showDetail_TangCa(e.ExtraParams["empoyeeID"]);
                        break;
                    case "detail_PCK":
                        showDetail_PhuCap(e.ExtraParams["empoyeeID"]);
                        break;
                }
            }
            catch (Exception ex)
            {
                if (globall.indebug)
                    throw;

                Tools.messageEx(ex);
            }
        }

        private void showDetail_NgayCong(string empID)
        {
            dsTinhLuong ds = new dsTinhLuong();
            Provider.LoadDataByProc(ds, ds.p_tinhLuong_GetAllKetQuaQuetThe.TableName, "p_tinhLuong_GetAllKetQuaQuetThe",
                new SqlParameter("tuNgay", txtDate1.SelectedDate),
                new SqlParameter("denNgay", txtDate2.SelectedDate.AddDays(1)),
                new SqlParameter("empID", empID)
            );
            Provider.LoadDataByProc(ds, ds.tblEmpSalary.TableName, "p_tinhLuong_GetLuongCoBan",
                new SqlParameter("tuNgay", txtDate1.SelectedDate),
                new SqlParameter("denNgay", txtDate2.SelectedDate.AddDays(1))
            );

            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                new DataColumn("ngay", typeof(DateTime)),
                new DataColumn("TT"),
                new DataColumn("tgDiMuon", typeof(double)),
                new DataColumn("tgVeSom", typeof(double)),
                new DataColumn("ngayCong", typeof(double)),
                new DataColumn("tienCong", typeof(double)),
                new DataColumn("hsLuong", typeof(int))
            });



            TinhLuongHelper hp = new TinhLuongHelper(ds, txtDate1.SelectedDate, txtDate2.SelectedDate.AddDays(1), empID);
            foreach (dsTinhLuong.p_tinhLuong_GetAllKetQuaQuetTheRow kq in ds.p_tinhLuong_GetAllKetQuaQuetThe)
            {
                var r = dt.NewRow();
                hp.Set_KQQT(kq);

                r["ngay"] = kq.ngay;
                r["TT"] = Core.Controller.QuetThe.Helper.GetTrangThai(kq);
                if (kq["tgDiMuon"] != DBNull.Value)
                    r["tgDiMuon"] = Convert.ToInt32(kq["tgDiMuon"]) > 0 ? kq["tgDiMuon"] : 0;
                if (kq["tgVeSom"] != DBNull.Value)
                    r["tgVeSom"] = Convert.ToInt32(kq["tgVeSom"]) > 0 ? kq["tgVeSom"] : 0;
                r["hsLuong"] = kq["heSoLuong"] == DBNull.Value ? 100 : Convert.ToInt32(kq["heSoLuong"]);
                r["ngayCong"] = hp.TinhNgayCong();
                r["tienCong"] = hp.TinhTienNgayCong();

                dt.Rows.Add(r);
            }

            stoDetail.DataSource = dt;
            stoDetail.DataBind();

            grdDetail.ColumnModel.SetColumnHeader(0, Lng.Luong_ReportMonth.ngay + "<br />(" + dt.Rows.Count + ")");
            grdDetail.ColumnModel.SetColumnHeader(2, Lng.Luong_ReportMonth.tgDiMuon + "<br />(" + string.Format("{0:#,0}", dt.Compute("SUM(tgDiMuon)", "")) + ")");
            grdDetail.ColumnModel.SetColumnHeader(3, Lng.Luong_ReportMonth.tgVeSom + "<br />(" + string.Format("{0:#,0}", dt.Compute("SUM(tgVeSom)", "")) + ")");
            grdDetail.ColumnModel.SetColumnHeader(4, Lng.Luong_ReportMonth.ngaycong + "<br />(" + string.Format("{0:#,0.##}", dt.Compute("SUM(ngayCong)", "")) + ")");
            grdDetail.ColumnModel.SetColumnHeader(6, Lng.Luong_ReportMonth.tiencong + "<br />(" + string.Format("{0:#,0.##}", dt.Compute("SUM(tienCong)", "")) + ")");

            wDetail.Title = Lng.Luong_ReportMonth.title + empID;
            wDetail.Show();
        }

        private void showDetail_TangCa(string empID)
        {
            dsTinhLuong ds = new dsTinhLuong();
            Provider.LoadDataByProc(ds, ds.p_tinhLuong_GetAllKetQuaQuetThe.TableName, "p_tinhLuong_GetAllKetQuaQuetThe",
                new SqlParameter("tuNgay", txtDate1.SelectedDate),
                new SqlParameter("denNgay", txtDate2.SelectedDate.AddDays(1)),
                new SqlParameter("empID", empID)
            );
            Provider.LoadData(ds, ds.tbCaLam_TinhTangCa.TableName);

            Provider.LoadDataByProc(ds, ds.tblEmpSalary.TableName, "p_tinhLuong_GetLuongCoBan",
                new SqlParameter("tuNgay", txtDate1.SelectedDate),
                new SqlParameter("denNgay", txtDate2.SelectedDate.AddDays(1))
            );
            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                new DataColumn("ngay", typeof(DateTime)),
                new DataColumn("TT"),
                new DataColumn("tgTinhTangCa", typeof(double)),
                new DataColumn("tienTangCa", typeof(double))
            });
            TinhLuongHelper hp = new TinhLuongHelper(ds, txtDate1.SelectedDate, txtDate2.SelectedDate.AddDays(1), empID);
            foreach (dsTinhLuong.p_tinhLuong_GetAllKetQuaQuetTheRow kq in ds.p_tinhLuong_GetAllKetQuaQuetThe)
            {
                var r = dt.NewRow();
                hp.Set_KQQT(kq);

                r["ngay"] = kq.ngay;
                r["TT"] = Core.Controller.QuetThe.Helper.GetTrangThai(kq);
                r["tgTinhTangCa"] = kq["tgTinhTangCa"] != DBNull.Value ? Convert.ToDouble(kq["tgTinhTangCa"]) : 0;
                r["tienTangCa"] = hp.TinhTienTangCa();

                dt.Rows.Add(r);
            }

            stoDetail_TC.DataSource = dt;
            stoDetail_TC.DataBind();
            grdDetail_TC.ColumnModel.SetColumnHeader(0, Lng.Luong_ReportMonth.ngay + "<br />(" + dt.Rows.Count + ")");
            grdDetail_TC.ColumnModel.SetColumnHeader(2, Lng.Luong_ReportMonth.tangca + "<br />(" + string.Format("{0:#,0}", dt.Compute("SUM(tgTinhTangCa)", "")) + ")");
            grdDetail_TC.ColumnModel.SetColumnHeader(3, Lng.Luong_ReportMonth.TienTangCa + "<br />(" + string.Format("{0:#,0.#}", dt.Compute("SUM(tienTangCa)", "")) + ")");

            wDetail_TC.Title = Lng.Luong_ReportMonth.title3 + empID;
            wDetail_TC.Show();
        }

        private void showDetail_PhuCap(string empID)
        {
            dsTinhLuong ds = new dsTinhLuong();
            Provider.LoadData(ds, ds.tblRef_Allowance.TableName);
            Provider.LoadDataByProc(ds, ds.tbThamSoTinhLuong.TableName, "p_tinhLuong_GetThamSoTinhLuong",
                new SqlParameter("thang", new DateTime(txtDate1.SelectedDate.Year, txtDate1.SelectedDate.Month, 1)),
                new SqlParameter("empID", empID)
            );

            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                new DataColumn("PC"),
                new DataColumn("TT", typeof(float))
            });

            var ts = ds.tbThamSoTinhLuong.FirstOrDefault(i => i.employeeID == empID);
            if (ts != null)
            {
                for (int i = 1; i < 11; i++)
                {
                    var r = dt.NewRow();
                    var a = ds.tblRef_Allowance.FirstOrDefault(it => it.AllowanceID == "PC" + i);
                    if (a != null)
                        r["PC"] = a.AllowanceName;

                    if (ts["PC" + i] != DBNull.Value && Convert.ToDouble(ts["PC" + i]) > 0)
                    {
                        r["TT"] = ts["PC" + i];
                        dt.Rows.Add(r);
                    }
                }
            }

            stoDetail_PK.DataSource = dt;
            stoDetail_PK.DataBind();

            grdDetail_PK.ColumnModel.SetColumnHeader(0, Lng.Luong_ReportMonth.khoanphucap + "<br />(" + dt.Rows.Count + ")");
            grdDetail_PK.ColumnModel.SetColumnHeader(1, Lng.Luong_ReportMonth.sotien + "<br />(" + string.Format("{0:#,0}", dt.Compute("SUM(TT)", "")) + ")");

            wDetail_PK.Title = Lng.Luong_ReportMonth.title2 + empID;
            wDetail_PK.Show();
        }

        protected void sto_SubmitData4Excel(object sender, StoreSubmitDataEventArgs e)
        {
            ExportExcel4extGridOnSubmitData(e.Xml);
        }
        #region treeview
        void LoadTreeData()
        {
            var cty = db.tblRef_Companies.FirstOrDefault();
            var dt = db.tblRef_Departments.ToList();
            Ext.Net.TreeNode n = new Ext.Net.TreeNode("<<ROOT>>",
                string.IsNullOrWhiteSpace(cty.CompanyName) ? "Smart Shirts" : cty.CompanyName,
                Ext.Net.Icon.None
            );

            LoadTreeNode(null, n, dt);

            TreeFunc.Root.Clear();
            TreeFunc.Root.Add(n);
            n.Expanded = true;
        }
        void LoadTreeNode(string parentid, Ext.Net.TreeNode node, List<tblRef_Department> dt)
        {
            var lst2 = dt.Where(i => i.DepParent == parentid).OrderBy(i => i.OrderNo);
            node.Leaf = (lst2 == null || lst2.Count() == 0);
            foreach (var item in lst2)
            {
                Ext.Net.TreeNode n = getNodebyFunction(item);
                LoadTreeNode(item.DepID, n, dt);

                node.Nodes.Add(n);
            }
        }
        Ext.Net.TreeNode getNodebyFunction(tblRef_Department f)
        {
            if (f == null)
                return null;
            return new Ext.Net.TreeNode(f.DepID, GetFunctionHtmlCaption(f), Ext.Net.Icon.None);
        }
        private string GetFunctionHtmlCaption(tblRef_Department f)
        {
            if (f == null)
            {
                var cty = db.tblRef_Companies.FirstOrDefault();
                return string.Format("<span class='nodecode'>{0}</span> <span class='nodecaption'>[{1}]</span>",
                    string.IsNullOrWhiteSpace(cty.CompanyID) ? "SS" : cty.CompanyID,
                    string.IsNullOrWhiteSpace(cty.CompanyName) ? "Smart Shirts" : cty.CompanyName
                );
            }

            return string.Format("<span class='nodecode'>{0}</span> <span class='nodecaption'>[{1}]</span>", f.DepID, f.DepName);
        }

        protected void btnEdit_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            h_depSelected.SetValue("");
            DefaultSelectionModel rsm = TreeFunc.SelectionModel.Primary as DefaultSelectionModel;
            if (rsm == null || rsm.SelectedNode == null)
            {
                Tools.messageConfirmErr(Lng.common_msg.Please_Choose_Data);
                return;
            }
            var f = db.tblRef_Departments.SingleOrDefault(i => i.DepID == rsm.SelectedNode.NodeID);
            if (f == null)
            {
                Tools.messageConfirmErr(Lng.Category_Department.Do_Not_Access_Root);
                return;
            }
            else
            {
                cbophong.SetValue(f.DepName, f.DepID);
                h_depSelected.SetValue(f.DepID);
            }
        }
        #endregion
        private string getMonthName(int numMonth)
        {
            string strMonth = "";
            //List<int> _lMonth = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            List<string> _lMonthName = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            strMonth = _lMonthName[numMonth - 1];
            return strMonth;
        }
        protected void btnExcel_DirectClick(object sender, DirectEventArgs e)
        {
            #region get data
            DataTable dt;
            if (txtMaNVSearch.IsEmpty)
            {
                dt = logic.GetBangLuongChiTiet(new DateTime(txtDate1.SelectedDate.Year, txtDate1.SelectedDate.Month, 1), 
                                               h_depSelected.Value as string,
                                               txtDate1.SelectedDate.Date,
                                               txtDate2.SelectedDate.Date, 
                                               TinhLuongHelper.DemNgayCong(txtDate1.SelectedDate, txtDate2.SelectedDate)
                                               );
            }
            else
            {

                dt = logic.GetBangLuongChiTiet_WithEmp(new DateTime(txtDate1.SelectedDate.Year, txtDate1.SelectedDate.Month, 1),
                                                    txtMaNVSearch.Text.Trim('\n', '\r', '\t', ' '),
                                                    txtDate1.SelectedDate.Date,
                                                    txtDate2.SelectedDate.Date, 
                                                    TinhLuongHelper.DemNgayCong(txtDate1.SelectedDate, txtDate2.SelectedDate));
            }

            if (dt == null || dt.Rows.Count == 0)
            {
                Tools.message(Lng.Luong_ReportMonth.msg_1 + txtDate1.SelectedDate.Month + Lng.Luong_ReportMonth.nam + txtDate1.SelectedDate.Year);
                return;
            }
            //var dt2 = ExcelExportHelper.CreateGroupInDT(dt, "DepName", "STT");
            #endregion

            ExcelExportHelper ex = new ExcelExportHelper("Luong/monthlySalary.xls");
            //if (string.IsNullOrWhiteSpace(h_depSelected.Value as string))
            //    ex.WriteToCell("A3", System.Configuration.ConfigurationManager.AppSettings["SS_Dep"]);
            //else
            ex.WriteToCell("A1", db.w5Systems.Where(p => p.Ma == "TitlePhieuLuong").FirstOrDefault().KeywordVN.ToUpper());
            ex.WriteToCell("A3", string.Format("BẢNG THANH TOÁN TIỀN LƯƠNG THÁNG {0} NĂM {1}", txtDate2.SelectedDate.Month, txtDate2.SelectedDate.Year));
            ex.WriteToCell("A4", string.Format("SALARY IN {0} {1}", getMonthName(txtDate2.SelectedDate.Month).ToUpper(), txtDate2.SelectedDate.Year));
            ex.WriteToCell("A6", string.Format("Cycle Salary: {0:dd/MM/yyyy} ~ {1:dd/MM/yyyy}", txtDate1.SelectedDate, txtDate2.SelectedDate));

            dt.Columns.Add("laBangLuongCu2", typeof(string));
            foreach (DataRow dr in dt.Rows)
            {
                dr["tgTangCa_cn"] = ((dr["tgTangCa_cn"] as double?) ?? 0) + ((dr["ngaycong_cn"] as double?) ?? 0);
                dr["tienTangCa_cn"] = ((dr["tienTangCa_cn"] as double?) ?? 0) + ((dr["tienNC_cn"] as double?) ?? 0);

                //double tongPhuCapKhac = 0;
                //double tongKhauTru = 0;
                //for (int i = 1; i < 21; i++)
                //{
                //    double pc = ((dr["PC" + i] as double?) ?? 0);
                //    if (pc > 0)
                //        tongPhuCapKhac += pc;
                //    else
                //        tongKhauTru += pc;
                //}
                //dr["tongPhuCapKhac"] = tongPhuCapKhac;
                //dr["tongKhauTru"] = tongKhauTru;
                dr["laBangLuongCu2"] = (DbHelper.DrGetBoolean(dr, "laBangLuongCu") == true ? "cũ" : "");
            }
            ex.FillDataTable(dt);
            ex.RendAndFlush("BangLuongChiTiet_"+DbHelper.DrGetString(LoginHelper.Dept, "code"));
        }

        protected void btnSendApproved_DirectClick(object sender, DirectEventArgs e)
        {
            try
            {
                SendMailExchange sm = new SendMailExchange(AllLogic.SysPa_Get("mail_u"), AllLogic.SysPa_Get("mail_p"));
                sm.sendMailTo(wSendApproved_sendTo.Text, wSendApproved_subject.Text, wSendApproved_body.Text);
                Tools.message("Send success");
                wSendApproved.Hide();
            }
            catch (Exception ex)
            {
                Tools.messageEx(ex);
            }
        }

        [DirectMethod]
        public int demngaycong(string beginDate, string endDate)
        {
            return TinhLuongHelper.DemNgayCong(Convert.ToDateTime(beginDate.Replace("\"", "")), Convert.ToDateTime(endDate.Replace("\"", ""))); // A chơi 2 thằng này em xem luôn đi
        }
    }
}