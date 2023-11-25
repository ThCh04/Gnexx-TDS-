using Gnexx.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gnexx.Middleware
{
    public class LoginFilter : IAsyncActionFilter
    {
        private readonly ValidateUserSession _userSession;

        public LoginFilter(ValidateUserSession userSession)
        {
            _userSession = userSession;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (_userSession.HasUser())
            {
                var controller = (UserController)context.Controller;
                context.Result = controller.RedirectToAction("index", "Auth");
            }
            else
            {
                await next();
            }
        }
    }
}
