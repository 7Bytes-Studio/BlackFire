//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework
{
    public abstract class ModuleBase : EntityTreeNode, IModule
    {
        public ModuleBase(): base(null)
        {
            Value = new UserData(string.Format("Module:{0}",GetType().FullName));
        }

        #region IModule 接口实现


        /// <summary>
        /// 是否处于工作状态。
        /// </summary>
        public virtual bool IsWorking { get { return Alive && !m_HasSuspended; }}

        /// <summary>
        /// 模块是否有被挂起。
        /// </summary>
        private bool m_HasSuspended = false;


        /// <summary>
        /// 唤醒模块。
        /// </summary>
        public virtual void Resume()
        {
            if (m_HasSuspended)
            {
                OnResume();
                m_HasSuspended = false;
            }
            
        }

        /// <summary>
        /// 挂起模块。
        /// </summary>
        public virtual void Suspend()
        {
            if (!m_HasSuspended)
            {
                OnSuspend();
                m_HasSuspended = true;
            }
           
        }

        #endregion

        #region 事件


        /// <summary>
        /// 模块被唤醒事件。
        /// </summary>
        protected virtual void OnResume()
        {

        }

        /// <summary>
        /// 模块被挂起事件。
        /// </summary>
        protected virtual void OnSuspend()
        {

        }


        #endregion

        #region 检查

        protected virtual void CheckWorkingStateOrThrow()
        {
            if (!IsWorking)
            {
                throw new System.Exception(string.Format("The module '{0}' is not working, do not operate the module.",GetType()));
            }
        }

        #endregion
    }
}
