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

        public class GenericServices<ViewModel, Model> : IGenericService<ViewModel> 
             where ViewModel : class
             where Model : class
        {
            private readonly IGenericRepository<Model> _repository;
            private readonly IMapper _mapper;

            public GenericServices(IGenericRepository<Model> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public virtual async Task Update(ViewModel vm, int id)
            {
                Model entity = _mapper.Map<Model>(vm);
                await _repository.UpdateAsync(entity, id);
            }

            public virtual async Task Add(ViewModel vm)
            {
                Model entity = _mapper.Map<Model>(vm);

                await _repository.CreateAsync(entity);
            }

            public virtual async Task Delete(int id)
            {
                var product = await _repository.GetById(id);
                await _repository.DeleteAsync(product);
            }

            public virtual async Task<ViewModel> GetByIdSaveViewModel(int id)
            {
                var entity = await _repository.GetById(id);

                ViewModel vm = _mapper.Map<ViewModel>(entity);
                return vm;
            }

            public virtual async Task<List<ViewModel>> GetAllViewModel()
            {
                var entityList = await _repository.GetAllAsync();

                return _mapper.Map<List<ViewModel>>(entityList);
            }
        }
    }
