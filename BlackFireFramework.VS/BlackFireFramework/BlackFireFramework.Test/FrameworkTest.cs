using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace BlackFireFramework.Test
{
    [TestClass]
    public class FrameworkTest
    {
        [TestMethod]
        public void TestMethod_Framework()
        {
            Log.SetLogCallback(LogCallback);

            Framework.Born("FrameworkCreator", 0f, 0f);
            Framework.Act("FrameworkCreator", 0f, 0f);
            Framework.Die("FrameworkCreator", 0f, 0f);
        }

        public void LogCallback(LogLevel logLevel, object message)
        {
             Debug.WriteLine(logLevel + ":" + message);
        }




        [TestMethod]
        public void TestMethod_TestAssembly()
        {
            Debug.WriteLine(EntityTree.GetEntityInChildren(typeof(IModuleManager)).ToString());
            Debug.WriteLine(EntityTree.GetEntityInChildren(typeof(IExportedAssemblyManager)).ToString());
            for (int i = 0; i < 60; i++)
            {
                Framework.Act("FrameworkCreator", 0f, 0f);
            }
            var exportedAssemblyManager = (IExportedAssemblyManager)EntityTree.GetEntityInChildren(typeof(IExportedAssemblyManager));
            exportedAssemblyManager.LoadExportedAssembly("BlackFireFramework.TestAssembly");
        }



    }
}
