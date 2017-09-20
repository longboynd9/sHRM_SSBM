using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using iHRM.Core.Business;
using iHRM.Win.Cls;

namespace iHRM.Win.Frm.MayChamCong
{
    public class ProviderMCC
    {
        private static string _ConnectionString_MCC = Provider.ConnectionString_MCC;
        private static SqlConnection _CreateConnection()
        {
            var cnn = new SqlConnection(_ConnectionString_MCC);
            cnn.Open();
            return cnn;
        }

        /// <summary>
        /// Cập nhật dữ liệu vào DataBase.
        /// </summary>
        /// <returns>True: cập nhật thành công; False: cập nhật thất bại</returns>
        /// <author>Lttung - Một ngày đẹp trời năm 2011</author>
        public static bool UpdateData(DataSet dataset, string tableName)
        {
            if (dataset.Tables[tableName].GetChanges() == null)
                return false;

            bool blnResult = false;
            SqlConnection cnn = _CreateConnection();
            SqlCommand cmd = cnn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            try
            {
                cmd.CommandText = "SELECT * FROM " + tableName;
                cb.ConflictOption = ConflictOption.OverwriteChanges;
                blnResult = da.Update(dataset, tableName) > 0;
            }
            catch (Exception ex)
            {
                GUIHelper.Notifications(ex.ToString(), "Thông báo", GUIHelper.NotifiType.error);
            }
            finally
            {
                cnn.Dispose();
                cmd.Dispose();
                da.Dispose();
            }
            return blnResult;
        }

        public static int UpdateData(DataTable dt, string tableName = "")
        {
            if (dt == null || dt.GetChanges() == null)
                return 0;

            if (string.IsNullOrWhiteSpace(tableName))
                tableName = dt.TableName;

            SqlConnection cnn = _CreateConnection();
            SqlCommand cmd = cnn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            try
            {
                cmd.CommandText = "SELECT * FROM " + tableName;
                cb.ConflictOption = ConflictOption.OverwriteChanges;
                return da.Update(dt);
            }
            catch (Exception ex)
            {
                GUIHelper.Notifications(ex.ToString(), "Thông báo", GUIHelper.NotifiType.error);
                return -1;
            }
            finally
            {
                cnn.Dispose();
                cmd.Dispose();
                da.Dispose();
            }
        }


    }
}
