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
        public bool RunInBackground { get { return Application.runInBackground; } set { Application.runInBackground = value; } }
        private void InitSetting()
        {
            if (m_ApplyGameSpeedWhenInitialized)
            {
                Time.timeScale = m_GameSpeed;
            }

            if (m_ApplyFpsWhenInitialized)
            {
                Application.targetFrameRate = m_Fps;
            }
        }
    }
}
