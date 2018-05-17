using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading;

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

        [TestMethod]
        public void TestMethod_Http_Post()
        {
            //此项目为了与外界解耦，不适合在发布的项目源码的时候拿第三方网站进行测试，请自行粘贴自己喜欢的网站来进行POST测试。

            //var result = Utility.Http.Post("http://0x69h.com/wp-admin/admin-ajax.php", "action=addLike&um_id=82&um_action=ding");

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
