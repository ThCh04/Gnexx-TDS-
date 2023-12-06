using Gnexx.Models.Entities;
using Gnexx.Repository.Context;
using Gnexx.Services.Interfaces.Repository;

namespace Gnexx.Repository.Repositories
{
    public class UserEntityrepo : GenericRepository<UsersEntitie>, IUserEntityrepo
    {
        private readonly GnexxDbContext _gnexxDb;
        
        public UserEntityrepo(GnexxDbContext context) : base(context)
        {
            _gnexxDb = context;
        }
    }
}
