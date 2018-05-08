//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework 
{
	public sealed class ILRuntimeDemo : MonoBehaviour 
	{
        [SerializeField] private ILRuntimeManager m_ILRuntimeManager = null;
        private void Start()
        {
            m_ILRuntimeManager.HotfixAssemblyName = "BlackFireFramework.Hotfix";
            m_ILRuntimeManager.LoadHotFixAssembly(new ILRuntimeManager.HotFixAssemblyLoader_FromDllFile(),Application.streamingAssetsPath+ "/"+ m_ILRuntimeManager.HotfixAssemblyName + ".dll",()=> {


                Debug.Log(m_ILRuntimeManager.HotfixAssemblyName+" 加载成功!");

                m_ILRuntimeManager.Appdomain.Invoke(m_ILRuntimeManager.HotfixAssemblyName+".StaticClass", "StaticMethodTest_Void_Empty", null, null);
                m_ILRuntimeManager.Appdomain.Invoke(m_ILRuntimeManager.HotfixAssemblyName+".StaticClass", "StaticMethodTest_Void_Monobehaviour", null, this);


            });
        }





    }
}
