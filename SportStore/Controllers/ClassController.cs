using SportStore.DataBase;
using SportStore.Entities;
using SportStore.Logic;

namespace SportStore.Controllers
{
    public class ClassController : BaseController<Class, ClassLogic>
    {
        public ClassController(SchoolContext context) : base(context)
        {
        }
    }
}
