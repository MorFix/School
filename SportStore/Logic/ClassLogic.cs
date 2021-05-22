using Microsoft.EntityFrameworkCore;
using SportStore.Entities;

namespace SportStore.Logic
{
    public class ClassLogic : BaseLogic<Class>
    {
        public override DbSet<Class> GetEntities()
        {
            return Context.Classes;
        }
    }
}
