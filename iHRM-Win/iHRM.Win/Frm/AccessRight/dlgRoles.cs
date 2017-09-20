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
    public partial class dlgRoles : dlgBase
    {
        /// <summary>
        /// Hành động đang thêm (0) hay sửa (1)
        /// </summary>
        public int CustomFormAction = -1;

        public dlgRoles()
        {
            InitializeComponent();

            dlgData.IdColumnName = "id";
            dlgData.CaptionColumnName = "caption";
            dlgData.FormCaption = "Nhóm quyền";

            dlgData.CB.Add(new ControlBinding("code", txtTen, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("caption", textEdit1, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("description", memoEdit1, ControlBinding_DataType.String));
        }
        
    }
}
