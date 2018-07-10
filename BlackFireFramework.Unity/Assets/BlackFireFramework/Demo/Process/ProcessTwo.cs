//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BlackFireFramework.Game;


namespace BlackFireFramework.Unity
{
    public sealed class ProcessTwo : ProcessBase
    {
        public ProcessTwo(string processName) : base(processName)
        {

        }

        protected override void OnProcessDestroy()
        {
            Debug.Log("ProcessTwo::OnProcessDestroy");
        }

        protected override void OnProcessEnter()
        {
            Debug.Log("ProcessTwo::OnProcessEnter");
        }

        protected override void OnProcessExit()
        {
            Debug.Log("ProcessTwo::OnProcessExit");
        }

        protected override void OnProcessInit()
        {
            Debug.Log("ProcessTwo::OnProcessInit");
        }

        protected override void OnProcessUpdate()
        {
            Debug.Log("ProcessTwo::OnProcessUpdate ");
        }
    }
}
