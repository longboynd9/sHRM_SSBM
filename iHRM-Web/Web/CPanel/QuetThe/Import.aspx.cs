using System;
using iHRM.WebPC.Code;
using System.IO;
using iHRM.Core.Business.Logic;

namespace iHRM.WebPC.Cpanel.QuetThe
{
    public partial class Import : BackEndPageBase
    {
        Core.Controller.QuetThe.NhapDuLieuQuetThe controller = new Core.Controller.QuetThe.NhapDuLieuQuetThe();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string datas = AllLogic.SaveData_Get("ImpDLQuetThe");
                if (datas[0] == '2')
                    ktPhay.Checked = true;
                datas = datas.Substring(1);
                var a = datas.Split(',');

                stoMapping.DataSource = new object[]
                {
                    new object[]{Lng.QuetThe_Import.somay, a.Length > 0 ? a[0] : "0"},
                    new object[]{Lng.QuetThe_Import.ngay, a.Length > 1 ? a[1] : "1"},
                    new object[]{Lng.QuetThe_Import.gio, a.Length > 2 ? a[2] : "2"},
                    new object[]{Lng.QuetThe_Import.mathe, a.Length > 3 ? a[3] : "3"},
                    new object[]{Lng.QuetThe_Import.mamay, a.Length > 4 ? a[4] : "5"}
                };
                stoMapping.DataBind();

                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }

        protected void btnAttack_Click(object sender, EventArgs e)
        {
            if (txtUpFile.HasFile)
            {
                string p = Server.MapPath("~/Cpanel/QuetThe/Tempory/Import1/");
                if (Directory.Exists(p))
                {
                    try
                    {
                        Directory.Delete(p, true);
                    }
                    catch
                    {
                        do
                        {
                            p = Server.MapPath("~/Cpanel/QuetThe/Tempory/Import" + new Random().Next() + "");
                        }
                        while (Directory.Exists(p));
                    }
                }

                //if (txtUpFile.PostedFile.ContentType.ToLower() != "application/octet-stream")
                if (!txtUpFile.FileName.EndsWith(".zip", StringComparison.CurrentCultureIgnoreCase)
                    && !txtUpFile.FileName.EndsWith(".txt", StringComparison.CurrentCultureIgnoreCase))
                {
                    Tools.message(Lng.QuetThe_Import.msg_2);
                    return;
                }

                try
                {
                    if (!Directory.Exists(p))
                        Directory.CreateDirectory(p);

                    string msg = "";
                    if (txtUpFile.FileName.EndsWith(".zip"))
                    {
                        string zipFilePath = Path.Combine(p, "import.zip");
                        txtUpFile.PostedFile.SaveAs(zipFilePath);

                        using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile(zipFilePath))
                        {
                            zip.ExtractAll(p, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
                        }
                        //File.Delete(zipFilePath);

                        foreach (FileInfo fi in (new DirectoryInfo(p)).GetFiles("*.txt"))
                        {
                            try
                            {
                                msg += doImport(fi) + "\n";
                            }
                            catch (Exception ex)
                            {
                                msg += string.Format("File: {0} -----ex: {1}", fi.Name, ex.Message);
                            }
                        }
                    }
                    else
                    {
                        string txtFilePath = Path.Combine(p, "import.txt");
                        txtUpFile.PostedFile.SaveAs(txtFilePath);
                        
                        var fi = new FileInfo(txtFilePath);
                        try
                        {
                            msg += doImport(fi) + "\n";
                        }
                        catch (Exception ex)
                        {
                            msg += string.Format("File: {0} -----ex: {1}", fi.Name, ex.Message);
                        }
                    }

                    txtLog.Text = msg;
                }
                catch
                {
                    Tools.message(Lng.QuetThe_Import.msg_3);
                    return;
                }
            }
        }

        private string doImport(FileInfo fi)
        {
            int m_soMay, m_ngay, m_gio, m_maThe, m_maMay;
            #region mapping
            string s = h_mapping.Value as string;
            if (s.EndsWith(","))
                s = s.Substring(0, s.Length - 1);
            var a = s.Split(',');
            m_soMay = int.Parse(a[0]);
            m_ngay = int.Parse(a[1]);
            m_gio = int.Parse(a[2]);
            m_maThe = int.Parse(a[3]);
            m_maMay = int.Parse(a[4]);
            #endregion

            //save state
            string datas = "1";
            if (ktPhay.Checked)
                datas = "2";
            datas += s;
            AllLogic.SaveData_Set("ImpDLQuetThe", datas);

            return controller.doImport(fi.FullName, m_soMay, m_ngay, m_gio, m_maThe, m_maMay, ktPhay.Checked ? ',' : '\t');
        }

        DateTime AddTime(DateTime d, string time) //07:30:26
        {
            string[] a = time.Split(':');
            return d.AddHours(int.Parse(a[0])).AddMinutes(int.Parse(a[1])).AddSeconds(int.Parse(a[2]));
        }
    }
}