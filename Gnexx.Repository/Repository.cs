using Gnexx.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly GnexxDbContext _context;
        private readonly DbSet<T> entity;

        public Repository(GnexxDbContext context)
        {
            _context = context;
            entity = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entity.AsEnumerable();
        }

        public T FindById(int ID)
        {
            return entity.FirstOrDefault(FindById(ID));
        }
    }
}
