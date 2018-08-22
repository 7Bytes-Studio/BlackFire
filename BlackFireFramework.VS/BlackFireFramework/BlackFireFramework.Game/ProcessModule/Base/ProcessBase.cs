//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework.Game
{
    public abstract class ProcessBase : EntityTreeNode
    {
        internal static ProcessBase LastProcess;
        internal static ProcessBase CurrentProcess;
        
        public ProcessBase():base(null)
        {
            Event.On(GlobalEvent.ChangeProcess, this, (sender, args) =>
            {
                var convertArgs = args as ChangeProcessEventArgs;
                if (!sender.Equals(this) && convertArgs.ToProcessType == GetType()) //改变状态至当前类型状态。
                {
                    IsWorking = true;
                    OnProcessEnter();
                    m_StartWorkingTime = DateTime.Now;
                    LastEnterDate = DateTime.Now;
                    CurrentProcess = this;
                }
            });
        }

        public abstract string Name { get; }

        public bool IsWorking { get; private set; }

        private float m_WorkingTime;
        public float WorkingTime
        {
            get { return m_WorkingTime; }
        }
        
        public float ActivityTime
        {
            get { return IsWorking?(float)(DateTime.Now - LastEnterDate).TotalSeconds:0f;}
        }
        
        public DateTime LastEnterDate { get; private set; }
        public DateTime LastExitDate { get; private set; }

        private DateTime m_StartWorkingTime = DateTime.Now; //开始运作的时间。
        protected override void OnBorn()
        {
            OnProcessInit();
        }

        protected override void OnAct()
        {
            if (IsWorking)
            {
                m_WorkingTime += (float) (DateTime.Now - m_StartWorkingTime).TotalSeconds;
                m_StartWorkingTime = DateTime.Now;
                OnProcessUpdate();
            }
        }

        protected override void OnDie()
        {
            OnProcessDestroy();
            Event.Off(GlobalEvent.ChangeProcess,this);
        }



        protected abstract void OnProcessInit();

        protected abstract void OnProcessEnter();

        protected abstract void OnProcessUpdate();

        protected abstract void OnProcessExit();

        protected abstract void OnProcessDestroy();



        protected void ChangeProcess(Type processType)
        {
            if (processType != GetType())
            {
                IsWorking = false;
                OnProcessExit();
                LastExitDate = DateTime.Now;
                LastProcess = this;
                Event.Fire(GlobalEvent.ChangeProcess, this, new ChangeProcessEventArgs() { FromProcessType = GetType(), ToProcessType = processType });
            }
        }

        protected void ChangeProcess<T>()where T:ProcessBase
        {
            if (typeof(T) != GetType())
            {
                IsWorking = false;
                OnProcessExit();
                LastExitDate = DateTime.Now;
                LastProcess = this;
                Event.Fire(GlobalEvent.ChangeProcess, this, new ChangeProcessEventArgs() { FromProcessType = GetType(), ToProcessType = typeof(T) });
            }
        }


    }
}
