using System.Security.Claims;
using SportStore.Entities;

namespace SportStore.Controllers
{
    public class SchoolClaimsIdentity : ClaimsIdentity
    {
        public User User { get; }

        public SchoolClaimsIdentity(User user) : base(new[] { new Claim(ClaimTypes.Name, user.IdNumber) }, "Login")
        {
            User = user;
        }
    }
}
