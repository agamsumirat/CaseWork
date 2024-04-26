using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CaseWork.Utils.DatabaseHelper
{
    public class DatabaseHelper
    {
        private readonly string connectionString;

        public DatabaseHelper(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("CaseWorok");
        }

        public IDbConnection GetConnection() => new SqlConnection(connectionString);
    }
}
