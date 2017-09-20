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
    public partial class CongThucTinhLuong : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
        
        public CongThucTinhLuong()
        {
            InitializeComponent();
        }
        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadGrvLayout(grv);
        }
        private void LoadData()
        {
            grd.DataSource = db.tbBangLuongCalcs;
        }
        private void frmDangKyCaLam_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
        
        private void grv_DoubleClick(object sender, EventArgs e)
        {
            var r = grv.GetFocusedRow() as tbBangLuongCalc;
            if (r == null)
                return;

            MathEvaluator.EvaluatorEditor dlgCalcEditor = new MathEvaluator.EvaluatorEditor();
            dlgCalcEditor.CalcText = r.expression;
            if (dlgCalcEditor.ShowDialog() == DialogResult.OK)
                r.expression = dlgCalcEditor.CalcText;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                db.SubmitChanges();
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
            }
            catch(Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
        }
    }
    
}
