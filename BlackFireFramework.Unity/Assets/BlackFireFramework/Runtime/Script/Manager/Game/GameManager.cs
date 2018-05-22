//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework 
{
	public sealed class GameManager : ManagerBase
    {
        [SerializeField] [Range(0, 100)] private int m_GameSpeed = 1; 
        public int GameSpeed { get { return m_GameSpeed; } set { m_GameSpeed = value; } }

        public bool RunInBackground { get { return Application.runInBackground; } set { Application.runInBackground = value; } }




        /// <summary>
        /// 流程模块接口。
        /// </summary>
        private IProcessModule m_ProcessModule = null;


        public override void InitManager()
        {
            base.InitManager();
            BlackFire.ModuleManager.Register<IProcessModule>();
            m_ProcessModule =  BlackFire.ModuleManager.GetModule<IProcessModule>();
        }

        public override void UpdateManager()
        {
            base.UpdateManager();
            Time.timeScale = GameSpeed;
        }

        /// <summary>
        /// 添加游戏流程。
        /// </summary>
        /// <param name="process"></param>
        public void AddProcess(ProcessBase process)
        {
            m_ProcessModule.AddProcess(process);
        }

        /// <summary>
        /// 启动第一个游戏流程。
        /// </summary>
        public void StartFirstProcess()
        {
            m_ProcessModule.StartFirstProcess();
        }

        /// <summary>
        /// 获取所有的流程实例。
        /// </summary>
        /// <returns>所有流程实例数组。</returns>
        public ProcessBase[] GetProcesses()
        {
            return m_ProcessModule.GetProcesses();
        }
    }
}
