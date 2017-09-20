using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using iHRM.Core.Business.Base;
using System.Web;
using System.Text;
using System.Configuration;

namespace iHRM.Core.Business
{
    /// <summary>
    /// Class SqlProvider
    /// </summary>
    public class Provider
    {
        private static string _ConnectionString = null;
        private static string _ConnectionString_MCC = null;
        private static string _ConnectionString_PushServer = null;
        public static string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                _ConnectionString = value;
            }
        }
        public static string ConnectionString_MCC
        {
            get
            {
                return _ConnectionString_MCC;
            }
            set
            {
                _ConnectionString_MCC = value;
            }
        }
        public static string ConnectionString_PushServer
        {
            get
            {
                return _ConnectionString_PushServer;
            }
            set
            {
                _ConnectionString_PushServer = value;
            }
        }
        public static SqlConnection CreateConnection()
        {
            var cnn = new SqlConnection(ConnectionString);
            return cnn;
        }

        private static SqlConnection _CreateConnection()
        {
            var cnn = new SqlConnection(ConnectionString);
            cnn.Open();
            return cnn;
        }
        #region exec reader
        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="storedName">Name of the stored.</param>
        /// <param name="readerAction">The reader action.</param>
        /// <param name="pars"></param>
        public static void ExecuteReader(string storedName, Action<SqlDataReader> readerAction, params SqlParameter[] pars)
        {
            using (var objConn = _CreateConnection())
            {
                var cmd = new SqlCommand(storedName, objConn) { CommandType = CommandType.StoredProcedure };

                if (pars != null && pars.Length > 0)
                    cmd.Parameters.AddRange(pars);

                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                        readerAction(reader);
                }
            }
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="storedName">Name of the stored.</param>
        /// <param name="readerAction">The reader action.</param>
        /// <param name="pars"></param>
        public static void ExecuteReaderSingle(string storedName, Action<SqlDataReader> readerAction, params SqlParameter[] pars)
        {
            using (var objConn = _CreateConnection())
            {
                var cmd = new SqlCommand(storedName, objConn) { CommandType = CommandType.StoredProcedure };

                if (pars != null && pars.Length > 0)
                    cmd.Parameters.AddRange(pars);

                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleRow | CommandBehavior.SingleResult))
                {
                    if (reader.Read())
                        readerAction(reader);
                }
            }
        }
        #endregion

        #region none query
        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="storedName">Name of the stored.</param>
        /// <param name="sqlParams">The SQL parameters.</param>
        /// <param name="encodeHtmlOptions">The encode HTML options.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public static ExecuteResult ExecuteNonQuery(string storedName, params SqlParameter[] sqlParams)
        {
            using (var objConn = _CreateConnection())
            {
                var cmd = new SqlCommand(storedName, objConn) { CommandType = CommandType.StoredProcedure };
                if (sqlParams != null)
                    cmd.Parameters.AddRange(sqlParams);
                return _ExecuteCommandGetResult(cmd);
            }
        }

        public static ExecuteResult ExecuteNonQuery_SQL(string sql, params SqlParameter[] sqlParams)
        {
            using (var objConn = _CreateConnection())
            {
                var cmd = new SqlCommand(sql, objConn);

                if (sqlParams != null)
                    cmd.Parameters.AddRange(sqlParams);
                return _ExecuteCommandGetResult(cmd);
            }
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="storedName">Name of the stored.</param>
        /// <param name="dr">Các tham số</param>
        /// <returns></returns>
        public static ExecuteResult ExecuteNonQuery(string storedName, DataRow dr)
        {
            using (var objConn = _CreateConnection())
            {
                var cmd = new SqlCommand(storedName, objConn) { CommandType = CommandType.StoredProcedure };

                AddDataRowParameter(cmd, dr);
                return _ExecuteCommandGetResult(cmd);
            }
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <returns></returns>
        private static ExecuteResult _ExecuteCommandGetResult(SqlCommand cmd)
        {
            ExecuteResult ret = new ExecuteResult();
            StringBuilder sbMsg = new StringBuilder();

            SqlParameter retval = null;
            if (cmd.Parameters.Contains("@Return_Value"))
                retval = cmd.Parameters["@Return_Value"];
            else
                retval = cmd.Parameters.Add("@Return_Value", SqlDbType.VarChar);
            retval.Direction = ParameterDirection.ReturnValue;
            cmd.Connection.InfoMessage += (object obj, SqlInfoMessageEventArgs e) => { sbMsg.AppendLine(e.Message); };
            try
            {
                var reader = cmd.ExecuteReader();
                ret.Data = new DataTable();
                ret.Data.Load(reader);
                ret.NumberOfRowAffected = reader.RecordsAffected;
                ret.Status = SqlStatus.Succsess;
                ret.Message = sbMsg.ToString();
                ret.ReturnValue = (int)retval.Value;
            }
            catch (Exception ex)
            {
                ExceptionHandling(ex);
                ret.Message = ex.Message;
                ret.Status = SqlStatus.Erorr;
            }

            return ret;
        }

        public static int ExecNoneQuery(string storedName, params SqlParameter[] sqlParams)
        {
            using (var objConn = _CreateConnection())
            {
                var cmd = new SqlCommand(storedName, objConn) { CommandType = CommandType.StoredProcedure };

                if (sqlParams != null)
                    cmd.Parameters.AddRange(sqlParams);

                try
                {
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ExceptionHandling(ex);
                    return -1;
                }
            }
        }
        #endregion

        #region Scalar
        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="storedName">Name of the stored.</param>
        /// <param name="sqlParams">The SQL parameters.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public static object ExecuteScalar(string storedName, params SqlParameter[] sqlParams)
        {
            using (var objConn = _CreateConnection())
            {
                using (var cmd = new SqlCommand(storedName, objConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (sqlParams != null)
                        cmd.Parameters.AddRange(sqlParams);
                    try
                    {
                        return cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandling(ex);
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="storedName">Name of the stored</param>
        /// <param name="dr">datarow of parameter</param>
        /// <returns></returns>
        public static object ExecuteScalar(string storedName, DataRow dr)
        {
            using (var objConn = _CreateConnection())
            {
                using (var cmd = new SqlCommand(storedName, objConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        AddDataRowParameter(cmd, dr);
                        return cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandling(ex);
                    }

                    return null;
                }
            }
        }

        public static object ExecSqlScalar(string sql, params SqlParameter[] sqlParams)
        {
            using (var objConn = _CreateConnection())
            {
                using (var cmd = new SqlCommand(sql, objConn))
                {
                    if (sqlParams != null)
                        cmd.Parameters.AddRange(sqlParams);
                    try
                    {
                        return cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandling(ex);
                    }

                    return null;
                }
            }
        }
        #endregion

        #region data table

        /// <summary>
        /// Executes the data reader.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="arrParam">The arr parameter.</param>
        /// <returns></returns>
        public static DataTable ExecuteDataTableReader(string storedProcedureName, params SqlParameter[] arrParam)
        {
            using (var conn = _CreateConnection())
            {
                // Define the command 
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;

                    // Handle the parameters 
                    if (arrParam != null && arrParam.Length > 0)
                        cmd.Parameters.AddRange(arrParam);

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
                        ExceptionHandling(ex);
                    }

                    return null;
                }
            }
        }

        public static DataTable ExecuteDataTableReader(string storedProcedureName, DataRow dr1)
        {
            using (var conn = _CreateConnection())
            {
                // Define the command 
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;

                    try
                    {
                        AddDataRowParameter(cmd, dr1);
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
                        ExceptionHandling(ex);
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Executes the data table.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="arrParam">The arr parameter.</param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string storedProcedureName, params SqlParameter[] arrParam)
        {
            using (var conn = _CreateConnection())
            {
                // Define the command 
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;
                    // Handle the parameters 
                    if (arrParam != null && arrParam.Length > 0)
                        cmd.Parameters.AddRange(arrParam.ToArray());

                    try
                    {
                        // Define the data adapter and fill the dataset 
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandling(ex);
                    }

                    return null;
                }

            }
        }

        /// <summary>
        /// Executes the data reader.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="arrParam">The arr parameter.</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSetReader(string storedProcedureName, params SqlParameter[] arrParam)
        {
            using (var conn = _CreateConnection())
            {
                // Define the command 
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;

                    // Handle the parameters 
                    if (arrParam != null && arrParam.Length > 0)
                        cmd.Parameters.AddRange(arrParam);

                    try
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            var ds = new DataSet();
                            do
                            {
                                var dt = new DataTable();
                                dt.Load(dr);
                                ds.Tables.Add(dt);
                            }
                            while (!dr.IsClosed);

                            return ds;
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandling(ex);
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Executes the data table.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="arrParam">The arr parameter.</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string storedProcedureName, params SqlParameter[] arrParam)
        {
            using (var conn = _CreateConnection())
            {
                // Define the command 
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;
                    // Handle the parameters 
                    if (arrParam != null && arrParam.Length > 0)
                        cmd.Parameters.AddRange(arrParam.ToArray());

                    try
                    {
                        // Define the data adapter and fill the dataset 
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            var ds = new DataSet();
                            da.Fill(ds);
                            return ds;
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandling(ex);
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Executes and get 1 data row
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="arrParam">The arr parameter.</param>
        /// <returns></returns>
        public static DataRow ExecuteDataRow(string storedProcedureName, params SqlParameter[] arrParam)
        {
            using (var objConn = _CreateConnection())
            {
                var cmd = new SqlCommand(storedProcedureName, objConn) { CommandType = CommandType.StoredProcedure };

                if (arrParam != null && arrParam.Length > 0)
                    cmd.Parameters.AddRange(arrParam);

                try
                {
                    using (var reader = cmd.ExecuteReader( CommandBehavior.CloseConnection | CommandBehavior.SingleRow | CommandBehavior.SingleResult))
                    {
                        if (reader.HasRows)
                        {
                            var dt = new DataTable();
                            dt.Load(reader);
                            if (dt.Rows.Count > 0)
                                return dt.Rows[0];
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandling(ex);
                }

                return null;
            }
        }
        
        public static DataTable ExecuteDataTableReader_SQL(string sql, params SqlParameter[] arrParam)
        {
            using (var conn = _CreateConnection())
            {
                // Define the command 
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;

                    // Handle the parameters 
                    if (arrParam != null && arrParam.Length > 0)
                        cmd.Parameters.AddRange(arrParam);

                    try
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            var data = new DataTable();
                            //if (dr.HasRows)
                                data.Load(dr);
                            return data;
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandling(ex);
                    }

                    return null;
                }
            }
        }
        #endregion

        #region for ds
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
                ExceptionHandling(ex);
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
                ExceptionHandling(ex);
                return -1;
            }
            finally
            {
                cnn.Dispose();
                cmd.Dispose();
                da.Dispose();
            }
        }

        /// <summary>
        /// Nạp dữ liệu.
        /// </summary>
        /// <author>Lttung - Một ngày đẹp trời năm 2011</author>
        public static void LoadData(DataSet dataset, string tableName, string sWhere = "")
        {
            SqlConnection cnn = _CreateConnection();
            SqlCommand cmd = cnn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                if (!string.IsNullOrEmpty(sWhere) && sWhere.IndexOf("where", StringComparison.CurrentCultureIgnoreCase) == -1)
                    sWhere = " WHERE " + sWhere;
                cmd.CommandText = "SELECT * FROM " + tableName + " " + sWhere;
                da.Fill(dataset, tableName);
            }
            catch (Exception ex)
            {
                ExceptionHandling(ex);
            }
            finally
            {
                cnn.Dispose();
                cmd.Dispose();
                da.Dispose();
            }
        }

        public static void LoadDataBySql(DataSet dataset, string tableName, string sql)
        {
            SqlConnection cnn = _CreateConnection();
            SqlCommand cmd = cnn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                cmd.CommandText = sql;
                da.Fill(dataset, tableName);
            }
            finally
            {
                cnn.Dispose();
                cmd.Dispose();
                da.Dispose();
            }
        }

        public static void LoadDataByProc(DataSet dataset, string tableName, string procName, params SqlParameter[] pa)
        {
            SqlConnection cnn = _CreateConnection();
            SqlCommand cmd = new SqlCommand(procName, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (pa != null)
                cmd.Parameters.AddRange(pa);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(dataset, tableName);
            }
            finally
            {
                cnn.Dispose();
                cmd.Dispose();
                da.Dispose();
            }
        }

        #endregion
        
        #region helper

        public static void AddDataRowParameter(SqlCommand cmd, DataRow dr)
        {
            SqlCommandBuilder.DeriveParameters(cmd);
            foreach (SqlParameter p1 in cmd.Parameters)
            {
                string name = p1.ParameterName.Replace("@", "");
                if (name == "RETURN_VALUE")
                    continue;

                if (!dr.Table.Columns.Contains(name))
                {
                    p1.Value = DBNull.Value;
                    break;
                }
                else
                {
                    p1.Value = dr[name];
                }
            }
        }
        public static SqlParameter CreateParameter_StringArray(string paName, string[] arr)
        {
            var pa = new SqlParameter(paName, SqlDbType.Structured);
            DataTable dt = new DataTable();
            dt.Columns.Add("VALUE");
            foreach (string s in arr)
            {
                var dr = dt.NewRow();
                dr["VALUE"] = s;
                dt.Rows.Add(dr);
            }
            pa.TypeName = "LST_String";
            pa.Value = dt;

            return pa;
        }
        public static SqlParameter CreateParameter_StringList(string paName, List<string> arr)
        {
            var pa = new SqlParameter(paName, SqlDbType.Structured);
            DataTable dt = new DataTable();
            dt.Columns.Add("VALUE");
            foreach (string s in arr)
            {
                var dr = dt.NewRow();
                dr["VALUE"] = s;
                dt.Rows.Add(dr);
            }
            pa.TypeName = "LST_String";
            pa.Value = dt;

            return pa;
        }
        #endregion

        private static void ExceptionHandling(Exception ex)
        {
            throw ex;
        }
        
    }
}
