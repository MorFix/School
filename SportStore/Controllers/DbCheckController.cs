using Microsoft.AspNetCore.Mvc;
using SportStore.DataBase;

namespace SportStore.Controllers
{
    [Route("api/shirts")]
    public class DbCheckController : Controller
    {
        private DataBaseContext _db;

        public DbCheckController(DataBaseContext dbContext)
        {
            _db = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(_db.Shirts.AsQueryable());
        }
    }
}
