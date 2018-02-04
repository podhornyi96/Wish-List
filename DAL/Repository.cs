using System.Configuration;
using System.Data.Common;

namespace DAL
{
    /// <summary>
    /// Simple DB Context class. Provides methods for accessing the data.
    /// Implement base class/interface and extend this class it once we have more data storages and mode advanced functionality.
    /// </summary>
    internal static class Repository
    {

        //Consider Dapper for the future releases with updated SPs.
        //https://github.com/StackExchange/dapper-dot-net

        /// <summary>
        /// Repository instance to work with.
        /// </summary>
        internal enum Instance
        {
            /// <summary>
            /// Primary read/write DB.
            /// </summary>
            Primary,
            /// <summary>
            /// Crawlers read-only DB.
            /// </summary>
            Crawlers,
            /// <summary>
            /// Read-only DB.
            /// </summary>
            ReadOnly,
            /// <summary>
            /// Read-only 2 DB. WTH is this?
            /// </summary>
            ReadOnly2,
            /// <summary>
            /// Logging DB.
            /// </summary>
            Logging
        }


        public static DbConnection GetConnection(Instance dc = Instance.Primary)
        {
            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");

            var connection = factory.CreateConnection();

            if (connection == null)
                return null;

            connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString." + dc].ConnectionString;

            return connection;
        }
    }
}
