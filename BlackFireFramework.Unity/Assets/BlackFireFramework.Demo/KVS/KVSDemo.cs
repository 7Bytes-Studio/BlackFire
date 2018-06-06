//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework 
{
	public sealed class KVSDemo : MonoBehaviour 
	{
        private void OnGUI()
        {
            if (GUILayout.Button("PlayerPrefs查询"))
            {
                Debug.Log(PlayerPrefs.GetString("PlayerPrefs:Alan"));
            }

            if (GUILayout.Button("PlayerPrefs存储"))
            {
                PlayerPrefs.SetString("PlayerPrefs:Alan", "{ \"name\":\"PlayerPrefs.alan\" }");
            }



            if (GUILayout.Button("KVS查询"))
            {
                Debug.Log(KVS.GetValue<KVSPlayerPrefs>("KVS:Alan"));
            }
            if (GUILayout.Button("PlayerPrefs查询"))
            {
                Debug.Log(PlayerPrefs.GetString("KVS:Alan"));
            }


            if (GUILayout.Button("KVS存储"))
            {
                KVS.SetValue<KVSPlayerPrefs>("KVS:Alan", "{ \"name\":\"KVS.alan\" }");
            }

            if (GUILayout.Button("KVS存储"))
            {
                KVS.SetValue<KVSPlayerPrefs>("KVS:Alan2", "{ \"name\":\"KVS.alan2\" }");
            }


            if (GUILayout.Button("KVS存储"))
            {
                KVS.SetValue<KVSPlayerPrefs>("KVS:Alan3", "{ \"name\":\"KVS.alan3\" }");
            }


            if (GUILayout.Button("KVS删除"))
            {
                KVS.Del<KVSPlayerPrefs>("KVS:Alan");
            }

            if (GUILayout.Button("KVS全部删除"))
            {
                KVS.DelAll<KVSPlayerPrefs>();
            }





            if (GUILayout.Button("KVS Sqlite 查询 666"))
            {
                Debug.Log(KVS.GetValue<KVSSqlite>("666"));
            }

            if (GUILayout.Button("KVS Sqlite 查询 777"))
            {
                Debug.Log(KVS.GetValue<KVSSqlite>("777"));
            }


            if (GUILayout.Button("KVS Sqlite 存储 666"))
            {
                KVS.SetValue<KVSSqlite>("666", "666-------------");  
            }

            if (GUILayout.Button("KVS Sqlite 存储 777"))
            {
                KVS.SetValue<KVSSqlite>("777", "777-------------");
            }

            if (GUILayout.Button("KVS Sqlite 删除 777"))
            {
                KVS.Del<KVSSqlite>("777");
            }

            if (GUILayout.Button("KVS Sqlite 删除全部"))
            {
                KVS.DelAll<KVSSqlite>();
            }

            if (GUILayout.Button("Has Demo1"))
            {
                var result = KVS.HasKey<KVSSqlite>("Demo1");
                Debug.Log(result);
            }

            if (GUILayout.Button("Big Data Test"))
            {
                var testStr = "Start------";
                for (int i = 0; i < 100; i++)
                {
                    testStr += "UnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnityUnity";
                }
                testStr += "------End";
                KVS.SetValue<KVSSqlite>("BigDataTest",testStr);
            }

            if (GUILayout.Button("Big Data Query"))
            {
                Debug.Log(KVS.GetValue<KVSSqlite>("BigDataTest"));
            }

        }




    }
}
