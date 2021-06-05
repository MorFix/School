using System;
using System.Collections.Generic;

namespace SportStore.Entities
{
    public class Lesson : BaseEntity
    {
        public Teacher Teacher { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public string Subject { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int Hour { get; set; }

        public Lesson()
        {
            Students = new List<Student>();
        }
    }
}