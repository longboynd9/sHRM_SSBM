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
using iHRM.WebPC.Code;
using iHRM.Common.Code;
using System.Xml;
using iHRM.Core.Business.DbObject;

namespace iHRM.WebPC.Cpanel.QuetThe
{
    public partial class ReportMonth : Code.BackEndPageBase
    {
        Core.Business.Logic.ChamCong.ReportMonthLogic logic = new Core.Business.Logic.ChamCong.ReportMonthLogic();
        Core.Controller.QuetThe.ReportMonth controler = new Core.Controller.QuetThe.ReportMonth();
        dcDatabaseDataContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

            if (!IsPostBack)
            {
                txtDate1.SelectedDate = Core.Controller.QuetThe.Helper.GetStartDateSalaryCycle;
                txtDate2.SelectedDate = txtDate1.SelectedDate.AddMonths(1).AddDays(-1);

                LoadTreeData();
                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }
        protected void btnView_DirectClick(object sender, DirectEventArgs e)
        {
            if (txtMaNVSearch.IsEmpty && h_depSelected.IsEmpty)
            {
                Tools.message(Lng.QuetThe_ReportMonth.msg_1);
                return;
            }

            DataTable dtData = controler.GetData(txtMaNVSearch.Text, h_depSelected.Value as string, null, txtDate1.SelectedDate, txtDate2.SelectedDate.AddDays(1));
            if (dtData == null || dtData.Rows.Count == 0)
            {
                Tools.message(Lng.common_msg.RecordNotFound);
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
                    case "detail":
                        showDetail(commandId, e.ExtraParams["tenNV"]);
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

        protected void grd_OnDblClick(object sender, DirectEventArgs e)
        {
            try
            {
                CellSelectionModel csm = grd.SelectionModel.Primary as CellSelectionModel;
                showDetail(csm.SelectedCell.RecordID, Lng.QuetThe_ReportMonth.detail + "[" + csm.SelectedCell.RecordID + "]");
            }
            catch (Exception ex)
            {
                if (globall.indebug)
                    throw;

                Tools.messageEx(ex);
            }
        }

        void showDetail(string idNV, string title)
        {
            wDetail.Title = title;
            h_detaiID.Value = idNV;
            var dt = logic.GetReportMonth_4Emp(txtDate1.SelectedDate, txtDate2.SelectedDate.AddDays(1), idNV);
            dt.Columns.Add("TT");
            dt.Columns.Add("tgTangCa", typeof(double));
            foreach (DataRow dr in dt.Rows)
            {
                dr["TT"] = Core.Controller.QuetThe.Helper.GetTrangThai(dr, 2);
                if (dr["tgDiMuon"] != DBNull.Value && Convert.ToInt32(dr["tgDiMuon"]) < 0)
                    dr["tgDiMuon"] = 0;
                if (dr["tgVeSom"] != DBNull.Value && Convert.ToInt32(dr["tgVeSom"]) < 0)
                {
                    dr["tgTangCa"] = -1 * Convert.ToInt32(dr["tgVeSom"]);
                    dr["tgVeSom"] = 0;
                }
            }
            stoDetail.DataSource = dt;
            stoDetail.DataBind();
            wDetail.Show();

            stt_Ngay.Text = "Tổng: " + dt.Rows.Count;
            stt_CongWD.Text = string.Format("WD: {0:0.##} ({1:0.##})", dt.Compute("SUM(kqNgayCong)", "tt_chuNhat=0"), dt.Compute("SUM(tgTinhTangCa)", "tt_chuNhat=0"));
            stt_CongCN.Text = string.Format("CN: {0:0.##} ({1:0.##})", dt.Compute("SUM(kqNgayCong)", "tt_chuNhat=1"), dt.Compute("SUM(tgTinhTangCa)", "tt_chuNhat=1"));
            stt_DSVM.Text = string.Format("ĐM: {0:#,0} - VS: {1:#,0} - LT: {2} - VM: {3}",
                dt.Compute("SUM(tgDiMuon)", ""),
                dt.Compute("SUM(tgVeSom)", ""),
                dt.Compute("SUM(tt_leTet)", ""),
                dt.Compute("SUM(tt_nghiPhep)", "")
            );
        }

        protected void stoDetail_BeforeStoreChanged(object sender, BeforeStoreChangedEventArgs e)
        {
            XmlDocument doc = e.DataHandler.XmlData;
            string exMsg = "";
            foreach (XmlNode updated in doc.SelectNodes("/records/Updated/record"))
            {
                try
                {
                    Guid id = new Guid(updated.SelectSingleNode("id").InnerText);
                    TimeSpan tgQuetDen = ParseTime(updated.SelectSingleNode("tgQuetDen").InnerText);
                    TimeSpan tgQuetVe = ParseTime(updated.SelectSingleNode("tgQuetVe").InnerText);
                    iHRM.Win.ExtClass.QuetThe.QuetThe.SetTimeQT(id, tgQuetDen, tgQuetVe, force: true, userLoginin: LoginHelper.user);
                }
                catch (Exception ex)
                {
                    exMsg += ex.Message + "\n";
                }
            }
            e.Cancel = true;
            if (exMsg == "")
            {
                Tools.message(Lng.QuetThe_ReportMonth.msg_4);
            }
            else
            {
                Tools.messageConfirmErr(exMsg);
            }
            X.AddScript("btnReloadDetail.fireEvent('click');");
        }

        TimeSpan ParseTime(string s)
        {
            TimeSpan ts = new TimeSpan();

            if (!string.IsNullOrWhiteSpace(s))
            {
                try
                {
                    string[] a = s.Split(':');
                    ts = ts.Add(new TimeSpan(int.Parse(a[0]), a.Length > 1 ? int.Parse(a[1]) : 0, a.Length > 2 ? int.Parse(a[2]) : 0));
                }
                catch { }
            }
            return ts;
        }

        protected void btnReloadDetail_DirectClick(object sender, DirectEventArgs e)
        {
            showDetail(h_detaiID.Value as string, Lng.QuetThe_ReportMonth.detail + "[" + h_detaiID.Value + "]");
        }

        protected void sto1_SubmitData(object sender, StoreSubmitDataEventArgs e)
        {
            ExportExcel4extGridOnSubmitData(e.Xml);
        }

        protected void stoDetail_SubmitData(object sender, StoreSubmitDataEventArgs e)
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

    }
}