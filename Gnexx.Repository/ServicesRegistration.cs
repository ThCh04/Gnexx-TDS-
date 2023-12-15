using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Gnexx.Repository.Context;
using Gnexx.Services.Interfaces.Repository;
using Gnexx.Repository.Repositories;

namespace Gnexx.Repository
{
    public static class ServicesRegistration
    {
        public static void AddRepositoryfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Configuration of Database
            

            services.AddDbContext<GnexxDbContext>(Options =>
            Options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            m => m.MigrationsAssembly(typeof(GnexxDbContext).Assembly.FullName)));
            
            #endregion

            #region Dependency Injection

            //Generics
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<INewsRepo, NewsRepo>();
            services.AddTransient<IUserEntityrepo, UserEntityrepo>();
            services.AddTransient<ICoachRepo, CoachRepo>();
            services.AddTransient<IPlayerRepo, PlayerRepo>();
            services.AddTransient<IPostRepo, PostRepo>();
            services.AddTransient<ITeamsRepo, TeamsRepo>();
            services.AddTransient<IResponsesRepo, ResponseRepo>();

            //Other repos

            #endregion

        }
    }
}
