//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class DelayToLoadGraphicsManager : MonoBehaviour
    {
        private void Start()
        {
            var cgTpl = Resources.Load<GraphicsManager>("/CG/CG");
            IManager manager = Instantiate<GraphicsManager>(cgTpl, transform);
            manager.StartManager();
        }
    }
}