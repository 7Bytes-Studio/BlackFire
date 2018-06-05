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
        public ProcessBase(string processName):base(new UserData(processName))
        {
            Event.On(GlobalEvent.ChangeProcess, this, (sender, args) =>
            {
                var convertArgs = args as ChangeProcessEventArgs;
                if (!sender.Equals(this) && convertArgs.ToProcessType == GetType())
                {
                    IsWorking = true;
                    OnProcessEnter();
                }
            });
        }

        public bool IsWorking { get; private set; }

        protected override void OnBorn()
        {
            OnProcessInit();
        }

        protected override void OnAct()
        {
            if (IsWorking)
            {
                OnProcessUpdate();
            }
        }

        protected override void OnDie()
        {
            OnProcessDestroy();
        }



        protected internal abstract void OnProcessInit();

        protected internal abstract void OnProcessEnter();

        protected internal abstract void OnProcessUpdate();

        protected internal abstract void OnProcessExit();

        protected internal abstract void OnProcessDestroy();



        protected void ChangeProcess(Type processType)
        {
            if (processType != GetType())
            {
                IsWorking = false;
                OnProcessExit();
                Event.Fire(GlobalEvent.ChangeProcess, this, new ChangeProcessEventArgs() { FromProcessType = GetType(), ToProcessType = processType });
            }
        }

        protected void ChangeProcess<T>()where T:ProcessBase
        {
            if (typeof(T) != GetType())
            {
                IsWorking = false;
                OnProcessExit();
                Event.Fire(GlobalEvent.ChangeProcess, this, new ChangeProcessEventArgs() { FromProcessType = GetType(), ToProcessType = typeof(T) });
            }
        }


    }
}
