using Gnexx.Data.Entities;
using Gnexx.Repository.Context;
using Gnexx.Services.Interfaces.Repository;

namespace Gnexx.Repository.Repositories
{
    public class Commentsrepo : GenericRepository<Comments>, ICommentsRepo
    {
        private readonly GnexxDbContext _gnexxDb;
        
        public Commentsrepo(GnexxDbContext context) : base(context)
        {
            _gnexxDb = context;
        }
    }
}
