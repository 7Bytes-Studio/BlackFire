using System;
using System.Collections.Generic;
using System.Reflection;

namespace BlackFireFramework
{
    public static partial class Utility
    {
        public static class Reflection
        {

            #region Type

            public static Type GetType(string assemblyName,string typeFullName)
            {
                Assembly assembly = Assembly.Load(assemblyName);
                return assembly.GetType(typeFullName);
            }

            
            public static Type GetType(string[] assemblyNames,string typeFullName)
            {
                for (int i = 0; i < assemblyNames.Length; i++)
                {
                    var assembly = Assembly.Load(assemblyNames[i]);
                    var type = assembly.GetType(typeFullName);
                    if (null!=type)
                    {
                        return type;
                    }
                }
                return null;
            }



            /// <summary>
            /// 获取指定程序集的所有的子类实现类型。
            /// </summary>
            /// <param name="assemblyName">指定的程序集。</param>
            /// <param name="typeBase">基类类型。</param>
            /// <returns>所有的子类实现类型数组。</returns>
            public static Type[] GetImplTypes(string assemblyName,Type typeBase)
            {
                Assembly assembly = Assembly.Load(assemblyName);
                if (null != assembly)
                {
                    List<Type> list = new List<Type>();
                    var types = assembly.GetTypes();
                    if (null != types)
                        for (int i = 0; i < types.Length; i++)
                        {
                            if (types[i].IsClass && !types[i].IsAbstract && typeBase.IsAssignableFrom(types[i]))
                            {
                                list.Add(types[i]);
                            }
                        }
                    return list.ToArray();
                }
                return null;
            }
            
            
            /// <summary>
            /// 获取指定程序集的所有的子类实现类型。
            /// </summary>
            /// <param name="assemblyName">指定的程序集。</param>
            /// <param name="typeBase">基类类型。</param>
            /// <returns>所有的子类实现类型数组。</returns>
            public static Type[] GetImplTypes(string[] assemblyNames,Type typeBase)
            {
                List<Type> list = new List<Type>();
                for (int i = 0; i < assemblyNames.Length; i++)
                {
                    var tps = GetImplTypes(assemblyNames[i], typeBase);
                    if (null!=tps)
                    {
                        for (int j = 0; j < tps.Length; j++)
                        {
                            list.Add(tps[j]);
                        }
                    }
                }
                return list.ToArray();
            }
            

            /// <summary>
            /// 是否是指定的基类类型的实现类。
            /// </summary>
            /// <param name="baseType">指定的基类类型。</param>
            /// <param name="implType">实现类类型。</param>
            /// <returns>结果。</returns>
            public static bool IsImplType(Type baseType,Type implType)
            {
                return baseType.IsAssignableFrom(implType);
            }


            #endregion

            #region Activator

            /// <summary>
            /// 实例化一个对应类型的实例（构造方法必需是 ctor()）。
            /// </summary>
            /// <typeparam name="T">对应类型。</typeparam>
            /// <returns>实例。</returns>
            public static T New<T>()
            {
               return Activator.CreateInstance<T>();
            }

            /// <summary>
            /// 实例化一个对应类型的实例。
            /// </summary>
            /// <param name="type">对应的类型。</param>
            /// <param name="args">实例化构造方法的参数。</param>
            /// <returns>实例。</returns>
            public static object New(Type type, params object[] args)
            {
                return Activator.CreateInstance(type,args);
            }


            #endregion

            #region Method

            public static int GetConstructorCount(Type type)
            {
               return type.GetConstructors().Length;
            }
            
            public static bool HasConstructor(Type type,params Type[] types)
            {
                return null!=type.GetConstructor(types);
            }
            
            


            #endregion

            #region Invoke

            public static void Invoke(Type type,string methodName,params object[] args)
            {
                BindingFlags bindingFlags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
                var method = type.GetMethod(methodName,bindingFlags);
                method.Invoke(null,args);
            }

            #endregion

            #region Attribute

            public static T GetMethodAttribute<T>(Type type,string methodName)where T: Attribute
            {
                var mi = type.GetMethod(methodName);
                if (null!=mi)
                {
                    var attributes = mi.GetCustomAttributes(typeof(T),false);
                    if (0<attributes.Length)
                    {
                        return attributes[0] as T;
                    }
                }
                return null;
            }

            #endregion
        }
    }
}