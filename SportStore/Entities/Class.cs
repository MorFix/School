using System;
using System.Collections.Generic;
using SportStore.Enums;

namespace SportStore.Entities
{
    public class Class : BaseEntity
    {
        public string Name { get; set; }
        public ClassLevel Level { get; set; }

        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public Guid RoomId { get; set; }
        public Room Room { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public Class()
        {
        }

        public Class(string name, ClassLevel level, Guid teacherId, Guid roomId, Guid id) : base(id)
        {
            Name = name;
            Level = level;
            TeacherId = teacherId;
            Students = new List<Student>();
            RoomId = roomId;
        }
    }
}