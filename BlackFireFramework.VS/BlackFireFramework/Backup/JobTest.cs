using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading;

namespace BlackFireFramework.Test
{
    [TestClass]
    public class JobTest
    {
        [TestMethod]
        public void TestMethod_Job()
        {
            Debug.WriteLine("Start");
            ThreadPool.SetMinThreads(100,100);

            for (int i = 0; i < 1000; i++)
            {
                ThreadPool.QueueUserWorkItem(state=> { Debug.WriteLine("State:  "+state.ToString());  });
            }

            Debug.WriteLine("End");
        }
    }
}
