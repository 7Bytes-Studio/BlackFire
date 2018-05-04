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

        public static void Fire(string topicName,object sender,EventArgs eventArgs, bool fireNow = true)
        {
            var eventTopic = CheckOrCreateEventTopic(sender,topicName);
            eventTopic.Content = eventArgs;

            var publisher = Publisher.Spawn(sender);
            publisher.JoinTopic(eventTopic);

            if (fireNow)
            {
                publisher.Publish();
            }
            else
            {
                EnSyncQueue(eventTopic);
            }
        }

        public static void On(string topicName,object listener,EventHandler eventHandler)
        {
            if (null== listener || null== eventHandler)
            {
                throw new ArgumentNullException(string.Format("参数listener和eventHandler都不能为空。"));
            }

            var subscriber = Subscriber.Spawn(listener,eventHandler);
            var eventTopic = CheckOrCreateEventTopic(listener,topicName);
            eventTopic.OnSubscrib(subscriber);
        }

        public static void Off(string topicName, object listener)
        {
            var eventTopic = EventTopic.GetEventTopic(topicName);
            if (null!=eventTopic)
            {
                eventTopic.OnUnsubscribe(Subscriber.GetSubscriber(listener));
            }
        }


        private static EventTopic CheckOrCreateEventTopic(object creator,string topicName)
        {
            var eventTopic = EventTopic.GetEventTopic(topicName);
            if (null == eventTopic)
            {
                eventTopic = EventTopic.Create(creator, topicName);
            }
            return eventTopic;
        }


        private static Queue<EventTopic> s_QueueEventTopic = new Queue<EventTopic>();

        private static void EnSyncQueue(EventTopic eventTopic)
        {
            s_QueueEventTopic.Enqueue(eventTopic);
        }

        private static void DeSyncQueue()
        {
            while (0< s_QueueEventTopic.Count)
            {
                s_QueueEventTopic.Dequeue();
            }
        }

    }

    

}
