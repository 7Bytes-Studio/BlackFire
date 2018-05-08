using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace BlackFireFramework.Test
{
    [TestClass]
    public class StringExtensionTest
    {
        [TestMethod]
        public void TestMethod_StringExtensionTest()
        {
            Debug.WriteLine("123456789x".Slice(":"));
            Debug.WriteLine("123456789x".Slice("3:6"));
            Debug.WriteLine("123456789x".Slice("6:9"));
            Debug.WriteLine("123456789x".Slice("3:"));
            Debug.WriteLine("123456789x".Slice(":6"));
            Debug.WriteLine("123456789x".Slice("-5:"));

            Debug.WriteLine("askjdfoasd{Femaing}fa;ksjfdaskdfjaksdfj".Replace("11:|   Fuck      "));
            Debug.WriteLine("123456789".Replace("-4:|xxxx"));
        }
    }
}
