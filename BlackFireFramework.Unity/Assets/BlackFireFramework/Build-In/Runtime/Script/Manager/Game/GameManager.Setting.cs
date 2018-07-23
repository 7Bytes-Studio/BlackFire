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

namespace BlackFireFramework.Unity
{
	public sealed partial class GameManager
    {
        [SerializeField] private bool m_ApplyGameSpeedWhenInitialized;
        [SerializeField] [Range(0f, 100f)] private float m_GameSpeed = 1;

        [SerializeField] private bool m_ApplyNeverSleep;
        [SerializeField] private bool m_NeverSleep;


        /// <summary>
        /// 获取或设置是否禁止休眠。
        /// </summary>
        public bool NeverSleep
        {
            get
            {
                return m_NeverSleep;
            }
            set
            {
                m_NeverSleep = value;
                Screen.sleepTimeout = value ? SleepTimeout.NeverSleep : SleepTimeout.SystemSetting;
            }
        }



        /// <summary>
        /// 设置游戏运行速度。
        /// </summary>
        public float GameSpeed { get { return m_GameSpeed; } set { m_GameSpeed = value; Time.timeScale = value; } }


        [SerializeField] private bool m_ApplyFpsWhenInitialized;
        [SerializeField] private int m_Fps = 60;
        /// <summary>
        /// 设置游戏以指定的帧率运行(ps:这个设定会受垂直同步影响，如果设置了垂直同步，那么就会抛弃这个设定而根据屏幕硬件的刷新速度来运行)。
        /// </summary>
        public int Fps { get { return m_Fps; } set { m_Fps = value; Application.targetFrameRate = value; } }

        [SerializeField] private bool m_RunInBackground;
        [SerializeField] private bool m_ApplyRunInBackground;
        public bool RunInBackground { get { return m_RunInBackground; } set { m_RunInBackground = value; Application.runInBackground = value; } }

        private void InitSetting()
        {
            if (m_ApplyRunInBackground)
            {
                Application.runInBackground = m_RunInBackground;
            }

            if (m_ApplyGameSpeedWhenInitialized)
            {
                Time.timeScale = m_GameSpeed;
            }

            if (m_ApplyFpsWhenInitialized)
            {
                Application.targetFrameRate = m_Fps;
            }

            if (m_ApplyNeverSleep)
            {
                Screen.sleepTimeout = m_NeverSleep ? SleepTimeout.NeverSleep : SleepTimeout.SystemSetting;
            }

        }
    }
}
