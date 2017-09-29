namespace RygOgRejs.DataAccess
{
    /// <summary>
    /// Represents a data repository
    /// </summary>
    public abstract class DataRepository
    {
        /// <summary>
        /// The query executor
        /// </summary>
        protected QueryExecutor executor;

        /// <summary>
        /// Initializes a new instance of the DataRepository class
        /// </summary>
        public DataRepository()
        {
            executor = new QueryExecutor();
        }
    }
}
