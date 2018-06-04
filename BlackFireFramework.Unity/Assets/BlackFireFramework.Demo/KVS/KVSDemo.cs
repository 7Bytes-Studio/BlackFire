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

            if (GUILayout.Button("KVS删除"))
            {
                KVS.Remove<KVSPlayerPrefs>("KVS:Alan");
            }

            if (GUILayout.Button("KVS全部删除"))
            {
                KVS.RemoveAll<KVSPlayerPrefs>();
            }


        }

    }
}
