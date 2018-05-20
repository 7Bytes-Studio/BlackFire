//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

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
            Thread httpServerThread = new Thread(state => {

                m_HttpServer = Utility.Http.CreateHttpServer(new Utility.Http.LazyHttpServerInfo(getData => {

                    Debug.Log(getData);
                    return JsonUtility.ToJson(new Json_Response() { code=200,msg="event server is working!" });

                }, postData =>
                {
                    Debug.Log(postData);
                    Json_Instruction instruction = JsonUtility.FromJson<Json_Instruction>(postData.Trim());
                    return InstructionHandler(instruction);

                }, defaultData=> {

                    return JsonUtility.ToJson(new Json_Response() { code = 404, msg = "404" });

                })
                { Port = 666, Prefixes = new string[] { }, OnStartSucceed = (sender, args) => { Debug.Log("服务器开启成功。"); }, OnStartFailure = (sender, args) => { Debug.Log("服务器开启失败:" + args.Exception); } });

                m_HttpServer.Start();

            });
            httpServerThread.Start();
        }

        public void OnModuleGUI()
        {
           
        }

        public void OnDestroy()
        {
            if (null != m_HttpServer)
            {
                m_HttpServer.Close();
            }
        }





        #region Handler

        private string InstructionHandler(Json_Instruction json_Instruction)
        {
            Debug.Log(json_Instruction.instruction);
            Debug.Log(json_Instruction.eventTopic.topic);
            Debug.Log(json_Instruction.eventTopic.sender);
            for (int i = 0; i < json_Instruction.eventTopic.args.Count; i++)
            {
                Debug.Log(string.Format("{0}:{1}", json_Instruction.eventTopic.args[i].type, json_Instruction.eventTopic.args[i].value));
            }
            return JsonUtility.ToJson(new Json_Response() { code = 200, msg = "post data was handled successfully!" });
        }


        #endregion





    }
}
