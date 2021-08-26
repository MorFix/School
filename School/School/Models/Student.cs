using System;
using System.Drawing;
using SportStore.Enums;

namespace School.Models
{
    public class Student : User
    {
        public Guid ClassId { get; set; }
        public Class Class { get; set; }

        public string Behavior { get; set; }
    }
}