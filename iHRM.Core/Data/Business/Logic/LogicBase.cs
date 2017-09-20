using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace iHRM.Core.Business.Logic
{
    public class LogicBase
    {
        public class VirtualPagingInfo
        {
            private string _OrderBy = "";
            public string OrderBy { get { return _OrderBy; } set { _OrderBy = value; } }

            private int _Page = 1;
            public int Page { get { return _Page; } set { _Page = value; } }

            private int _PageSize = 10;
            public int PageSize { get { return _PageSize; } set { _PageSize = value; } }

            private int _RecordCount = 0;
            public int RecordCount { get { return _RecordCount; } set { _RecordCount = value; } }

            public int MaxPage
            {
                get { return _PageSize == 0 ? 0 : (int)Math.Ceiling(1.0 * _RecordCount / _PageSize); }
            }
        }

        protected string _TableName = "";
        protected VirtualPagingInfo _VirtualPaging = null;

        protected LogicBase(string TableName)
        {
            _TableName = TableName;
        }

        public virtual DataTable GetAll(params SqlParameter[] pa)
        {
            SqlConnection cnn = Provider.CreateConnection();
            SqlCommand cmd = new SqlCommand(string.Format("p_{0}_GetAll", _TableName), cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (pa != null && pa.Length > 0)
                cmd.Parameters.AddRange(pa);
            var paRecordCount = new SqlParameter("@RecordCount", SqlDbType.Int);
            if (_VirtualPaging != null)
            {
                cmd.Parameters.Add(new SqlParameter("@OrderBy",     string.IsNullOrWhiteSpace(_VirtualPaging.OrderBy) ? (string)null : ("," + _VirtualPaging.OrderBy + ",")));
                cmd.Parameters.Add(new SqlParameter("@Page",        _VirtualPaging.Page));
                cmd.Parameters.Add(new SqlParameter("@PageSize",    _VirtualPaging.PageSize));
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

        public virtual DataRow GetById(Guid id)
        {
            return Provider.ExecuteDataRow(string.Format("p_{0}_GetByID", _TableName), new SqlParameter("@id", id));
        }
        
        public virtual Guid? InsertOrUpdate(DataRow dr)
        {
            SqlConnection cnn = Provider.CreateConnection();
            SqlCommand cmd = new SqlCommand(string.Format("p_{0}_InsertOrUpdate", _TableName), cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                Provider.AddDataRowParameter(cmd, dr);
                return (Guid?)cmd.ExecuteScalar();
            }
            catch
            {
                if (globall.indebug) throw;
            }
            finally
            {
                cnn.Close();
            }

            return null;
        }

        public virtual bool Delete(DataRow dr)
        {
            SqlConnection cnn = Provider.CreateConnection();
            SqlCommand cmd = new SqlCommand(string.Format("p_{0}_Delete", _TableName), cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                Provider.AddDataRowParameter(cmd, dr);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch
            {
                if (globall.indebug) throw;
            }
            finally
            {
                cnn.Close();
            }

            return false;
        }
    }
}
