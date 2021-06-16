using System.Collections.Generic;
using SportStore.Entities;

namespace SportStore.Seed
{
    public class TeachersSeed : BaseSeed<Teacher>
    {
        public override IEnumerable<Teacher> GetData()
        {
            return new[]
            {
                new Teacher("admin", "Admin", "Levi", "1234")
            };
        }
    }
}