using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;

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

            Debug.WriteLine("66".To<int>());
            Debug.WriteLine("66.66".To<float>());
            Debug.WriteLine("66.66".To<double>());
            Debug.WriteLine("66.66".To<decimal>());
            Debug.WriteLine("6".To<char>());
            Debug.WriteLine("66.66".To<string>());
            Debug.WriteLine("66".To<int?>());
            Debug.WriteLine("66.66".To<float?>());
            Debug.WriteLine("66.66".To<decimal?>());
            Debug.WriteLine("66.66".To<float?>());
            Debug.WriteLine("6".To<char?>());
            Debug.WriteLine("xxx".To<string>());

            Debug.WriteLine("888888".To(typeof(int)));
            Debug.WriteLine("888888".To(typeof(int?)));

            Debug.WriteLine("888.888".To(typeof(float)));
            Debug.WriteLine("888.888".To(typeof(float?)));

            Debug.WriteLine("888.888".To(typeof(double)));
            Debug.WriteLine("888.888".To(typeof(double?)));

            Debug.WriteLine("88888.8".To(typeof(decimal)));
            Debug.WriteLine("88888.8".To(typeof(decimal?)));

            Debug.WriteLine("8".To(typeof(char)));
            Debug.WriteLine("8".To(typeof(char?)));

            Debug.WriteLine("xxx".To(typeof(string)));

        }
    }
}
