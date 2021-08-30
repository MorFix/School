using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using School.Enums;

namespace School.Entities
{
    public class Class : BaseEntity
    {
        [Required(ErrorMessage = "חובה להזין שם"), Display(Name = "שם")]
        public string Name { get; set; }

        [Required, Display(Name = "שכבה")]
        public ClassLevel Level { get; set; }

        [Required, Display(Name = "מורה")]
        public Guid TeacherId { get; set; }

        [Display(Name = "מורה")]
        public Teacher Teacher { get; set; }

        [Required, Display(Name = "חדר")]
        public Guid RoomId { get; set; }

        [Display(Name = "חדר")]
        public Room Room { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public Class()
        {
        }

        public Class(string name, ClassLevel level, Guid teacherId, Guid roomId)
        {
            Name = name;
            Level = level;
            TeacherId = teacherId;
            Students = new List<Student>();
            RoomId = roomId;
        }
    }
}