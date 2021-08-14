using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportStore.DataBase;
using SportStore.Entities;
using SportStore.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SportStore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private SchoolContext Ctx { get;  }

        public HomeController(SchoolContext ctx)
        {
            Ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, string returnUrl)
        {
            var dbUser = Ctx.People.FirstOrDefault(x => x.IdNumber == username && x.Password == password);
            if (dbUser == null)
            {
                return View(new LoginViewModel("הפרטים אינם נכונים"));
            }
            
            var claims = new List<Claim>
            {
                new (ClaimTypes.Name, dbUser.IdNumber)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Login");

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return Redirect(returnUrl ?? "/Home");
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(string username, string password, string firstName, string lastName, Guid classId)
        {
            var dbUser = Ctx.People.FirstOrDefault(x => x.IdNumber == username);
            if (dbUser != null)
            {
                return View(new LoginViewModel("המשתמש קיים במערכת"));
            }

            Ctx.Students.Add(new Student(username, firstName, lastName, password, classId));

            await Ctx.SaveChangesAsync();
            
            return Redirect("/Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
