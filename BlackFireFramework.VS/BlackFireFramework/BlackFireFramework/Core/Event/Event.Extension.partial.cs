//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading;

namespace BlackFireFramework
{
    public static partial class Event
    {

        //public static void Fire<T>(string topicName,object sender,T eventArgs,bool fireNow = true) where T : EventArgs
        //{
        //    Event.Fire(topicName,sender,(EventArgs)eventArgs,fireNow);
        //}

        public static void On<T>(string topicName, object listener,EventHandler<T> eventHandler) where T:EventArgs
        {
            Event.On(topicName,listener,(sender,args)=> {
                if (null!= eventHandler)
                {
                    eventHandler.Invoke(sender,args as T);
                }
            });
        }

    }
}
