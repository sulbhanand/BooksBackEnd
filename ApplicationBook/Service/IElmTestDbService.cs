using ApplicationBook.Data.Core;

namespace ApplicationBook.Service
{
    public interface IElmTestDbService
    {
        Task<List<Book>> GetElmTestDbsAsync(int pageNumber);
    }
}
