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
using iHRM.Core.Business.DbObject;

namespace iHRM.Win.Frm.MayChamCong
{
    public partial class ThongTinNhanVien_Old : DevExpress.XtraEditors.XtraForm
    {
        public ThongTinNhanVien_Old()
        {
            InitializeComponent();
        }
        dcDatabaseMCCDataContext db = new dcDatabaseMCCDataContext(Provider.ConnectionString_MCC);
        private void KhaibaoMCC_Load(object sender, EventArgs e)
        {
            menuRefresh_LuongCB_Click(null, null);
        }

        private void grvKhaiBaoMCC_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == gridColumn1)
                    e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private void grvKhaibaoMCC_InitNewRow_1(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var nv = db.tbNhanViens.OrderByDescending(p => p.maChamCong).FirstOrDefault();
            long lastMaCC = 0;
            if (nv != null)
            {
                lastMaCC = nv.maChamCong;
            }
            var dr = grvTTNV.GetRow(e.RowHandle) as tbNhanVien;
            if (dr != null)
            {
                dr.maChamCong = lastMaCC + 1;
            }
        }

        private void menuRefresh_LuongCB_Click(object sender, EventArgs e)
        {
            db = new dcDatabaseMCCDataContext(Provider.ConnectionString_MCC);
            grcTTNV.DataSource = db.tbNhanViens.OrderBy(p => p.tenChamCong).ThenBy(p => p.maChamCong);
        }

        private void menuDelete_LuongCB_Click(object sender, EventArgs e)
        {
            if (GUIHelper.ConfirmBox("Bạn chắc chắn muốn xóa nhân viên: " + grvTTNV.GetFocusedRowCellValue("tenChamCong").ToString()))
            {
                try
                {
                    if (grvTTNV.FocusedRowHandle >= 0)
                    {
                        grvTTNV.DeleteRow(grvTTNV.FocusedRowHandle);
                    }
                    db.SubmitChanges();
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                }
                catch (Exception)
                {
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelFalse);
                }
            }
        }

        private void menuSave_LuongCB_Click(object sender, EventArgs e)
        {
            try
            {
                db.SubmitChanges();
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
            }
            catch (Exception)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveFalse);
            }
        }

        private void grvTTNV_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == columnSoTheQuet)
            {
                if (db.tbNhanViens.Where(p=>p.maThe == e.Value.ToString()).Count() >= 1)
                {
                    GUIHelper.MessageError("Mã thẻ quẹt " + e.Value + " đã có người sử dụng!");
                }
            }
            if (e.Column == columnMaThesHRM)
            {
                if (db.tbNhanViens.Where(p=>p.maThesHRM == e.Value.ToString()).Count() >= 1)
                {
                    GUIHelper.MessageError("Mã thẻ sHRM " + e.Value + " đã có người sử dụng!");
                }
            }
        }
    }
}