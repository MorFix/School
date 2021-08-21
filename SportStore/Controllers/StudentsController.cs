using Microsoft.AspNetCore.Mvc;
using SportStore.DataBase;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using SportStore.Controllers.Security;
using SportStore.Enums;

namespace SportStore.Controllers
{
    [Route("students")]
    [Authorize]
    public class StudentsController : Controller
    {
        private SchoolContext _ctx;

        public StudentsController(SchoolContext ctx)
        {
            _ctx = ctx;
        }

        [Permissions(PermissionsLevel.Manage)]
        public IActionResult Index()
        {
            var students = _ctx.Students.ToList();
              
            return View(students);
        }
    }
}
