using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;

namespace BlackFireFramework.Test
{
    [TestClass]
    public class ObjectExtensionTest
    {
        [TestMethod]
        public void TestMethod_ObjectExtensionTest()
        {
            TestMethodInvoke testMethodInvoke = new TestMethodInvoke();



            Debug.WriteLine(testMethodInvoke.Invoke("publicAdd", 1, 2));
            Debug.WriteLine(testMethodInvoke.Invoke("publicStaticAdd", 1, 2));

            Debug.WriteLine(testMethodInvoke.Invoke("privateAdd", 1, 2));
            Debug.WriteLine(testMethodInvoke.Invoke("privateStaticAdd", 1, 2));

            Debug.WriteLine(testMethodInvoke.Invoke("protectedAdd", 1, 2));
            Debug.WriteLine(testMethodInvoke.Invoke("protectedStaticAdd", 1, 2));

            Debug.WriteLine(testMethodInvoke.Invoke("internalAdd", 1, 2));
            Debug.WriteLine(testMethodInvoke.Invoke("internalStaticAdd", 1, 2));

            Debug.WriteLine(testMethodInvoke.Invoke("ToString"));
            Debug.WriteLine(testMethodInvoke.Invoke("ToString"));
            Debug.WriteLine(testMethodInvoke.Invoke("ToString"));
            Debug.WriteLine(testMethodInvoke.Invoke("ToString"));
            Debug.WriteLine(testMethodInvoke.Invoke("ToString"));

            TestMethodInvoke testMethodInvoke1 = new TestMethodInvoke();

            Debug.WriteLine(testMethodInvoke1.Invoke("publicAdd", 1, 2));
            Debug.WriteLine(testMethodInvoke1.Invoke("publicStaticAdd", 1, 2));

            Debug.WriteLine(testMethodInvoke1.Invoke("privateAdd", 1, 2));
            Debug.WriteLine(testMethodInvoke1.Invoke("privateStaticAdd", 1, 2));

            Debug.WriteLine(testMethodInvoke1.Invoke("protectedAdd", 1, 2));
            Debug.WriteLine(testMethodInvoke1.Invoke("protectedStaticAdd", 1, 2));

            Debug.WriteLine(testMethodInvoke1.Invoke("internalAdd", 1, 2));
            Debug.WriteLine(testMethodInvoke1.Invoke("internalStaticAdd", 1, 2));

            Debug.WriteLine(testMethodInvoke1.Invoke("ToString"));
            Debug.WriteLine(testMethodInvoke1.Invoke("ToString"));
            Debug.WriteLine(testMethodInvoke1.Invoke("ToString"));
            Debug.WriteLine(testMethodInvoke1.Invoke("ToString"));
            Debug.WriteLine(testMethodInvoke1.Invoke("ToString"));

        }

        private class TestMethodInvoke
        {
            public override string ToString()
            {
                return "Fucking...";
            }

            public int publicAdd(int a, int b)
            {
                return a + b;
            }

            public static int publicStaticAdd(int a, int b)
            {
                return a + b;
            }

            private int privateAdd(int a, int b)
            {
                return a + b;
            }

            private static int privateStaticAdd(int a, int b)
            {
                return a + b;
            }
            protected int protectedAdd(int a, int b)
            {
                return a + b;
            }

            protected static int protectedStaticAdd(int a, int b)
            {
                return a + b;
            }

            internal int internalAdd(int a, int b)
            {
                return a + b;
            }

            internal static int internalStaticAdd(int a, int b)
            {
                return a + b;
            }


        }

    }
}
