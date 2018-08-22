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
    public sealed class ProcessContest : ProcessBase
    {
        public override string Name
        {
            get { return "Contest"; }
        }
        
        protected override void OnProcessDestroy()
        {
            Debug.Log(Name+"::OnProcessDestroy");
        }

        protected override void OnProcessEnter()
        {
            Debug.Log(Name+"::OnProcessEnter");
        }

        protected override void OnProcessExit()
        {
            Debug.Log(Name+"::OnProcessExit");
        }

        protected override void OnProcessInit()
        {
            Debug.Log(Name+"::OnProcessInit");
        }
        private int i = 0; 
        protected override void OnProcessUpdate()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChangeProcess(typeof(ProcessEnd));
            }
            Debug.Log(Name+"::OnProcessUpdate " + i++);
        }
    }
}
