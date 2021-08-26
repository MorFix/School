using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using School.DataBase;

namespace SportStore.Controllers.Security
{
    public class AuthMiddleware
    {
        private RequestDelegate Next { get; }

        public AuthMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public Task InvokeAsync(HttpContext context, SchoolContext dbCtx)
        {
            var userId = context.User.Identity.Name;

            if (!context.User.Identity.IsAuthenticated)
            {
                return Next(context);
            }

            var user = dbCtx.Users.FirstOrDefault(x => x.IdNumber == userId);

            context.Items.Add("user", user);

            return Next(context);
        }
    }
}
