using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.IO;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using System.Xml;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic.Luong;
using iHRM.Core.Business;
using System.Data.SqlClient;
using iHRM.WebPC.Classes;
using iHRM.Win.ExtClass.Luong;

namespace iHRM.WebPC.Cpanel.Luong
{
    public partial class PheDuyetBangLuong : global::iHRM.WebPC.Code.BackEndPageBase
    {
        global::iHRM.Core.Business.DbObject.dcDatabaseDataContext db;
        global::iHRM.Core.Business.Logic.Luong.TinhLuong logic = new global::iHRM.Core.Business.Logic.Luong.TinhLuong();

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
            if (!IsPostBack)
            {
                LoadTreeData();
                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }

        protected void btnView_DirectClick(object sender, DirectEventArgs e)
        {
            DateTime tuNgay = new DateTime(txtDate.SelectedDate.Year, txtDate.SelectedDate.Month, 17);
            DateTime denNgay = new DateTime(txtDate.SelectedDate.AddMonths(1).Year, txtDate.SelectedDate.AddMonths(1).Month, 16);
            var dtData = logic.GetBangLuong(txtDate.SelectedDate,
                                            tuNgay,
                                            denNgay,
                                            h_depSelected.Value as string);
            if (dtData == null || dtData.Rows.Count == 0)
            {
                Tools.message(Lng.Luong_PheDuyetBangLuong.msg_1 + txtDate.SelectedDate.Month + Lng.Luong_PheDuyetBangLuong.nam + txtDate.SelectedDate.Year);
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
                new SqlParameter("tuNgay", txtDate.SelectedDate),
                new SqlParameter("denNgay", txtDate.SelectedDate.AddMonths(1)),
                new SqlParameter("empID", empID)
            );

            Provider.LoadDataByProc(ds, ds.tblEmpSalary.TableName, "p_tinhLuong_GetLuongCoBan",
                new SqlParameter("tuNgay", txtDate.SelectedDate),
                new SqlParameter("denNgay", txtDate.SelectedDate.AddMonths(1))
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



            TinhLuongHelper hp = new TinhLuongHelper(ds, txtDate.SelectedDate, txtDate.SelectedDate.AddMonths(1), empID);
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

            grdDetail.ColumnModel.SetColumnHeader(0, Lng.Luong_PheDuyetBangLuong.ngay + "<br />(" + dt.Rows.Count + ")");
            grdDetail.ColumnModel.SetColumnHeader(2, Lng.Luong_PheDuyetBangLuong.tgDiMuon + "<br />(" + string.Format("{0:#,0}", dt.Compute("SUM(tgDiMuon)", "")) + ")");
            grdDetail.ColumnModel.SetColumnHeader(3, Lng.Luong_PheDuyetBangLuong.tgVeSom + "<br />(" + string.Format("{0:#,0}", dt.Compute("SUM(tgVeSom)", "")) + ")");
            grdDetail.ColumnModel.SetColumnHeader(4, Lng.Luong_PheDuyetBangLuong.ngaycong + "<br />(" + string.Format("{0:#,0.##}", dt.Compute("SUM(ngayCong)", "")) + ")");
            grdDetail.ColumnModel.SetColumnHeader(6, Lng.Luong_PheDuyetBangLuong.tiencong + "<br />(" + string.Format("{0:#,0.##}", dt.Compute("SUM(tienCong)", "")) + ")");

            wDetail.Title = Lng.Luong_ReportMonth.title + empID;
            wDetail.Show();
        }

        private void showDetail_TangCa(string empID)
        {
            dsTinhLuong ds = new dsTinhLuong();
            Provider.LoadDataByProc(ds, ds.p_tinhLuong_GetAllKetQuaQuetThe.TableName, "p_tinhLuong_GetAllKetQuaQuetThe",
                new SqlParameter("tuNgay", txtDate.SelectedDate),
                new SqlParameter("denNgay", txtDate.SelectedDate.AddMonths(1)),
                new SqlParameter("empID", empID)
            );
            Provider.LoadData(ds, ds.tbCaLam_TinhTangCa.TableName);

            Provider.LoadDataByProc(ds, ds.tblEmpSalary.TableName, "p_tinhLuong_GetLuongCoBan",
                new SqlParameter("tuNgay", txtDate.SelectedDate),
                new SqlParameter("denNgay", txtDate.SelectedDate.AddMonths(1))
            );

            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                new DataColumn("ngay", typeof(DateTime)),
                new DataColumn("TT"),
                new DataColumn("tgTinhTangCa", typeof(double)),
                new DataColumn("tienTangCa", typeof(double))
            });



            TinhLuongHelper hp = new TinhLuongHelper(ds, txtDate.SelectedDate, txtDate.SelectedDate.AddMonths(1), empID);
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

            grdDetail_TC.ColumnModel.SetColumnHeader(0, Lng.Luong_PheDuyetBangLuong.ngay + "<br />(" + dt.Rows.Count + ")");
            grdDetail_TC.ColumnModel.SetColumnHeader(2, Lng.Luong_PheDuyetBangLuong.tangca + "<br />(" + string.Format("{0:#,0}", dt.Compute("SUM(tgTinhTangCa)", "")) + ")");
            grdDetail_TC.ColumnModel.SetColumnHeader(3, Lng.Luong_PheDuyetBangLuong.TienTangCa + "<br />(" + string.Format("{0:#,0.#}", dt.Compute("SUM(tienTangCa)", "")) + ")");

            wDetail_TC.Title = Lng.Luong_PheDuyetBangLuong.title + empID;
            wDetail_TC.Show();
        }

        private void showDetail_PhuCap(string empID)
        {
            dsTinhLuong ds = new dsTinhLuong();
            Provider.LoadData(ds, ds.tblRef_Allowance.TableName);
            Provider.LoadDataByProc(ds, ds.tbThamSoTinhLuong.TableName, "p_tinhLuong_GetThamSoTinhLuong", 
                new SqlParameter("thang", txtDate.SelectedDate),
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

            grdDetail_PK.ColumnModel.SetColumnHeader(0, Lng.Luong_PheDuyetBangLuong.khoanphucap + "<br />(" + dt.Rows.Count + ")");
            grdDetail_PK.ColumnModel.SetColumnHeader(1, Lng.Luong_PheDuyetBangLuong.sotien + "<br />(" + string.Format("{0:#,0}", dt.Compute("SUM(TT)", "")) + ")");

            wDetail_PK.Title = Lng.Luong_PheDuyetBangLuong.title2 + empID;
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



        protected void btnExcel_DirectClick(object sender, DirectEventArgs e)
        {
            Classes.ExcelExportHelper ex = new Classes.ExcelExportHelper("Luong/monthlySalary.xls");
            if (string.IsNullOrWhiteSpace(h_depSelected.Value as string))
                ex.WriteToCell("A3", System.Configuration.ConfigurationManager.AppSettings["SS_Dep"]);
            else
                ex.WriteToCell("A3", cbophong.Text);
            ex.WriteToCell("A5", string.Format(Lng.Luong_PheDuyetBangLuong.bangluongthang +"{0:MM/yyyy}", txtDate.SelectedDate));
            ex.WriteToCell("A6", string.Format("SALARY IN {0:MM/yyyy}", txtDate.SelectedDate));
            ex.WriteToCell("A7", string.Format( Lng.Luong_PheDuyetBangLuong.chukyluong+": {0:dd/MM/yyyy} ~ {1:dd/MM/yyyy}", txtDate.SelectedDate, txtDate.SelectedDate.AddMonths(1).AddDays(-1)));

            var dt = logic.GetBangLuongChiTiet(txtDate.SelectedDate, h_depSelected.Value as string, txtDate.SelectedDate, txtDate.SelectedDate.AddMonths(1).AddDays(-1));
            BangLuongChiTiet_recalc(dt);
            var dt2 = Common.Code.baseExcelExportHelper.CreateGroupInDT(dt, "DepName", "STT");

            ex.FillDataTable(dt2);
            ex.RendAndFlush("BangLuongChiTiet");
        }

        private void BangLuongChiTiet_recalc(DataTable dt)
        {
            dsTinhLuong ds = new dsTinhLuong();
            Provider.LoadDataByProc(ds, ds.p_tinhLuong_GetAllKetQuaQuetThe.TableName, "p_tinhLuong_GetAllKetQuaQuetThe",
                new SqlParameter("tuNgay", txtDate.SelectedDate),
                new SqlParameter("denNgay", txtDate.SelectedDate.AddMonths(1))
            );
            Provider.LoadData(ds, ds.tbCaLam_TinhTangCa.TableName);
            Provider.LoadDataByProc(ds, ds.tbThamSoTinhLuong.TableName, "p_tinhLuong_GetThamSoTinhLuong", new SqlParameter("thang", txtDate.SelectedDate));

            Provider.LoadDataByProc(ds, ds.tblEmpSalary.TableName, "p_tinhLuong_GetLuongCoBan",
                new SqlParameter("tuNgay", txtDate.SelectedDate),
                new SqlParameter("denNgay", txtDate.SelectedDate.AddMonths(1))
            );

            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("_ngaycong_bt",      typeof(double))
                ,new DataColumn("_ngaycong_phep",   typeof(double))
                ,new DataColumn("_ngaycong_lt",     typeof(double))
                ,new DataColumn("_tangca_bt",       typeof(double))
                ,new DataColumn("_tangca_cn",       typeof(double))
                ,new DataColumn("_tangca_lt",       typeof(double))
                ,new DataColumn("_luongNC_ngay",    typeof(double))
                ,new DataColumn("_luongNC_phep",    typeof(double))
                ,new DataColumn("_luongNC_lt",      typeof(double))
                ,new DataColumn("_luongTC_bt",    typeof(double))
                ,new DataColumn("_luongTC_cn",    typeof(double))
                ,new DataColumn("_luongTC_lt",      typeof(double))
                ,new DataColumn("_AC",      typeof(double))
                ,new DataColumn("_AE",      typeof(double))
                ,new DataColumn("_AF",      typeof(double))
                ,new DataColumn("_AG",      typeof(double))
                ,new DataColumn("_AH",      typeof(double))
                ,new DataColumn("_AK",      typeof(double))
                ,new DataColumn("_AL",      typeof(double))
            });
            for (int i = 1; i < 11; i++)
                dt.Columns.Add(new DataColumn("PC" + i, typeof(double)));



            //TinhLuongHelper hp = new TinhLuongHelper(ds, txtDate.SelectedDate, txtDate.SelectedDate.AddMonths(1));
            foreach (DataRow r in dt.Rows)
            {
                //var kqs = ds.p_tinhLuong_GetAllKetQuaQuetThe.Where(i => i.EmployeeID == r["EmployeeID"] as string).ToList();

                //r["_ngaycong_bt"] = kqs.Sum(i => hp.TinhNgayCong(i, 1));
                //r["_ngaycong_phep"] = kqs.Sum(i => hp.TinhNgayCong(i, 2));
                //r["_ngaycong_lt"] = kqs.Sum(i => hp.TinhNgayCong(i, 3));

                //r["_tangca_bt"] = kqs.Sum(i => hp.TinhGioTangCa(i, 1));
                //r["_tangca_cn"] = 0;
                //r["_tangca_lt"] = kqs.Sum(i => hp.TinhGioTangCa(i, 2));

                //r["_luongNC_ngay"] = kqs.Sum(i => hp.TinhTienNgayCong(i, 1));
                //r["_luongNC_phep"] = kqs.Sum(i => hp.TinhTienNgayCong(i, 2));
                //r["_luongNC_lt"] = kqs.Sum(i => hp.TinhTienNgayCong(i, 3));

                //r["_luongTC_bt"] = kqs.Sum(i => hp.TinhTienTangCa(i, 1));
                //r["_luongTC_cn"] = 0;
                //r["_luongTC_lt"] = kqs.Sum(i => hp.TinhTienTangCa(i, 2));

                //var pcK = ds.tbThamSoTinhLuong.Where(i => i.employeeID == r["EmployeeID"] as string).FirstOrDefault();
                //if (pcK != null)
                //{
                //    for (int i = 1; i < 11; i++)
                //        r["PC" + i] = pcK["PC" + i];
                //}

                //double tongluong = DbHelper.DrGetDouble(r, "tongLuong");
                //r["_AC"] = tongluong * 22 / 100;
                //r["_AE"] = tongluong * 8 / 100;
                //r["_AF"] = tongluong * 1.5 / 100;
                //r["_AG"] = tongluong * 1 / 100;
                //r["_AH"] = tongluong * 2 / 100;
                //r["_AK"] = tongluong * 12 / 100;
                //r["_AL"] = tongluong - DbHelper.DrGetDouble(r, "_AL");
            }
        }









        protected void btnApprovedAll_DirectClick(object sender, DirectEventArgs e)
        {
            var sm = grd.SelectionModel.Primary as RowSelectionModel;
            if (sm.SelectedRows.Count > 0)
            {
                int status = 0;
                if (sender == btnApprovedAll)
                    status = 1;
                if (sender == btnRejectAll)
                    status = 2;
                if (sender == btnReviseAll)
                    status = 3;

                int totalOk = 0;
                foreach (var row in sm.SelectedRows)
                    totalOk += logic.UpdateApprovedStt(new Guid(row.RecordID), status);

                Tools.message(Lng.common_msg.Edit_Success + " (" + totalOk + ")");
                btnView_DirectClick(null, null);
            }
            else
            {
                Tools.message(Lng.common_msg.Please_Choose_Data);
            }
        }


    }
}