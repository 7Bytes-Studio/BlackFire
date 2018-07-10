//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework.Unity
{
	public sealed class SceneDemo : MonoBehaviour 
	{

        private void OnGUI()
        {


            if (GUILayout.Button("加载场景"))
            {
                BlackFire.Resource.LoadSceneAsync(new SceneInfo("BigSceneLoadTest", UnityEngine.SceneManagement.LoadSceneMode.Additive), e => Debug.Log("场景加载完毕。"), e => Debug.Log(e.Process), e => Debug.Log("加载失败。"));
            }


            if (GUILayout.Button("卸载场景"))
            {
                BlackFire.Resource.UnloadSceneAsync("BigSceneLoadTest", e => Debug.Log("卸载成功。"), e => Debug.Log(e.Process),e=>Debug.Log("卸载失败。"));
            }

            if (GUILayout.Button("设置当前活动场景"))
            {
                BlackFire.Resource.ActiveScene= "BigSceneLoadTest";
            }

            

            if (GUILayout.Button("合并场景"))
            {
                BlackFire.Resource.MergeScene("BigSceneLoadTest","Scene.Demo");
            }

            if (GUILayout.Button("移动场景"))
            {
                List<GameObject> list = new List<GameObject>();
                for (int i = 0; i < 1000; i++)
                {
                    list.Add(new GameObject("..."+i+"..."));
                }
                BlackFire.Resource.MoveToScene(list,"BigSceneLoadTest", e => Debug.Log("移动成功。"), e => Debug.Log(e.Process), e => Debug.Log("移动失败。"));
            }

            GUILayout.Label(BlackFire.Resource.ActiveScene);

        }

    }
}
