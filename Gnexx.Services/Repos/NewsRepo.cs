using Gnexx.Models.Entities;
using Gnexx.Repository;
using Gnexx.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Services.Repos
{
    public class NewsRepo : INewsRepo
    {

        private readonly IRepository<News> _repository;

        public NewsRepo(IRepository<News> repository)
        {
            _repository = repository;
        }

        public IEnumerable<News> GetAll()
        {
            return _repository.GetAll();
        }

        public News FindById(int ID)
        {
            return _repository.FindById(ID);
        }


    }
}
