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
using BlackFireFramework.Game;

namespace BlackFireFramework.Unity
{
	public sealed partial class GameManager : ManagerBase
    {

        /// <summary>
        /// 流程模块接口。
        /// </summary>
        private IProcessModule m_ProcessModule = null;


        protected override void OnStart()
        {
            base.OnStart();

            InitModule();

            InitSetting();

            InitProcess();

            InitState();
        }



        protected override void OnUpdate()
        {
            base.OnUpdate();
            
        }

        protected override void OnShutdown()
        {
            base.OnShutdown();
        }


        private void InitModule()
        {
            RegisterModule<IProcessModule>();
            m_ProcessModule = GetModule<IProcessModule>();
        }

    }
}
