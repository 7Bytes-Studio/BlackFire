//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework
{
    /// <summary>
    /// Sparrow Timer.
    /// </summary>
    public static class Timer
    {
        #region Magic Methods
        public static TimeTask Delay(float time)
        {
            return TimeTask.Spawn().SetTask(TimeTaskType.Delay, time, 0);
        }

        public static TimeTask DelayFrame(int frames)
        {
            return TimeTask.Spawn().SetTask(TimeTaskType.DelayFrame, 0f, frames);
        }

        public static TimeTask Loop(float time)
        {
            return TimeTask.Spawn().SetTask(TimeTaskType.Loop, time, 0);
        }

        public static TimeTask LoopFrame(int frames)
        {
            return TimeTask.Spawn().SetTask(TimeTaskType.LoopFrame, 0f, frames); ;
        }

        public static TimeTask Interval(float time)
        {
            return TimeTask.Spawn().SetTask(TimeTaskType.Interval, time, 0);
        }

        public static TimeTask IntervalFrame(int frames)
        {
            return TimeTask.Spawn().SetTask(TimeTaskType.IntervalFrame, 0f, frames);
        }

        public static TimeTask RealDelay(float time)
        {
            return TimeTask.Spawn().SetTask(TimeTaskType.RealDelay, time, 0);
        }

        public static TimeTask RealLoop(float time)
        {
            return TimeTask.Spawn().SetTask(TimeTaskType.RealLoop, time, 0);
        }

        public static TimeTask RealInterval(float time)
        {
            return TimeTask.Spawn().SetTask(TimeTaskType.RealInterval, time, 0);
        }

        #endregion




    }
}







