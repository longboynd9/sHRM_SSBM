using Ext.Net;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace iHRM.WebPC.Cpanel.Category
{
    public partial class CatDefineDetail : BackEndPageBase
    {
        protected override void initRight()
        {
            adm_FuncID = 185;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["catDefID"] != null)
            {
                Lng.Web_Language.Lng_SetControlTexts(this);
                dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
                var catDef = db.tbCatDefines.SingleOrDefault(i => i.id == new Guid(Request["catDefID"]));
                if (catDef == null)
                    return;

                var dt = db.tbCatDefineColumns.Where(i => i.catDefID == catDef.id).ToList();


                if (dt.Count == 0)
                {
                    var dt2 = global::iHRM.Core.Business.Logic.AllLogic.GetSchema(catDef.tableName);
                    foreach (DataColumn dc in dt2.Columns)
                    {
                        var dr = new tbCatDefineColumn();
                        dr.id = Guid.NewGuid();
                        dr.columnName = dc.ColumnName;
                        dr.caption = dc.Caption;
                        dr.dataType = 1;
                        dr.sortIdx = dt.Count;

                        dt.Add(dr);
                    }
                }

                JsonReader jr = (JsonReader)Store1.Reader.FirstOrDefault();
                jr.Fields.Clear();
                //GridPanel1.ColumnModel.Columns.Clear();
                if (!string.IsNullOrWhiteSpace(catDef.autoExpanColumnName))
                    GridPanel1.AutoExpandColumn = catDef.autoExpanColumnName;

                jr.IDProperty = catDef.idColumnName;
                foreach (var it in dt.OrderByDescending(i => i.sortIdx))
                {
                    jr.Fields.Add(new RecordField(it.columnName, (RecordFieldType)it.dataType));
                    if (it.columnName == catDef.idColumnName && catDef.columnIdEditType == "edit")
                        jr.Fields.Add(new RecordField(it.columnName + "___1", (RecordFieldType)it.dataType));

                    if (it.sortIdx > 0)
                    {

                        #region add column
                        ColumnBase c;

                        if (string.IsNullOrWhiteSpace(it.dataSource))
                        {
                            switch ((RecordFieldType)it.dataType)
                            {
                                case RecordFieldType.Boolean:
                                    c = new CheckColumn();
                                    c.Editor.Add(new Checkbox());
                                    c.Editable = true;
                                    break;
                                case RecordFieldType.Date:
                                    c = new DateColumn();
                                    ((DateColumn)c).Format = "dd/MM/yyyy HH:mm";
                                    c.Editor.Add(new DateField() { Format = "dd/MM/yyyy HH:mm" });
                                    break;
                                case RecordFieldType.Float:
                                    c = new NumberColumn() { Format = "0.00", Align = Alignment.Right };
                                    c.Editor.Add(new NumberField() { AllowDecimals = true });
                                    break;
                                case RecordFieldType.Int:
                                    c = new NumberColumn() { Format = "0,000", Align = Alignment.Right };
                                    c.Editor.Add(new NumberField() { AllowDecimals = false, DecimalPrecision = 0 });
                                    break;
                                default:
                                    c = new Column();
                                    c.Editor.Add(new TextField());
                                    break;
                            }
                        }
                        else
                        {
                            column_datasource dc = new column_datasource(it.dataSource);

                            var jr1 = new JsonReader();
                            jr1.IDProperty = dc.valueField;
                            jr1.Fields.Add(new RecordField(dc.displayField));
                            jr1.Fields.Add(new RecordField(dc.valueField));

                            Store sto1 = new Store();
                            sto1.ID = it.columnName + "___store";
                            sto1.Reader.Add(jr1);
                            this.Controls.Add(sto1);

                            var cmb1 = new ComboBox();
                            cmb1.ID = it.columnName + "___cmb";
                            cmb1.DisplayField = dc.displayField;
                            cmb1.ValueField = dc.valueField;
                            cmb1.Store.Add(sto1);

                            sto1.DataSource = Provider.ExecuteDataTableReader_SQL(dc.source);
                            sto1.DataBind();

                            c = new Column();
                            //c.Renderer.Fn = "alert(1)";
                            c.Editor.Add(cmb1);
                        }

                        c.Header = it.caption;
                        c.DataIndex = it.columnName + (it.columnName == catDef.idColumnName && catDef.columnIdEditType == "edit" ? "___1" : "");
                        if (it.width > 0)
                            c.Width = it.width;

                        GridPanel1.ColumnModel.Columns.Insert(1, c);
                        #endregion

                        #region add filter
                        GridFilter gf;

                        switch ((RecordFieldType)it.dataType)
                        {
                            case RecordFieldType.Boolean:
                                gf = new BooleanFilter();
                                break;
                            case RecordFieldType.Date:
                                gf = new DateFilter();
                                break;
                            case RecordFieldType.Int:
                            case RecordFieldType.Float:
                                gf = new NumericFilter();
                                break;
                            default:
                                gf = new StringFilter();
                                break;
                        }

                        gf.DataIndex = it.columnName + (it.columnName == catDef.idColumnName && catDef.columnIdEditType == "edit" ? "___1" : "");
                        GridFilters1.Filters.Add(gf);
                        #endregion
                    }
                }

                var dtData = (new global::iHRM.Core.Business.Logic.Category.CatDefine()).GetDataOfTable(catDef.tableName, dt.Select(i => i.columnName).ToArray());
                if (catDef.columnIdEditType == "edit")
                {
                    dtData.Columns.Add(catDef.idColumnName + "___1", dtData.Columns[catDef.idColumnName].DataType);
                    foreach (DataRow dr in dtData.Rows)
                        dr[catDef.idColumnName + "___1"] = dr[catDef.idColumnName];
                }
                Store1.DataSource = dtData;
                Store1.DataBind();
            }
        }



        protected void Store1_BeforeChanged(object sender, BeforeStoreChangedEventArgs e)
        {
            if (Request["catDefID"] == null)
                return;

            dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
            var catDef = db.tbCatDefines.SingleOrDefault(i => i.id == new Guid(Request["catDefID"]));
            if (catDef == null)
                return;

            var dt = db.tbCatDefineColumns.Where(i => i.catDefID == catDef.id).ToList();


            if (dt.Count == 0)
            {
                var dt2 = global::iHRM.Core.Business.Logic.AllLogic.GetSchema(catDef.tableName);
                foreach (DataColumn dc in dt2.Columns)
                {
                    var dr = new tbCatDefineColumn();
                    dr.id = Guid.NewGuid();
                    dr.columnName = dc.ColumnName;
                    dr.caption = dc.Caption;
                    dr.dataType = 1;
                    dr.sortIdx = dt.Count;

                    dt.Add(dr);
                }
            }

            XmlDocument doc = e.DataHandler.XmlData;
            buildInsert(catDef, dt, doc);
            buildDelete(catDef, doc);
            buildUpdate(catDef, dt, doc);

            e.Cancel = true;
            Tools.message("Cập nhật thành công");
        }

        SqlCommand CreateSqlCommand(string sqlText, List<tbCatDefineColumn> dtColumn)
        {
            SqlCommand cmd = new SqlCommand(sqlText, Provider.CreateConnection());
            foreach (var dr in dtColumn)
            {
                SqlParameter pa = new SqlParameter();
                pa.ParameterName = dr.columnName;

                switch (dr.dataType)
                {
                    case (int)RecordFieldType.Boolean:
                        pa.SqlDbType = SqlDbType.Bit;
                        break;
                    case (int)RecordFieldType.Date:
                        pa.SqlDbType = SqlDbType.DateTime;
                        break;
                    case (int)RecordFieldType.Float:
                        pa.SqlDbType = SqlDbType.Float;
                        break;
                    case (int)RecordFieldType.Int:
                        pa.SqlDbType = SqlDbType.Int;
                        break;
                    default:
                        pa.SqlDbType = SqlDbType.NVarChar;
                        break;
                }

                cmd.Parameters.Add(pa);
            }

            return cmd;
        }

        void buildInsert(tbCatDefine catDef, List<tbCatDefineColumn> dtColumn, XmlDocument doc)
        {
            string sql = string.Format("INSERT INTO [{0}] ({1}) VALUES ({2})",
                catDef.tableName,
                string.Join(",", dtColumn.Where(i => i.dataType > 0).Select(i => "[" + i.columnName + "]")),
                string.Join(",", dtColumn.Where(i => i.dataType > 0).Select(i => "@" + i.columnName))
            );

            SqlCommand cmd = CreateSqlCommand(sql, dtColumn.Where(i => i.dataType > 0).ToList());

            try
            {
                cmd.Connection.Open();
                foreach (XmlNode n in doc.SelectNodes("/records/Created/record"))
                {
                    foreach (SqlParameter pa in cmd.Parameters)
                    {
                        string v = n.SelectSingleNode(pa.ParameterName + (pa.ParameterName == catDef.idColumnName && catDef.columnIdEditType == "edit" ? "___1" : "")).InnerText;

                        if (pa.SqlDbType == SqlDbType.Bit && string.IsNullOrWhiteSpace(v))
                            pa.Value = false;
                        else
                            pa.Value = v;
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        void buildDelete(tbCatDefine catDef, XmlDocument doc)
        {
            string sql = string.Format("DELETE FROM [{0}] WHERE [{1}] = @{1}",
                catDef.tableName,
                catDef.idColumnName
            );

            SqlCommand cmd = new SqlCommand(sql, Provider.CreateConnection());
            cmd.Parameters.Add(new SqlParameter(catDef.idColumnName, DBNull.Value));

            try
            {
                cmd.Connection.Open();
                foreach (XmlNode n in doc.SelectNodes("/records/Deleted/record"))
                {
                    foreach (SqlParameter pa in cmd.Parameters)
                        pa.Value = n.SelectSingleNode(pa.ParameterName).InnerText;

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        void buildUpdate(tbCatDefine catDef, List<tbCatDefineColumn> dtColumn, XmlDocument doc)
        {
            string sql = string.Format("UPDATE [{0}] SET {2} WHERE [{1}] = @{1}",
                catDef.tableName,
                catDef.idColumnName,
                string.Join(",", dtColumn.Where(i => !Equals(i.columnName, catDef.idColumnName)).Select(i => "[" + i.columnName + "] = @" + i.columnName)) +
                    (catDef.columnIdEditType == "edit" ? string.Format(",[{0}] = @{0}___1", catDef.idColumnName) : "")
            );

            SqlCommand cmd = CreateSqlCommand(sql, dtColumn);
            if (catDef.columnIdEditType == "edit")
            {
                cmd.Parameters.Add(catDef.idColumnName + "___1", cmd.Parameters[catDef.idColumnName].SqlDbType);
            }

            try
            {
                cmd.Connection.Open();
                foreach (XmlNode n in doc.SelectNodes("/records/Updated/record"))
                {
                    foreach (SqlParameter pa in cmd.Parameters)
                        pa.Value = n.SelectSingleNode(pa.ParameterName).InnerText;

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                cmd.Connection.Close();
            }
        }










        class column_datasource
        {
            public string source, displayField, valueField;

            public column_datasource(string data)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(data);

                source = doc.SelectSingleNode("/datasource/source").InnerText;
                displayField = doc.SelectSingleNode("/datasource/displayField").InnerText;
                valueField = doc.SelectSingleNode("/datasource/valueField").InnerText;
            }
        }
    }
}