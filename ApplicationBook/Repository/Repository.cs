
using ApplicationBook.Dat;
using Dapper;

namespace ApplicationBook.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DapperDbContext _dapperDbContext;    
        public Repository(DapperDbContext dapperDbContext) {
            _dapperDbContext = dapperDbContext; 
        } 
        public async Task<T> Find(string id)
        {
            try
            {
                string query = "Select * From ElmTestDb Where BookId=" + id;
                using (var contaxt = _dapperDbContext.CreateConnection())
                {
                    var t = await contaxt.QueryFirstOrDefaultAsync<T>(query);
                    return t;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<T>> GetAll(int pageNumber)
        {
            try
            {
                string query = "Select * From Book ORDER BY BookId OFFSET "+ (pageNumber - 1) +" ROWS FETCH NEXT 10 ROWS ONLY;";
                using (var contaxt = _dapperDbContext.CreateConnection())
                {
                    var t = await contaxt.QueryAsync<T>(query);
                    return t.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
