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
    /// <summary>
    /// The IBinde Extension.
    /// </summary>
    public static class IBinderExtension
    {
        /// <summary>
        /// Bind implementation type to the specified type.
        /// </summary>
        public static IBinder As<T>(this IBinder binder)
        {
            return binder.As(typeof(T));
        }
    }
}
