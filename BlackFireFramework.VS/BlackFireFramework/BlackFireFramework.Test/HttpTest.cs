using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using Newtonsoft;
using Newtonsoft.Json;

namespace BlackFireFramework.Test
{
    [TestClass]
    public class HttpTest
    {
        [TestMethod]
        public void TestMethod_Http_Get()
        {
            //此项目为了与外界解耦，不适合在发布的项目源码的时候拿第三方网站进行测试，请自行粘贴自己喜欢的网站来进行GET测试。
            //var json = Utility.Http.Get("http://localhost/packages/api.json",string.Empty);

            //Debug.WriteLine(json);
        }
        #region Json



        [System.Serializable]
        public sealed class Json_Instruction
        {
            public string instruction; //FireEvent,RemoveEventTopic and so on...

            public string platform; //platform...

            public Json_EventTopic eventTopic;
        }
        [System.Serializable]
        public sealed class Json_EventTopic
        {
            public string topic;

            public string sender;

            public List<Json_Var> args;
        }

        [System.Serializable]
        public sealed class Json_Var
        {
            public string type;
            public string value;
        }

        #endregion

        [TestMethod]
        public void TestMethod_Http_Post()
        {
            //此项目为了与外界解耦，不适合在发布的项目源码的时候拿第三方网站进行测试，请自行粘贴自己喜欢的网站来进行POST测试。

            //var jsonObject = new Json_Instruction()
            //{
            //    platform = "Web",
            //    instruction = "FireEvent",
            //    eventTopic = new Json_EventTopic()
            //    {
            //        topic = "TestTopic",
            //        sender = "Web",
            //        args = new List<Json_Var>()
            //        {
            //          new Json_Var(){ type = "int", value = "66666666666" },
            //          new Json_Var(){ type = "float", value = "6666.6666666" },
            //          new Json_Var(){ type = "double", value = "6666.6666666" },
            //          new Json_Var(){ type = "decimal", value = "6.88888888888" },
            //          new Json_Var(){ type = "char", value = "6" },
            //          new Json_Var(){ type = "string", value = "66666666666" },
            //        }
            //    } };

            //var result = Utility.Http.Post("http://localhost:666", JsonConvert.SerializeObject(jsonObject));

            //Debug.WriteLine(result);
        }

        [TestMethod]
        public void TestMethod_Http_Download()
        {
            //Thread httpDownloadThread = new Thread(() =>
            //{

            //    Utility.Http.DownLoad(new Utility.Http.HttpDownloadInfo(
            //      url: "https://ss1.bdstatic.com/lvoZeXSm1A5BphGlnYG/skin/820.jpg?2",
            //      savePath: "D:\\image.jpg",
            //      tempFileExtension: "tmp",
            //      downloadBufferUnit: 1024,
            //      onDownloadSuccess: (sender, args) => { Debug.WriteLine("下载成功。"); },
            //      onDownloadFailure: (sender, args) => { Debug.WriteLine("下载失败。"); },
            //      onDownloadProgress: (sender, args) => { Debug.WriteLine(args.DownloadProgress); }
            //     ));


            //});

            //httpDownloadThread.Start();

        }

    }
}
