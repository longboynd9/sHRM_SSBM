using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong
{
    public partial class ThamSoTinhLuong : frmBase
    {
        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        dlgThamSoTinhLuong dlgEditor;
        impThamSoTinhLuong frmImp;

        public ThamSoTinhLuong()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            txtThang.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            LoadAllowance();
            LoadGrvLayout(grv);
        }

        private void LoadAllowance()
        {
            int idx = 4;
            grv.Columns.Remove(gridColumn4);
            grv.Columns.Remove(gridColumn1);
            foreach (DataRow dr in CacheDataTable.GetCacheDataTable(TableConst.tblRef_Allowance.TableName).Rows)
            {
                DevExpress.XtraGrid.Columns.GridColumn g = grv.Columns.Add();
                g.Caption = dr[TableConst.tblRef_Allowance.AllowanceName].ToString();
                g.DisplayFormat.FormatString = "#,0";
                g.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                g.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
                g.AppearanceCell.Options.UseFont = true;
                g.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                g.AppearanceHeader.Options.UseFont = true;
                g.BestFit();
                g.FieldName = dr[TableConst.tblRef_Allowance.AllowanceID].ToString();
                g.Visible = true;
                g.VisibleIndex = idx;

                idx += 1;
                grv.Columns.Add(g);
                grv.BestFitColumns(true);
            }
            grv.Columns.Add(gridColumn1);
            grv.Columns.Add(gridColumn4);
            gridColumn1.VisibleIndex = idx - 1;
            gridColumn4.VisibleIndex = idx;


        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu tham số tính lương...";
            dw_it.OnDoing = (s,ev) =>
            {
                var dt = Provider.ExecuteDataTableReader("p_tinhLuong_GetThamSoTinhLuong4Show"
                    , new SqlParameter("keyword", txtSearchKey.Text == "" ? null : txtSearchKey.Text)
                    , new SqlParameter("thang", new DateTime(txtThang.DateTime.Year, txtThang.DateTime.Month, 1))
                    , new SqlParameter("depID", chonPhongBan1.SelectedValue)
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
                var emp = db.tbThamSoTinhLuongs.SingleOrDefault(i => i.id == (dr[TableConst.tbKetQuaQuetThe.id] as Guid?));

                if (emp == null)
                {
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                }
                else
                {
                    try
                    {
                        db.tbThamSoTinhLuongs.DeleteOnSubmit(emp);
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
            var lst = db.tbThamSoTinhLuongs.Where(i => drs.Select(j => j[TableConst.tbKetQuaQuetThe.id] as Guid?).Contains(i.id));

            if (lst == null || lst.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                return;
            }

            try
            {
                db.tbThamSoTinhLuongs.DeleteAllOnSubmit(lst);
                db.SubmitChanges();

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                grv.DeleteSelectedRows();
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dlgEditor == null)
            {
                dlgEditor = new dlgThamSoTinhLuong();
                dlgEditor.Owner = this;
            }
            dlgEditor.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (frmImp == null)
            {
                frmImp = new impThamSoTinhLuong();
                frmImp.Owner = this;
            }
            frmImp.Show();
        }

        private void grv_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column == gridColumn4)
            {
                var drs = grv.GetSelectedRows().Select(i => grv.GetDataRow(i));
                if (drs.Count() == 0)
                {
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                    return;
                }

                var db = new dcDatabaseDataContext(Provider.ConnectionString);
                var lst = db.tbThamSoTinhLuongs.Where(i => drs.Select(j => j[TableConst.tbKetQuaQuetThe.id] as Guid?).Contains(i.id));

                if (lst == null || lst.Count() == 0)
                {
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                    return;
                }

                try
                {
                    db.tbThamSoTinhLuongs.DeleteAllOnSubmit(lst);
                    db.SubmitChanges();

                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                    grv.DeleteSelectedRows();
                }
                catch (Exception ex)
                {
                    win_globall.ExecCatch(ex);
                }
            }
            else if (e.Column == gridColumn1)
            {
                DataTable dtAllowance = new DataTable();
                dtAllowance.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("AllowanceID"),
                    new DataColumn("AllowanceName"),
                    new DataColumn("Value")
                });

                foreach (DataRow dr in CacheDataTable.GetCacheDataTable(TableConst.tblRef_Allowance.TableName).Rows)
                {
                    var dr1 = dtAllowance.NewRow();
                    dr1["AllowanceID"] = dr[TableConst.tblRef_Allowance.AllowanceID];
                    dr1["AllowanceName"] = dr[TableConst.tblRef_Allowance.AllowanceName];
                    dr1["Value"] = 0;

                    dtAllowance.Rows.Add(dr1);
                }
                DateTime thang = ((DateTime)grv.GetRowCellValue(e.RowHandle, gridColumn5)).Date;
                string employeeID = grv.GetRowCellValue(e.RowHandle, gridColumn10).ToString();
                var a = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * FROM tbThamSoTinhLuong WHERE thang='{0:yyyy-MM-dd}' AND employeeID='{1}'", thang, employeeID));
                try
                {
                    for (int i = 1; i <= 20; i++)
                    {
                        dtAllowance.Select("AllowanceID = 'PC" + i + "'").First()["Value"] = a.Rows[0]["PC" + i];
                    }
                }
                catch (Exception)
                {
                }
                new dlgThamSoTinhLuong(dtAllowance, thang, employeeID).ShowDialog();
            }
        }
    }
}
