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

namespace BlackFire
{
    public class ActionQueue 
    {
        public int Count { get { return s_Queue.Count; } }

        private readonly Queue<Action> s_Queue = new Queue<Action>();

        public void Enqueue(Action action)
        {
            if (null == action) return;
            s_Queue.Enqueue(action);
        }

        public Action Dequeue()
        {
           return s_Queue.Dequeue();
        }

        public void DequeueAll()
        {
            while (0 < s_Queue.Count)
            {
                s_Queue.Dequeue().Invoke();
            }
        }

        public void Clear()
        {
           s_Queue.Clear();
        }
    }
}
