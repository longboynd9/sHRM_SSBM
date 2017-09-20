using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.Category
{
    public class NhanVien : LogicBase
    {
        public VirtualPagingInfo VirtualPaging
        {
            get { return _VirtualPaging; }
            set { _VirtualPaging = value; }
        }
        public NhanVien() : base(iHRM.Core.Business.TableConst.tbNhanVien.TableName) { _VirtualPaging = new VirtualPagingInfo(); }
        public virtual DataTable GetAllSearch(Guid? idCuaHang, params SqlParameter[] pa)
        {
            SqlConnection cnn = Provider.CreateConnection();
            SqlCommand cmd = new SqlCommand(string.Format("p_{0}_GetAllSearch", _TableName), cnn);
            cmd.Parameters.Add(new SqlParameter("idCuaHang", idCuaHang));
            cmd.CommandType = CommandType.StoredProcedure;
            if (pa != null && pa.Length > 0)
                cmd.Parameters.AddRange(pa);

            var paRecordCount = new SqlParameter("@RecordCount", SqlDbType.Int);
            if (_VirtualPaging != null)
            {
                cmd.Parameters.Add(new SqlParameter("@OrderBy", string.IsNullOrWhiteSpace(_VirtualPaging.OrderBy) ? (string)null : ("," + _VirtualPaging.OrderBy + ",")));
                cmd.Parameters.Add(new SqlParameter("@Page", _VirtualPaging.Page));
                cmd.Parameters.Add(new SqlParameter("@PageSize", _VirtualPaging.PageSize));
                paRecordCount.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paRecordCount);
            }

            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (_VirtualPaging != null)
                    _VirtualPaging.RecordCount = Convert.ToInt32(paRecordCount.Value);
                return dt;
            }
            catch
            {
                if (globall.indebug) throw;
            }
            finally
            {
                cnn.Close();
            }

            return new DataTable();
        }
    }
}
