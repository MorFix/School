using Microsoft.AspNetCore.Http;
using SportStore.Entities;

namespace SportStore.Controllers.Security
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
