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
    public partial class ChonPhongBan_Old : UserControl
    {
        public event EventHandler OnSelected;
        public string SelectedValue
        {
            get { return treeDept.EditValue as string; }
            set { treeDept.EditValue = value; }
        }

        public DataRow SelectedRow
        {
            get
            {
                var r = treeDept.GetSelectedDataRow() as DataRowView;
                return r == null ? null : r.Row;
            }
        }

        public ChonPhongBan_Old()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!this.InDesignMode())
            {
                treeDept.Properties.DataSource = Cls.CacheDataTable.GetCacheDataTable(Core.Business.TableConst.tblRef_Department.TableName);
            }
        }

        private void treeDept_Resize(object sender, EventArgs e)
        {
           // this.Height = treeDept.Height;
        }

        private void treeDept_EditValueChanged(object sender, EventArgs e)
        {
            if (OnSelected != null)
                OnSelected(treeDept, null);
        }
    }
}
