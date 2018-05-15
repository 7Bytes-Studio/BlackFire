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
    using System.Collections;

    /// <summary>
    /// ILRuntime热更管家。
    /// </summary>
    public sealed class ILRuntimeManager : MonoBehaviour 
	{
        #region Events

        /// <summary>
        /// 初始化ILRuntime热更框架事件。
        /// </summary>
        public event EventHandler OnInitializeILRuntime;
        /// <summary>
        /// ILRuntime热更框架加载完毕事件。
        /// </summary>
        public event EventHandler OnHotFixLoaded;


        #endregion



        private AppDomain m_Appdomain = null;
        public AppDomain Appdomain { get { return m_Appdomain; } }

        [SerializeField]private string m_HotfixAssemblyName="Your hotfix assembly!";
        public string HotfixAssemblyName { get { return m_HotfixAssemblyName; } }

        private static ILRuntimeManager s_Instance;

        /// <summary>
        /// ILRuntimeManager第一个未被销毁的实例。
        /// </summary>
        public static ILRuntimeManager Instance { get { return s_Instance; } }

        private void Awake()
        {
            if (null== s_Instance)
            {
                s_Instance = this;
            }
           
            m_Appdomain = new AppDomain();
        }

        private void OnDestroy()
        {
            if (this.Equals(s_Instance))
            {
                s_Instance = null;
            }
        }

        #region 基础方法

        public void LoadHotfixAssembly(IHotFixAssemblyLoader assemblyLoader, Action loadCompleteCallback)
        {

            StartCoroutine(assemblyLoader.LoadHotFixAssembly(m_Appdomain,()=> {

                OnInitializeILRuntimeHandler();
                if (null!=OnInitializeILRuntime)
                {
                    OnInitializeILRuntime.Invoke(this,EventArgs.Empty);
                }
                OnHotFixLoadedHandler();
                if (null != OnHotFixLoaded)
                {
                    OnHotFixLoaded.Invoke(this, EventArgs.Empty);
                }

                if (null!=loadCompleteCallback)
                {
                    loadCompleteCallback.Invoke();
                }

            }));

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

        /// <summary>
        /// 启动热更程序内部的计数器(协程)。
        /// </summary>
        /// <param name="enumerator">计数器(协程)。</param>
        public static void StartHoxfixCoroutine(IEnumerator enumerator)
        {
            s_Instance.StartCoroutine(enumerator);
        }




        #region Handlers

        private void OnInitializeILRuntimeHandler()
        {
            m_Appdomain.RegisterCrossBindingAdaptor(new CoroutineAdapter()); //注册协程适配器。
        }

        private void OnHotFixLoadedHandler()
        {

        }

        #endregion

    }




}
