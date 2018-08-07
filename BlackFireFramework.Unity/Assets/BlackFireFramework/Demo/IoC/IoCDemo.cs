//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Runtime.CompilerServices;
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

        public void OnRegister(ISparrowIoC ioc)
        {
            Debug.Log(this.GetType());
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