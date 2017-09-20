using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using Ext.Net;
using System.IO;
using iHRM.Core.Business.Logic;
using System.Data;
using System.Xml;

namespace iHRM.WebPC.Cpanel.Luong
{
    public partial class PheDuyetLuong : BackEndPageBase
    {
        global::iHRM.Core.Business.Logic.Luong.PheDuyetLuong logic = new global::iHRM.Core.Business.Logic.Luong.PheDuyetLuong();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !X.IsAjaxRequest)
            {
                LoadData();
                
                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }

        void LoadData()
        {
            Store1.DataSource = logic.GetLst(txtSearchKey.Text,
                txtTuNgay.IsEmpty ? null : (DateTime?)txtTuNgay.Value,
                txtDenNgay.IsEmpty ? null : (DateTime?)txtDenNgay.Value,
                chkOnlyWaiting.Checked
            );
            Store1.DataBind();
        }

        protected void btnSearch_DirectClick(object sender, DirectEventArgs e)
        {
            LoadData();
        }

        protected void btnAp1_DirectClick(object sender, DirectEventArgs e)
        {
            var sm = grd.SelectionModel.Primary as RowSelectionModel;
            if (sm.SelectedRows.Count > 0)
            {
                var it = logic.GetItem(new Guid(sm.SelectedRows[0].RecordID));
                FormSetDataRow(editor, it);
                editor.RemoveClass("w1Cls1");
                editor.RemoveClass("w1Cls2");
                editor.RemoveClass("w1Cls3");
                editor.Cls = "w1Cls" + it["status"];
                editor.Show();
                h_IDEditor.Value = sm.SelectedRows[0].RecordID;
            }
        }

        protected void btnApproved_DirectClick(object sender, DirectEventArgs e)
        {
            int status = 0;
            if (sender == btnApproved)
                status = 1;
            if (sender == btnReject)
                status = 2;
            if (sender == btnRevise)
                status = 3;

            if (logic.SetItemStatus(new Guid(h_IDEditor.Value as string), status, txtRemark.Text))
            {
                Tools.message(Lng.common_msg.Edit_Success);
                editor.Hide();
                LoadData();
            }
            else
            {
                Tools.message(Lng.common_msg.Edit_Fail);
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
                {
                    totalOk += (logic.SetItemStatus(new Guid(row.RecordID), status, txtRemark.Text)) ? 1 : 0;
                }

                Tools.message(Lng.common_msg.Edit_Success + " (" + totalOk + ")");
                LoadData();
            }
        }

    }
}