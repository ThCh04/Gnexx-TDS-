using Gnexx.Models.Entities;
using Gnexx.Repository.Context;
using Gnexx.Services.Interfaces.Repository;

namespace Gnexx.Repository.Repositories
{
    public class TeamsRepo : GenericRepository<Team>, ITeamsRepo
    {
        private readonly GnexxDbContext _gnexxDb;
        
        public TeamsRepo(GnexxDbContext context) : base(context)
        {
            _gnexxDb = context;
        }
    }
}
