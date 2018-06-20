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
using System.IO;

namespace BlackFireFramework.Unity
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











       

        public void OnInit(DebuggerManager debuggerManager)
        {
            Application.logMessageReceived += Application_logMessageReceived;

            KVSInit();

            BlackFireFramework.Utility.Enum.Foreach<LogLevel>(e => {

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
                    BlackFireFramework.Utility.Enum.Foreach<LogLevel>(e => {


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
                        BlackFireFramework.Utility.Enum.Foreach<LogLevel>(e => {

                            m_ToggleLogCountDic[e] = 0;
                        });
                    }
                });

                BlackFireGUI.HorizontalLayout(() =>
                {

                    if (!m_HasSetLogFile)
                    {
                        m_FilePath = GUILayout.TextField(m_FilePath??@"D:\\BlackFire.Log");
                        m_HasSetLogFile = GUILayout.Button("Set", GUILayout.Width(50));
                        OpenLogFile();
                        if (m_HasSetLogFile && !string.IsNullOrEmpty(m_FilePath))
                        {
                            try //捕捉文件路径异常。
                            {
                                if (!m_HasSetLogFileMode)
                                {
                                    Log.SetLogFileMode(m_FilePath, 1000);
                                    m_HasSetLogFileMode = true;
                                }
                                KVS.SetValue<KVSPlayerPrefs>(m_FilePathHead, m_FilePath);
                            }
                            catch (System.Exception ex)
                            {
                                Log.Fatal(ex);
                            }

                        }
                    }
                    else
                    {
                        GUILayout.TextField(m_FilePath);
                        OpenLogFile();
                    }
                    
                });

            });

            BlackFireGUI.BoxHorizontalLayout(() =>
            {
                BlackFireGUI.ScrollView(101, id =>
                {
                    m_LogInfoLinkedList.Foreach(current=> {

                        if (!m_ToggleLogResDic[current.Value.LogLevel]) return;

                        if (current.Value.Selected = GUILayout.Toggle(current.Value.Selected, current.Value.Message))
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
            KVSDestroy();
            m_CurrentSelectedLogInfo = null;
            m_LogInfoLinkedList.Clear();
            m_LogInfoLinkedList = null;
            m_ToggleLogResDic.Clear();
            m_ToggleLogResDic = null;
        }


        #region Private

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

        private void OpenLogFile()
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN //其他平台有待验证。
            if (!string.IsNullOrEmpty(Log.LogFilePath) && m_HasSetLogFileMode && GUILayout.Button("Open", GUILayout.Width(50)))
            {
                if (File.Exists(Log.LogFilePath))
                {
                    System.Diagnostics.Process.Start(m_FilePath);
                }
            }
#endif
        }
        private string m_FilePath = null;
        private bool m_HasSetLogFileMode = false;
        private string m_InputLogCount = "99";


        //KVS...

        private string m_LogOptionHead = "Log/ToggleLogOption/";
        private string m_FilePathHead = "Log/FilePath";

        //KVS...

        private void KVSInit()
        {
            #region LogOption

            BlackFireFramework.Utility.Enum.Foreach<LogLevel>(e => {

                if (KVS.HasKey<KVSPlayerPrefs>(m_LogOptionHead + e))
                {
                    m_ToggleLogResDic.Add(e, bool.Parse(KVS.GetValue<KVSPlayerPrefs>(m_LogOptionHead + e)));
                }
                else
                {
                    KVS.SetValue<KVSPlayerPrefs>(m_LogOptionHead + e, false.ToString());
                    m_ToggleLogResDic.Add(e, false);
                }
            });

            #endregion

            #region LogFilePath

            if (KVS.HasKey<KVSPlayerPrefs>(m_FilePathHead))
            {
                m_FilePath = KVS.GetValue<KVSPlayerPrefs>(m_FilePathHead);
                Log.SetLogFileMode(m_FilePath,1000);
                m_HasSetLogFileMode = true;
            }

            #endregion
        }

        private void KVSDestroy()
        {
            BlackFireFramework.Utility.Enum.Foreach<LogLevel>(e => {
                KVS.SetValue<KVSPlayerPrefs>(m_LogOptionHead + e, m_ToggleLogResDic[e].ToString());
            });
        }


        #endregion


    }


}
