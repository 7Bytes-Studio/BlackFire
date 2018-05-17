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

        private LinkedList<LogInfo> m_LogInfoLinkedList = new LinkedList<LogInfo>();

        private LogInfo m_CurrentSelectedLogInfo = null;

        private class LogInfo
        {
            public LogLevel LogLevel;
            public string Message;
            public string StackTrace;
            public bool Selected;
        }

        private string m_InputLogCount = "99";
        private string m_FilePath=@"D:\\BlackFire.Log";

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





        public void OnInit(DebuggerManager debuggerManager)
        {

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
                    Utility.Enum.Foreach<LogLevel>(e => {


                        m_ToggleLogResDic[e] = GUILayout.Toggle(m_ToggleLogResDic[e], string.Format("{0}({1})", e , m_ToggleLogCountDic[e]));

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
                    m_FilePath = GUILayout.TextField(m_FilePath);
                    GUILayout.Button("Set",GUILayout.Width(50));
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
