using Microsoft.Data.SqlClient;
using System.Data;

namespace ApplicationBook.Dat
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperDbContext(IConfiguration configuration)
        {
             _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
