using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RygOgRejs.DataAccess
{
    /// <summary>
    /// Represents a query executor
    /// </summary>
    public class QueryExecutor
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private string connectionString;

        /// <summary>
        /// Initializes a new instance of the QueryExecutor class
        /// </summary>
        public QueryExecutor()
        {
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RygOgRejs";

        }

        /// <summary>
        /// Executes an sql query
        /// </summary>
        /// <param name="sqlQuery">The query to execute</param>
        /// <returns></returns>
        public DataSet Execute(string sqlQuery)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    return Execute(command);
                }
            }
        }

        /// <summary>
        /// Executes an sql command
        /// </summary>
        /// <param name="command">The command to execute</param>
        /// <returns></returns>
        public DataSet Execute(SqlCommand command)
        {
            SqlConnection connection = null;
            if(command.Connection == null)
            {
                connection = new SqlConnection(connectionString);
                command.Connection = connection;
            }

            using(command)
            {
                using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }

        }
    }
}