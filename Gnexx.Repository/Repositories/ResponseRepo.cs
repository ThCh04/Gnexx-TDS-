using Gnexx.Data.Entities;
using Gnexx.Repository.Context;
using Gnexx.Services.Interfaces.Repository;

namespace Gnexx.Repository.Repositories
{
    public class ResponseRepo : GenericRepository<Response>, IResponsesRepo
    {
        private readonly GnexxDbContext _gnexxDb;
        
        public ResponseRepo(GnexxDbContext context) : base(context)
        {
            _gnexxDb = context;
        }
    }
}
