using Microsoft.AspNetCore.Mvc;
using SportStore.DataBase;
using SportStore.Entities;
using SportStore.Logic;

namespace SportStore.Controllers
{
    public abstract class BaseController<TEntity, TLogic> : Controller 
        where TEntity : BaseEntity, new()
        where TLogic : BaseLogic<TEntity>, new()
    {
        public TLogic Logic { get; set; }

        protected BaseController(SchoolContext context)
        {
            Logic = new TLogic {Context = context};
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return View(Logic.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return View(Logic.GetById(id));
        }


        [HttpPost]
        public IActionResult Insert()
        {
            Logic.Insert();

            return View();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id)
        {
            Logic.Update(id);

            return View();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Logic.Delete(id);

            return View();
        }
    }
}
