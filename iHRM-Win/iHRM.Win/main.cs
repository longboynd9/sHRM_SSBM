using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using iHRM.Win.Cls;
using iHRM.Win.Frm;
using iHRM.Win.Frm.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace iHRM.Win
{
    public class main
    {
        public static mainBase Instance = null;

        public static void Load()  
        {
            Instance = new Frm.mainForm.main4();
            //Instance.ShowForm("iHRM.Win.Frm.Common.frmHome");
            //Instance.ShowForm("iHRM.Win.Frm.Common.frmHuongDanSuDung");
        }
    }

    public class mainBase : RibbonForm
    {
        public class Dowork_Item
        {
            public string Caption { get; set; }
            public DoWorkEventHandler OnDoing;
            public ProgressChangedEventHandler OnProcessing;
            public RunWorkerCompletedEventHandler OnCompleting;
            public BackgroundWorker bw { get; set; }
        }

        protected Queue<Dowork_Item> Queue_DoworkItem = new Queue<Dowork_Item>();
        protected Dowork_Item Doworking_Item;
        public virtual void DoworkItem_Reg(Dowork_Item item) { }

        public mainBase()
        {
        }

    }
}
