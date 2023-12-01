
namespace Gnexx.Services.Interfaces.Services
{
    public interface IGenericService<ViewModel>
        where ViewModel : class
    {
        Task Add(ViewModel vm);
        Task Delete(int id);
        Task<List<ViewModel>> GetAllViewModel();
        Task<ViewModel> GetByIdSaveViewModel(int id);
        Task Update(ViewModel vm, int id);
    }
}