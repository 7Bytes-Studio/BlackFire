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
    /// Sparrow IoC interface.
    /// </summary>
    public interface ISparrowIoC
    {
        /// <summary>
        /// Build the type instance you have previously bound.
        /// </summary>
        /// <param name="type">You need to bind the target type.</param>
        /// <returns>Instance of the binding type.</returns>
        object Build(Type type);

        /// <summary>
        /// The instance of the registration implementation.
        /// </summary>
        /// <param name="instance">The instance of implementation</param>
        /// <returns>IBinder interface.</returns>
        IBinder RegisterInstance(object instance);

        /// <summary>
        /// The Type of the registration implementation.
        /// </summary>
        /// <param name="type">The type of implementation.</param>
        /// <param name="parameter">Implement the parameters of the class.</param>
        /// <returns></returns>
        IBinder RegisterType(Type type, params object[] parameter);

        /// <summary>
        /// Release.
        /// </summary>
        void Release(Type targetType);

        /// <summary>
        /// Release all.
        /// </summary>
        void ReleaseAll();
    }
}