using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using School.DataBase;

namespace School.Controllers.Security
{
    public class AuthMiddleware
    {
        private RequestDelegate Next { get; }

        public AuthMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public async Task InvokeAsync(HttpContext context, SchoolContext dbCtx)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                await Next(context);

                return;
            }

            var user = dbCtx.Users.FirstOrDefault(x => x.IdNumber == context.User.Identity.Name);
            if (user == null)
            {
                await context.SignOutAsync();

                context.Response.Redirect("/");

                return;
            }

            context.Items.Add("user", user);
            
            await Next(context);
        }
    }
}
