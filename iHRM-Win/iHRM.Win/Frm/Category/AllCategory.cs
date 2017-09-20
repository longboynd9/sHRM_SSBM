using iHRM.Core.Business;
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
    public partial class AllCategory : Form
    {
        Core.Business.Logic.Category.CatDefine logic = new Core.Business.Logic.Category.CatDefine();

        public AllCategory()
        {
            InitializeComponent();
        }

        private void AllCategory_Load(object sender, EventArgs e)
        {
            var dt = logic.GetAllCatDefine();

            this.btnFormLst.DropDownItems.AddRange(dt.Select().Select(i => new System.Windows.Forms.ToolStripMenuItem()
            {
                Text = i[TableConst.tbCatDefine.caption].ToString(), 
                Tag = i
            }).ToArray());
        }

        private void btnFormLst_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var dr = e.ClickedItem.Tag as DataRow;

            Guid id = (Guid)dr["id"];
            foreach(CategoryDetail frm in this.MdiChildren)
            {
                if (frm.ID_CatCatDefine == id)
                {
                    frm.Activate();
                    return;
                }
            }
            CategoryDetail frm1 = new CategoryDetail();
            frm1.ID_CatCatDefine = id;
            frm1.TopLevel = false;
            frm1.MdiParent = this;
            frm1.Show();
        }
        
    }
}
