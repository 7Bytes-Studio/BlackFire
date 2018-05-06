//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Reflection;

namespace BlackFireFramework
{
    public class Singleton<T> where T : class
    {
        private static T instance;
        private static readonly object syslock = new object();
        public static readonly Type[] EmptyTypes = new System.Type[0];

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syslock)
                    {
                        if (instance == null)
                        {
                            ConstructorInfo ci = typeof(T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, EmptyTypes, null);
                            if (ci == null) { throw new InvalidOperationException("这个类必须包含一个私有的构造函数"); }
                            instance = (T)ci.Invoke(null);
                        }
                    }
                }
                return instance;
            }

        }


    }

}