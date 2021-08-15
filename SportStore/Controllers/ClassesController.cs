using Microsoft.AspNetCore.Mvc;
using SportStore.DataBase;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using SportStore.ViewModels;

namespace SportStore.Controllers
{
    [Route("classes")]
    [Authorize]
    public class ClassesController : Controller
    {
        private SchoolContext _ctx;

        public ClassesController(SchoolContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            var classesList = _ctx.Classes
                .Join(
                    _ctx.Students,
                    c => c.Id,
                    s => s.ClassId,
                    (c, s) => new
                    {
                        ClassName = c.Name,
                        FirstName = s.FirstName,
                        LastName = s.LastName
                    }
                    ).ToList().OrderBy(x => x.ClassName)
                    .GroupBy(x => x.ClassName, x => new FullNameViewModel(x.FirstName, x.LastName));

            return View(classesList);
        }
    }
}
