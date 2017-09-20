using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Linq;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using System.Data.SqlClient;

namespace iHRM.Win.Frm.PushDataToServer
{
    public partial class frmPushDataToServer : DevExpress.XtraEditors.XtraForm
    {
        public frmPushDataToServer()
        {
            InitializeComponent();
        }
        private void btnPushToYSS_Click(object sender, EventArgs e)
        {
            if (chkThongTinNhanVien.Checked)
            {
                pushThongTinNhanVien();
            }
            if (chkCong.Checked)
            {
                pushKetQuaQuetThe();
            }
        }
        public void pushKetQuaQuetThe()
        {
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            int count = 0;
            dw_it.OnDoing = (s, ev) =>
            {
                btnPushToYSS.Enabled = false;
                SqlParameter tuNgay = new SqlParameter("tuNgay", chonKyLuong1.TuNgay);
                SqlParameter denNgay = new SqlParameter("denNgay", chonKyLuong1.DenNgay);
                var dtKQQT = Provider.ExecuteDataTableReader("p_GettbKetQuaQuetThe", tuNgay, denNgay);
                count = dtKQQT.Rows.Count;
                var a = new dcDatabaseDataContext(Provider.ConnectionString_PushServer);
                using (var objConn = _CreateConnection())
                {
                    var cmd = new SqlCommand("p_updateTbKetQuaQuetTheFromClient", objConn) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.Add(new SqlParameter("dtKetQuaQuetThe", dtKQQT));
                    cmd.Parameters.Add(new SqlParameter("tuNgay", chonKyLuong1.TuNgay));
                    cmd.Parameters.Add(new SqlParameter("denNgay", chonKyLuong1.DenNgay));
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            };
            dw_it.OnCompleting = (ps, data) =>
            {
                ucProgress1.Message = ucProgress1.Message + string.Format("\r\n Push thành công {0} records kết quả quẹt thẻ", count);
                btnPushToYSS.Enabled = true;
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }
        public void pushThongTinNhanVien()
        {
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            int count = 0;
            dw_it.OnDoing = (s, ev) =>
            {
                btnPushToYSS.Enabled = false;
                var dtKQQT = Provider.ExecuteDataTableReader("p_GettbEmployee");
                count = dtKQQT.Rows.Count;
                var a = new dcDatabaseDataContext(Provider.ConnectionString_PushServer);
                using (var objConn = _CreateConnection())
                {
                    var cmd = new SqlCommand("p_updateTbEmployeeFromClient", objConn) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.Add(new SqlParameter("dtTbEmployee", dtKQQT));
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            };
            dw_it.OnCompleting = (ps, data) =>
            {
                ucProgress1.Message = ucProgress1.Message + string.Format("\r\n Push thành công {0} records nhân viên", count);
                btnPushToYSS.Enabled = true;
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }
        private SqlConnection _CreateConnection()
        {
            var cnn = new SqlConnection(Provider.ConnectionString_PushServer);
            cnn.Open();
            return cnn;
        }
    }
}