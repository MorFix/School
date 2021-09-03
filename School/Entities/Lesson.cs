using School.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School.Entities
{
    public class Lesson : BaseEntity
    {
        [Display(Name = "מורה")]
        public Guid TeacherId { get; set; }

        [Display(Name = "מורה")]
        public Teacher Teacher { get; set; }

        public virtual IEnumerable<Student> Students { get; set; }

        [Display(Name = "חדר")]
        public Guid RoomId { get; set; }

        [Display(Name = "חדר")]
        public Room Room { get; set; }

        [Display(Name = "מקצוע")]
        public Subject Subject { get; set; }

        [Display(Name = "יום")]
        public DayOfWeek DayOfWeek { get; set; }

        [Required(ErrorMessage = "חובה להזין שעה"), Range(0, 20, ErrorMessage = "על השעה להיות מספר חיובי בין 0 ל20")]
        [Display(Name = "שעה")]
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