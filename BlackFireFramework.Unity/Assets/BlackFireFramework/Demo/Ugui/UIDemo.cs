//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework 
{
	public sealed class UIDemo : MonoBehaviour 
	{
        private void Start()
        {
            Event.On("Topic://TestCanvas",this,(s,e)=> {
                BlackFire.Ugui.Release(UguiEntity.GetEntity<UguiEntity>(s as UguiLogicBase));
            });
        }

        private void OnGUI()
        {
            if (GUILayout.Button("测试"))
            {
                BlackFire.Ugui.Acquire("TestCanvas",666.ToString(), e => {
                    if (e.Target.name.Contains("Test"))
                    {
                        e.Target.name = DateTime.Now.ToLongTimeString();
                    }
                });
            }

            if (GUILayout.Button("销毁模板"))
            {
                BlackFire.Ugui.Release("TestCanvas");
            }
        }
    }
}
