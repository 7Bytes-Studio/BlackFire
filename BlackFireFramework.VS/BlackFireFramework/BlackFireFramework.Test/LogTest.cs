using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace BlackFireFramework.Test
{
    [TestClass]
    public class LogTest
    {
        [TestMethod]
        public void TestMethod_Log()
        {
            Log.SetLogCallback(LogCallback);

            Log.Trace("This is Trace Message.");
            Log.Debug("This is Debug Message.");
            Log.Info("This is Info Message.");
            Log.Warn("This is Warn Message.");
            Log.Error("This is Error Message.");
            Log.Fatal("This is Fatal Message.");

        }

        public void LogCallback(LogLevel logLevel, object message)
        {
            Debug.WriteLine(logLevel+":"+message);
        }



    }
}
