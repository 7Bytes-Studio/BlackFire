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

        /// <summary>
        /// 事件主题。
        /// </summary>
        public class EventTopic
        {
            /// <summary>
            /// 主题。
            /// </summary>
            public string UniqueTopicName; //全局唯一键。

            /// <summary>
            /// 主题所在的线程Id。
            /// </summary>
            public int ThreadId;

            /// <summary>
            /// 主题的创建者。
            /// </summary>
            public object Creator;

            /// <summary>
            /// 主题创建时间。
            /// </summary>
            public DateTime CreateTime;




            /// <summary>
            /// 发布的内容。
            /// </summary>
            public EventArgs Content;

            /// <summary>
            /// 主题被发布的次数。
            /// </summary>
            public int NumberOfTopicsPublished;

            /// <summary>
            /// 主题发布者。
            /// </summary>
            public Publisher Publisher { get;private set; }

            /// <summary>
            /// 主题订阅者们。
            /// </summary>
            public LinkedList<Subscriber> Subscribers = new LinkedList<Subscriber>();


            /// <summary>
            /// 主题被发布事件。
            /// </summary>
            /// <param name="publisher">发布者。</param>
            internal void OnPublish(Publisher publisher)
            {
                Publisher = publisher;
                Subscribers.Foreach(current => {

                    current.Value.OnReceived(this);

                });
            }

            /// <summary>
            /// 主题被订阅事件。
            /// </summary>
            /// <param name="subscriber">订阅者。</param>
            internal void OnSubscrib(Subscriber subscriber)
            {
                if (!Subscribers.Contains(subscriber))
                {
                    Subscribers.AddLast(subscriber);
                }
            }

            /// <summary>
            /// 主题被取消订阅事件。
            /// </summary>
            /// <param name="subscriber">订阅者。</param>
            internal void OnUnsubscribe(Subscriber subscriber)
            {
                if (Subscribers.Contains(subscriber))
                {
                    Subscribers.Remove(subscriber);
                    Subscriber.Recycle(subscriber);
                }
            }



            #region static

            private readonly static Dictionary<string, EventTopic> s_DictionaryEventTopic = new Dictionary<string, EventTopic>();

            /// <summary>
            /// 创建事件主题。
            /// </summary>
            /// <param name="creator">创建者。</param>
            /// <param name="topicName">事件主题名字。</param>
            /// <returns></returns>
            public static EventTopic Create(object creator,string topicName)
            {
                if (!s_DictionaryEventTopic.ContainsKey(topicName))
                {
                    var eventTopic = new EventTopic();
                    eventTopic.Creator = creator;
                    eventTopic.UniqueTopicName = topicName;
                    eventTopic.CreateTime = DateTime.Now;
                    eventTopic.ThreadId = Thread.CurrentThread.ManagedThreadId;
                    s_DictionaryEventTopic.Add(topicName,eventTopic);
                    return eventTopic;
                }
                throw new Exception(string.Format("事件主题:{0}已经创建过了，请务重复创建。"));
            }


            /// <summary>
            /// 获取事件主题。
            /// </summary>
            /// <param name="topicName">事件主题的名字。</param>
            /// <returns></returns>
            public static EventTopic GetEventTopic(string topicName)
            {
                if (s_DictionaryEventTopic.ContainsKey(topicName))
                {
                    return s_DictionaryEventTopic[topicName];
                }
                return null;
            }

            #endregion

        }


    }

}
