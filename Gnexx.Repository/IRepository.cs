namespace Gnexx.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T FindById(int ID);
    }
}
