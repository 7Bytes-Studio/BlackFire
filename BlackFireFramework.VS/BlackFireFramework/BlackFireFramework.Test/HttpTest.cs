using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace BlackFireFramework.Test
{
    [TestClass]
    public class HttpTest
    {
        [TestMethod]
        public void TestMethod_Http_Get()
        {
            var json = Utility.Http.Get("http://localhost/packages/api.json",string.Empty);

            Debug.WriteLine(json);
        }

        [TestMethod]
        public void TestMethod_Http_Post()
        {
            //此项目为了与外界解耦，不适合在发布的项目源码的时候拿第三方网站进行测试，请自行粘贴自己喜欢的网站来进行POST测试。

            //var result = Utility.Http.Post("http://0x69h.com/wp-admin/admin-ajax.php", "action=addLike&um_id=82&um_action=ding");

            //Debug.WriteLine(result);
        }

    }
}
