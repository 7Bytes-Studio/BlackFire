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
            m_ILRuntimeManager.LoadHotFixAssembly(new HotFixAssemblyLoader_FromDllFile(Application.streamingAssetsPath + "/" + m_ILRuntimeManager.HotfixAssemblyName + ".dll"),()=> {


                Debug.Log(m_ILRuntimeManager.HotfixAssemblyName+" 加载成功!");

                //m_ILRuntimeManager.Appdomain.Invoke(m_ILRuntimeManager.HotfixAssemblyName+".StaticClass", "StaticMethodTest_Void_Empty", null, null);
                //m_ILRuntimeManager.Appdomain.Invoke(m_ILRuntimeManager.HotfixAssemblyName+".StaticClass", "StaticMethodTest_Void_Monobehaviour", null, this);

                //var id = m_ILRuntimeManager.InvokeDynamicMethod("DynamicClass","get_Id");
                //var name1 = m_ILRuntimeManager.InvokeDynamicMethod("DynamicClass","get_Name");
                //var name2 = m_ILRuntimeManager.InvokeDynamicMethod("DynamicClass","get_Name");

                var iltIns =  m_ILRuntimeManager.New("DynamicClass");
                var name1 = m_ILRuntimeManager.InvokeMethod(iltIns,"get_Name");
                var name2 = m_ILRuntimeManager.InvokeMethod(iltIns,"get_Name");
                var res1 = m_ILRuntimeManager.InvokeGenericMethod(new System.Type[] { typeof(int) },iltIns,"Test",10000);
                var res2 = m_ILRuntimeManager.InvokeGenericMethod(new System.Type[] { typeof(int), typeof(string) },iltIns,"Test1",10000,"66666");

                var res3 = m_ILRuntimeManager.InvokeGenericMethod<int>(iltIns, "Test", 10000);
                var res4 = m_ILRuntimeManager.InvokeGenericMethod<int,string>(iltIns,"Test1",10000,"66666");

                Debug.Log(name1);
                Debug.Log(name2);
                Debug.Log(res1);
                Debug.Log(res2);
                Debug.Log(res3);
                Debug.Log(res4);

            });
        }





    }
}
