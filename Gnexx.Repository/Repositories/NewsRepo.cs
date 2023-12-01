using Gnexx.Models.Entities;
using Gnexx.Repository;
using Gnexx.Repository.Context;
using Gnexx.Services.Interfaces;
using Gnexx.Services.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Repository.Repositories
{
    public class NewsRepo : GenericRepository<News>, INewsRepo
    {
        private readonly GnexxDbContext _gnexxDb;
        public NewsRepo(GnexxDbContext db) : base(db)
        {
            _gnexxDb = db;
        }

    }
}
