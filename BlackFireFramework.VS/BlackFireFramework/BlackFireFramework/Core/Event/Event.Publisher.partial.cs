//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using System.Collections.Generic;

namespace BlackFireFramework
{
    public static partial class Event
    {
        /// <summary>
        /// 主题发布者。
        /// </summary>
        public sealed class Publisher
        {
            public object Target { get; internal set; }
            public EventTopic Topic { get; set; }

            /// <summary>
            /// 加入主题。
            /// </summary>
            /// <param name="topic">事件主题。</param>
            public void JoinTopic(EventTopic topic)
            {
                Topic = topic;
            }

            /// <summary>
            /// 发布主题。
            /// </summary>
            public void Publish()
            {
                if (null != Topic)
                {
                    Topic.OnPublish(this);
                }
            }


            private readonly static ObjectQueue<Publisher> s_ObjectQueue = new ObjectQueue<Publisher>(()=>new Publisher());

            /// <summary>
            /// 产出。
            /// </summary>
            public static Publisher Spawn(object target)
            {
                var publisher = s_ObjectQueue.Spawn();
                publisher.Target = target;
                return publisher;
            }

            /// <summary>
            /// 回收。
            /// </summary>
            public static void Recycle(Publisher publisher)
            {
                s_ObjectQueue.Recycle(publisher);
            }


        }
    }

}
