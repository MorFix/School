using Microsoft.AspNetCore.Http;
using School.Models;

namespace School.Controllers.Security
{
    public static class HttpContextExtensions
    {
        public static User GetSchoolUser(this HttpContext context)
        {
            context.Items.TryGetValue("user", out var user);

            return user as User;
        }
    }
}
