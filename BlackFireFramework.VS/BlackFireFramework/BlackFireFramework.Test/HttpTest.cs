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
            var result = Utility.Http.Post("http://0x69h.com/wp-admin/admin-ajax.php", "action=addLike&um_id=82&um_action=ding");

            Debug.WriteLine(result);
        }

    }
}
