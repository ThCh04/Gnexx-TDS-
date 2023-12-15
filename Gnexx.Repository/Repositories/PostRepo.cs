using Gnexx.Data.Entities;
using Gnexx.Repository.Context;
using Gnexx.Services.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Repository.Repositories
{
    public class PostRepo : GenericRepository<Postulation>, IPostRepo
    {
        private readonly GnexxDbContext _gnexxDb;

        public PostRepo(GnexxDbContext context) : base(context)
        {
            _gnexxDb = context;
        }
    }
}
