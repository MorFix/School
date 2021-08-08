using SportStore.Enums;
using System;
using System.Collections.Generic;

namespace SportStore.Entities
{
    public class Lesson : BaseEntity
    { 
        public Teacher Teacher { get; set; }
        public IEnumerable<Class> Classes { get; set; }
        public Subject Subject { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int Hour { get; set; }

        public Lesson(Teacher teacher, IEnumerable<Class> classes, Subject subject, DayOfWeek day, int hour)
        {
            Teacher = teacher;
            Classes = classes;
            Subject = subject;
            DayOfWeek = day;
            Hour = hour;
        }
    }
}