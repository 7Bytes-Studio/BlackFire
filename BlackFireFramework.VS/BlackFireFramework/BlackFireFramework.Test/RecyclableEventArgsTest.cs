using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace BlackFireFramework.Test
{
    [TestClass]
    public class RecyclableEventArgsTest
    {
        private const int TestCount = 100;

        [TestMethod]
        public void TestMethod_RecyclableEventArgsTest_DontUse()
        {
            TestRecyclableEventArgs[] args = new TestRecyclableEventArgs[TestCount];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = new TestRecyclableEventArgs();
            }


            for (int i = 0; i < args.Length; i++)
            {
                args[i] = null;
            }

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = new TestRecyclableEventArgs();
            }

        }

        [TestMethod]
        public void TestMethod_RecyclableEventArgsTest_Use()
        {
            TestRecyclableEventArgs[] args = new TestRecyclableEventArgs[TestCount];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = TestRecyclableEventArgs.Spawn<TestRecyclableEventArgs>();
            }


            for (int i = 0; i < args.Length; i++)
            {
                TestRecyclableEventArgs.Recycle(args[i]);
            }

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = TestRecyclableEventArgs.Spawn<TestRecyclableEventArgs>();
            }

        }


        [TestMethod]
        public void TestMethod_RecyclableEventArgsTest_UnRecycle()
        {
            for (int i = 0; i < TestCount; i++)
            {
                var ins = new TestRecyclableEventArgs();
                ins.TestNoticeStr = "Hello world! " + i;
                Debug.WriteLine(ins.TestNoticeStr);
                ins = null;
            }
        }


        [TestMethod]
        public void TestMethod_RecyclableEventArgsTest_Recycle()
        {
            for (int i = 0; i < TestCount; i++)
            {
                var ins = TestRecyclableEventArgs.Spawn<TestRecyclableEventArgs>();
                ins.TestNoticeStr = "Hello world! " + i;
                Debug.WriteLine(ins.TestNoticeStr);
                TestRecyclableEventArgs.Recycle(ins);
            }
        }


        [TestMethod]
        public void TestMethod_RecyclableEventArgsTest_TwoTestImpl_Recycle()
        {
            for (int i = 0; i < TestCount; i++)
            {

                var ins1 = TestRecyclableEventArgs.Spawn<TestRecyclableEventArgs>();
                ins1.TestNoticeStr = "Hello world! " + i;
                Debug.WriteLine(ins1.TestNoticeStr);
                TestRecyclableEventArgs.Recycle(ins1);

                var ins2 = OtherTestRecyclableEventArgs.Spawn<OtherTestRecyclableEventArgs>();
                ins2.TestNoticeStr = "Hello world! " + i;
                Debug.WriteLine(ins2.TestNoticeStr);
                OtherTestRecyclableEventArgs.Recycle(ins2);

            }
        }







        /// <summary>
        /// 测试类。
        /// </summary>
        public sealed class TestRecyclableEventArgs : RecyclableEventArgs
        {
            public string TestNoticeStr = string.Empty;

            protected override void OnRecycle()
            {
                Debug.WriteLine("OnRecycle: " + GetHashCode());
            }

            protected override void OnSpawn()
            {
                Debug.WriteLine("OnSpawn: " + GetHashCode());
            }
        }


        /// <summary>
        /// 另外一个测试类。
        /// </summary>
        public sealed class OtherTestRecyclableEventArgs : RecyclableEventArgs
        {
            public string TestNoticeStr = string.Empty;

            protected override void OnRecycle()
            {
                 Debug.WriteLine("OnRecycle: " + GetHashCode());
            }

            protected override void OnSpawn()
            {
                 Debug.WriteLine("OnSpawn: " + GetHashCode());
            }
        }



    }
}
