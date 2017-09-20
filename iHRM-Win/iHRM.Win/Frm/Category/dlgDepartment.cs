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

namespace iHRM.Win.Frm.Category
{
    public partial class dlgDepartment : dlgBase
    {
        public dlgDepartment()
        {
            InitializeComponent();

            dlgData.IdColumnName = TableConst.tblRef_Department.DepID;
            dlgData.CaptionColumnName = TableConst.tblRef_Department.DepName;
            dlgData.FormCaption = "Phòng ban";

            dlgData.CB.Add(new ControlBinding(TableConst.tblRef_Department.DepID, txtDepID, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblRef_Department.DepName, txtDepName, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblRef_Department.DepName_Eng, txtDepName_Eng, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblRef_Department.OrderNo, txtOrder, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding(TableConst.tblRef_Department.Notes, txtNotes, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblRef_Department.DepParent, txtDepParent, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblRef_Department.Path, txtPath, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblRef_Department.DepTypeID, txtDepTypeID, ControlBinding_DataType.String));
        }
        public void setReadonlyControl(bool isEdit)
        {
            txtDepID.ReadOnly = isEdit;
            txtDepParent.ReadOnly = isEdit;
            txtDepTypeID.ReadOnly = isEdit;
            txtPath.ReadOnly = isEdit;
        }
        private void textEdit5_EditValueChanged(object sender, EventArgs e)
        {
            dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
            string pathParent ="";
            var depParent = db.tblRef_Departments.Where(p => p.DepID == txtDepParent.Text).FirstOrDefault();
            if (depParent != null)
            {
                pathParent = depParent.Path;
            }
            txtPath.Text = pathParent + txtDepID.Text + "/";
        }

        private void txtDepID_EditValueChanged(object sender, EventArgs e)
        {
            textEdit5_EditValueChanged(sender, e);
        }
        
    }
}
