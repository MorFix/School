using System.Collections.Generic;
using SportStore.Entities;

namespace SportStore.Seed
{
    public class StudentsSeed : BaseSeed<Student>
    {
        public override IEnumerable<Student> GetData()
        {
            return new[]
            {
                new Student("123456789", "Mor", "Cohen", "1234"),
                new Student("111111111", "Omer", "Dital", "1234"),
                new Student("222222222", "Tal", "Mikey", "1234"),
                new Student("333333333", "Inbal", "Avraham", "1234")
            };
        }
    }
}