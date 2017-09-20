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
    public partial class DataTinhLuong : frmBase
    {
        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();
        //dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        //dlgThamSoTinhLuong dlgEditor;
        impDataTinhLuong frmImp;

        public DataTinhLuong()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            txtThang.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            LoadGrvLayout(grv);
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
                    catch(Exception ex)
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
            //if (dlgEditor == null)
            //{
            //    dlgEditor = new dlgThamSoTinhLuong();
            //    dlgEditor.Owner = this;
            //}
            //dlgEditor.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (frmImp == null)
            {
                frmImp = new impDataTinhLuong();
                frmImp.Owner = this;
            }
            frmImp.Show();
        }
    }
}
