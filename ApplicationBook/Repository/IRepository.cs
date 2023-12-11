namespace ApplicationBook.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Find(string id);
        Task<List<T>> GetAll(int pageNumber);
    }
}