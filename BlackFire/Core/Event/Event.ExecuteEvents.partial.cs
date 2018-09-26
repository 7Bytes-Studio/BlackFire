/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;

namespace BlackFire
{
    public static partial class Event
    {

        public interface IEventHandler { }

        public static void SetGetEventHandlersCallback(Func<object, IEventHandler[]> callback)
        {
            s_GetEventHandlersCallback = callback;
        }
        public static Func<object, IEventHandler[]> s_GetEventHandlersCallback;

        public static IEventHandler[] GetEventHandler(object root)
        {
            if (null!= s_GetEventHandlersCallback)
            {
                return s_GetEventHandlersCallback.Invoke(root);
            }
            return root is IEventHandler ? new IEventHandler[] { root as IEventHandler } : null;
        }

        public static void Fire<THandler>(object root,Action<THandler> executeEventsCallback) where THandler:IEventHandler
        {
            var ehs = GetEventHandler(root);
            if (null!=ehs && null!= executeEventsCallback)
            {
                for (int i = 0; i < ehs.Length; i++)
                {
                    if (ehs[i] is THandler)
                    {
                        executeEventsCallback.Invoke((THandler)ehs[i]);
                        break;
                    }
                }
            }
        }
    }
}
