/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Collections.Generic;

namespace BlackFire
{
    public static partial class Job
    {
        /// <summary>
        /// Job静态类被使用。
        /// </summary>
        static Job()
        {
            Framework.LifeCircle.OnBorn += Born;
            Framework.LifeCircle.OnAct += Act;
            Framework.LifeCircle.OnDie += Die;
        }


        /// <summary>
        /// 诞生。
        /// </summary>
        internal static void Born()
        {
            
        }

        /// <summary>
        /// 活动。
        /// </summary>
        internal static void Act()
        {
            DeSyncStateQueue();
        }

        /// <summary>
        /// 灭亡。
        /// </summary>
        internal static void Die()
        {
           
        }


        private static void EnSyncStateQueue(JobState jobState, DoneSyncCallback doneSyncCallback)
        {
            s_QueueJobStateSyncData.Enqueue(new JobStateSyncData() { JobState = jobState,DoneSyncCallback = doneSyncCallback});
        }


        private static void DeSyncStateQueue()
        {
            while (0<s_QueueJobStateSyncData.Count)
            {
                var jobStateSync =  s_QueueJobStateSyncData.Dequeue();
                if (null!= jobStateSync.DoneSyncCallback)
                {
                    jobStateSync.DoneSyncCallback.Invoke(jobStateSync.JobState);
                }
            }
        }


        private static Queue<JobStateSyncData> s_QueueJobStateSyncData = new Queue<JobStateSyncData>();

        private sealed class JobStateSyncData
        {
            public JobState JobState;

            public DoneSyncCallback DoneSyncCallback;
        }


    }
}
