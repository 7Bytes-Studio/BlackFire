/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire
{
    /// <summary>
    /// The ISparrowIoC Extension.
    /// </summary>
    public static class ISparrowIoCExtension
    {
        /// <summary>
        /// The Type of the registration implementation.
        /// </summary>
        public static IBinder RegisterType<T>(this ISparrowIoC ioc,params object[] parameter)
        {
            return ioc.RegisterType(typeof(T),parameter);
        }

        /// <summary>
        /// The callback of the registration implementation.
        /// </summary>
        public static IBinder Register<T>(this ISparrowIoC ioc,IoCBuildCallback<T> callback)
        {
            return ioc.RegisterInstance(callback.Invoke(ioc));
        }

        /// <summary>
        /// The callback of the registration implementation.
        /// </summary>
        public static IBinder Register(this ISparrowIoC ioc, IoCBuildCallback callback)
        {
            return ioc.RegisterInstance(callback.Invoke(ioc));
        }


        /// <summary>
        /// Build the type instance you have previously bound.
        /// </summary>
        public static T Build<T>(this ISparrowIoC ioc)
        {
            return (T)ioc.Build(typeof(T)); 
        }
    }
}
