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
    public partial class KhaibaoMCC_Old : DevExpress.XtraEditors.XtraForm
    {
        public KhaibaoMCC_Old()
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
            var dr = grvKhaibaoMCC.GetRow(e.RowHandle) as tbMayChamCong;
            if (dr != null)
            {
                dr.id = Guid.NewGuid();
            }
        }

        private void menuRefresh_LuongCB_Click(object sender, EventArgs e)
        {
            db = new dcDatabaseMCCDataContext(Provider.ConnectionString_MCC);
            grcKhaibaoMCC.DataSource = db.tbMayChamCongs.OrderBy(p => p.tenMay);
        }

        private void menuDelete_LuongCB_Click(object sender, EventArgs e)
        {
            if (GUIHelper.ConfirmBox("Bạn chắc chắn muốn xóa máy chấm công IP: " + grvKhaibaoMCC.GetFocusedRowCellValue("diaChiIP").ToString()))
            {
                if (grvKhaibaoMCC.FocusedRowHandle >= 0)
                {
                    grvKhaibaoMCC.DeleteRow(grvKhaibaoMCC.FocusedRowHandle);
                }
                db.SubmitChanges();
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

    }
}