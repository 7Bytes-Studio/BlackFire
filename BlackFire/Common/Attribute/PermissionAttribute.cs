/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;

namespace BlackFire
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class PermissionAttribute : Attribute
    {

        public int Permission { get; private set; }
        public PermissionAttribute(int permission)
        {
            Permission = permission;
        }

    }
}
