using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace iHRM.Win.Frm.mainForm
{
    public partial class main3 : mainBase
    {
        Frm.Common.frmProgress frmPrg;

        public main3()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            frmPrg = new Frm.Common.frmProgress();
            frmPrg.Owner = this;
        }
        private void main_Load(object sender, EventArgs e)
        {
            LoadUser();
        }
        #region 4 mennu event

        void LoadUser()
        {
            #region tải menu async
            var actionInitMenu = new DoWork_Item();
            actionInitMenu.Caption = "Đang tải phân quyền...";
            actionInitMenu.OnDoing = (bg) =>
            {
                //load top menu                
                var dt = LoginHelper.user.w5sysRole.w5sysRules
                    .Where(i => i.w5sysFunction.parentId == const1.functionRootTreeID)
                    .OrderBy(i => i.w5sysFunction.order1).ToList();
                bg.ReportProgress(1, dt);
            };
            actionInitMenu.OnReport = (idx, obj) =>
            {
                if (idx == 1)
                    initTopMenu(obj as List<w5sysRule>);
            };
            DoWork_Reg(actionInitMenu);
            #endregion
        }

        void initTopMenu(List<w5sysRule> dt)
        {
            var lstBtnTopMenu = dt.Where(i => BitHelper.Has(i.rules, (int)Enums.eFunction.Find)).Select(i => CreateTopMenuButton(i.w5sysFunction));
            bar5.RemoveLink(barButtonItem3.Links[0]);
            for (int i = bar5.ItemLinks.Count - 1; i >= 0; i--)
            {
                barManager1.Items.Remove(bar5.ItemLinks[i].Item);
                //bar5.RemoveLink(bar5.ItemLinks[i]);
            }

            foreach (var btn in lstBtnTopMenu)
            {
                var bi = new DevExpress.XtraBars.BarItem[] { btn };
                barManager1.Items.AddRange(bi);
                bar5.AddItems(bi);
            }
            bar5.AddItems(new DevExpress.XtraBars.BarItem[] { barButtonItem3 });

            barButtonItem3.Caption = LoginHelper.user.caption;

            if (Language.CurrentLng == eLanguage.VN)
            {
                barStaticItem7.Glyph = Properties.Resources.vn;
                barStaticItem7.Caption = "Tiếng việt";
                this.Text = DbHelper.DrGetString(LoginHelper.Dept, "caption") + " - ACPlus";
            }
            else
            {
                barStaticItem7.Glyph = Properties.Resources.en;
                barStaticItem7.Caption = "English";
                this.Text = DbHelper.DrGetString(LoginHelper.Dept, "caption_EN") + " - ACPlus";
            }

            //idLogo.Src = DbHelper.DrGetString(LoginHelper.Dept, "logo");
            //if (string.IsNullOrWhiteSpace(idLogo.Src))
            //    idLogo.Src = "/sHRM/Styles/img/Logo_129.png";
            barStaticItem10.Caption = Environment.MachineName;
            barStaticItem11.Caption = DbHelper.DrGetString(LoginHelper.Dept, "code");

            //treeList1.DataSource = LoginHelper.user.w5sysRole.w5sysRules.Select(i => i.w5sysFunction)
            //    .OrderBy(i => i.order1).ToList();
            treeList1.DataSource = null;
        }

        private void barStaticItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm.Common.frmTTTK frm = new Frm.Common.frmTTTK();
            frm.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void barStaticItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DxStyleList frm = new DxStyleList();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Config.appConfig.istyle = frm.SelectedStyle;
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(Config.appConfig.istyle);
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Frm.Common.frmLogin();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadUser();
            }
        }

        DevExpress.XtraBars.BarButtonItem CreateTopMenuButton(w5sysFunction f)
        {
            var bb = new DevExpress.XtraBars.BarButtonItem();
            bb.Caption = Language.CurrentLng == eLanguage.VN ? f.caption : f.caption_EN;
            if (!string.IsNullOrWhiteSpace(f.asemblyInherits) && !f.caption.StartsWith("*"))
                bb.Caption = "*" + bb.Caption;

            bb.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            bb.Tag = f;
            bb.ItemClick += Bb_ItemClick;
                        
            return bb;
        }

        private void Bb_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = e.Item.Tag as w5sysFunction;
            treeList1.DataSource = AddLeftMenu(f.id);
        }

        List<w5sysFunction> AddLeftMenu(long pID)
        {
            var lst = LoginHelper.user.w5sysRole.w5sysRules.Select(i => i.w5sysFunction)
                .Where(i => i.parentId == pID)
                .OrderBy(i => i.order1).ToList();

            List<w5sysFunction> lst2 = new List<w5sysFunction>();
            foreach (var it in lst)
                lst2.AddRange(AddLeftMenu(it.id));

            lst.AddRange(lst2);

            foreach (var it in lst)
            {
                if (!string.IsNullOrWhiteSpace(it.asemblyInherits) && !it.caption.StartsWith("*"))
                    it.caption = "*" + it.caption;
            }

            return lst;
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode == null)
                return;

            var fn = treeList1.GetDataRecordByNode(treeList1.FocusedNode) as w5sysFunction;
            //treeList1.FocusedNode.Selected = true;
            ShowForm(fn.asemblyInherits);
        }
        
        #endregion

        #region doWork

        public override void DoWork_Reg(DoWork_Item item)
        {
            DoWork_queueItem.Enqueue(item);
            if (!bgw_doWork.IsBusy)
            {
                bgw_doWork.RunWorkerAsync();
                barEditItem3.Visibility = barStaticItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }

        private void bgw_doWork_DoWork(object sender, DoWorkEventArgs e)
        {
            while (DoWork_queueItem.Count > 0)
            {
                DoWork_doingItem = DoWork_queueItem.Dequeue();
                bgw_doWork.ReportProgress(-1, DoWork_doingItem.Caption);
                if (DoWork_doingItem.OnDoing != null)
                    DoWork_doingItem.OnDoing(bgw_doWork);
            }
        }
        private void bgw_doWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
            {
                barStaticItem1.Caption = e.UserState.ToString();
            }
            else
            {
                if (DoWork_doingItem != null && DoWork_doingItem.OnReport != null)
                    DoWork_doingItem.OnReport(e.ProgressPercentage, e.UserState);
            }
        }
        private void bgw_doWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            barEditItem3.Visibility = barStaticItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barStaticItem1.Caption = "Ready";
        }

        private void barStaticItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bgw_doWork.CancelAsync();
        }

        #endregion

        #region do progress
        
        public override void DoProgress_Reg(DoProgress_Item item)
        {
            DoProgress_queueItem.Enqueue(item);
            if (!bgw_doProgress.IsBusy)
            {
                bgw_doProgress.RunWorkerAsync();
                barEditItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }

        private void bgw_doProgress_DoWork(object sender, DoWorkEventArgs e)
        {
            while (DoProgress_queueItem.Count > 0)
            {
                DoProgress_doingItem = DoProgress_queueItem.Dequeue();
                bgw_doProgress.ReportProgress(-1);

                DoProgress_doingItem.SetProgressValue = (v) => { bgw_doProgress.ReportProgress(-2, v); };
                DoProgress_doingItem.SetProgressText = (v) => { bgw_doProgress.ReportProgress(-3, v); };
                DoProgress_doingItem.SetProgressStatus = (v) => { bgw_doProgress.ReportProgress(-4, v); };
                DoProgress_doingItem.OutProgressMessage = (v) => { bgw_doProgress.ReportProgress(-5, v); };

                if (DoProgress_doingItem.OnDoing != null)
                    DoProgress_doingItem.OnDoing(bgw_doProgress);
            }
        }
        private void bgw_doProgress_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case -1:
                    barStaticItem1.Caption = DoProgress_doingItem.Caption;
                    frmPrg.Form_Title = DoProgress_doingItem.Caption;
                    frmPrg.Form_Description = DoProgress_doingItem.Desciption;
                    frmPrg.Show(); frmPrg.BringToFront();
                    break;
                case -2:
                    frmPrg.SetProgressValue((int)e.UserState);
                    break;
                case -3:
                    frmPrg.SetProgressText((string)e.UserState);
                    break;
                case -4:
                    frmPrg.SetProgressStatus((DoProgress_status)e.UserState);
                    break;
                case -5:
                    frmPrg.OutProgressMessage((string)e.UserState);
                    break;
                default:
                    if (DoProgress_doingItem != null && DoProgress_doingItem.OnReport != null)
                        DoProgress_doingItem.OnReport(e.ProgressPercentage, e.UserState);
                    break;
            }
        }
        private void bgw_doProgress_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //frmPrg.Hide();
            barEditItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barStaticItem1.Caption = "Ready";
        }
        #endregion
    }
}
