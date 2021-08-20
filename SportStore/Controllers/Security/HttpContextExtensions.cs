using Microsoft.AspNetCore.Http;
using SportStore.Entities;

namespace SportStore.Controllers.Security
{
    public static class HttpContextExtensions
    {
        public static User GetSchoolUser(this HttpContext context)
        {
            return (context.User.Identity as SchoolClaimsIdentity)?.User;
        }
    }
}
