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
    public partial class dlgUser2Role : dlgCustomBase
    {
        Core.Business.Logic.AccessRight.User logic = new Core.Business.Logic.AccessRight.User();
        DataTable Data;

        public List<long> SelectedID
        {
            get
            {
                return grv2.GetSelectedRows().Select(i => (long)grv2.GetDataRow(i)["id"]).ToList();
            }
            set
            {
                grv2.ClearSelection();
                foreach (var id in value)
                {
                    var dr = Data.Select("id=" + id).SingleOrDefault();
                    if (dr != null)
                        grv2.SelectRow(grv2.GetRowHandle(Data.Rows.IndexOf(dr)));
                }
            }
        }

        public dlgUser2Role()
        {
            InitializeComponent();

            Data= logic.GetAll();
            grd2.DataSource = Data;
        }
        private void dlgUser2Role_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grv2.SelectedRowsCount == 0)
            {
                Cls.GUIHelper.Notifications_msg(Cls.GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void dlgUser2Role_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing);
            this.Hide();
        }
    }
}
