namespace iHRM.Core.Business.Base
{
    public enum SqlStatus
    {
        /// <summary>
        /// The erorr
        /// </summary>
        Erorr = 0,
        /// <summary>
        /// The status
        /// </summary>
        Succsess = 1
    }

    /// <summary>
    /// Kết quả thực hiện câu lệnh
    /// </summary>
    public class ExecuteResult
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public SqlStatus Status { get; set; }
        
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string Message { get; set; }
        
        /// <summary>
        /// Gets or sets the record effect.
        /// </summary>
        /// <value>
        /// The record effect.
        /// </value>
        public int NumberOfRowAffected { get; set; }
        
        /// <summary>
        /// Gets or sets the return value.
        /// </summary>
        /// <value>
        /// The return value
        /// </value>
        public int ReturnValue { get; set; }

        /// <summary>
        /// Gets or sets the return value.
        /// </summary>
        /// <value>
        /// The return value
        /// </value>
        public System.Data.DataTable Data { get; set; }
    }
}