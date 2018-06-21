//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Game;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework.Unity
{
    public sealed class ProcessOne : ProcessBase
    {
        public ProcessOne(string processName) : base(processName)
        {

        }

        protected override void OnProcessDestroy()
        {
            Debug.Log("ProcessOne::OnProcessDestroy");
        }

        protected override void OnProcessEnter()
        {
            Debug.Log("ProcessOne::OnProcessEnter");
        }

        protected override void OnProcessExit()
        {
            Debug.Log("ProcessOne::OnProcessExit");
        }

        protected override void OnProcessInit()
        {
            Debug.Log("ProcessOne::OnProcessInit");
        }

        protected override void OnProcessUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeProcess(typeof(ProcessTwo));
            }
            Debug.Log("ProcessOne::OnProcessUpdate");
        }
    }
}
