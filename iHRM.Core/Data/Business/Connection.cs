using System.Data.SqlClient;


namespace iHRM.Core.Business
{
    /// <summary>
    /// 
    /// </summary>
	public class TheConnection
	{
        /// <summary>
        /// The _connection
        /// </summary>
		private readonly SqlConnection _connection;

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
		public SqlConnection Connection
		{
			get { return _connection; }
			//set { _connection = value; }
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="TheConnection"/> class.
        /// </summary>
		public TheConnection()
		{
			_connection = new SqlConnection(Provider.ConnectionString);
            _connection.Open();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="TheConnection"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
		public TheConnection(string connectionString)
		{
			_connection = new SqlConnection(connectionString);
			_connection.Open();
		}
	}
}
