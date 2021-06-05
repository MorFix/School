using System.Collections.Generic;

namespace SportStore.Entities
{
    public class Teacher : Person
    {
        public Class Classes { get; set; }
        public IEnumerable<Lesson> Lessons { get; set; }

        public Teacher()
        {
            Lessons = new List<Lesson>();
        }
    }
}