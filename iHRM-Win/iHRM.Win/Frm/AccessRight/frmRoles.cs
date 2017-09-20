using iHRM.Core.i_Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Win.Cls;
using iHRM.Core.Business;
using iHRM.Common.Code;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic.AccessRight;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

namespace iHRM.Win.Frm.AccessRight
{
    public partial class frmRoles : frmBase
    {
        Core.Business.DbObject.dcDatabaseDataContext db = new Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
        Core.Business.Logic.AccessRight.Role logic = new Core.Business.Logic.AccessRight.Role();

        DataTable DataRoles;
        DataRow CRowRoles;

        public frmRoles()
        {
            InitializeComponent();
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            DataRoles = CacheDataTable.GetCacheDataTable("w5sysRole");
            grd.DataSource = DataRoles;
            LoadPreData();

            LoadGrvLayout(grv);
        }
        void LoadPreData()
        {
            foreach (Enums.eFunction e in Enum.GetValues(typeof(Enums.eFunction)))
            {
                if ((int)e == 0)
                    continue;

                var tc1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                tc1.Caption = e.ToString();
                tc1.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                tc1.FieldName = e.ToString();
                tc1.Tag = (int)e;
                tc1.Name = "r_" + ((int)e);
                tc1.Visible = true;
                tc1.VisibleIndex = (int)e;
                tc1.Width = 75;
                tc1.OptionsColumn.FixedWidth = true;
                tc1.OptionsColumn.AllowEdit = true;
                treeList1.Columns.Add(tc1);

            }
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }

        private void grv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                CRowRoles = grv.GetFocusedDataRow();
                if (CRowRoles == null)
                {
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                    return;
                }
                mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
                dw_it.Caption = "Đang tải dữ liệu phân quyền...";
                dw_it.OnDoing = (s, ev) =>
                {
                    var lst = db.w5sysRules.Where(i => i.roleID == (long)CRowRoles["id"]);
                    var data = logic.BuildTreeFunction(lst, 1);
                    dw_it.bw.ReportProgress(1, data);
                };
                dw_it.OnProcessing = (ps, data) =>
                {
                    treeList1.DataSource = data.UserState;
                };
                main.Instance.DoworkItem_Reg(dw_it);
            }
            catch
            {
                if (globall.indebug)
                    throw;
            }
        }
        bool meSetValue = false;
        private void treeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {

            setAllTree(e.Node, e.Column, e.Value);
            //Khi thay đổi update lại các nút cha của nó
            UpdateTreeList(e.Node, e.Column, e.Value);
            setChildTree(e.Node, e.Column, e.Value);
           
        }

        //update lại cái ruler

        bool setDongCapTree(TreeListNode n, TreeListColumn c, object v)
        {
            if ((bool)v)
                return true;
            else
            {
                foreach (TreeListNode n1 in n.Nodes)
                {
                    if (c.Name.StartsWith("r_"))
                    {
                        if ((bool)n1.GetValue(c.Caption))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        void setParentTree(TreeListNode n, TreeListColumn c, object v)
        {
           try
           {
               if (setDongCapTree(n.ParentNode, c, v))
               {
                   n.ParentNode.SetValue(c, true);
                   //setChildTree(n.ParentNode, c, v);
               }
               else
               {
                   //setChildTree(e.Node, e.Column, e.Value);
                   n.ParentNode.SetValue(c, false);
                   int h = 0;
                   h += (int)c.Tag;
                   string s = n.ParentNode.GetValue("rule") + "";
                   int kkk = int.Parse(s);
                   n.ParentNode.SetValue("rule", (int)(kkk - h));
                   setParentTree(n.ParentNode, c, (bool)n.ParentNode.GetValue(c.Caption));
               }
           }
           catch { }


        }


        void setChildTree(TreeListNode n, TreeListColumn c, object v)
        {
            foreach (TreeListNode nn in n.Nodes)
            {
                nn.SetValue(c, v);
                string s = n.GetValue("rule") + "";
                int k = int.Parse(s);
                nn.SetValue("rule", k);//gan gia tri
                setAllTree(nn, c, v);
                setChildTree(nn, c, v); //gan con cua no
            }
        }

        //duyệt tất cả nút từ nút tương tác trong TreeList
        void UpdateTreeList(TreeListNode nn, TreeListColumn c, object v)
        {
            //điền kiện thoát khỏi đệ quy
            if (nn == nn.RootNode)
                return;
            //gán giá trị mặt định ruler cho mỗi nút
            int rule = 1023;
            //duyệt tất cả các colum của mỗi nút
            foreach (DevExpress.XtraTreeList.Columns.TreeListColumn tc1 in treeList1.Columns)
            {
                if (tc1.Name.StartsWith("r_"))
                {
                    //kiểm tra nút đồng cấp đang duyệt có giá trị như thế nào
                    bool tammoi = value(nn, tc1.Caption, (bool)nn.ParentNode.GetValue(tc1.Caption));
                    //thực hiện gán giá trị cho thèn cha theo giá  trị của thèn con
                    if (tammoi)
                    {
                        nn.ParentNode.SetValue(tc1.Caption, true);
                    }
                    else
                    { 
                        nn.ParentNode.SetValue(tc1.Caption, false);
                        rule -= int.Parse(tc1.Tag + "");
                    }
                }
            }
            //chỉnh sửa lại cái rule cho thèn cha
            nn.ParentNode.SetValue("rule", rule);
            UpdateTreeList(nn.ParentNode, c, v);
        }
        /// <summary>
        /// Hàm này thực hiện duyệt tất các nút đồng cấp
        /// </summary>
        /// <param name="nn"></param>
        /// <param name="c"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool value(TreeListNode nn, string c, bool v)
        {
            bool h = v;
            foreach (TreeListNode n1 in nn.ParentNode.Nodes)
            {
                //duyệt tất cả các colum của môt nút
                foreach (DevExpress.XtraTreeList.Columns.TreeListColumn tc1 in treeList1.Columns)
                {
                    if (tc1.Name.StartsWith("r_"))
                    {
                        if(c==tc1.Caption)
                        {
                            if ((bool)n1.GetValue(tc1.Caption))
                            {
                                h = (bool)n1.GetValue(tc1.Caption);
                                goto mh;
                            }
                            h = (bool)n1.GetValue(tc1.Caption);
                        }
                    }
                }
            }
            mh:
            return h;
        }
        private void setAllTree(TreeListNode nn, TreeListColumn c, object v)
        {
            if (c == treeListColumn1) //neu cot dau thi gan cho cac cot sau
            {
                int rule = Convert.ToInt32(v);
                meSetValue = true;
                foreach (DevExpress.XtraTreeList.Columns.TreeListColumn tc1 in treeList1.Columns)
                {
                    if (tc1.Name.StartsWith("r_"))
                    {
                        nn.SetValue(tc1.FieldName, BitHelper.Has(rule, (int)tc1.Tag));
                    }
                }

                meSetValue = false;
            }
        }


        private void treeList1_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (meSetValue)
                return;

            if (e.Column.Name.StartsWith("r_"))
            {
                int rule = 0;
                foreach (DevExpress.XtraTreeList.Columns.TreeListColumn tc1 in treeList1.Columns)
                {
                    if (tc1.Name == e.Column.Name)
                    {
                        if ((bool)e.Value)
                        {
                            rule += (int)tc1.Tag;
                        }
                    }
                    else if (tc1.Name.StartsWith("r_"))
                    {
                        if ((bool)e.Node.GetValue(tc1.FieldName))
                            rule += (int)tc1.Tag;
                    }
                }
                e.Node.SetValue("rule", rule);
            }
        }

        private void buttonPanel2_OnSave(object sender, EventArgs e)
        {
            if (CRowRoles == null)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang lưu dữ liệu phân quyền...";
            dw_it.OnDoing = (s, ev) =>
            {
                List<w5sysRule> rules = new List<w5sysRule>();
                foreach (Role.ruleAlias ra in (treeList1.DataSource as List<Role.ruleAlias>))
                {
                    w5sysRule f = new w5sysRule();
                    f.functionID = ra.id;
                    f.roleID = (long)CRowRoles["id"];
                    f.rules = ra.rule;
                    f.status = 1;

                    rules.Add(f);
                }

                try
                {
                    using (var ts = new System.Transactions.TransactionScope())
                    {
                        w5sysRole r1 = db.w5sysRoles.SingleOrDefault(i => i.id == (long)CRowRoles["id"]);
                        if (r1 == null)
                        {
                            dw_it.bw.ReportProgress(1, "Record not found");
                            return;
                        }

                        db.w5sysRules.DeleteAllOnSubmit(r1.w5sysRules);
                        db.SubmitChanges();

                        db.w5sysRules.InsertAllOnSubmit(rules);
                        db.SubmitChanges();

                        ts.Complete();
                    }

                    dw_it.bw.ReportProgress(2, "Cập nhật thành công!");
                    return;
                }
                catch (Exception ex)
                {
                    dw_it.bw.ReportProgress(1, ex.Message);
                    return;
                }
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                    GUIHelper.MessageError(data.UserState as string, "Có lỗi trong quá trình lưu dữ liệu phân quyền");
                else if (data.ProgressPercentage == 2)
                    GUIHelper.Notifications(data.UserState as string, "Lưu dữ liệu phân quyền", GUIHelper.NotifiType.tick);
            };

            main.Instance.DoworkItem_Reg(dw_it);

        }

        #region control nhom quyen

        dlgRoles _dlgEditor = null;
        dlgRoles dlgEditor
        {
            get
            {
                if (_dlgEditor == null)
                {
                    _dlgEditor = new dlgRoles();
                    dlgEditor.Owner = this;
                    dlgEditor.OnSave += dlgEditor_OnSave;
                }
                return _dlgEditor;
            }
            set
            {
                _dlgEditor = value;
            }
        }

        private void dlgEditor_OnSave(object sender, EventArgs e)
        {
            try
            {
                var db = new dcDatabaseDataContext(Provider.ConnectionString);
                if (dlgEditor.CustomFormAction == 0)
                {
                    w5sysRole r = new w5sysRole();
                    SetDataContextFromDataRow(r, dlgEditor.MyValue);
                    r.status = 1;
                    db.w5sysRoles.InsertOnSubmit(r);
                    db.SubmitChanges();

                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                    DataRoles.Rows.Add(dlgEditor.MyValue);
                }
                else
                {
                    var r = db.w5sysRoles.SingleOrDefault(i => i.id == (long)dlgEditor.myID);
                    if (r == null)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                        return;
                    }

                    SetDataContextFromDataRow(r, dlgEditor.MyValue);
                    db.SubmitChanges();
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                }
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }

        private void buttonPanel1_OnNew(object sender, EventArgs e)
        {
            dlgEditor.MyValue = DataRoles.NewRow();
            dlgEditor.CustomFormAction = 0;
            dlgEditor.Show();
        }

        private void buttonPanel1_OnEdit(object sender, EventArgs e)
        {
            dlgEditor.MyValue = CRowRoles;
            dlgEditor.CustomFormAction = 1;
            dlgEditor.Show();
        }

        private void buttonPanel1_OnDelete(object sender, EventArgs e)
        {
            if (CRowRoles == null)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            try
            {
                using (var ts = new System.Transactions.TransactionScope())
                {
                    w5sysRole r1 = db.w5sysRoles.SingleOrDefault(i => i.id == (long)CRowRoles["id"]);
                    if (r1 == null)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                        return;
                    }

                    db.w5sysRules.DeleteAllOnSubmit(r1.w5sysRules);
                    db.SubmitChanges();

                    db.w5sysRoles.DeleteOnSubmit(r1);
                    db.SubmitChanges();

                    ts.Complete();
                }

                CRowRoles.Delete();
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
                return;
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message, "Xóa nhóm quyền không thành công");
                return;
            }

        }

        #endregion

    }
}
