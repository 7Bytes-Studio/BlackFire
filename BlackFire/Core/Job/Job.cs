/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Threading;

namespace BlackFire
{
    public static partial class Job
    {

        public static void SetJobThreads(int minThreads,int maxTheads)
        {
            ThreadPool.SetMinThreads(minThreads,minThreads);
            ThreadPool.SetMaxThreads(maxTheads, maxTheads);
        }


        public static void StartNew(WaitCallback waitCallback,Token token=null)
        {
            ThreadPool.QueueUserWorkItem(state=> {

                if (null!= waitCallback)
                {
                    JobState jobState = new JobState();
                    jobState.Token = token ?? new Token();
                    jobState.State = state;

                    waitCallback.Invoke(jobState);
                }

            });
        }


        public static void StartNew(WaitCallback waitCallback,DoneSyncCallback doneSyncCallback,Token token=null)
        {
            ThreadPool.QueueUserWorkItem(state => {

                if (null != waitCallback)
                {
                    JobState jobState = new JobState();
                    jobState.Token = token ?? new Token();
                    jobState.State = state;
                    waitCallback.Invoke(jobState);
                    EnSyncStateQueue(jobState,doneSyncCallback);
                }

            });
        }


        public static void StartLongNew(WaitCallback waitCallback, Token token = null)
        {
            Thread thread = null;
            thread = new Thread(state => {
                if (null != waitCallback)
                {
                    JobState jobState = new JobState();
                    jobState.Token = token ?? new Token();
                    jobState.State = thread;
                    waitCallback.Invoke(jobState);
                }
            });
            thread.Start();
        }

        public static void StartLongNew(WaitCallback waitCallback, DoneSyncCallback doneSyncCallback, Token token = null)
        {
            Thread thread = null;
            thread = new Thread(state => {
                if (null != waitCallback)
                {
                    JobState jobState = new JobState();
                    jobState.Token = token ?? new Token();
                    jobState.State = thread;
                    waitCallback.Invoke(jobState);
                    EnSyncStateQueue(jobState, doneSyncCallback);
                }
            });
            thread.Start();

        }

    }
}
