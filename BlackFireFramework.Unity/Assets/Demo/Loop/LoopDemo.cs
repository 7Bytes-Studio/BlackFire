//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class LoopDemo : MonoBehaviour
    {
        private IEnumerator Start()
        {
            float lastTime = Time.time;
            BlackFire.Loop.Register(() =>
            {
                var showTime = Time.time - lastTime;
                Debug.Log(showTime);
                lastTime = Time.time;
            }, LoopType.FixedUpdate,"demo");
            
            yield return new WaitForSeconds(5f);
            
            BlackFire.Loop.UnRegister("demo");
        }
    }
}