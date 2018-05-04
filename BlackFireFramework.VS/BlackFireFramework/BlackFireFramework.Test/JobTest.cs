using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace BlackFireFramework.Test
{
    [TestClass]
    public class JobTest
    {
        [TestMethod]
        public void TestMethod_Job()
        {
            var token = new Job.Token();
            Job.StartNew(t=> {

                for (int i = 0; i < 10000; i++)
                {
                    Debug.Write(i);
                }

            }, token);


        }
    }
}
