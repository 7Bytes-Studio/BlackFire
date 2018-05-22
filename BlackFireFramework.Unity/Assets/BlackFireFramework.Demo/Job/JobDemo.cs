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
	public sealed class JobDemo : MonoBehaviour 
	{
        private Job.Token m_Token = new Job.Token();

        private void Awake()
        {
            Log.Info(Thread.CurrentThread.ManagedThreadId);

            //Job.StartNew(state =>
            //{

            //    for (int i = 0; i < 20000; i++)
            //    {
            //        Log.Info(i);
            //        if (state.Token.IsCancellationRequested)
            //        {
            //            break;
            //        }
            //    }

            //    state.SyncState = 66666;

            //},syncState =>
            //{

            //    GetComponent<Transform>().gameObject.name = syncState.SyncState.ToString();
            //    Log.Info(syncState.SyncState);

            //}, m_Token);

            Job.StartLongNew(state=> {

                m_HttpServer = Utility.Http.CreateHttpServer(new Utility.Http.LazyHttpServerInfo(getData => {

                    Debug.Log(getData);
                    state.SyncState = getData;
                    return JsonUtility.ToJson(new Json_Response() { code = 200, msg = "server is working!" });

                },null,null)
                { Port = 1000, Prefixes = new string[] { }, OnStartSucceed = (sender, args) => { Log.Info("server is working!。"); }, OnStartFailure = (sender, args) => { Log.Warn("server is not working! \n" + args.Exception); } });

                m_HttpServer.Start();

            });



        }

        private Utility.Http.HttpServer m_HttpServer;

        private void OnDestroy()
        {
            m_HttpServer.Close();
            m_Token.Cancel();
        }
    }
}
