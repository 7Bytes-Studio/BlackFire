//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@gmail.com
//Website: http://www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework
{
    /// <summary>
    /// The Sparrow IoC Binder.
    /// </summary>
    public interface IBinder
    {
        /// <summary>
        /// Bind implementation type to the specified type.
        /// </summary>
        /// <param name="type">Specified type.</param>
        /// <returns>IBinder interface.</returns>
        IBinder As(Type type);

        /// <summary>
        /// Bind implementation type to self.
        /// </summary>
        /// <returns></returns>
        IBinder AsSelf();

        /// <summary>
        /// As single instance.
        /// </summary>
        IBinder AsSingleton();

        /// <summary>
        /// Set the build Optimal.
        /// </summary>
        //void SetOptimal();
    }
}