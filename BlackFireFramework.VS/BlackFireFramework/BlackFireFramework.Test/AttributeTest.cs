using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace BlackFireFramework.Test
{
    [TestClass]
    public class AttributeTest
    {
        [TestMethod]
        public void TestMethod_Attribute()
        {
           var r = Utility.Reflection.GetMethodAttribute<PermissionAttribute>(typeof(TestClass),"Test");
           Debug.WriteLine(r.Permission);
           var r1 = Utility.Reflection.GetMethodAttribute<PermissionAttribute>(typeof(SubTestClass),"Test");
           Debug.WriteLine(r1.Permission);
        }

        public interface ITest
        {
            void Test();
        }


        public class TestClass : ITest
        {
            [Permission(100)]
            public void Test()
            {
               
            }
        }

        public sealed class SubTestClass : TestClass
        {

        }

    }
}
