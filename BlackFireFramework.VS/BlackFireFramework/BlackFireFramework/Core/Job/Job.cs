//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Threading;

namespace BlackFireFramework
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


    }
}
