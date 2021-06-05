using System.Collections.Generic;

namespace SportStore.Entities
{
    public class Student : Person
    {
        public Class Classes { get; set; }
        public IEnumerable<Lesson> Lessons { get; set; }

        public Student()
        {
            Lessons = new List<Lesson>();
        }
    }
}