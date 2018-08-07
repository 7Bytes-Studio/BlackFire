//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class IoCDemo : MonoBehaviour
    {
        private void Start()
        {

        }
    }

    public sealed class IoCRegister1 : IIoCRegister
    {
        public string Owner
        {
            get { return "Alan"; }
        }
        public void OnRegister(ISparrowIoC ioc)
        {
        }
    }
    public sealed class IoCRegister2 : IIoCRegister
    {
        public string Owner
        {
            get { return "Alan"; }
        }
        public void OnRegister(ISparrowIoC ioc)
        {
        }
    }
    public sealed class IoCRegister3 : IIoCRegister
    {
        public string Owner
        {
            get { return "Alan"; }
        }
        public void OnRegister(ISparrowIoC ioc)
        {
        }
    }
    
    public sealed class IoCRegister11 : IIoCRegister
    {
        public string Owner
        {
            get { return "Alex"; }
        }
        public void OnRegister(ISparrowIoC ioc)
        {
        }
    }
    public sealed class IoCRegister22 : IIoCRegister
    {
        public string Owner
        {
            get { return "Alex"; }
        }
        public void OnRegister(ISparrowIoC ioc)
        {
        }
    }
    public sealed class IoCRegister33 : IIoCRegister
    {
        public string Owner
        {
            get { return "Alex"; }
        }
        public void OnRegister(ISparrowIoC ioc)
        {
        }
    }

}