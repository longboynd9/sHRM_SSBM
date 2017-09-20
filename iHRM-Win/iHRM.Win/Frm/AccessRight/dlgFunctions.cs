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

namespace iHRM.Win.Frm.AccessRight
{
    public partial class dlgFunctions : dlgBase
    {
        public dlgFunctions()
        {
            InitializeComponent();

            dlgData.IdColumnName = "id";
            dlgData.CaptionColumnName = "caption";
            dlgData.FormCaption = "Chức năng";
            
            dlgData.CB.Add(new ControlBinding("id", txtTen, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("parentId", txtParentID, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("caption", textEdit1, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("caption_EN", textEdit2, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("order1", textEdit3, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("asemblyPath", textEdit4, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("asemblyInherits", textEdit6, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("icon", pictureEditIcon, ControlBinding_DataType.Image));
            //dlgData.CB.Add(new ControlBinding("modal", checkEdit1, ControlBinding_DataType.Bool));
        }

        protected override void FormGetData()
        {
            base.FormGetData();
            myValue["modal"] = checkEdit1.Checked ? 1 : (checkEdit2.Checked ? 2 : (checkEdit2.Checked ? 3 : 0));
            myValue["status"] = checkEdit5.Checked ? 1 : 0;
        }
        protected override void FormSetData()
        {
            base.FormSetData();
            checkEdit1.Checked = (myValue["modal"] as int?) == 1;
            checkEdit2.Checked = (myValue["modal"] as int?) == 2;
            checkEdit3.Checked = (myValue["modal"] as int?) == 3;
            checkEdit4.Checked = (myValue["modal"] as int? ?? 0) == 0;
            checkEdit5.Checked = (myValue["status"] as long?) == 1;
        }

        private void dlgFunctions_Load(object sender, EventArgs e)
        {

        }
    }
}
