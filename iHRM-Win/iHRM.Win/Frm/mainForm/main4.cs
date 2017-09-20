using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace iHRM.Win.Frm.mainForm
{
    public partial class main4 : mainBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        BackgroundWorker bgw_doWork = new BackgroundWorker();
        List<w5sysFunction> _lFunc = new List<w5sysFunction>();
        List<FuncSearch> _lFuncSearch = new List<FuncSearch>();
        public main4()
        {
            InitializeComponent();
            bgw_doWork.WorkerReportsProgress = true;
            bgw_doWork.WorkerSupportsCancellation = true;
            bgw_doWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_doWork_DoWork);
            bgw_doWork.ProgressChanged += bgw_doWork_ProgressChanged;
            bgw_doWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_doWork_RunWorkerCompleted);
            _lFunc = db.w5sysFunctions.ToList();
            loadMenu();

            rep_SearchLookUpEdit2.DataSource = _lFuncSearch;
            rep_SearchLookUpEdit2.DisplayMember = "caption";
            rep_SearchLookUpEdit2.ValueMember = "asemblyInherits";
            this.Text += "[" + LoginHelper.user.caption + "]";
            barSubItem1.MenuCaption = LoginHelper.user.caption;
            barStaticItem2.Caption = "Version " + win_globall.updater_ver;
            barStaticItem1.Caption = Environment.MachineName;
        }
        //public void loadMenu(int roleID) 
        public void loadMenu()
        {
            foreach (var page in _lFunc.Where(p => p.parentId == 2 && p.status.Value == 1).OrderBy(p => p.order1))
            {
                if (!BitHelper.Has(LoginHelper.getRightAccess(page.id), (int)Enums.eFunction.Find)) continue; //cos quyeefn find thi moi hien

                RibbonPage rb_Page = new RibbonPage(page.caption);
                foreach (var group in _lFunc.Where(p => p.parentId == page.id && p.status.Value == 1).OrderBy(p => p.order1))
                {
                    if (!BitHelper.Has(LoginHelper.getRightAccess(group.id), (int)Enums.eFunction.Find)) continue;

                    RibbonPageGroup rb_Group = new RibbonPageGroup(group.caption);
                    foreach (var button in _lFunc.Where(p => p.parentId == group.id && p.status.Value == 1).OrderBy(p => p.order1))
                    {
                        if (!BitHelper.Has(LoginHelper.getRightAccess(button.id), (int)Enums.eFunction.Find)) continue;
                        FuncSearch funcSear = new FuncSearch() { id = button.id, caption = button.caption, asemblyInherits = button.asemblyInherits };
                        _lFuncSearch.Add(funcSear);
                        BarButtonItem btn_Item = new BarButtonItem();
                        btn_Item.Caption = button.caption;
                        if (button.icon != null)
                        {
                            btn_Item.LargeGlyph = Image.FromStream(new MemoryStream(button.icon.ToArray()));
                        }
                        btn_Item.Tag = button;
                        btn_Item.ItemClick += btn_ItemClick;
                        rb_Group.ItemLinks.Add(btn_Item);
                    }
                    rb_Page.Groups.Add(rb_Group);
                }
                ribbonControl1.Pages.Add(rb_Page);
            }
            ribbonControl1.Pages.Remove(ribbonPage1);
            ribbonControl1.Pages.Add(ribbonPage1);
        }

        private string[] getStrFormFromName(string name)
        {
            string str_state = "", str_Form = "";

            if (name[0] == '#')
            {
                str_state = name.Substring(1, name.IndexOf("/") - 1);
                name = name.Substring(name.IndexOf("/") + 1);
            }

            if (name.IndexOf("(") > 0)
            {
                str_Form = name.Substring(0, name.IndexOf("("));
            }
            else
            {
                str_Form = name;
            }
            return new string[] { str_Form, str_state };
        }
        private Dictionary<string, string> getParamfromName(string name)
        {
            Dictionary<string, string> paramts = new Dictionary<string, string>();
            string str_Param = "";
            if (name.IndexOf("(") > 0)
            {
                str_Param = name.Substring(name.IndexOf("("), name.IndexOf(")") - name.IndexOf("(") + 1);
                foreach (string item in str_Param.Replace(" ", "").Replace("(", "").Replace(")", "").Split(','))
                {
                    string key = item.Split('=')[0];
                    string value = item.Split('=')[1];
                    paramts.Add(key, value);
                }
            }
            return paramts;
        }
        private void btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            w5sysFunction fn = (w5sysFunction)e.Item.Tag;
            string name = (fn.modal == 1 ? "#dialog/" : (fn.modal == 2 ? "#owner/" : (fn.modal == 3 ? "#another/" : ""))) + fn.asemblyInherits;
            var frm = showFormByPath(name);
            if (frm != null)
            {
                if (frm is frmBase)
                {
                    (frm as frmBase).iRule = LoginHelper.getRightAccess(fn.id);
                }
            }
        }
        private Form showFormByPath(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name == "*")
            {
                GUIHelper.MessageBox("Form chưa được định nghĩa");
                return null;
            }

            string str_Form = "", str_state = "";
            // Get params in form.
            Form frm_Exist = GetFormExist(name);
            if (frm_Exist == null)
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                var a1 = getStrFormFromName(name);
                str_Form = a1[0]; str_state = a1[1];
                param = getParamfromName(name);

                Type typ = Type.GetType(str_Form);
                Form frm_Cre = (Form)Activator.CreateInstance(typ);
                // Set param for form
                try
                {
                    foreach (var p in param)
                    {
                        var a = typ.GetProperty(p.Key);
                        a.SetValue(frm_Cre, p.Value);
                    }
                }
                catch (Exception ex)
                {
                    GUIHelper.Notifications("Lỗi set parameter Form", "Lỗi", GUIHelper.NotifiType.error);
                }

                switch (str_state)
                {
                    case "dialog":
                        frm_Cre.ShowDialog();
                        break;
                    case "owner":
                        frm_Cre.Owner = this;
                        frm_Cre.Show();
                        break;
                    case "another":
                        frm_Cre.ShowDialog();
                        break;
                    case "close":
                    case "logout":
                        this.Close();
                        break;
                    default:
                        frm_Cre.MdiParent = this;
                        frm_Cre.Show();
                        break;
                }
                return frm_Cre;
            }
            else
            {
                frm_Exist.Activate();
                return frm_Exist;
            }
        }

        private Form GetFormExist(string name)
        {
            Type typ_Frm = Type.GetType(getStrFormFromName(name)[0]);
            Form frm = (Form)Activator.CreateInstance(typ_Frm);

            foreach (Form item in this.MdiChildren)
            {
                Type typ_Item = item.GetType();
                if (typ_Item == typ_Frm) // Nếu là form thì so sánh tiếp param.
                {
                    bool isEqualParams = true;

                    foreach (var p_Frm in getParamfromName(name))
                    {

                        try
                        {
                            var p_Item = typ_Item.GetProperty(p_Frm.Key);
                            if (p_Item.GetValue(item).ToString() != p_Frm.Value.ToString())
                            {
                                isEqualParams = false;
                            }
                        }
                        catch (Exception)
                        {
                            isEqualParams = false;
                            GUIHelper.Notifications("Không thể truy cập thuộc tính " + p_Frm.Key, "Lỗi", GUIHelper.NotifiType.error);
                        }

                    }
                    if (isEqualParams)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public override void DoworkItem_Reg(Dowork_Item item)
        {
            Queue_DoworkItem.Enqueue(item);
            item.bw = bgw_doWork;

            if (!bgw_doWork.IsBusy)
            {
                barEditItem4.Visibility = BarItemVisibility.Always;
                bgw_doWork.RunWorkerAsync();
            }
        }

        bool Done_nextDoing = false;
        private void bgw_doWork_DoWork(object sender, DoWorkEventArgs e)
        {
            while (Queue_DoworkItem.Count > 0)
            {
                Doworking_Item = Queue_DoworkItem.Dequeue();
                if (Doworking_Item.OnDoing != null)
                {
                    Done_nextDoing = false;
                    bgw_doWork.ReportProgress(-100, Doworking_Item.Caption);
                    Doworking_Item.OnDoing(sender, e);
                    bgw_doWork.ReportProgress(-101);

                    while (!Done_nextDoing)
                        System.Threading.Thread.Sleep(350);
                }
            }
        }
        void bgw_doWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case -100:
                    barStaticItem5.Caption = e.UserState as string;
                    break;
                case -101:
                    Done_nextDoing = true;
                    break;
                default:
                    if (Doworking_Item.OnProcessing != null)
                        Doworking_Item.OnProcessing(sender, e);
                    break;
            }
        }
        private void bgw_doWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Doworking_Item.OnCompleting != null)
                Doworking_Item.OnCompleting(sender, e);
            barEditItem4.Visibility = BarItemVisibility.Never;
            barStaticItem5.Caption = "Ready";
        }

        private void ribbonControl1_SelectedPageChanged(object sender, EventArgs e)
        {
        //    if (ribbonControl1.SelectedPage != rbTimKiem)
        //    {
        //        panelControl1.Visible = false;
        //    }
        //    else
        //    {
        //        bEItemFindFunc.Links[0].Focus();
        //    }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //showFormByPath("iHRM.Win.Frm.Employee.ImportAnhNhanVien");
            showFormByPath("iHRM.Win.Frm.QuetThe.frmDangKyCongTacDaiHan");
        }

        private void rep_SearchLookup_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void barEditItem3_EditValueChanged(object sender, EventArgs e)
        {
            string Path = barEditItem3.EditValue.ToString();
         
            if (Path != null)
            {
                showFormByPath(Path);
            }
        }
        
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            AccessRight.frmChangePassword frm = new AccessRight.frmChangePassword();
            frm.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            showFormByPath("iHRM.Win.Frm.AccessRight.frmFunctions");
        }

        private void barButtonItem3_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            showFormByPath("iHRM.Win.Frm.AccessRight.frmRoles");
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            showFormByPath("iHRM.Win.Frm.AccessRight.frmUsers");
        }

        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            showFormByPath("iHRM.Win.Frm.QuetThe.frmDieuChinhCongTacDaiHan");
        }
    }

    public class FuncSearch
    {
        public long id { get; set; }
        public string caption { get; set; }
        public string asemblyInherits { get; set; }
    }

}
