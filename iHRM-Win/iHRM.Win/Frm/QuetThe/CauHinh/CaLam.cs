using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using iHRM.Win.Cls;

namespace iHRM.Win.Frm.QuetThe.CauHinh
{
    public partial class CaLam :  frmBase
    {
        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();
        DataTable Data;
        DataRow CRow;

        dlgCaLam _dlgEditor = null;
        dlgCaLam dlgEditor
        {
            get
            {
                if (_dlgEditor == null)
                {
                    _dlgEditor = new dlgCaLam();
                    dlgEditor.Owner = this;
                    dlgEditor.OnSave += dlgEditor_OnSave;
                }
                return _dlgEditor;
            }
            set
            {
                _dlgEditor = value;
            }
        }

        public CaLam()
        {
            InitializeComponent();
        }

        private void CaLam_Load(object sender, EventArgs e)
        {
            buttonPanel1_OnFind(null, null);
        }

        private void grv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            CRow = grv.GetFocusedDataRow();
        }

        private void buttonPanel1_OnFind(object sender, EventArgs e)
        {
            Data = logic.GetAll();
            grd.DataSource = Data;
        }
        private void buttonPanel1_OnNew(object sender, EventArgs e)
        {
            dlgEditor.MyValue = Data.NewRow();
            dlgEditor.Show();
        }
        private void buttonPanel1_OnEdit(object sender, EventArgs e)
        {
            dlgEditor.MyValue = CRow;
            dlgEditor.Show();
        }
        private void buttonPanel1_OnDelete(object sender, EventArgs e)
        {
            if (CRow == null)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            var db = new dcDatabaseDataContext(Provider.ConnectionString);
            var it = db.tbCaLamViecs.SingleOrDefault(i => i.id == DbHelper.DrGetGuid(CRow, TableConst.tbCaLamViec.id));

            if (it != null)
            {
                try
                {
                    if (!GUIHelper.ConfirmBox("Bạn chắc chắn muốn xóa ?"))
                        return;

                    db.tbCaLam_TinhTangCas.DeleteAllOnSubmit(it.tbCaLam_TinhTangCas);
                    db.tbCaLamViecs.DeleteOnSubmit(it);
                    db.SubmitChanges();

                    Data.Rows.Remove(CRow);
                    grv_FocusedRowChanged(null, null);
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                }
                catch(Exception ex)
                {
                    win_globall.ExecCatch(ex);
                }
            }
            else
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
            }
        }

        private void dlgEditor_OnSave(object sender, EventArgs e) //sự kiện khi ấn nút lưu ở dlg
        {
            try
            {
                dlgEditor.MyValue[TableConst.tbCaLamViec.id] = logic.InsertOrUpdate(dlgEditor.MyValue);

                if (dlgEditor.myID == null)
                {
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                    Data.Rows.Add(dlgEditor.MyValue);
                }
                else
                {
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                }
            }
            catch(Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }


    }
}
