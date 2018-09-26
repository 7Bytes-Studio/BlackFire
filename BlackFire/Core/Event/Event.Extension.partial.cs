/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Threading;

namespace BlackFire
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
