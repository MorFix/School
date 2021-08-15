using System;
using System.Collections.Generic;

namespace SportStore.Entities
{
    public class Class : BaseEntity
    {
        public string Name { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public IEnumerable<Student> Students { get; set; }

        public Class()
        {
        }

        public Class(string name, Guid teacherId)
        {
            Name = name;
            TeacherId = teacherId;
            Students = new List<Student>();
        }
    }
}