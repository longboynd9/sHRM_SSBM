using DevExpress.XtraEditors;
using iHRM.Core.Business;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm
{
    public partial class
        dlgBase : DevExpress.XtraEditors.XtraForm
    {
        public dlgBase()
        {
            InitializeComponent();
            this.FormClosing += DlgBase_FormClosing;
        }

        static Icon addNewIcon = Icon.FromHandle(Properties.Resources.btnAdd_Image.GetHicon());
        static Icon editIcon = Icon.FromHandle(Properties.Resources.btnEdit_Image.GetHicon());

        protected DlgData dlgData = new DlgData();

        public object myID;

        protected DataRow myValue = null;
        public DataRow MyValue
        {
            get { return myValue; }
            set
            {
                myValue = value;
                FormSetData();
            }
        }
        public event EventHandler OnSave;

        protected virtual void FormSetData()
        {
            foreach (var it in dlgData.CB)
                it.Edit.EditValue = DbHelper.DrGet(myValue, it.DataIndex);

            myID = DbHelper.DrGet(myValue, dlgData.IdColumnName);
            if (myID == null)
            {
                this.Icon = addNewIcon;
                this.Text = "Thêm mới " + dlgData.FormCaption;
            }
            else
            {
                this.Icon = editIcon;
                this.Text = dlgData.FormCaption + " " + DbHelper.DrGet(myValue, dlgData.CaptionColumnName);
            }
        }

        protected virtual void FormGetData()
        {
            if (myValue == null)
                return;

            foreach (var it in dlgData.CB)
            {
                if (myValue.Table.Columns.Contains(it.DataIndex))
                {
                    if (it.DataType == ControlBinding_DataType.DateTime)
                    {
                        myValue.Table.Columns[it.DataIndex].ReadOnly = false;
                        myValue[it.DataIndex] = (it.Edit.EditValue == null || it.Edit.EditValue.ToString() == "") ? DBNull.Value : it.Edit.EditValue;
                    }
                    else if (it.DataType == ControlBinding_DataType.Image)
                    {
                        myValue.Table.Columns[it.DataIndex].ReadOnly = false;
                        PictureEdit picImage = (PictureEdit)it.Edit;
                        if (picImage.EditValue != null)
                        {
                            myValue[it.DataIndex] = picImage.EditValue as byte[];
                        }
                        else
                        {
                            myValue[it.DataIndex] = DBNull.Value; //con gà
                        }

                    }
                    else
                    {
                        myValue.Table.Columns[it.DataIndex].ReadOnly = false;
                        myValue[it.DataIndex] = it.Edit.EditValue ?? DBNull.Value;
                    }
                }
            }
        }
        public Image ResizeByWidth(Image img, int width)
        {
            // lấy chiều rộng và chiều cao ban đầu của ảnh
            int originalW = img.Width;
            int originalH = img.Height;

            // lấy chiều rộng và chiều cao mới tương ứng với chiều rộng truyền vào của ảnh (nó sẽ giúp ảnh của chúng ta sau khi resize vần giứ được độ cân đối của tấm ảnh
            int resizedW = width;
            int resizedH = (originalH * resizedW) / originalW;

            // tạo một Bitmap có kích thước tương ứng với chiều rộng và chiều cao mới
            Bitmap bmp = new Bitmap(resizedW, resizedH);

            // tạo mới một đối tượng từ Bitmap
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.InterpolationMode = InterpolationMode.High;

            // vẽ lại ảnh với kích thước mới
            graphic.DrawImage(img, 0, 0, resizedW, resizedH);

            // gải phóng resource cho đối tượng graphic
            graphic.Dispose();

            // trả về anh sau khi đã resize
            return (Image)bmp;
        }
        private void DlgBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing);
            this.Hide();
        }

        private void buttonPanel1_OnSave(object sender, EventArgs e)
        {

            FormGetData();
            if (OnSave != null)
                OnSave(this, null);
        }
    }
}
