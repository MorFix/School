using System;
using System.Collections.Generic;
using SportStore.Enums;

namespace School.Models
{
    public class Class : BaseEntity
    {
        public string Name { get; set; }
        public ClassLevel Level { get; set; }
    }
}