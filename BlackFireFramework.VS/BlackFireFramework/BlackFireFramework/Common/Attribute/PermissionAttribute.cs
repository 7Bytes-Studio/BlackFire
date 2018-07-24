//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework
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
