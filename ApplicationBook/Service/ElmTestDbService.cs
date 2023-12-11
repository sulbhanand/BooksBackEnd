using ApplicationBook.Data.Core;
using ApplicationBook.Repository;

namespace ApplicationBook.Service
{
    public class ElmTestDbService : IElmTestDbService
    {
		private readonly IRepository<Book> _repository;
		public ElmTestDbService(IRepository<Book> repository) { 
			_repository = repository;
		}	
        public async Task<List<Book>> GetElmTestDbsAsync(int pageNumber)
        {
			try
			{
				var result = await _repository.GetAll(pageNumber);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }
    }
}
