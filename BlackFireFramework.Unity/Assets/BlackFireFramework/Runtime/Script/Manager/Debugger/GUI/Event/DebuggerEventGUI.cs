//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework
{
    public sealed class DebuggerEventGUI : IDebuggerModuleGUI
    {
        private Utility.Http.HttpServer m_HttpServer = null;
        private Thread m_HttpServerThread = null;

        public int Priority
        {
            get
            {
                return 1;
            }
        }

        public string ModuleName
        {
            get
            {
                return "Event";
            }
        }

        public void OnInit(DebuggerManager debuggerManager)
        {

        }


        private string m_ServerPort="666";

        private string m_Domain = "0.0.0.0";

        private string m_EventTopic = string.Empty;
        private string m_EventSender = string.Empty;
        private string m_EventArgType = string.Empty;

        private LinkedList<Var> m_EventArgs = new LinkedList<Var>();
        private sealed class Var { public string type; public string value; }

        public void OnModuleGUI()
        {

            BlackFireGUI.BoxHorizontalLayout(() => {


                if (null == m_HttpServer || !m_HttpServer.IsWorking)
                {
                    GUILayout.Label(string.Format("Event Server : ".HexColor("green") + " {0}:{1}".HexColor("#33CCFF"), m_Domain = Utility.IP.GetPublicIP(), m_ServerPort), new GUIStyle("Label") { alignment = TextAnchor.MiddleCenter, padding = new RectOffset(0, 0, 0, 0) });

                    m_ServerPort = GUILayout.TextField(m_ServerPort);

                    if (GUILayout.Button("Start", GUILayout.Width(50)))
                    {
                        StartServer(m_ServerPort.To<int>());
                    }
                }
                else
                {
                    GUILayout.Label(string.Format("Event Server {0}:{1}".HexColor("green"), m_Domain = Utility.IP.GetPublicIP(), m_ServerPort), new GUIStyle("Label") { alignment = TextAnchor.MiddleCenter, padding = new RectOffset(0, 0, 0, 0) });
                    if (GUILayout.Button("Close", GUILayout.Width(50)))
                    {
                        m_HttpServer.Close();
                        m_HttpServer = null;
                        m_HttpServerThread.Abort();
                        m_HttpServerThread = null;
                    }
                }

            });


            BlackFireGUI.BoxVerticalLayout(() => {

                BlackFireGUI.HorizontalLayout(()=> {

                    GUILayout.Label("Topic : ".HexColor("#009966"), GUILayout.Width(50));
                    m_EventTopic = GUILayout.TextField(m_EventTopic);

                });

                BlackFireGUI.HorizontalLayout(() => {

                    GUILayout.Label("Sender : ".HexColor("#009966"), GUILayout.Width(50));
                    m_EventSender = GUILayout.TextField(m_EventSender);

                });


                BlackFireGUI.HorizontalLayout(() => {

                    GUILayout.Label("Args : ".HexColor("#009966") +"Type : ".HexColor("#FFFF99"), GUILayout.Width(80));
                    m_EventArgType = GUILayout.TextField(m_EventArgType);
                    if (GUILayout.Button("+", GUILayout.Width(30)))
                    {
                        if (string.IsNullOrEmpty(m_EventArgType.Trim())) return;
                        m_EventArgs.AddLast(new Var() { type = m_EventArgType });
                    }
                    if (GUILayout.Button("-", GUILayout.Width(30)))
                    {
                        if (0<m_EventArgs.Count)
                        {
                            m_EventArgs.RemoveLast();
                        }
                    }
                    if (GUILayout.Button("x", GUILayout.Width(30)))
                    {
                        m_EventTopic = string.Empty;
                        m_EventSender = string.Empty;
                        m_EventArgType = string.Empty;
                        m_EventArgs.Clear();
                    }
                    if (GUILayout.Button("Fire", GUILayout.Width(50)))
                    {
                        if (!string.IsNullOrEmpty(m_EventTopic) && !string.IsNullOrEmpty(m_EventSender))
                        {
                            object[] args = new object[m_EventArgs.Count];
                            int i=0;
                            m_EventArgs.Foreach(current=> {
                                args[i++] = current.Value.value.To(Utility.Convertor.Convert( current.Value.type ));
                            });
                            Event.Fire(m_EventTopic, m_EventSender, new DebuggerEventArgs(args));
                            AddEventEntry("Debugger",m_EventTopic, m_EventSender, m_EventArgs.ToArray());
                        }

                    }
                });

                BlackFireGUI.ScrollView(201,id => {

                    m_EventArgs.Foreach(current => {
                        BlackFireGUI.HorizontalLayout(() => {
                            GUILayout.Label(string.Format("{0} : ", current.Value.type.HexColor("#FFFF99")),GUILayout.ExpandWidth(false));
                            current.Value.value = GUILayout.TextField(current.Value.value);
                        });
                    });

                },GUILayout.MaxHeight(80));


            });



            BlackFireGUI.BoxVerticalLayout(() => {

                BlackFireGUI.ScrollView(202, id =>
                {
                        m_LinkedListEventEntry.Foreach(current => {
                            GUILayout.Toggle(true,current.Value.ToString());
                        });
                }, GUILayout.ExpandHeight(false), GUILayout.MinHeight(100));

            });





        }

        public void OnDestroy()
        {
            if (null != m_HttpServer)
            {
                m_HttpServer.Close();
            }
            if (null!= m_HttpServerThread)
            {
                m_HttpServerThread.Abort();
            }
        }

        private void StartServer(int port)
        {
            m_HttpServerThread = new Thread(state => {

                m_HttpServer = Utility.Http.CreateHttpServer(

                        new Utility.Http.LazyHttpServerInfo(getData => {

                            Debug.Log(getData);
                            return JsonUtility.ToJson(new Json_Response() { code = 200, msg = "event server is working!" });

                        }, postData =>
                        {
                            Debug.Log(postData);
                            Json_Instruction instruction = JsonUtility.FromJson<Json_Instruction>(postData.Trim());
                            return InstructionHandler(instruction);

                        }, defaultData => {

                            return JsonUtility.ToJson(new Json_Response() { code = 404, msg = "404" });

                        })
                        {
                            Ip = Utility.IP.GetRealPublicIP(),
                            Port = port,
                            Prefixes = new string[] { },
                            OnStartSucceed = (sender, args) => { Log.Info("event server is working!。"); },
                            OnStartFailure = (sender, args) => { Log.Error("event server is not working! \n" + args.Exception); },
                            OnBeforeResponse = (response) => { response.ContentType = "application/json;charset=utf-8"; }
                        }
                        
                        );

                m_HttpServer.Start();

            });
            m_HttpServerThread.IsBackground = true;
            m_HttpServerThread.Start();
        }

        private sealed class EventEntry
        {
            public string Platform;
            public DateTime Time;
            public string Topic;
            public string Sender;
            public Var[] Vars;
            public override string ToString()
            {
                var varStr = string.Empty;
                for (int i = 0; i < Vars.Length; i++)
                {
                    varStr += string.Format("{0} : {1}   ", Vars[i].type,Vars[i].value);
                }

                return string.Format("[{0}] : Platform {1}  EventTopic : {2}  Sender : {3}  Vars : {4}", Time.ToLongDateString ().HexColor("green"), Platform.HexColor("yellow"), Topic.HexColor("yellow"), Sender.HexColor("yellow"), varStr.HexColor("yellow"));
            }
        }

        private LinkedList<EventEntry> m_LinkedListEventEntry = new LinkedList<EventEntry>();

        private void AddEventEntry(string platform, string topic,string sender,Var[] vars)
        {
            m_LinkedListEventEntry.AddLast(new EventEntry() { Time = DateTime.Now, Platform = platform, Topic = topic, Sender = sender , Vars = vars });
        }

        #region Handler

        private string InstructionHandler(Json_Instruction json_Instruction)
        {

            if ("FireEvent"==json_Instruction.instruction)
            {
                return FireEventInstruction(json_Instruction);
            }

            return JsonUtility.ToJson(new Json_Response() { code = -1, msg = "Undefined instructions!" });

        }


        private string FireEventInstruction(Json_Instruction json_Instruction)
        {
            int code = 200; string msg = "post data was handled successfully!";
            try
            {
                object[] args = new object[json_Instruction.eventTopic.args.Count];
                List<Var> listVar = new List<Var>();
                for (int i = 0; i < json_Instruction.eventTopic.args.Count; i++)
                {
                    args[i] = json_Instruction.eventTopic.args[i].value.To(Utility.Convertor.Convert(json_Instruction.eventTopic.args[i].type));
                    listVar.Add(new Var() { type = json_Instruction.eventTopic.args[i].type, value = json_Instruction.eventTopic.args[i].value });
                }

                Event.Fire(json_Instruction.eventTopic.topic, json_Instruction.eventTopic.sender, new DebuggerEventArgs(args));
                AddEventEntry(json_Instruction.platform, json_Instruction.eventTopic.topic, json_Instruction.eventTopic.sender, listVar.ToArray());
            }
            catch (Exception ex)
            {
                code = -1;
                msg = ex.ToString();
            }
            return JsonUtility.ToJson(new Json_Response() { code = code, msg = msg });
        }


        #endregion





    }
}
