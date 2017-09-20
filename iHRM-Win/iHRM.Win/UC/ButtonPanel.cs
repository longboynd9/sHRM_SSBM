using iHRM.Common.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.UC
{
    public partial class ButtonPanel : ToolStrip
    {
        #region property

        public bool isAdmin;

        public ToolStripItemDisplayStyle DisplayStyle
        {
            get { return btnFind.DisplayStyle; }
            set
            {
                foreach (ToolStripItem c in this.Items)
                {
                    if (c is ToolStripButton)
                    {
                        (c as ToolStripButton).DisplayStyle = value;
                    }
                }
            }
        }

        public System.Windows.Forms.TextImageRelation TextAndImageRelation
        {
            get { return btnFind.TextImageRelation; }
            set
            {
                foreach (ToolStripItem c in this.Items)
                {
                    if (c is ToolStripButton)
                    {
                        (c as ToolStripButton).TextImageRelation = value;
                    }
                }
            }
        }

        public enum eShowStyle { Custom, List, Choose, Detail, Print, All }
        private eShowStyle showStyle = eShowStyle.Custom;
        public eShowStyle ShowStyle
        {
            get { return showStyle; }
            set
            {
                showStyle = value;
                switch (showStyle)
                {
                    case eShowStyle.Choose:
                        btnFind.Visible = btnChoose.Visible = btnExit.Visible = true;
                        _useButtonFind = _useButtonChoose = _useButtonEdit = true;
                        btnSave.Visible = btnNew.Visible = btnEdit.Visible = btnDel.Visible = btnImport.Visible = btnExport.Visible = btnPrint.Visible = false;
                        _useButtonSave = _useButtonNew = _useButtonEdit = _useButtonDelete = _useButtonImport = _useButtonExport = _useButtonPrint = false;
                        break;
                    case eShowStyle.List:
                        btnFind.Visible = btnNew.Visible = btnEdit.Visible = btnDel.Visible = btnExit.Visible = true;
                        _useButtonFind = _useButtonNew = _useButtonEdit = _useButtonDelete = _useButtonEdit = true;
                        btnSave.Visible = btnChoose.Visible = btnImport.Visible = btnExport.Visible = btnPrint.Visible = false;
                        _useButtonSave = _useButtonChoose = _useButtonImport = _useButtonExport = _useButtonPrint = false;
                        break;
                    case eShowStyle.Detail:
                        btnSave.Visible = btnExit.Visible = true;
                        _useButtonSave = _useButtonEdit = true;
                        btnFind.Visible = btnChoose.Visible = btnNew.Visible = btnEdit.Visible = btnDel.Visible = btnImport.Visible = btnExport.Visible = btnPrint.Visible = false;
                        _useButtonFind = _useButtonChoose = _useButtonNew = _useButtonEdit = _useButtonDelete = _useButtonImport = _useButtonExport = _useButtonPrint = false;
                        break;
                    case eShowStyle.Print:
                        btnFind.Visible = btnImport.Visible = btnExport.Visible = btnPrint.Visible = btnExit.Visible = true;
                        _useButtonFind = _useButtonImport = _useButtonExport = _useButtonPrint = _useButtonExit = true;
                        btnSave.Visible = btnChoose.Visible = btnNew.Visible = btnEdit.Visible = btnDel.Visible = false;
                        _useButtonSave = _useButtonChoose = _useButtonNew = _useButtonEdit = _useButtonDelete = false;
                        break;
                    case eShowStyle.All:
                        btnSave.Visible = btnFind.Visible = btnImport.Visible = btnExport.Visible = btnPrint.Visible = btnExit.Visible = btnChoose.Visible = btnNew.Visible = btnEdit.Visible = btnDel.Visible = true;
                        _useButtonSave = _useButtonChoose = _useButtonNew = _useButtonEdit = _useButtonDelete = _useButtonFind = _useButtonImport = _useButtonExport = _useButtonPrint = _useButtonExit = true;
                        break;
                }
            }
        }

        #region use button
        private bool _useButtonFind = false;
        public bool useButtonFind
        {
            get { return _useButtonFind; }
            set { _useButtonFind = btnFind.Visible = value; showStyle = eShowStyle.Custom; }
        }
        private bool _useButtonChoose = false;
        public bool useButtonChoose
        {
            get { return _useButtonChoose; }
            set { _useButtonChoose = btnChoose.Visible = value; showStyle = eShowStyle.Custom; }
        }
        private bool _useButtonNew = false;
        public bool useButtonNew
        {
            get { return _useButtonNew; }
            set { _useButtonNew = btnNew.Visible = value; showStyle = eShowStyle.Custom; }
        }
        private bool _useButtonEdit = false;
        public bool useButtonEdit
        {
            get { return _useButtonEdit; }
            set { _useButtonEdit = btnEdit.Visible = value; showStyle = eShowStyle.Custom; }
        }
        private bool _useButtonDelete = false;
        public bool useButtonDelete
        {
            get { return _useButtonDelete; }
            set { _useButtonDelete = btnDel.Visible = value; showStyle = eShowStyle.Custom; }
        }
        private bool _useButtonImport = false;
        public bool useButtonImport
        {
            get { return _useButtonImport; }
            set { _useButtonImport = btnImport.Visible = value; showStyle = eShowStyle.Custom; }
        }
        private bool _useButtonExport = false;
        public bool useButtonExport
        {
            get { return _useButtonExport; }
            set { _useButtonExport = btnExport.Visible = value; showStyle = eShowStyle.Custom; }
        }
        private bool _useButtonPrint = false;
        public bool useButtonPrint
        {
            get { return _useButtonPrint; }
            set { _useButtonPrint = btnPrint.Visible = value; showStyle = eShowStyle.Custom; }
        }
        private bool _useButtonExit = true;
        public bool useButtonExit
        {
            get { return _useButtonExit; }
            set { _useButtonExit = btnExit.Visible = value; showStyle = eShowStyle.Custom; }
        }
        private bool _useButtonSave = false;
        public bool useButtonSave
        {
            get { return _useButtonSave; }
            set { _useButtonSave = btnSave.Visible = value; showStyle = eShowStyle.Custom; }
        }
        #endregion

        #region show button
        public bool showButtonFind
        {
            get { return btnFind.Visible; }
            set { btnFind.Visible = value; showStyle = eShowStyle.Custom; }
        }
        public bool showButtonChoose
        {
            get { return btnChoose.Visible; }
            set { btnChoose.Visible = value; showStyle = eShowStyle.Custom; }
        }
        public bool showButtonNew
        {
            get { return btnNew.Visible; }
            set { btnNew.Visible = value; showStyle = eShowStyle.Custom; }
        }
        public bool showButtonEdit
        {
            get { return btnEdit.Visible; }
            set { btnEdit.Visible = value; showStyle = eShowStyle.Custom; }
        }
        public bool showButtonDelete
        {
            get { return btnDel.Visible; }
            set { btnDel.Visible = value; showStyle = eShowStyle.Custom; }
        }
        public bool showButtonImport
        {
            get { return btnImport.Visible; }
            set { btnImport.Visible = value; showStyle = eShowStyle.Custom; }
        }
        public bool showButtonExport
        {
            get { return btnExport.Visible; }
            set { btnExport.Visible = value; showStyle = eShowStyle.Custom; }
        }
        public bool showButtonPrint
        {
            get { return btnPrint.Visible; }
            set { btnPrint.Visible = value; showStyle = eShowStyle.Custom; }
        }
        public bool showButtonExit
        {
            get { return btnExit.Visible; }
            set { btnExit.Visible = value; showStyle = eShowStyle.Custom; }
        }
        public bool showButtonSave
        {
            get { return btnSave.Visible; }
            set { btnSave.Visible = value; showStyle = eShowStyle.Custom; }
        }
        #endregion

        #region enable button
        public bool enableButtonFind
        {
            get { return btnFind.Enabled; }
            set { btnFind.Enabled = value; }
        }
        public bool enableButtonChoose
        {
            get { return btnChoose.Enabled; }
            set { btnChoose.Enabled = value; }
        }
        public bool enableButtonNew
        {
            get { return btnNew.Enabled; }
            set { btnNew.Enabled = value; }
        }
        public bool enableButtonEdit
        {
            get { return btnEdit.Enabled; }
            set { btnEdit.Enabled = value; }
        }
        public bool enableButtonDelete
        {
            get { return btnDel.Enabled; }
            set { btnDel.Enabled = value; }
        }
        public bool enableButtonImport
        {
            get { return btnImport.Enabled; }
            set { btnImport.Enabled = value; }
        }
        public bool enableButtonExport
        {
            get { return btnExport.Enabled; }
            set { btnExport.Enabled = value; }
        }
        public bool enableButtonPrint
        {
            get { return btnPrint.Enabled; }
            set { btnPrint.Enabled = value; }
        }
        public bool enableButtonExit
        {
            get { return btnExit.Enabled; }
            set { btnExit.Enabled = value; }
        }
        public bool enableButtonSave
        {
            get { return btnSave.Enabled; }
            set { btnSave.Enabled = value; }
        }
        #endregion

        private ToolStripButton btnFind = new ToolStripButton();
        private ToolStripButton btnNew = new ToolStripButton();
        private ToolStripButton btnEdit = new ToolStripButton();
        private ToolStripButton btnDel = new ToolStripButton();
        private ToolStripButton btnImport = new ToolStripButton();
        private ToolStripButton btnExport = new ToolStripButton();
        private ToolStripButton btnChoose = new ToolStripButton();
        private ToolStripButton btnExit = new ToolStripButton();
        private ToolStripButton btnSave = new ToolStripButton();
        private ToolStripButton btnPrint = new ToolStripButton();

        #endregion

        public ButtonPanel()
        {
            InitializeComponent();
            Init();
        }
        public ButtonPanel(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            // 
            // btnExit
            // 
            this.btnExit.Image = global::iHRM.Win.Properties.Resources.btnExit_Image;
            this.btnExit.Text = "  Đóng  ";
            this.btnExit.Click += btnExit_Click;
            // 
            // btnFind
            // 
            this.btnFind.Image = global::iHRM.Win.Properties.Resources.btnRefresh_Image;
            this.btnFind.Text = "Làm mới";
            this.btnFind.Click += btnFind_Click;
            // 
            // btnDel
            // 
            this.btnDel.Image = global::iHRM.Win.Properties.Resources.btnDelete_Image;
            this.btnDel.Text = "   Xóa   ";
            this.btnDel.Click += btnDel_Click;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::iHRM.Win.Properties.Resources.btnEdit_Image;
            this.btnEdit.Text = "   Sửa   ";
            this.btnEdit.Click += btnEdit_Click;
            // 
            // btnNew
            // 
            this.btnNew.Image = global::iHRM.Win.Properties.Resources.btnAdd_Image;
            this.btnNew.Text = "Thêm mới";
            this.btnNew.Click += btnNew_Click;
            // 
            // btnChoose
            // 
            this.btnChoose.Image = global::iHRM.Win.Properties.Resources.btnChoose_Image;
            this.btnChoose.Text = "   Chọn   ";
            this.btnChoose.Click += btnChoose_Click;
            // 
            // btnExport
            // 
            this.btnExport.Image = global::iHRM.Win.Properties.Resources.btnExport_Image;
            this.btnExport.Text = "Export";
            this.btnExport.Click += btnExport_Click;
            // 
            // btnImport
            // 
            this.btnImport.Image = global::iHRM.Win.Properties.Resources.btnImport_Image;
            this.btnImport.Text = "Import";
            this.btnImport.Click += btnImport_Click;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::iHRM.Win.Properties.Resources.btnPrint_Image;
            this.btnPrint.Text = "   In   ";
            this.btnPrint.Click += btnPrint_Click;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.btnSave.Text = "   Lưu   ";
            this.btnSave.Click += btnSave_Click;

            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.btnFind,
                this.btnNew,
                this.btnEdit,
                this.btnDel,
                this.btnImport,
                this.btnExport,
                this.btnChoose,
                this.btnSave,
                this.btnPrint,
                this.btnExit
            });
            this.TextAndImageRelation = TextImageRelation.ImageAboveText;
            this.Font = new System.Drawing.Font("Segoe UI", 12);
        }

        #region method

        public void setFunctionEnable(int r)
        {
            if (_useButtonFind)
                btnFind.Enabled = isAdmin || BitHelper.Has(r, (int)Enums.eFunction.Print);
            if (_useButtonNew)
                btnNew.Enabled = isAdmin || BitHelper.Has(r, (int)Enums.eFunction.New);
            if (_useButtonEdit)
                btnEdit.Enabled = isAdmin || BitHelper.Has(r, (int)Enums.eFunction.Edit);
            if (_useButtonDelete)
                btnDel.Enabled = isAdmin || BitHelper.Has(r, (int)Enums.eFunction.Delete);
            if (_useButtonImport)
                btnImport.Enabled = isAdmin || BitHelper.Has(r, (int)Enums.eFunction.Import);
            if (_useButtonExport)
                btnExport.Enabled = isAdmin || BitHelper.Has(r, (int)Enums.eFunction.Export);
            if (_useButtonPrint)
                btnPrint.Enabled = isAdmin || BitHelper.Has(r, (int)Enums.eFunction.Print);
            if (_useButtonChoose)
                btnChoose.Enabled = isAdmin || BitHelper.Has(r, (int)Enums.eFunction.Choose);
            if (_useButtonSave)
                btnChoose.Enabled = isAdmin || BitHelper.Has(r, (int)Enums.eFunction.Edit);
        }

        public void setFunctionVisible(int r)
        {
            if (_useButtonFind)
                btnFind.Visible = isAdmin || BitHelper.Has(r, (int)Enums.eFunction.Find);
            if (_useButtonNew)
                btnNew.Visible = isAdmin || BitHelper.Has(r, (int)Enums.eFunction.New);
            if (_useButtonEdit)
                btnEdit.Visible = isAdmin || BitHelper.Has(r, (int)Enums.eFunction.Edit);
            if (_useButtonSave)
                btnEdit.Visible = isAdmin || BitHelper.Has(r, (int)Enums.eFunction.Edit);
            if (_useButtonDelete)
                btnDel.Visible = isAdmin || BitHelper.Has(r, (int)Enums.eFunction.Delete);
            if (_useButtonImport)
                btnImport.Visible = isAdmin || BitHelper.Has(r, (int)Enums.eFunction.Import);
            if (_useButtonExport)
                btnExport.Visible = isAdmin || BitHelper.Has(r, (int)Enums.eFunction.Export);
            if (_useButtonPrint)
                btnPrint.Visible = isAdmin || BitHelper.Has(r, (int)Enums.eFunction.Print);
            if (_useButtonChoose)
                btnChoose.Visible = isAdmin || BitHelper.Has(r, (int)Enums.eFunction.Choose);
        }

        #endregion

        #region event

        public event EventHandler OnFind;
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (OnFind != null)
                OnFind(sender, e);
        }

        public event EventHandler OnChosse;
        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (OnChosse != null)
                OnChosse(sender, e);
        }

        public event EventHandler OnNew;
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (OnNew != null)
                OnNew(sender, e);
        }

        public event EventHandler OnEdit;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (OnEdit != null)
                OnEdit(sender, e);
        }

        public event EventHandler OnSave;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (OnSave != null)
                OnSave(sender, e);
        }

        public event EventHandler OnDelete;
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (OnDelete != null)
                OnDelete(sender, e);
        }

        public event EventHandler OnImport;
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (OnImport != null)
                OnImport(sender, e);
        }

        public event EventHandler OnExport;
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (OnExport != null)
                OnExport(sender, e);
        }

        public event EventHandler OnPrintf;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (OnPrintf != null)
                OnPrintf(sender, e);
        }

        public event EventHandler OnExit;
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (OnExit == null)
            {
                if (this.Parent is Form)
                    ((Form)this.Parent).Close();
            }
            else
            {
                OnExit(sender, e);
            }
        }

        #endregion

    }
}
