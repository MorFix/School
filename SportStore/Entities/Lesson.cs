using SportStore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "חובה להזין שעה"), Range(0, 20, ErrorMessage = "על השעה להיות מספר חיובי בין 0 ל20")]
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