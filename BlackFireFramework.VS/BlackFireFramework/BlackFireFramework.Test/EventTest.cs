using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace BlackFireFramework.Test
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void TestMethod()
        {
            Event.On("Test","Listener:Alex",(sender,args)=> { Debug.WriteLine("Alex: Hello world!");});
            Event.On("Test","Listener:Adam",(sender,args)=> { Debug.WriteLine("Adam: Hello world!");});
            Event.On("Test","Listener:Allen",(sender,args)=> { Debug.WriteLine("Allen: Hello world!");});
            Event.On("Test","Listener:Asiba",(sender,args)=> { Debug.WriteLine("Asiba: Hello world!");});
            Event.On("Test","Listener:Aha",(sender,args)=> { Debug.WriteLine("Aha: Hello world!");});

            Event.Fire("Test","Sender:Alan",EventArgs.Empty);

            Debug.WriteLine("---Off");

            Event.Off("Test", "Listener:Adam");
            Event.Off("Test", "Listener:Aha");


            Event.Fire("Test", "Sender:Alan", EventArgs.Empty);
        }
    }
}
