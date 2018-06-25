//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework.Unity
{
    [System.Serializable]
    public sealed class PlayerStateEventArgs : RecyclableEventArgs
    {

        public float px;
        internal float py;

        protected override void OnRecycle()
        {
            px = 0f;
            py = 0f;
        }

        public void Set(float x,float y)
        {
            px = x;
            py = y;
        }

        protected override void OnSpawn()
        {
           
        }
    }
}
