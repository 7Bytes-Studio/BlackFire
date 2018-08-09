//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

namespace BlackFireFramework.Unity
{
    public sealed class IoCDemo : MonoBehaviour
    {
        private void Start()
        {
            var i = BlackFire.IoC.Build<ISayHello>();
            Log.Info(i.GetHashCode());
            i.SayHello();
            i = BlackFire.IoC.Build<ISayHello>();
            Log.Info(i.GetHashCode());
            i.SayHello();
        }
    }

    
    
    
    
    public interface ISayHello
    {
        void SayHello();
    }

    internal sealed class SayHelloImpl : ISayHello
    {
        public void SayHello()
        {
            Debug.Log("Alan:Hello!");
        }
    }
    
    internal sealed class SayHelloZCImpl : ISayHello,ICloneable
    {
        public void SayHello()
        {
            Debug.Log("ZC:Hello!");
        }

        public object Clone()
        {
            return new SayHelloZCImpl();
        }
    }
    

    public sealed class IoCRegister1 : IIoCRegister
    {

        public void OnRegister(ISparrowIoC ioc)
        {
            Debug.Log(this.GetType());
            //ioc.RegisterType<SayHelloImpl>().As<ISayHello>();
            //ioc.RegisterType<SayHelloZCImpl>().As<ISayHello>();
            //ioc.Register(i=>new SayHelloZCImpl()).As<ISayHello>();
            //ioc.RegisterInstance(new SayHelloZCImpl()).As<ISayHello>();
            //ioc.RegisterInstance(new SayHelloImpl()).As<ISayHello>().AsSingleton();
            ioc.Register(i=>new SayHelloZCImpl()).As<ISayHello>();
        }
    }
    public sealed class IoCRegister2 : IIoCRegister
    {

        public void OnRegister(ISparrowIoC ioc)
        { 
            Debug.Log(this.GetType());
        }
    }
    public sealed class IoCRegister3 : IIoCRegister
    {

        public void OnRegister(ISparrowIoC ioc)
        {
            Debug.Log(this.GetType());
        }
    }
    
    public sealed class IoCRegister11 : IIoCRegister
    {

        public void OnRegister(ISparrowIoC ioc)
        { 
            Debug.Log(this.GetType());
        }
    }
    public sealed class IoCRegister22 : IIoCRegister
    {

        public void OnRegister(ISparrowIoC ioc)
        {
            Debug.Log(this.GetType());
        }
    }
    public sealed class IoCRegister33 : IIoCRegister
    {

        public void OnRegister(ISparrowIoC ioc)
        { 
            Debug.Log(this.GetType());
        }
    }

}