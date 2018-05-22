//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;

namespace BlackFireFramework.Unity
{
    internal sealed class ProcessModule : ModuleBase, IProcessModule
    {
        private ProcessBase m_BootProcess = null;

        public void AddProcess(ProcessBase process)
        {
            CheckWorkingStateOrThrow();
            if (null== m_BootProcess)
            {
                m_BootProcess = process;
            }
            AddChildNode(process);
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
