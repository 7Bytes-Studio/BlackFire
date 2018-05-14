//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using UnityEngine;



namespace BlackFireFramework
{
    using ILRuntime.CLR.TypeSystem;
    using ILRuntime.Runtime.Enviorment;
    using ILRuntime.Runtime.Intepreter;

    public sealed class ILRuntimeManager : MonoBehaviour 
	{
        private AppDomain m_Appdomain = null;
        public AppDomain Appdomain { get { return m_Appdomain; } }

        public string HotfixAssemblyName="Your hotfix assembly!";

        private void Awake()
        {
            m_Appdomain = new AppDomain();
        }

        #region 基础方法

        public void LoadHotFixAssembly(IHotFixAssemblyLoader assemblyLoader, Action loadCompleteCallback)
        {

            StartCoroutine(assemblyLoader.LoadHotFixAssembly(m_Appdomain,loadCompleteCallback));

        }

        public object New(string typeName, params object[] ctorArgs)
        {
            return m_Appdomain.Instantiate(string.Format("{0}.{1}", HotfixAssemblyName, typeName), ctorArgs);
        }

        public object InvokeMethod(object iltIns,string methodName, params object[] args)
        {
            return m_Appdomain.Invoke( (iltIns as ILTypeInstance).Type.ToString() , methodName, iltIns, args);
        }

        public object InvokeMethod(string typeName, string methodName, params object[] args)
        {
            return m_Appdomain.Invoke(string.Format("{0}.{1}", HotfixAssemblyName, typeName), methodName, null, args);
        }


        public object InvokeGenericMethod(Type[] genericTypes,object iltIns, string methodName, params object[] args)
        {
            IType[] genericArguments = new IType[genericTypes.Length];
            for (int i = 0; i < genericTypes.Length; i++)
            {
                genericArguments[i] = m_Appdomain.GetType(genericTypes[i]);
            }

           return m_Appdomain.InvokeGenericMethod((iltIns as ILTypeInstance).Type.ToString(), methodName, genericArguments, iltIns, args);
        }

        public object InvokeGenericMethod(Type[] genericTypes, string typeName, string methodName, params object[] args)
        {
            IType[] genericArguments = new IType[genericTypes.Length];
            for (int i = 0; i < genericTypes.Length; i++)
            {
                genericArguments[i] = m_Appdomain.GetType(genericTypes[i]);
            }

            return m_Appdomain.InvokeGenericMethod(string.Format("{0}.{1}", HotfixAssemblyName, typeName), methodName, genericArguments,null, args);
        }




        #endregion




    }




}
