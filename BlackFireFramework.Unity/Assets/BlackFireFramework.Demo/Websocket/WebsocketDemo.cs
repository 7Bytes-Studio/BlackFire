//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Threading;
using System.Collections;
using UnityEngine;

namespace BlackFireFramework
{

    public sealed class WebsocketDemo : MonoBehaviour
    {
        private Utility.Http.HttpServer m_HttpServer = null;

        private void Start()
        {
            Thread httpServerThread = new Thread(state=> {

                m_HttpServer = Utility.Http.CreateHttpServer(new Utility.Http.LazyHttpServerInfo(getData => {

                    Debug.Log(getData);
                    return "555555555";

                }, postData =>
                {
                    Debug.Log(postData);
                    return "6666666666";

                }, null)
                { Port = 666, Prefixes = new string[] { }, OnStartSucceed = (sender, args) => { Debug.Log("服务器开启成功。"); }, OnStartFailure = (sender, args) => { Debug.Log("服务器开启失败:" + args.Exception); } });

                m_HttpServer.Start();

            });
            httpServerThread.Start();

        }

        private void OnDestroy()
        {
            if (null!= m_HttpServer)
            {
                m_HttpServer.Close();
            }
        }

    }



}