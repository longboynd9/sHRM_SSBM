using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Win.Cls;
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
using iHRM.Win.ExtClass;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class DownloadAttendance : dlgCustomBase
    {
        iHRM.Core.Business.Logic.ChamCong.dsMayChamCong dbMayChamCong;
        public DownloadAttendance()
        {
            InitializeComponent();
            dbMayChamCong = new Core.Business.Logic.ChamCong.dsMayChamCong();
        }
        private void XuLyDuLieu_Load(object sender, EventArgs e)
        {
            dateTuNgay.DateTime = dateDenNgay.DateTime = DateTime.Today;
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            DateTime TuNgay = dateTuNgay.DateTime;
            DateTime DenNgay = new DateTime( dateDenNgay.DateTime.Year,dateDenNgay.DateTime.Month,dateDenNgay.DateTime.Day,23,59,59);
            DataTable dataInOut = GetData(TuNgay,DenNgay);
            for (DateTime i = TuNgay; i <= DenNgay; )
            {
                StreamWriter sw = new StreamWriter(string.Format(Interface_Company.strLuuDataQuetThe+"\\{0:00}-{1:00}-{2:0000}.txt",i.Month, i.Day,  i.Year));
                try
                {
                    var q = dataInOut.Select(string.Format("TimeDate = '{0}'", i));
                    foreach (var item in q)
                    {
                        sw.WriteLine(string.Format("{0:000},{1},{2},{3:dd/MM/yyyy},{4:HH:mm:ss},{5}", item["MachineNo"], item["UserFullCode"], item["WorkCode"], item["TimeDate"], item["TimeStr"], item["EmployeeID"]));
                    }
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
                catch (Exception)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
                i = i.AddDays(1);
            }
            GUIHelper.Notifications("Lấy dữ liệu thành công", "Download dữ liệu quẹt thẻ",GUIHelper.NotifiType.info);
        }
        private DataTable GetData(DateTime TuNgay, DateTime DenNgay)
        {
            SqlConnection connection = new SqlConnection(Provider.ConnectionString_MCC);
            connection.Open();
            using (var conn = connection)
            {
                // Define the command 
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "p_GetDataQuetThe"; // Tên Store
                    cmd.Parameters.Add(new SqlParameter("tuNgay",TuNgay));
                    cmd.Parameters.Add(new SqlParameter("denNgay", DenNgay));
                    try
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            var data = new DataTable();
                            if (dr.HasRows)
                                data.Load(dr);
                            return data;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
           
        }
    }
}
