using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace iHRM.Win
{
    static class Program
    {
        [System.Runtime.InteropServices.DllImport("shell32.dll")]
        public static extern bool IsUserAnAdmin();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] agrs)
        {
            win_globall.agrs = (agrs == null || agrs.Length == 0 ? "" : agrs[0]);



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadExit += Application_ThreadExit;
            Application.ThreadException += Application_ThreadException;

            Config.Load();
            try
            {
                if (Config.appConfig.InstalledDLL == 0)
                {
                    var p = Process.Start(new ProcessStartInfo()
                    {
                        FileName = "SetupAttMachine.exe",
                        UseShellExecute = true
                    });
                    p.WaitForExit();
                    if (p.ExitCode != 1)
                    {
                        GUIHelper.MessageError("Bạn cần copy tay thư viện vào C:\\System32 và C:\\SysWow64", "Lỗi copy dll");
                        return;
                    }

                    Config.appConfig.InstalledDLL = 1;
                    Config.Save();
                }
            }
            catch (Exception)
            {
            }

            string DxHelper = System.IO.Path.Combine(win_globall.apppath, "DxHelper" + (IsUserAnAdmin() ? "_admin" : "") + ".exe");
            if (System.IO.File.Exists(DxHelper))
                System.Diagnostics.Process.Start(DxHelper);

            iHRM.Core.Business.Provider.ConnectionString = Frm.Common.frmConnect.buildcauhinh(Config.appConfig.strcnn);
            Control.CheckForIllegalCrossThreadCalls = false;

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(Config.appConfig.istyle);


            Application.Run(new Frm.Common.frmLogin());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Frm.Common.frmError er = new Frm.Common.frmError();
            er.ShowEx(e.Exception);
            er.ShowDialog();
        }

        private static void Application_ThreadExit(object sender, EventArgs e)
        {
            Config.Save();
        }
    }
}
