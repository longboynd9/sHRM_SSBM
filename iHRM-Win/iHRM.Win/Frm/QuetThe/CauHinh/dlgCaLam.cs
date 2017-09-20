using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.QuetThe.CauHinh
{
    public partial class dlgCaLam : dlgBase
    {
        DataTable dtSoTiengTinhCa = null;

        public dlgCaLam()
        {
            InitializeComponent();

            dlgData.IdColumnName = TableConst.tbCaLamViec.id;
            dlgData.CaptionColumnName = TableConst.tbCaLamViec.ten;
            dlgData.FormCaption = "Ca làm";

            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.ten, txtTen, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.tuGio, txtTuGio, ControlBinding_DataType.TimeSpan));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.denGio, txtDenGio, ControlBinding_DataType.TimeSpan));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.tgQuetTruoc_Vao, txtTgQuetTruocVao, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.tgQuetTruoc_Ra, txtTgQuetTruocRa, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.tgQuetSau_Vao, txtTgQuetSauVao, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.tgQuetSau_Ra, txtTgQuetSauRa, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.soTiengTinhCa, txtSoTiengTinhCa, ControlBinding_DataType.Float));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.soTiengTangCaTrachNhiem, txtTangCaTrachNhiem, ControlBinding_DataType.Float));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.soTiengTinhTangCa, txtSoTiengTinhTC, ControlBinding_DataType.Float));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.caSang_tuGio, txtCaSangTuGio, ControlBinding_DataType.TimeSpan));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.caSang_denGio, txtCaSangDenGio, ControlBinding_DataType.TimeSpan));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.caChieu_tuGio, txtCaChieuTuGio, ControlBinding_DataType.TimeSpan));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.caChieu_denGio, txtCaChieuDenGio, ControlBinding_DataType.TimeSpan));
        }

        protected override void FormSetData()
        {
            base.FormSetData();

            if (myID != null)
            {
                xtraTabPage2.PageVisible = true;
                dtSoTiengTinhCa = Provider.ExecuteDataTableReader_SQL("SELECT * FROM tbCaLam_TinhTangCa WHERE idCaLamViec='" + myID + "'");
                grd.DataSource = dtSoTiengTinhCa;
            }
            else
            {
                xtraTabPage2.PageVisible = false;
            }
        }

        protected override void FormGetData()
        {
            base.FormGetData();

            if (myValue["soTiengTinhTangCa"] == DBNull.Value)
            myValue["soTiengTinhTangCa"] = 0;

            Provider.UpdateData(dtSoTiengTinhCa, "tbCaLam_TinhTangCa");
            if (myID != null)
                Provider.ExecNoneQuery("p_tbcalam_recalc_soTiengTinhTangCa", new System.Data.SqlClient.SqlParameter("id", myID));
        }

        private void grv_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var dr = grv.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr[TableConst.tbCaLam_TinhTangCa.id] = Guid.NewGuid();
                dr[TableConst.tbCaLam_TinhTangCa.idCaLamViec] = myID;
            }
        }
        
        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            var it = grv.GetFocusedDataRow() as DataRow;
            if (it != null)
                it.Delete();
        }

    }
}
