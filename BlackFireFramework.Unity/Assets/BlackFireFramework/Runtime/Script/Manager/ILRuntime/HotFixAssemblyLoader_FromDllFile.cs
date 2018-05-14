//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections;
using UnityEngine;


namespace BlackFireFramework
{
    using ILRuntime.Runtime.Enviorment;
    using System.IO;

    internal sealed class HotFixAssemblyLoader_FromDllFile : IHotFixAssemblyLoader
    {

        public HotFixAssemblyLoader_FromDllFile(string assemblyPath)
        {
            AssemblyPath = assemblyPath;
        }

        public string AssemblyPath { get; private set; }

        public IEnumerator LoadHotFixAssembly(AppDomain appDomain, Action loadCompleteCallback)
        {
#if UNITY_ANDROID
        WWW www = new WWW(assemblyPath);
#else
            WWW www = new WWW("file:///" + AssemblyPath);
#endif
            while (!www.isDone)
                yield return null;
            if (!string.IsNullOrEmpty(www.error))
                UnityEngine.Debug.LogError(www.error);
            byte[] dll = www.bytes;
            www.Dispose();

#if UNITY_EDITOR

            var pdbPath = AssemblyPath.Replace("-4:|.pdb");

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
                if (null != loadCompleteCallback)
                {
                    loadCompleteCallback.Invoke();
                }
            }
        }

    }
}
