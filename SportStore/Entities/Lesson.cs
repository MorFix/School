using SportStore.Enums;
using System;
using System.Collections.Generic;

namespace SportStore.Entities
{
    public class Lesson : BaseEntity
    { 
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public virtual IEnumerable<Student> Students { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
        public Subject Subject { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int Hour { get; set; }

        public Lesson()
        {
        }

        public Lesson(Guid teacherId, Guid roomdId, Subject subject, DayOfWeek day, int hour)
        {
            TeacherId = teacherId;
            RoomId = roomdId;
            Subject = subject;
            DayOfWeek = day;
            Hour = hour;
            Students = new List<Student>();
        }
    }
}