using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.UC
{
    public partial class PageNavigator : UserControl
    {
        private int _MaxPage_Old = -1;
        private int _MaxPage = 0;
        private int _RecordCount = 0;
        public int RecordCount
        {
            get { return _RecordCount; }
            set
            {
                _RecordCount = value;
                labelControl1.Text = string.Format("Hiển thị {0:#,0} - {1:#,0} / {2:#,0}", 
                    (_CurrentPage - 1) * _PageSize + 1, 
                    _CurrentPage * _PageSize > RecordCount ? RecordCount : _CurrentPage * _PageSize, 
                    _RecordCount
                );

                _MaxPage = (int)Math.Ceiling(1.0 * _RecordCount / _PageSize);
                if (_MaxPage_Old != _MaxPage)
                {
                    _MaxPage_Old = _MaxPage;
                    textEdit1.Text = string.Format("/ {0:#,0} Trang", _MaxPage);

                    DataTable dt = new DataTable();
                    dt.Columns.Add("value", typeof(int));
                    dt.Columns.Add("text", typeof(string));
                    for (int i = 1; i <= _MaxPage; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["value"] = i;
                        dr["text"] = "Trang " + i;
                        dt.Rows.Add(dr);
                    }
                    lookUpEdit1.Properties.DataSource = dt;
                    _CurrentPage  = _CurrentPage > _MaxPage ? _MaxPage : _CurrentPage;
                    if (_CurrentPage < 1) _CurrentPage = 1;
                    CurrentPage = _CurrentPage;
                }
            }
        }

        private int _PageSize = 10;
        public int PageSize
        {
            get { return _PageSize; }
            set
            {
                _PageSize = value;
                lookUpEdit2.EditValue = _PageSize;
            }
        }

        private int _CurrentPage = 1;
        public int CurrentPage
        {
            get { return _CurrentPage; }
            set
            {
                _CurrentPage = value;
                lookUpEdit1.EditValue = _CurrentPage;
                simpleButton1.Enabled = _CurrentPage > 1;
                simpleButton2.Enabled = _CurrentPage > 1;
                simpleButton3.Enabled = _CurrentPage < _MaxPage;
                simpleButton4.Enabled = _CurrentPage < _MaxPage;
            }
        }

        void _ChangePage()
        {
            if (OnPageChange != null)
                OnPageChange(this, null);
        }

        public PageNavigator()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            dt.Columns.Add("value", typeof(int));
            dt.Columns.Add("text", typeof(string));
            foreach (int i in new int[] { 10, 50, 100, 500,1000,5000,10000,15000,20000 })
            {
                DataRow dr = dt.NewRow();
                dr["value"] = i;
                dr["text"] = i + " bản ghi mỗi trang";
                dt.Rows.Add(dr);
            }
            lookUpEdit2.Properties.DataSource = dt;
            lookUpEdit2.EditValue = 10;
        }

        public event EventHandler OnPageChange;

        private void lookUpEdit_Click(object sender, EventArgs e)
        {
            ((DevExpress.XtraEditors.LookUpEdit)sender).ShowPopup();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            _CurrentPage = Convert.ToInt32(lookUpEdit1.EditValue);
            _ChangePage();
        }

        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            _PageSize = Convert.ToInt32(lookUpEdit2.EditValue);
            _ChangePage();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (_CurrentPage > 1)
            {
                CurrentPage = 1;
                _ChangePage();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (_CurrentPage > 1)
            {
                CurrentPage = _CurrentPage - 1;
                _ChangePage();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (_CurrentPage < _MaxPage)
            {
                CurrentPage = _CurrentPage + 1;
                _ChangePage();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (_CurrentPage < _MaxPage)
            {
                CurrentPage = _MaxPage;
                _ChangePage();
            }
        }

    }
}
