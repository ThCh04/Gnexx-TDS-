
namespace Gnexx.Services.Interfaces.Services
{
    public interface IGenericServiceSave<SaveViewModel, ViewModel>
        where SaveViewModel : class
        where ViewModel : class
    {
        Task Add(SaveViewModel vm);
        Task Delete(int id);
        Task<List<ViewModel>> GetAllViewModel();
        Task<SaveViewModel> GetByIdSaveViewModel(int id);
        Task Update(SaveViewModel vm, int id);
    }
}