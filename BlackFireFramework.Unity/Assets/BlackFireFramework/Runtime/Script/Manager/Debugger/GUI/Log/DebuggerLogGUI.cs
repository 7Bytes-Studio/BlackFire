//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BlackFireFramework.Unity;


namespace BlackFireFramework 
{
    public sealed class DebuggerLogGUI : IDebuggerModuleGUI
    {
        private int m_MaxLogInfoCount = 99;
        private Dictionary<LogLevel, bool> m_ToggleLogResDic = new Dictionary<LogLevel, bool>();
        private Dictionary<LogLevel, int> m_ToggleLogCountDic = new Dictionary<LogLevel, int>();

        private string[] m_LogLevelHexColors = new string[] { "#AAAAAA", "white", "green", "yellow", "#FF3399" , "red" };

        private LinkedList<LogInfo> m_LogInfoLinkedList = new LinkedList<LogInfo>();

        private LogInfo m_CurrentSelectedLogInfo = null;

        private bool HasErrorOrException = false;

        private class LogInfo
        {
            public LogLevel LogLevel;
            public string Message;
            public string StackTrace;
            public bool Selected;
        }

        private string m_InputLogCount = "99";
        private string m_FilePath=@"D:\\BlackFire.Log";
        private bool m_HasSetLogFile;

        public int Priority
        {
            get
            {
                return 0;
            }
        }

        public string ModuleName
        {
            get
            {
               return "Log";
            }
        }




        private DebuggerManager m_DebuggerManager = null;
        public void OnInit(DebuggerManager debuggerManager)
        {
            m_DebuggerManager = debuggerManager;

            Application.logMessageReceived += Application_logMessageReceived;

            Utility.Enum.Foreach<LogLevel>(e => {

                m_ToggleLogResDic.Add(e,false);
                m_ToggleLogCountDic.Add(e,0);
            });

        }

        public void OnModuleGUI()
        {

            BlackFireGUI.BoxVerticalLayout(() =>
            {
                BlackFireGUI.HorizontalLayout(() =>
                {
                    int i = 0;
                    Utility.Enum.Foreach<LogLevel>(e => {


                        m_ToggleLogResDic[e] = GUILayout.Toggle(m_ToggleLogResDic[e], string.Format("{0}".HexColor(m_LogLevelHexColors[i])+"({1})", e , m_ToggleLogCountDic[e].ToString().HexColor(m_LogLevelHexColors[i++])));

                    });
                });

                BlackFireGUI.HorizontalLayout(() =>
                {
                    GUILayout.Label(string.Format("Log Count : {0}",m_LogInfoLinkedList.Count), new GUIStyle("Label") { fixedWidth = 150 });
                    GUILayout.Label(string.Format("Limit Max Count : "),new GUIStyle("Label") { fixedWidth = 110 });
                    m_InputLogCount = GUILayout.TextField(m_InputLogCount,GUILayout.Width(140));
                    int value = 0;
                    if (int.TryParse(m_InputLogCount,out value))
                    {
                        if (0 <= value)
                        {
                            if (999>=value)
                            {
                                m_MaxLogInfoCount = value;
                            }
                        }

                    }


                    if (GUILayout.Button("Clear", new GUIStyle("Button") { fixedWidth = 50 }))
                    {
                        m_LogInfoLinkedList.Clear();
                        m_CurrentSelectedLogInfo = null;
                        Utility.Enum.Foreach<LogLevel>(e => {

                            m_ToggleLogCountDic[e] = 0;
                        });
                    }
                });

                BlackFireGUI.HorizontalLayout(() =>
                {

                    if (!m_HasSetLogFile)
                    {
                        m_FilePath = GUILayout.TextField(m_FilePath);
                        m_HasSetLogFile = GUILayout.Button("Set", GUILayout.Width(50));
                        if (m_HasSetLogFile)
                        {
                            Log.SetLogFileMode(m_FilePath, 1000);
                        }
                    }
                    else
                    {
                        GUILayout.TextField(m_FilePath);
                    }
                    
                });

            });

            BlackFireGUI.BoxHorizontalLayout(() =>
            {
                BlackFireGUI.ScrollView(101, id =>
                {
                    m_LogInfoLinkedList.Foreach(current=> {

                        if (!m_ToggleLogResDic[current.Value.LogLevel]) return;

                        if (GUILayout.Toggle(current.Value.Selected, current.Value.Message))
                        {
                            if (null != m_CurrentSelectedLogInfo && !m_CurrentSelectedLogInfo.Equals(current.Value))
                            {
                                m_CurrentSelectedLogInfo.Selected = false;
                            }
                            m_CurrentSelectedLogInfo = current.Value;
                        }

                    });
                    

                });
            });

            BlackFireGUI.BoxHorizontalLayout(() =>
            {
                BlackFireGUI.ScrollView(102, id =>
                {
                    if (null!= m_CurrentSelectedLogInfo)
                    {
                        GUILayout.Label(m_CurrentSelectedLogInfo.StackTrace);
                    }
                }, GUILayout.MinHeight(65));
            });
        }

        public void OnDestroy()
        {
            m_CurrentSelectedLogInfo = null;
            m_LogInfoLinkedList.Clear();
            m_LogInfoLinkedList = null;
            m_ToggleLogResDic.Clear();
            m_ToggleLogResDic = null;
        }


        #region Handlers

        private void Application_logMessageReceived(string condition, string stackTrace, LogType type)
        {
            switch (type)
            {
                case LogType.Error:
                    AddLogInfo(LogLevel.Error, condition, stackTrace);
                    HasErrorOrException = true;
                    break;
                case LogType.Assert:
                    AddLogInfo(LogLevel.Error, condition, stackTrace);
                    break;
                case LogType.Warning:
                    AddLogInfo(LogLevel.Warn, condition, stackTrace);
                    break;
                case LogType.Log:

                    if (condition.Contains("Trace:"))
                    {
                        AddLogInfo(LogLevel.Trace, condition, stackTrace);
                    }
                    else if (condition.Contains("Info:"))
                    {
                        AddLogInfo(LogLevel.Info, condition, stackTrace);
                    }
                    else
                    {
                        AddLogInfo(LogLevel.Debug, condition, stackTrace);
                    }

                    break;
                case LogType.Exception:
                    AddLogInfo(LogLevel.Fatal, condition, stackTrace);
                    HasErrorOrException = true;
                    break;
                default:
                    break;
            }
        }

        private void AddLogInfo(LogLevel logLevel, string message, string stackTrace)
        {
            if (m_MaxLogInfoCount<=m_LogInfoLinkedList.Count)
            {
                return;
            }

            m_ToggleLogCountDic[logLevel]++;
            m_LogInfoLinkedList.AddLast(new LogInfo()
            {
                LogLevel = logLevel,
                Message = message,
                StackTrace = stackTrace,
                Selected = false
            });
        }


        #endregion


    }


}
