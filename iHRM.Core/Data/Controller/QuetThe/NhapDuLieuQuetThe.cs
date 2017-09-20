using iHRM.Core.Business.DbObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;

namespace iHRM.Core.Controller.QuetThe
{
    public class NhapDuLieuQuetThe : LogicBase
    {
        Business.Logic.ChamCong.import logic = new Business.Logic.ChamCong.import();

        public string doImport(string fPath, int m_soMay, int m_ngay, int m_gio, int m_maThe, int m_maMay, int m_maNV, char ktPC = '\t')
        {
            string[] lines = File.ReadAllLines(fPath);
            DataTable dt = new DataTable("t_tbDuLieuQuetThe");
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("soMay",typeof(string)),
                new DataColumn("thoigian", typeof(DateTime)),
                new DataColumn("maThe",typeof(string)),
                new DataColumn("maMay",typeof(string)),
                new DataColumn("maNV",typeof(string))
            });
            dt.PrimaryKey = new DataColumn[] { dt.Columns["thoigian"], dt.Columns["maThe"], dt.Columns["maNV"] };

            string[] dateFormat = new string[] { "dd-MM-yyyy", "dd/MM/yyyy" };
            foreach (string line in lines)
            {
                try
                {
                    //data------|04	28-08-2015	07:39:04	'00343608096245	0	0001
                    string[] data = line.Split(ktPC);
                    var dr = dt.NewRow();
                    var thoigian = AddTime(DateTime.ParseExact(data[m_ngay], dateFormat, null, System.Globalization.DateTimeStyles.None), data[m_gio]);

                    dr["soMay"] = data[m_soMay];
                    dr["thoigian"] = thoigian;
                    dr["maThe"] = data[m_maThe].Replace("'", "");
                    dr["maMay"] = data[m_maMay];
                    dr["maNV"] = data[m_maNV];

                    dt.Rows.Add(dr);
                }
                catch { }
            }

            int rowAffect = logic.importtttt(dt);

            return string.Format("File: {0} import success {1:#,0} record", Path.GetFileName(fPath), rowAffect);
        }
        DateTime AddTime(DateTime d, string time) //07:30:26
        {
            string[] a = time.Split(':');
            return d.AddHours(int.Parse(a[0])).AddMinutes(int.Parse(a[1])).AddSeconds(int.Parse(a[2]));
        }
    }
}
