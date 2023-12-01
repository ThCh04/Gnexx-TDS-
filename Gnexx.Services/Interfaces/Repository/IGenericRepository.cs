using Gnexx.Models.Entities;

namespace Gnexx.Services.Interfaces.Repository
{
    // Interfaz Repositorio generico
    public interface IGenericRepository <T> where T : class
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
