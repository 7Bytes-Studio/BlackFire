//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework
{
    public static partial class Event
    {

        public interface IEventHandler
        {

        }

        public static Action<object> FireHandlerChainCallback = null;


        public static void Fire<THandler>(object head,Action<THandler,object,EventArgs> callback) where THandler:IEventHandler
        {

        }
    }
}
