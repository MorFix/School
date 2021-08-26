using System;
using SportStore.Enums;

namespace SportStore.Controllers.Security
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
