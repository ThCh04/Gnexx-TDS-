namespace Gnexx.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T FindById(int ID);

        Task CreateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllWithInclude(List<string> properties);
        Task<T> GetById(int id);
        Task<bool> UpdateAsync(T entity, int id);
    }
}
