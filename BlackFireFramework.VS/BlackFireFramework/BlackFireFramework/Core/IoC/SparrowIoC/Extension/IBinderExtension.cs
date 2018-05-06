//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework
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
