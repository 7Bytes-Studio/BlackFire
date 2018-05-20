//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Reflection;

namespace BlackFireFramework
{
    public static class ObjectExtension
    {

        public static object To(this object value,Type tp)
        {
            if (value == null) return null;

            if (tp.IsGenericType)
            {
                tp = tp.GetGenericArguments()[0];
            }
            if (tp.Name.ToLower() == "string")
            {
                return value;
            }
            var TryParse = tp.GetMethod("TryParse", BindingFlags.Public | BindingFlags.Static, Type.DefaultBinder,
                                            new Type[] { typeof(string), tp.MakeByRefType() },
                                            new ParameterModifier[] { new ParameterModifier(2) });
            var parameters = new object[] { value, Activator.CreateInstance(tp) };
            bool success = (bool)TryParse.Invoke(null, parameters);
            if (success)
            {
                return parameters[1];
            }
            return null;
        }

        public static T To<T>(this object value)
        {
            if (value == null) return default(T);
            Type tp = typeof(T);
            if (tp.IsGenericType)
            {
                tp = tp.GetGenericArguments()[0];
            }
            if (tp.Name.ToLower() == "string")
            {
                return (T)value;
            }
            var TryParse = tp.GetMethod("TryParse", BindingFlags.Public | BindingFlags.Static, Type.DefaultBinder,
                                            new Type[] { typeof(string), tp.MakeByRefType() },
                                            new ParameterModifier[] { new ParameterModifier(2) });
            var parameters = new object[] { value, Activator.CreateInstance(tp) };
            bool success = (bool)TryParse.Invoke(null, parameters);
            if (success)
            {
                return (T)parameters[1];
            }
            return default(T);
        }



    }
}
