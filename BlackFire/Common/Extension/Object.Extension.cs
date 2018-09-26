/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Reflection;

namespace BlackFire
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


        #region Invoke



        private static Dictionary<string, MethodInfo> s_MethodInfoDic = new Dictionary<string, MethodInfo>();

        /// <summary>
        /// 反射获取MethodInfo并缓存下来进行调用。
        /// </summary>
        /// <param name="instance">实例。</param>
        /// <param name="methodName">实例的方法名。</param>
        /// <param name="argTypes">参数类型列表。</param>
        /// <param name="args">参数列表。</param>
        /// <returns>返回值。</returns>
        public static object Invoke(this object instance,string methodName,Type[] argTypes,object[] args)
        {
            if (null == instance) return null;
            var type = instance.GetType();
            var key = type.FullName + methodName;
            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;
            if (!s_MethodInfoDic.ContainsKey(key))
            {
                s_MethodInfoDic.Add(key, type.GetMethod(methodName, bindingFlags, Type.DefaultBinder, argTypes, new ParameterModifier[] { new ParameterModifier(argTypes.Length) }));
            }
            return s_MethodInfoDic[key].Invoke(instance, args);
        }


        /// <summary>
        /// 反射获取MethodInfo并缓存下来进行调用。
        /// </summary>
        /// <param name="instance">实例。</param>
        /// <param name="methodName">实例的方法名。</param>
        /// <param name="args">参数列表。</param>
        /// <returns>返回值。</returns>
        public static object Invoke(this object instance, string methodName, params object[] args)
        {
            if (null == instance) return null;
            var type = instance.GetType();
            var key = type.FullName + methodName;
            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;

            if (!s_MethodInfoDic.ContainsKey(key))
            {
                s_MethodInfoDic.Add(key, type.GetMethod(methodName, bindingFlags));
            }

            return s_MethodInfoDic[key].Invoke(instance,args);
        }

        #endregion

    }
}
