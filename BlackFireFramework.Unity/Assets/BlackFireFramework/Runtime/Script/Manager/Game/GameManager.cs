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
	public sealed partial class GameManager : ManagerBase
    {
        [SerializeField] private bool m_ApplyGameSpeedWhenInitialized;
        [SerializeField] [Range(0, 100)] private int m_GameSpeed = 1; 
        /// <summary>
        /// 设置游戏运行速度。
        /// </summary>
        public int GameSpeed { get { return m_GameSpeed; } set { m_GameSpeed = value; Time.timeScale = value; } }


        [SerializeField] private bool m_ApplyFpsWhenInitialized;
        [SerializeField] private int m_Fps = 60;
        /// <summary>
        /// 设置游戏以指定的帧率运行(ps:这个设定会受垂直同步影响，如果设置了垂直同步，那么就会抛弃这个设定而根据屏幕硬件的刷新速度来运行)。
        /// </summary>
        public int Fps { get { return m_Fps; } set { m_Fps = value; Application.targetFrameRate = value; } }

        [SerializeField] private string m_FirstProcess = string.Empty;
        /// <summary>
        /// 游戏启动的第一个流程。
        /// </summary>
        public string FirstProcess { get { return m_FirstProcess; } }


        [SerializeField] private string[] m_AvailableProcesses = null;
        /// <summary>
        /// 有效的游戏流程类型全名字符串数组。
        /// </summary>
        public string[] AvailableProcesses { get { return m_AvailableProcesses; } }


        [SerializeField] private string[] m_AllProcesses = null;
        /// <summary>
        /// 全部的游戏流程类型全名字符串数组。
        /// </summary>
        public string[] AllProcesses { get { return m_AllProcesses; } }


        public bool RunInBackground { get { return Application.runInBackground; } set { Application.runInBackground = value; } }

        /// <summary>
        /// 流程模块接口。
        /// </summary>
        private IProcessModule m_ProcessModule = null;


        protected override void OnStart()
        {
            base.OnStart();

            if (m_ApplyGameSpeedWhenInitialized)
            {
                Time.timeScale = m_GameSpeed;
            }

            if (m_ApplyFpsWhenInitialized)
            {
                Application.targetFrameRate = m_Fps;
            }

            BlackFire.ModuleManager.Register<IProcessModule>();
            m_ProcessModule =  BlackFire.ModuleManager.GetModule<IProcessModule>();

            InitProcess();
        }



        protected override void OnUpdate()
        {
            base.OnUpdate();
            
        }

        protected override void OnShutdown()
        {
            base.OnShutdown();
        }



        /// <summary>
        /// 添加游戏流程。
        /// </summary>
        /// <param name="process">流程。</param>
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






        #region Private

        [SerializeField] private bool m_StartFirstProcessWhenInitialized;
        public bool StartFirstProcessWhenInitialized { get { return m_StartFirstProcessWhenInitialized; } set { m_StartFirstProcessWhenInitialized = value; } }

        /// <summary>
        /// 初始化流程。
        /// </summary>
        private void InitProcess()
        {
            CheckFirstProcessOrThrow();

            AddProcess(Utility.Reflection.New(Type.GetType(m_FirstProcess), m_FirstProcess) as ProcessBase);

            for (int i = 0; i < m_AvailableProcesses.Length; i++)
            {
                if (m_AvailableProcesses[i]!= m_FirstProcess)
                {
                    AddProcess(Utility.Reflection.New(Type.GetType(m_AvailableProcesses[i]), m_AvailableProcesses[i]) as ProcessBase);
                }
            }

            if (m_StartFirstProcessWhenInitialized)
            {
                StartFirstProcess();
            }
        }
        private void CheckFirstProcessOrThrow()
        {
            if (m_FirstProcess.IsNullOrEmpty())
            {
                throw new Exception("The first process is required!");
            }
        }

        #endregion


    }
}
