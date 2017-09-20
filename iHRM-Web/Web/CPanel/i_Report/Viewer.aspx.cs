using System;
using System.Collections.Generic;
using System.Linq;
using Ext.Net;
using System.Data;
using System.Data.SqlClient;
using iHRM.Core.i_Report;
using iHRM.WebPC.Classes;

namespace iHRM.WebPC.Cpanel.i_Report
{
    public partial class Viewer : iHRM.WebPC.Code.BackEndPageBase
    {
        i_ReportBase rp = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Request["id"]))
                return;

            rp = GetReportClassByName("iHRM.Core.i_Report." + Request["id"]);
            if (rp == null)
                return;

            var jr = sto1.Reader[0] as JsonReader;
            jr.Fields.AddRange(rp.Columns.Select(i => GetRecordField(i)));

            if (!IsPostBack)
            {
                grd.ColumnModel.Columns.AddRange(rp.Columns.Select(i => GetColumnBase(i)));

                foreach (var it in rp.Filters)
                {
                    var c = GetFormFilterControl(it);
                    c.AddTo(frmFilter);
                    c.ApplyTo = "frmFilter";
                }

                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }

        protected void sto1_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            if (rp == null)
                return;

            var pas = new List<SqlParameter>();

            pas.Add(new SqlParameter("vp_PageSize", e.Limit));
            pas.Add(new SqlParameter("vp_CurrenetPage", (int)(e.Start / e.Limit) + 1));
            var vp_RecordCount = new SqlParameter("vp_RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pas.Add(vp_RecordCount);

            pas.AddRange(rp.Filters.Select(i => GetRequestPa(i)));

            var dt = i_ReportLogic.GetData(rp, pas.ToArray());
            sto1.DataSource = dt;
            sto1.DataBind();

            e.Total = (int)vp_RecordCount.Value;
            (sto1.Proxy[0] as PageProxy).Total = e.Total;

        }

        static i_ReportBase GetReportClassByName(string name)
        {
            try
            {
                string binPath = System.Web.HttpContext.Current.Server.MapPath("~/bin");
                System.Reflection.Assembly a = System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(binPath, "iHRM.Core.dll"));
                Type t = a.GetType(name);
                if (t != null)
                    return Activator.CreateInstance(t) as i_ReportBase;
            }
            catch { }

            return null;
        }

        RecordField GetRecordField(i_ReportItem ri)
        {
            switch (ri.DataType)
            {
                case i_ReportDataType.Bool:
                    return new RecordField(ri.DataIndex, RecordFieldType.Boolean);
                case i_ReportDataType.Date:
                    return new RecordField(ri.DataIndex, RecordFieldType.Date, ri.Format);
                case i_ReportDataType.Float:
                    return new RecordField(ri.DataIndex, RecordFieldType.Float, ri.Format);
                case i_ReportDataType.Int:
                    return new RecordField(ri.DataIndex, RecordFieldType.Int, ri.Format);
                default:
                    return new RecordField(ri.DataIndex, RecordFieldType.Auto);
            }
        }
        ColumnBase GetColumnBase(i_ReportItem ri)
        {
            ColumnBase c = null;
            switch (ri.DataType)
            {
                case i_ReportDataType.Bool:
                    c = new CheckColumn();
                    break;
                case i_ReportDataType.Date:
                    c = new DateColumn() { Format = ri.Format };
                    break;
                case i_ReportDataType.Float:
                case i_ReportDataType.Int:
                    c = new NumberColumn() { Format = ri.Format, Align = Alignment.Right };
                    break;
                default:
                    c = new Column();
                    break;
            }

            if (c != null)
            {
                c.DataIndex = ri.DataIndex;
                c.Header = ri.Caption;
                if (ri.Column_Width > 0)
                    c.Width = ri.Column_Width;
            }

            return c;
        }
        Field GetFormFilterControl(i_ReportItem ri)
        {
            Field c = null;

            if (ri.DataSource != null)
            {
                var jr1 = new JsonReader();
                jr1.IDProperty = ri.DataSource.ValueField;
                jr1.Fields.Add(new RecordField(ri.DataSource.DisplayField));
                jr1.Fields.Add(new RecordField(ri.DataSource.ValueField));

                Store sto1 = new Store();
                sto1.ID = ri.DataIndex + "___store";
                sto1.Reader.Add(jr1);
                this.Controls.Add(sto1);

                var cmb1 = new ComboBox();
                cmb1.ID = ri.DataIndex + "___cmb";
                cmb1.DisplayField = ri.DataSource.DisplayField;
                cmb1.ValueField = ri.DataSource.ValueField;
                cmb1.Store.Add(sto1);
                c = cmb1;

                sto1.DataSource = Core.Business.Provider.ExecuteDataTableReader_SQL(ri.DataSource.DataSource);
                sto1.DataBind();
            }
            else
            {
                switch (ri.DataType)
                {
                    case i_ReportDataType.PhongBan:
                        var t = new TriggerField();
                        t.Triggers.Add(new FieldTrigger() { Icon = TriggerIcon.Ellipsis });
                        t.Listeners.TriggerClick.Handler = "ShowChoiceDept('txtFi_" + ri.DataIndex + "');";
                        //t.AddListener("TriggerClick", "ShowChoiceDept('txtFi_" + ri.DataIndex + "');");
                        c = t;
                        break;
                    case i_ReportDataType.Bool:
                        c = new Checkbox();
                        break;
                    case i_ReportDataType.Date:
                        c = new DateField();
                        break;
                    case i_ReportDataType.Float:
                    case i_ReportDataType.Int:
                        c = new NumberField();
                        break;
                    default:
                        c = new TextField();
                        break;
                }
            }

            if (c != null)
            {
                c.Name = "txtFi_" + ri.DataIndex;
                c.ID = "txtFi_" + ri.DataIndex;
                c.DataIndex = ri.DataIndex;
                c.FieldLabel = ri.Caption;
                c.AnchorHorizontal = "-20";
            }

            return c;
        }

        private SqlParameter GetRequestPa(i_ReportItem i)
        {
            string v = null;
            if (i.DataSource != null)
            {
                v = Request["txtFi_" + i.DataIndex + "_Value"];
            }
            else
            {
                v = Request["txtFi_" + i.DataIndex];
            }
            return new SqlParameter(i.DataIndex, string.IsNullOrWhiteSpace(v) ? null : v);
        }

        protected void btnExcel_DirectClick(object sender, DirectEventArgs e)
        {
            #region get data

            if (rp == null)
                return;

            var pas = new List<SqlParameter>();

            pas.Add(new SqlParameter("vp_PageSize", int.MaxValue));
            pas.Add(new SqlParameter("vp_CurrenetPage", 1));
            var vp_RecordCount = new SqlParameter("vp_RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pas.Add(vp_RecordCount);

            pas.AddRange(rp.Filters.Select(i => GetRequestPa(i)));

            var dt = i_ReportLogic.GetData(rp, pas.ToArray());

            //var dt2 = ExcelExportHelper.CreateGroupInDT(dt, "DepName", "STT");
            #endregion

            ExcelExportHelper ex = null;

            if (string.IsNullOrWhiteSpace(rp.ExcelName))
            {
                ex = new ExcelExportHelper();
                ex.NewFile();
                ex.WriteToCell("A2", rp.ExcelName);

                for (int i = 0; i < rp.Columns.Count; i++) 
                    ex.WriteToCell(3, 1 + i, rp.Columns[i].Caption);

                var lstHeader = rp.Columns.Select(i => "#" + i.DataIndex).ToList();
                ex.FillDataTableByHead(dt, 4, 1, lstHeader);
            }
            else
            {
                if (!rp.ExcelName.EndsWith(".xls"))
                    rp.ExcelName += ".xls";

                ex = new ExcelExportHelper("i_Report/" + rp.ExcelName);
                ex.FillDataTable(dt);
            }
            
            ex.RendAndFlush();
        }
    }
}