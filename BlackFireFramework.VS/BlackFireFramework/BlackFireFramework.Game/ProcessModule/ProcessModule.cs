//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;

namespace BlackFireFramework.Game
{
    internal sealed class ProcessModule : ModuleBase, IProcessModule
    {
        
        private ProcessBase m_BootProcess = null;

        public ProcessBase BootProcess
        {
            get { return m_BootProcess; }
        }
        
        
        public ProcessBase CurrentProcess {
            get
            {
//                foreach (ProcessBase node in this)
//                {
//                    if (node.IsWorking)
//                    {
//                        return node;
//                    }
//                }
//                return null;
                return ProcessBase.CurrentProcess;
            }
        }
        
        public ProcessBase LastProcess {
            get
            {
                return ProcessBase.LastProcess;
            }
        }

        public void AddProcess(ProcessBase process)
        {
            CheckWorkingStateOrThrow();
            if (null== m_BootProcess)
            {
                m_BootProcess = process;
            }
            AddChildNode(process);
            //Log.Info(process.Value.Name+"  "+process.GetHashCode());
        }

        public ProcessBase[] GetProcesses()
        {
            List<ProcessBase> list = new List<ProcessBase>();
            foreach (ProcessBase node in this)
            {
                list.Add(node);
            }
            return list.ToArray();
        }

        public void StartFirstProcess()
        {
            CheckWorkingStateOrThrow();
            if (null != m_BootProcess)
            {
                Event.Fire(GlobalEvent.ChangeProcess, this, new ChangeProcessEventArgs() { FromProcessType = null, ToProcessType = m_BootProcess.GetType() });
            }
        }

    }
}
