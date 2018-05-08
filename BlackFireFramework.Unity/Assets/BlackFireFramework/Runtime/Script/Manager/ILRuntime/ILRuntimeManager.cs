//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace BlackFireFramework 
{
    using ILRuntime.Runtime.Enviorment;
    using System.IO;

    public sealed class ILRuntimeManager : MonoBehaviour 
	{
        private AppDomain m_Appdomain = null;
        public AppDomain Appdomain { get { return m_Appdomain; } }

        public string HotfixAssemblyName="Your hotfix assembly!";

        private void Awake()
        {
            m_Appdomain = new AppDomain();
        }


        public void LoadHotFixAssembly(IHotFixAssemblyLoader assemblyLoader,string assemblyPath, Action loadCompleteCallback)
        {

            StartCoroutine(assemblyLoader.LoadHotFixAssembly(m_Appdomain,assemblyPath,loadCompleteCallback));

        }

       










        public interface IHotFixAssemblyLoader
        {

            IEnumerator LoadHotFixAssembly(AppDomain appDomain,string assemblyPath,Action loadCompleteCallback);

        }


        internal sealed class HotFixAssemblyLoader_FromDllFile : IHotFixAssemblyLoader
        {
            public IEnumerator LoadHotFixAssembly(AppDomain appDomain,string assemblyPath,Action loadCompleteCallback)
            {
#if UNITY_ANDROID
        WWW www = new WWW(assemblyPath);
#else
                WWW www = new WWW("file:///" + assemblyPath);
#endif
                while (!www.isDone)
                    yield return null;
                if (!string.IsNullOrEmpty(www.error))
                    UnityEngine.Debug.LogError(www.error);
                byte[] dll = www.bytes;
                www.Dispose();

#if UNITY_EDITOR

                var pdbPath = assemblyPath.Replace("-4:|.pdb");

#if UNITY_ANDROID
        www = new WWW(pdbPath);
#else
                www = new WWW("file:///" + pdbPath);
#endif
                while (!www.isDone)
                    yield return null;
                if (!string.IsNullOrEmpty(www.error))
                    UnityEngine.Debug.LogError(www.error);
                byte[] pdb = www.bytes;

#endif

                using (System.IO.MemoryStream fs = new MemoryStream(dll))
                {
#if UNITY_EDITOR
                    using (System.IO.MemoryStream p = new MemoryStream(pdb))
                    {
                        appDomain.LoadAssembly(fs, p, new Mono.Cecil.Pdb.PdbReaderProvider());
                    }
#else
                    appDomain.LoadAssembly(fs, null, new Mono.Cecil.Pdb.PdbReaderProvider());
#endif
                    if (null!=loadCompleteCallback)
                    {
                        loadCompleteCallback.Invoke();
                    }
                }
            }
        }




    }




}
