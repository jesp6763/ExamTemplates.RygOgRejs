using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RygOgRejs.DataAccess
{
    public class QueryExecutor
    {
        private string connectionString;
        
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
            return null;
        }

        /// <summary>
        /// Executes an sql command
        /// </summary>
        /// <param name="command">The command to execute</param>
        /// <returns></returns>
        public DataSet Execute(SqlCommand command)
        {
            return null;
        }
    }
}
