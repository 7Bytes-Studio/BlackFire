using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using BlackFireFramework.TestAssembly;

namespace BlackFireFramework.Test
{
    [TestClass]
    public class TestAssemblyTest
    {
        [TestMethod]
        public void TestMethod_TestAssembly()
        {
            Log.SetLogCallback(LogCallback);

            Framework.Born(this, 0f, 0f);
            Framework.Act(this, 0f, 0f);
            Framework.Die(this, 0f, 0f);

            Debug.WriteLine(EntityTree.GetEntityInChildren(typeof(IModuleManager)).ToString());
            Debug.WriteLine(EntityTree.GetEntityInChildren(typeof(IExportedAssemblyManager)).ToString());

            var exportedAssemblyManager  =  (IExportedAssemblyManager)EntityTree.GetEntityInChildren(typeof(IExportedAssemblyManager));
            exportedAssemblyManager.LoadExportedAssembly("BlackFireFramework.TestAssembly");
        }

        public void LogCallback(LogLevel logLevel, object message)
        {
             Debug.WriteLine(logLevel + ":" + message);
        }
    }
}
