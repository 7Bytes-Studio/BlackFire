//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using System;

namespace BlackFireFramework
{
    public static class ILRuntimeManagerExtension
    {
        #region InvokeGenericMethod


        public static object InvokeGenericMethod<T>(this ILRuntimeManager iLRuntimeManager, string typeName, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes,typeName,methodName,args);
        }

        public static object InvokeGenericMethod<T1,T2>(this ILRuntimeManager iLRuntimeManager, string typeName, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T1), typeof(T2) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, typeName, methodName,args);
        }

        public static object InvokeGenericMethod<T1, T2, T3>(this ILRuntimeManager iLRuntimeManager, string typeName, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T1), typeof(T2), typeof(T3) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, typeName, methodName,args);
        }

        public static object InvokeGenericMethod<T1, T2, T3,T4>(this ILRuntimeManager iLRuntimeManager, string typeName, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, typeName, methodName,args);
        }

        public static object InvokeGenericMethod<T1, T2, T3, T4, T5>(this ILRuntimeManager iLRuntimeManager, string typeName, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, typeName, methodName,args);
        }

        public static object InvokeGenericMethod<T1, T2, T3, T4, T5, T6>(this ILRuntimeManager iLRuntimeManager, string typeName, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, typeName, methodName,args);
        }

        public static object InvokeGenericMethod<T1, T2, T3, T4, T5, T6, T7>(this ILRuntimeManager iLRuntimeManager, string typeName, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, typeName, methodName,args);
        }

        public static object InvokeGenericMethod<T1, T2, T3, T4, T5, T6, T7, T8>(this ILRuntimeManager iLRuntimeManager, string typeName, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, typeName, methodName,args);
        }

        public static object InvokeGenericMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILRuntimeManager iLRuntimeManager, string typeName, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, typeName, methodName,args);
        }

        public static object InvokeGenericMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILRuntimeManager iLRuntimeManager, string typeName, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, typeName, methodName,args);
        }





        public static object InvokeGenericMethod<T>(this ILRuntimeManager iLRuntimeManager, object iltIns, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, iltIns, methodName,args);
        }

        public static object InvokeGenericMethod<T1, T2>(this ILRuntimeManager iLRuntimeManager, object iltIns, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T1), typeof(T2) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, iltIns, methodName,args);
        }

        public static object InvokeGenericMethod<T1, T2, T3>(this ILRuntimeManager iLRuntimeManager, object iltIns, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T1), typeof(T2), typeof(T3) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, iltIns, methodName,args);
        }

        public static object InvokeGenericMethod<T1, T2, T3, T4>(this ILRuntimeManager iLRuntimeManager, object iltIns, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, iltIns, methodName,args);
        }

        public static object InvokeGenericMethod<T1, T2, T3, T4, T5>(this ILRuntimeManager iLRuntimeManager, object iltIns, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, iltIns, methodName,args);
        }

        public static object InvokeGenericMethod<T1, T2, T3, T4, T5, T6>(this ILRuntimeManager iLRuntimeManager, object iltIns, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, iltIns, methodName,args);
        }

        public static object InvokeGenericMethod<T1, T2, T3, T4, T5, T6, T7>(this ILRuntimeManager iLRuntimeManager, object iltIns, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, iltIns, methodName,args);
        }

        public static object InvokeGenericMethod<T1, T2, T3, T4, T5, T6, T7, T8>(this ILRuntimeManager iLRuntimeManager, object iltIns, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, iltIns, methodName,args);
        }

        public static object InvokeGenericMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILRuntimeManager iLRuntimeManager, object iltIns, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, iltIns, methodName,args);
        }

        public static object InvokeGenericMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILRuntimeManager iLRuntimeManager, object iltIns, string methodName, params object[] args)
        {
            var gtypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10) };
            return iLRuntimeManager.InvokeGenericMethod(gtypes, iltIns, methodName,args);
        }






        #endregion




    }
}
