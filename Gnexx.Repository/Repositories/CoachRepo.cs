using Gnexx.Data.Entities;
using Gnexx.Models.Entities;
using Gnexx.Repository.Context;
using Gnexx.Services.Interfaces.Repository;

namespace Gnexx.Repository.Repositories
{
    public class CoachRepo : GenericRepository<Coach>, ICoachRepo
    {
        private readonly GnexxDbContext _gnexxDb;
        
        public CoachRepo(GnexxDbContext context) : base(context)
        {
            _gnexxDb = context;
        }
    }
}
