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
    public partial class dlgUsers : dlgBase
    {
        /// <summary>
        /// Hành động đang thêm (0) hay sửa (1)
        /// </summary>
        public int CustomFormAction = -1;

        public dlgUsers()
        {
            InitializeComponent();

            dlgData.IdColumnName = "id";
            dlgData.CaptionColumnName = "caption";
            dlgData.FormCaption = "Người dùng";

            dlgData.CB.Add(new ControlBinding("loginID", txtTen, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("loginPW", textEdit2, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("caption", textEdit1, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("roleID", textEdit4, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("Email", textEdit3, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("description", memoEdit1, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("isAcceptable", chkIsAcceptDA, ControlBinding_DataType.Bool));
            dlgData.CB.Add(new ControlBinding("isAcceptBP", chkIsAcceptBP, ControlBinding_DataType.Bool));
            dlgData.CB.Add(new ControlBinding("idKhoiPB", treeDept, ControlBinding_DataType.Int));

            textEdit4.Properties.DataSource = Cls.CacheDataTable.GetCacheDataTable("w5sysRole");
            treeDept.Properties.DataSource = Cls.CacheDataTable.GetCacheDataTable("tblRef_Department");
        }

        protected override void FormGetData()
        {
            base.FormGetData();

            if (CustomFormAction == 0)
            {
                myValue["isAdmin"] = false;
                myValue["status"] = 1;
            }
            myValue["roleCaption"] = textEdit4.Text;
        }
        protected override void FormSetData()
        {
            base.FormSetData();
        }
    }
}
