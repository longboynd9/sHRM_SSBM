using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class dlgReportMonth : dlgCustomBase
    {
        Core.Business.Logic.ChamCong.ReportMonthLogic logic = new Core.Business.Logic.ChamCong.ReportMonthLogic();
        Core.Controller.QuetThe.ReportMonth controller = new Core.Controller.QuetThe.ReportMonth();

        DataTable dtData;

        public string empID { get; set; }
        public DateTime tuNgay { get; set; }
        public DateTime denNgay { get; set; }

        public dlgReportMonth()
        {
            InitializeComponent();
        }

        private void dlgReportMonth_Load(object sender, EventArgs e)
        {
            frmBase.LoadGrvLayout_custom(grv, "QuetThe.dlgReportMonth");
            LoadData();
        }

        public void LoadData()
        {
            this.Form_Title = string.Format("Bảng chấm công chi tiết [{0}]", empID);

            dtData = logic.GetReportMonth_4Emp(tuNgay, denNgay, empID);
            dtData.Columns.Add("TT");
            dtData.Columns.Add("tgTangCa", typeof(double));
            foreach (DataRow dr in dtData.Rows)
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

            grd.DataSource = dtData;

            if (dtData != null && dtData.Rows.Count > 0)
            {
                stt_Ngay.Text = "Tổng: " + dtData.Rows.Count;
                stt_CongWD.Text = string.Format("WD: {0:0.##} ({1:0.##})", dtData.Compute("SUM(kqNgayCong)", "tt_chuNhat=0"), dtData.Compute("SUM(tgTinhTangCa)", "tt_chuNhat=0"));
                stt_CongCN.Text = string.Format("CN: {0:0.##} ({1:0.##})", dtData.Compute("SUM(kqNgayCong)", "tt_chuNhat=1"), dtData.Compute("SUM(tgTinhTangCa)", "tt_chuNhat=1"));
                stt_DSVM.Text = string.Format("ĐM: {0:#,0} - VS: {1:#,0} - LT: {2} - VM: {3}",
                    dtData.Compute("SUM(tgDiMuon)", ""),
                    dtData.Compute("SUM(tgVeSom)", ""),
                    dtData.Compute("SUM(tt_leTet)", ""),
                    dtData.Compute("SUM(tt_nghiPhep)", "")
                );
            }

            toolStripButton3.Enabled = (dtData != null && dtData.Rows.Count > 0);
            dtData.AcceptChanges();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmBase.ExportGrid(grd);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var dt = dtData.GetChanges();
            if (dt == null || dt.Rows.Count == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            string msg = "";
            int rowAffect = 0;
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    Guid id = (Guid)dr["id"];
                    TimeSpan tgQuetDen = (dr["tgQuetDen"] as TimeSpan?) ?? new TimeSpan();
                    TimeSpan tgQuetVe = (dr["tgQuetVe"] as TimeSpan?) ?? new TimeSpan();
                    iHRM.Win.ExtClass.QuetThe.QuetThe.SetTimeQT(id, tgQuetDen, tgQuetVe,false, force: true, userLoginin: LoginHelper.user);
                    rowAffect += 1;
                }
                catch(Exception ex)
                {
                    msg += ex + "\n";
                }
            }

            if (!string.IsNullOrWhiteSpace(msg))
            {
                GUIHelper.MessageBox(msg, "Lưu hoàn tất (" + rowAffect + ")");
            }
            else
            {
                GUIHelper.Notifications(rowAffect + " bản ghi", "Lưu thành công", GUIHelper.NotifiType.tick);
                dtData.AcceptChanges();
            }
        }

        private void dlgReportMonth_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmBase.SaveGrvLayout_custom(grv, "QuetThe.dlgReportMonth");
        }

        private void dlgReportMonth_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }

        private void grv_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                var r = e.Row as DataRowView;
                if (r == null)
                    return;

                if (e.Column == gridColumn13)
                {
                    if ((r["isLocked"] as bool?) == true)
                        e.Value = Properties.Resources.ico20_lock;
                    else
                        e.Value = null;
                }
            }
        }

        private void grv_ShowingEditor(object sender, CancelEventArgs e)
        {
            var r = grv.GetFocusedDataRow();
            if (r == null)
                return;

            e.Cancel = ((r["isLocked"] as bool?) == true);
        }
    }
}
