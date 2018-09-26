/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire
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







