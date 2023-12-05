using Gnexx.Models.Entities;
using Gnexx.Repository.Context;
using Gnexx.Services.Interfaces.Repository;

namespace Gnexx.Repository.Repositories
{
    public class PlayerRepo : GenericRepository<Player>, IPlayerRepo
    {
        private readonly GnexxDbContext _gnexxDb;
        
        public PlayerRepo(GnexxDbContext context) : base(context)
        {
            _gnexxDb = context;
        }
    }
}
