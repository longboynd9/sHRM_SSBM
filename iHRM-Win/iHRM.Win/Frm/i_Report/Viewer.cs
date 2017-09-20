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

namespace iHRM.Win.Frm.i_Report
{
    public partial class Viewer : frmBase
    {
        private string id = "";
        public string Report_ID
        {
            get { return id; }
            set { id = value; }
        }

        i_ReportBase rp = null;

        public Viewer()
        {
            InitializeComponent();
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(id))
                return;

            rp = GetReportClassByName("iHRM.Core.i_Report." + id);
            if (rp == null)
                return;

            this.Text = rp.Caption;
            grv.Columns.AddRange(rp.Columns.Select(it => new DevExpress.XtraGrid.Columns.GridColumn()
            {
                Caption = it.Caption,
                FieldName = it.DataIndex,
                VisibleIndex = grv.Columns.Count,
                Width = it.Column_Width > 0 ? it.Column_Width : 157
            }).ToArray());

            foreach (var it in rp.Filters)
            {
                var lbl = new DevExpress.XtraEditors.LabelControl();
                lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
                lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
                lbl.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
                lbl.Size = new System.Drawing.Size(flowLayoutPanel1.Width - 8, 19);
                lbl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                lbl.Text = it.Caption;
                flowLayoutPanel1.Controls.Add(lbl);
                flowLayoutPanel1.Controls.Add(GetFormFilterControl(it));
            }

            LoadGrvLayout(grv, id);
        }
        
        static i_ReportBase GetReportClassByName(string name)
        {
            try
            {
                string dllPath = win_globall.apppath + "\\iHRM.Core.dll";
                System.Reflection.Assembly a = System.Reflection.Assembly.LoadFrom(dllPath);
                Type t = a.GetType(name);
                if (t != null)
                    return Activator.CreateInstance(t) as i_ReportBase;
            }
            catch { }

            return null;
        }

        Control GetFormFilterControl(i_ReportItem ri)
        {
            Control c = null;

            if (ri.DataSource != null)
            {
                var cmb = new System.Windows.Forms.ComboBox();
                cmb.FormattingEnabled = true;
                cmb.DisplayMember = ri.DataSource.DisplayField;
                cmb.ValueMember = ri.DataSource.ValueField;
                cmb.DataSource = Core.Business.Provider.ExecuteDataTableReader_SQL(ri.DataSource.DataSource);
                c = cmb;
            }
            else
            {
                switch (ri.DataType)
                {
                    case i_ReportDataType.PhongBan:
                        c = new UC.ChonPhongBan();
                        break;
                    case i_ReportDataType.Bool:
                        c = new DevExpress.XtraEditors.CheckEdit();
                        break;
                    case i_ReportDataType.Date:
                        c = new DevExpress.XtraEditors.DateEdit();
                        break;
                    case i_ReportDataType.Float:
                    case i_ReportDataType.Int:
                        c = new DevExpress.XtraEditors.CalcEdit();
                        break;
                    default:
                        c = new DevExpress.XtraEditors.TextEdit();
                        break;
                }
            }

            if (c != null)
            {
                c.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                c.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
                c.Font = new System.Drawing.Font("Tahoma", 12F);
                c.Size = new System.Drawing.Size(flowLayoutPanel1.Width - 8, 26);
                c.Name = "txt_" + ri.DataIndex;
            }

            return c;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (rp == null)
                return;

            btnFind.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu...";
            dw_it.OnDoing = (s,ev) =>
            {
                var pas = new List<SqlParameter>();

                pas.Add(new SqlParameter("vp_PageSize", pageNavigator1.PageSize));
                pas.Add(new SqlParameter("vp_CurrenetPage", pageNavigator1.CurrentPage));
                var vp_RecordCount = new SqlParameter("vp_RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output };
                pas.Add(vp_RecordCount);

                pas.AddRange(rp.Filters.Select(i => GetRequestPa(i)));

                var dt = i_ReportLogic.GetData(rp, pas.ToArray());
                dw_it.bw.ReportProgress(1, dt);
                dw_it.bw.ReportProgress(2, (int)vp_RecordCount.Value);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                switch (data.ProgressPercentage)
                {
                    case 1:
                        grd.DataSource = data.UserState; btnFind.Enabled = true;
                        break;
                    case 2:
                        pageNavigator1.RecordCount = (int)data.UserState;
                        break;
                }
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }

        SqlParameter GetRequestPa(i_ReportItem i)
        {
            object v = null;
            foreach(Control c in flowLayoutPanel1.Controls)
            {
                if (c.Name == "txt_" + i.DataIndex)
                {
                    if (c is ComboBox)
                        v = (c as ComboBox).SelectedValue;
                    else if (c is UC.ChonPhongBan)
                        v = (c as UC.ChonPhongBan).SelectedValue;
                    else if (c is DevExpress.XtraEditors.BaseEdit)
                        v = (c as DevExpress.XtraEditors.BaseEdit).EditValue;
                }
            }
            return new SqlParameter(i.DataIndex, v);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportGrid(grd);
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv, id);
        }
    }
}
