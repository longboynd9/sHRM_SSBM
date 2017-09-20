using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Configuration;
using System.Xml;
using System.IO;
using System.Net;
using System.Text;
using System.Data;
using System.Linq;
using Ext.Net;
using iHRM.WebPC.Classes;
using System.Data.SqlClient;
using iHRM.Common.Code;
using iHRM.Core.Controller.Import;
using iHRM.Core.Controller.Employee;

namespace iHRM.WebPC.Cpanel.Import
{
    public class importEmployeeHub : Hub
    {
        static bool isPlay = false;

        public importEmployeeHub()
        {
        }

        public void ToClient_Logg(LogItem log)
        {
            Clients.All.broadcastMessage("log", JSON.Serialize(log));
        }
        public void ToClient_Logg(string status, msgStt status_code, string message = "")
        {
            LogItem log = new LogItem()
            {
                id = Guid.NewGuid(),
                message = message,
                status = status,
                status_code = status_code,
                time = DateTime.Now
            };
            Clients.All.broadcastMessage("log", JSON.Serialize(log));
        }
        public void ToClient_SendAction(string action, string data, string data2 = "")
        {
            Clients.All.broadcastMessage(action, data, data2);
        }

        public void SendFromClient(string code, string data)
        {
            try
            {
                switch (code)
                {
                    case "START":
                        RunImport(data);
                        break;
                    case "STOP":
                        isPlay = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                ToClient_SendAction("exec-client-code-false", code, ex.Message);
            }
        }

        List<cMapping> colMapping = new List<cMapping>();

        void RunImport(string code)
        {
            string[] a = code.Split('|');
            string p = HttpContext.Current.Server.MapPath("~/Cpanel/Import/Tempory/" + a[0]);
            if (!File.Exists(p))
            {
                ToClient_Logg("File import not fount", msgStt.danger);
                return;
            }

            global::iHRM.Core.Business.Logic.AllLogic.SaveData_Set("ImpEmp_colMap", a[2]);
            foreach (string s in a[2].Split(','))
            {
                if (string.IsNullOrWhiteSpace(s))
                    continue;

                int i = s.IndexOf(':');
                if (i == -1)
                    continue;

                var m = impEmployee.lstEmpMapping.SingleOrDefault(it => it.c1 == s.Substring(0, i));
                if (m != null)
                    colMapping.Add(new cMapping() { c1 = m.c1, dataType = m.dataType, c2 = s.Substring(i + 1) });
            }

            //ImportBase importer = null;
            //if (a.Length > 1)
            //{
            //    Type t = Type.GetType("iHRM.WebPC.Cpanel.Import." + a[1]);
            //    importer = Activator.CreateInstance(t) as ImportBase;
            //}

            ExcelExtend excel = new ExcelExtend();
            excel.OpenFile(p);
            var dt = excel.GetAllAvalidData();
            ToClient_Logg("START import", msgStt.info);
            ToClient_SendAction("start-import", dt.Rows.Count.ToString());

            isPlay = true;
            try
            {
                int idx = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    ToClient_Logg(DoImport(dr));
                    idx += 1;
                    ToClient_SendAction("import-prg", idx.ToString());

                    if (!isPlay)
                    {
                        ToClient_Logg("STOP import", msgStt.info);
                        break;
                    }
                }

                ToClient_Logg("Import complete", msgStt.info);
            }
            catch (Exception ex)
            {
                ToClient_Logg("Import fail", msgStt.warning, ex.Message);
            }
        }

        public LogItem DoImport(System.Data.DataRow dr)
        {
            LogItem li = new LogItem();
            try
            {
                var pa = new SqlParameter[colMapping.Count];
                for (int i = 0; i < colMapping.Count; i++)
                {
                    pa[i] = new SqlParameter();
                    pa[i].ParameterName = colMapping[i].c1;

                    switch (colMapping[i].dataType)
                    {
                        case 's':
                            pa[i].Value = ImportHelper.MakeSureString(dr[colMapping[i].c2]);
                            break;
                        case 'i':
                            pa[i].Value = ImportHelper.MakeSureInt(dr[colMapping[i].c2]);
                            break;
                        case 'd':
                            pa[i].Value = ImportHelper.MakeSureDate(dr[colMapping[i].c2]);
                            break;
                        case 'f':
                            pa[i].Value = ImportHelper.MakeSureFloat(dr[colMapping[i].c2]);
                            break;
                        default:
                            pa[i].Value = dr[colMapping[i].c2];
                            break;
                    }
                }

                var ret = global::iHRM.Core.Business.Provider.ExecuteNonQuery("p_Employee_Import_Excel_AllColumn", pa);

                if (ret.ReturnValue == 1)
                {
                    li.status = "Done";
                    li.message = "";
                    li.status_code = msgStt.success;
                }
                else
                {
                    li.status = "Fail";
                    if (ret.ReturnValue == -1)
                        li.message = "NV đã tồn tại";
                    li.status_code = msgStt.warning;
                }
            }
            catch (Exception ex)
            {
                li.status = "Exception thorw";
                li.message = ex.Message;
                li.status_code = msgStt.danger;
            }

            li.id = Guid.NewGuid();
            li.time = DateTime.Now;
            return li;
        }
    }
}