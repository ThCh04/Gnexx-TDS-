using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Gnexx.Repository.Context;

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
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

           
            //Other repos

            #endregion

        }
    }
}
