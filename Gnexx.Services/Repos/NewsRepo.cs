using Gnexx.Models.Entities;
using Gnexx.Repository;
using Gnexx.Repository.Context;
using Gnexx.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Services.Repos
{
    public class NewsRepo<T> : INewsRepo<T> where T : class
    {

        private readonly GnexxDbContext _context;
        private readonly DbSet<T> entity;

        public NewsRepo(GnexxDbContext context)
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

        #region Create
        public virtual async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public virtual async Task<List<T>> GetAllAsync()
        {
            return await entity.ToListAsync();
        }
        public async Task<List<T>> GetAllWithInclude(List<string> properties)
        {
            var query = entity.AsQueryable();
            foreach (string property in properties)
            {
                query = query.Include(property);
            }
            return await query.ToListAsync();
        }
        public virtual async Task<T> GetById(int id)
        {
            return await entity.FindAsync(id);
        }
        #endregion

        #region Update
        public virtual async Task<bool> UpdateAsync(T entity, int id)
        {
            T entry = await this.entity.FindAsync(id);
            this.entity.Entry(entry).CurrentValues.SetValues(entity);
            return await Save();
        }
        #endregion

        #region Delete
        public virtual async Task<bool> DeleteAsync(T entity)
        {
            this.entity.Remove(entity);
            return await Save();
        }
        #endregion

        private async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }


    }
}
