using System;
using System.Collections.Generic;
using System.Drawing;
using SportStore.Enums;

namespace School.Models
{
    public abstract class User : BaseEntity
    {
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public double AddressX { get; set; }
        public double AddressY { get; set; }
        public PermissionsLevel PermissionsLevel { get; set; }
    }
}