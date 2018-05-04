//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using System;
using System.Collections.Generic;

namespace BlackFireFramework
{
    public static partial class Event
    {
        public sealed class Subscriber
        {

            public EventHandler EventHandler { get; internal set; }

            public object Target { get; internal set; }

            internal void OnReceived(EventTopic eventTopic)
            {
                if (null!= EventHandler)
                {
                    EventHandler.Invoke(eventTopic.Publisher.Target,eventTopic.Content);
                }
            }



            private readonly static ObjectQueue<Subscriber> s_ObjectQueue = new ObjectQueue<Subscriber>(() => new Subscriber());

            private readonly static Dictionary<object,Subscriber> s_SubscriberRecordDictionary = new Dictionary<object,Subscriber>();

            /// <summary>
            /// 产出。
            /// </summary>
            public static Subscriber Spawn(object target,EventHandler eventHandler)
            {
                var subscriber = s_ObjectQueue.Spawn();
                subscriber.Target = target;
                subscriber.EventHandler = eventHandler;

                if (!s_SubscriberRecordDictionary.ContainsKey(target))
                {
                    s_SubscriberRecordDictionary.Add(target,subscriber);
                }

                return subscriber;
            }

            /// <summary>
            /// 回收。
            /// </summary>
            public static void Recycle(Subscriber subscriber)
            {
                if (s_SubscriberRecordDictionary.ContainsKey(subscriber.Target))
                {
                    s_SubscriberRecordDictionary.Remove(subscriber.Target);
                }

                s_ObjectQueue.Recycle(subscriber);
            }

            /// <summary>
            /// 获取订阅者。
            /// </summary>
            /// <param name="target">订阅者的绑定引用。</param>
            /// <returns>订阅者。</returns>
            public static Subscriber GetSubscriber(object target)
            {
                if (s_SubscriberRecordDictionary.ContainsKey(target))
                {
                    return s_SubscriberRecordDictionary[target];
                }
                return null;
            }
        }
    }

}
