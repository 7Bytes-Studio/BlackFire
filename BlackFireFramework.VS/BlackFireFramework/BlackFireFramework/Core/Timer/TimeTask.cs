//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework
{
    /// <summary>
    /// 时间任务类
    /// </summary>
    public sealed class TimeTask
    {
        public TimeTaskType TimeTaskType { get; private set; }

        private static readonly ObjectQueue<TimeTask> s_ObjectQueue = new ObjectQueue<TimeTask>(() => new TimeTask());

        private TimerTaskCallback m_TimerTaskCallback = null;

        private bool m_Enabled = true;

        public bool Enabled { get { return m_Enabled; } private set { m_Enabled = value; } }

        internal TimeTask SetTask(TimeTaskType timeTask, float time, int frame)
        {
            TimeTaskType = timeTask;
            switch (TimeTaskType)
            {
                case TimeTaskType.Delay:
                    m_DelayTime = time;
                    break;
                case TimeTaskType.DelayFrame:
                    m_DelayFrame = frame;
                    break;
                case TimeTaskType.Loop:
                    m_LoopTime = time;
                    break;
                case TimeTaskType.LoopFrame:
                    m_LoopFrame = frame;
                    break;
                case TimeTaskType.Interval:
                    m_IntervalTime = time;
                    break;
                case TimeTaskType.IntervalFrame:
                    m_IntervalFrame = frame;
                    break;
                case TimeTaskType.RealDelay:
                    m_RealDelayTime = time;
                    break;
                case TimeTaskType.RealLoop:
                    m_RealLoopTime = time;
                    break;
                case TimeTaskType.RealInterval:
                    m_RealIntervalTime = time;
                    break;
                default:
                    break;
            }
            return this;
        }

        /// <summary>
        /// 中断
        /// </summary>
        public void Suspend()
        {
            Enabled = false;
        }

        /// <summary>
        /// 恢复
        /// </summary>
        public void Resume()
        {
            Enabled = true;
        }

        /// <summary>
        /// 取消
        /// </summary>
        public void Cancel()
        {
            OnRecycle();
        }

        public TimeTask On(TimerTaskCallback timerTaskCallback)
        {
            m_TimerTaskCallback += timerTaskCallback;
            return this;
        }

        private void Emit()
        {
            if (null != m_TimerTaskCallback)
            {
                m_TimerTaskCallback.Invoke();
            }
        }

        internal void Update()
        {
            if (!Enabled) return;

            if (null== m_TimerTaskCallback)
            {
                return;
            }

            switch (TimeTaskType)
            {
                case TimeTaskType.Delay:
                    if (0f >= (m_DelayTime -= Framework.Time.VirsulElapsedDeltaTime)) { Emit(); OnRecycle(); };
                    break;
                case TimeTaskType.DelayFrame:
                    if (0 >= (m_DelayFrame--)) { Emit(); OnRecycle(); };
                    break;
                case TimeTaskType.Loop:
                    if (0f < (m_LoopTime -= Framework.Time.VirsulElapsedDeltaTime)) { Emit(); } else { OnRecycle(); };
                    break;
                case TimeTaskType.LoopFrame:
                    if (0 < (m_LoopFrame--)) { Emit(); } else { OnRecycle(); };
                    break;
                case TimeTaskType.Interval:
                    if (m_IntervalTime <= (m_TempIntervalTime += Framework.Time.VirsulElapsedDeltaTime)) { m_TempIntervalTime = 0f; Emit(); }
                    break;
                case TimeTaskType.IntervalFrame:
                    if (0 == (m_TempIntervalFrame--) % m_IntervalFrame) Emit();
                    break;
                case TimeTaskType.RealDelay:
                    if (0f >= (m_RealDelayTime -= Framework.Time.RealElapsedDeltaTime)) { Emit(); OnRecycle(); };
                    break;
                case TimeTaskType.RealLoop:
                    if (0f < (m_RealLoopTime -= Framework.Time.RealElapsedDeltaTime)) { Emit(); } else { OnRecycle(); };
                    break;
                case TimeTaskType.RealInterval:
                    if (m_RealIntervalTime <= (m_TempRealIntervalTime += Framework.Time.RealElapsedDeltaTime)) { m_TempRealIntervalTime = 0f; Emit(); }
                    break;
                default:
                    break;
            }
        }

        #region Time Data

        internal float m_DelayTime;
        internal int m_DelayFrame;

        internal float m_LoopTime;
        internal int m_LoopFrame;

        internal float m_IntervalTime;
        internal float m_TempIntervalTime;
        internal int m_IntervalFrame;
        internal int m_TempIntervalFrame;

        internal float m_RealDelayTime;
        internal float m_RealLoopTime;
        internal float m_RealIntervalTime;
        internal float m_TempRealIntervalTime;

        #endregion

        #region ObjectQueue

        internal static TimeTask Spawn()
        {
            var target = s_ObjectQueue.Spawn();
            Framework.LifeCircle.OnAct += target.Update;
            return target;
        }

        internal void OnRecycle()
        {
            m_DelayTime = 0f;
            m_DelayFrame = 0;
            m_LoopTime = 0f;
            m_LoopFrame = 0;
            m_IntervalTime = 0f;
            m_TempIntervalTime = 0f;
            m_IntervalFrame = 0;
            m_TempIntervalFrame = 0;
            m_RealDelayTime = 0f;
            m_RealLoopTime = 0f;
            m_RealIntervalTime = 0f;

            TimeTaskType = TimeTaskType.Idle;
            m_TimerTaskCallback = null;
            s_ObjectQueue.Recycle(this);

            Framework.LifeCircle.OnAct -= Update;
        }

        #endregion
    }

}
