 using AutoMapper;
using Gnexx.Services.Interfaces.Repository;
using Gnexx.Services.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Services.Services
{

        public class GenericServiceSave<SaveViewModel, ViewModel, Model> : IGenericServiceSave<SaveViewModel, ViewModel> 
            where SaveViewModel : class
             where ViewModel : class
             where Model : class
        {
            private readonly IGenericRepository<Model> _repository;
            private readonly IMapper _mapper;

            public GenericServiceSave(IGenericRepository<Model> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public virtual async Task Update(SaveViewModel vm, int id)
            {
                Model entity = _mapper.Map<Model>(vm);
                await _repository.UpdateAsync(entity, id);
            }

            public virtual async Task Add(SaveViewModel vm)
            {
                Model entity = _mapper.Map<Model>(vm);

                await _repository.CreateAsync(entity);
            }

            public virtual async Task Delete(int id)
            {
                var product = await _repository.GetById(id);
                await _repository.DeleteAsync(product);
            }

            public virtual async Task<SaveViewModel> GetByIdSaveViewModel(int id)
            {
                var entity = await _repository.GetById(id);

                SaveViewModel vm = _mapper.Map<SaveViewModel>(entity);
                return vm;
            }

            public virtual async Task<List<ViewModel>> GetAllViewModel()
            {
                var entityList = await _repository.GetAllAsync();

                return _mapper.Map<List<ViewModel>>(entityList);
            }
        }
    }
