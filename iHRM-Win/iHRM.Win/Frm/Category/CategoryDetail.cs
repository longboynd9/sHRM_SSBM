using iHRM.Core.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using iHRM.Core.Business.DbObject;

namespace iHRM.Win.Frm.Category
{
    public class CategoryDetail : lstBase_grdEdit
    {
        tbCatDefine catDef;

        private Guid id_CatCatDefine;
        public Guid ID_CatCatDefine
        {
            get { return id_CatCatDefine; }
            set
            {
                id_CatCatDefine = value;

                var db = new dcDatabaseDataContext(Provider.ConnectionString);
                catDef = db.tbCatDefines.SingleOrDefault(i => i.id == id_CatCatDefine);

                lstData.FormCaption = catDef.caption;
                lstData.IdColumnName = catDef.idColumnName;
                lstData.TableName = catDef.tableName;

                lstData.GrdColumns.AddRange(catDef.tbCatDefineColumns.OrderBy(i => i.sortIdx).Select(i => getGridColumn1(i)).ToArray());
                if (catDef.columnIdEditType == "edit")
                    lstData.GrdColumns.Insert(0, new GridColumn1(catDef.idColumnName, "ID", ControlBinding_DataType.String));
            }
        }

        private GridColumn1 getGridColumn1(tbCatDefineColumn i)
        {
            var g1 = new GridColumn1(i.columnName, i.caption, ControlBinding_DataType.String, i.sortIdx > 0, i.width);
            switch (i.dataType)
            {
                case 4: // (int)RecordFieldType.Boolean:
                    g1.DataType = ControlBinding_DataType.Bool;
                    break;
                case 5: //(int)RecordFieldType.Date:
                    g1.DataType = ControlBinding_DataType.DateTime;
                    break;
                case 3: //(int)RecordFieldType.Float:
                    g1.DataType = ControlBinding_DataType.Float;
                    break;
                case 2: //(int)RecordFieldType.Int:
                    g1.DataType = ControlBinding_DataType.Int;
                    break;
            }
            return g1;
        }

        public CategoryDetail()
        {
        }
        
        protected override void OnInitNewRow(ref DataRow r)
        {
            if (catDef.columnIdEditType == "auto")
                r[lstData.IdColumnName] = Guid.NewGuid();
        }
    }
}
