using Gnexx.Services.Interfaces;
using Gnexx.Services.Interfaces.Services;
using Gnexx.Services.Services;
using Gnexx.Services.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Gnexx.Services
{
    public static class ServicesRegistration
    {
        public static void AddServiceLayer(this IServiceCollection service)
        {
            #region AutoMapper

            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            #endregion

            #region Services

            service.AddTransient<IUserIdentityService, UserService>();
            service.AddTransient<IUserEntityService, UserEntityService>();
            service.AddTransient<INewsService, NewsService>();
            service.AddTransient<ICoachService, CoachService>(); 
            service.AddTransient<IPlayerService, PlayerService>();  
            service.AddTransient<IPostService, PostService>();
            service.AddTransient<ICoachService, CoachService>();
            service.AddTransient<ITeamsService, TeamsService>();
            service.AddTransient<IResponseService, ResponseServices>();


            #endregion
        }
    }
}
