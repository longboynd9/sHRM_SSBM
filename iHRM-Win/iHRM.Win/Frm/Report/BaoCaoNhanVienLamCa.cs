using iHRM.Core.i_Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;
namespace iHRM.Win.Frm.Report
{
    public partial class BaoCaoNhanVienLamCa : frmBase
    {
        dcDatabaseDataContext db;
        public BaoCaoNhanVienLamCa()
        {
            InitializeComponent();
            db = new dcDatabaseDataContext(iHRM.Core.Business.Provider.ConnectionString);
            lookupCaLam.Properties.DataSource = db.tbCaLamViecs.ToList();
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string depID = chonPhongBan1.SelectedValue;
            Guid? idCaLam = (Guid?) lookupCaLam.EditValue;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu...";
            dw_it.OnDoing += (s,ev) => 
            {
                var vp_RecordCount = new SqlParameter("vp_RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var dt = Core.Business.Provider.ExecuteDataTableReader("p_BaoCaoNhanVienLamCa",
                        new SqlParameter("maNV", txtMaNV.Text),
                        new SqlParameter("depID", depID),
                        new SqlParameter("idCaLam",idCaLam),
                        new SqlParameter("tuNgay",chonKyLuong1.TuNgay),
                        new SqlParameter("denNgay",chonKyLuong1.DenNgay),
                        new SqlParameter("vp_PageSize",pageNavigator1.PageSize),
                        new SqlParameter("vp_CurrenetPage", pageNavigator1.CurrentPage), 
                        vp_RecordCount
                    );
                dw_it.bw.ReportProgress(1, dt);
                dw_it.bw.ReportProgress(2, (int)vp_RecordCount.Value); 
            };
            dw_it.OnProcessing = (ps, data) => 
            {
                switch (data.ProgressPercentage)
                {
                    case 1:
                        grcNVLamCa.DataSource = data;
                        btnFind.Enabled = true;
                        break;
                    case 2:
                        pageNavigator1.RecordCount = (int)data.UserState;
                        break;
                }
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportGrid(grcNVLamCa);
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
    }
}
