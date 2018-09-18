//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Network;
using BlackFireFramework.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


namespace Alan 
{
	public sealed class DownloadTest : MonoBehaviour 
	{

        //private DownloadHttp downloadHttp = null;

        private void OnGUI()
        {

            //if (GUILayout.Button("测试下载"))
            //{
            //    downloadHttp = new DownloadHttp();
            //    downloadHttp.OnDownloadProgress += DownloadHttp_OnDownloadProgress;
            //    downloadHttp.OnDownloadSucceeded += DownloadHttp_OnDownloadSucceeded;
            //    downloadHttp.OnDownloadFailure += DownloadHttp_OnDownloadFailure;
            //    downloadHttp.Start(@"http://img.ksbbs.com/asset/Mon_1703/eb048d7839442d0.mp4",@"D:\x.mp4",1024);
            //}

            //if (GUILayout.Button("测试关闭"))
            //{
            //    if (null != downloadHttp)
            //    {
            //        downloadHttp.Stop();
            //    }
            //}

            if (GUILayout.Button("测试下载"))
            {
                BlackFire.Network.StartDownloadTask(new DownloadTaskInfo(
                     taskName:"Test",
                     url: @"http://localhost/test.iso",
                     savePath: @"D:\xx.iso",
                     contentSize: 2421987328,
                     useDownloadImplType:typeof(DownloadHttpBigFile),
                     onDownloadSucceeded: OnDownloadSucceeded,
                     onDownloadFailure: OnDownloadFailure,
                     onDownloadProgress: OnDownloadProgress
                    ));

                BlackFire.Network.StartDownloadTask(new DownloadTaskInfo(
                     taskName: "Test1",
                     url: @"http://localhost/test.iso",
                     savePath: @"D:\xxx.iso",
                     contentSize: 2421987328,
                     useDownloadImplType: typeof(DownloadHttpBigFile),
                     onDownloadSucceeded: OnDownloadSucceeded,
                     onDownloadFailure: OnDownloadFailure,
                     onDownloadProgress: OnDownloadProgress
                    ));
            }

            if (GUILayout.Button("测试关闭"))
            {
                BlackFire.Network.StopDownloadTask("Test");
            }

            if (GUILayout.Button("Crc32测试"))
            {
                StartCoroutine(CheckFileCrc32());
            }

        }


        private IEnumerator CheckFileCrc32()
        {
            var t = new CheckFileCrc32(@"D:\xx.iso", 1024 * 1024 * 10);
            yield return t;
            Debug.Log(string.Format("{0:x}", t.Crc32));
        }


        private void OnDownloadProgress(object sender, DownloadProgressEventArgs e)
        {
            Debug.Log("Progress   " + e.DownloadRealSize + "   "+ e.DownloadContentSize + "   " + e.Progress);
        }

        private void OnDownloadFailure(object sender, DownloadFailureEventArgs e)
        {
            Debug.Log("Failure   " + e.DownloadErrorCode +"  "+e.ErrorMessage);
        }

        private void OnDownloadSucceeded(object sender, EventArgs e)
        {
            Debug.Log("Succeeded");
            //StartCoroutine(CheckFileCrc32());
        }


    }





}
