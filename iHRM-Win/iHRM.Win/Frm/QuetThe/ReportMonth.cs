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
    public partial class ReportMonth : frmBase
    {
        Core.Controller.QuetThe.ReportMonth controller = new Core.Controller.QuetThe.ReportMonth();
        //dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        Common.dlgChonDoiTuong chonDT = new Common.dlgChonDoiTuong();
        dlgReportMonth dlgEditor = new dlgReportMonth();

        public ReportMonth()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            dlgEditor.Owner = this;
            LoadGrvLayout(grv);
        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu đăng ký ca làm...";
            dw_it.OnDoing = (s,ev) => 
            {
                var dt = controller.GetData(chonDT.SelectedIndex == 1 ? chonDT.SelectedValue : "",
                    chonDT.SelectedIndex == 2 ? chonDT.SelectedValue : "",
                    chonDT.SelectedIndex == 3 ? Convert.ToInt32(chonDT.SelectedValue) : 0,
                    chonKyLuong1.TuNgay,
                    chonKyLuong1.DenNgay,
                    true
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
        
        private void txtDoiTuong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (chonDT.ShowDialog() == DialogResult.OK)
                txtDoiTuong.Text = chonDT.SelectedText;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var r = grv.GetFocusedDataRow();
            if (r!= null)
            {
                dlgEditor.empID = DbHelper.DrGetString(r, "EmployeeID");
                dlgEditor.tuNgay = chonKyLuong1.TuNgay;
                dlgEditor.denNgay = chonKyLuong1.DenNgay;

                dlgEditor.Show();
                dlgEditor.LoadData();
            }
        }
    }
}
