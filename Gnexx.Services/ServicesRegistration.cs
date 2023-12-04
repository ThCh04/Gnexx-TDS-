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

            service.AddTransient<IUserService, UserService>();
            service.AddTransient<INewsService, NewsService>();

            #endregion
        }
    }
}
