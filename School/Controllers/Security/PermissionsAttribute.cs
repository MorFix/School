using System;
using School.Enums;

namespace School.Controllers.Security
{
    public class PermissionsAttribute : Attribute
    {
        public PermissionsLevel[] Permissions { get; }

        public PermissionsAttribute(params PermissionsLevel[] permissions)
        {
            Permissions = permissions;
        }
    }
}
