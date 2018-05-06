//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@gmail.com
//Website: http://www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;

namespace BlackFireFramework
{
    internal sealed class SparrowIoC: ISparrowIoC
    {

        #region Constructor
        public SparrowIoC()
        {
            m_Binder = new Binder(this);
        }

        #endregion

        #region IoCBinder LinkedList Operation

        private LinkedList<IoCBindData> m_IoCBindDataLinkedList = new LinkedList<IoCBindData>();

        private IoCBindData GetIoCBindDataByTargetType(Type targetType)
        {
            IoCBindData ioCBindData = null;
            m_IoCBindDataLinkedList.PredicateForeach<IoCBindData>(current => {

                if (null!=current.Value.TargetType && current.Value.TargetType == targetType)
                {
                    ioCBindData = current.Value;
                    return true;
                }

                return false;
            });
            return ioCBindData;
        }

        private IoCBindData GetIoCBindDataBySelfBindType(Type selfBindType)
        {
            IoCBindData ioCBindData = null;
            m_IoCBindDataLinkedList.PredicateForeach<IoCBindData>(current => {

                if (null != current.Value.SelfBindType && current.Value.SelfBindType == selfBindType)
                {
                    ioCBindData = current.Value;
                    return true;
                }

                return false;
            });
            return ioCBindData;
        }

        private IoCBindData GetIoCBindDataByInstance(object instance)
        {
            IoCBindData ioCBindData = null;
            m_IoCBindDataLinkedList.PredicateForeach<IoCBindData>(current => {

                if (null != current.Value.Instance && current.Value.Instance.Equals(instance))
                {
                    ioCBindData = current.Value;
                    return true;
                }

                return false;
            });
            return ioCBindData;
        }


        #endregion

        #region IoC Operation
        public object Build(Type targetType)
        {
            TargetTypeCheck(targetType);
            var bindData = GetIoCBindDataByTargetType(targetType);
            if (null != bindData)
            {
                return bindData.Build(targetType);
            }
            return null;
        }

        public void Release(Type targetType)
        {
            TargetTypeCheck(targetType);
            var bindData = GetIoCBindDataByTargetType(targetType);
            if (null != bindData)
            {
                bindData.OnRelease();
                m_IoCBindDataLinkedList.Remove(bindData);
            }
        }

        public void ReleaseAll()
        {
            m_IoCBindDataLinkedList.Foreach<IoCBindData>(current => {

                current.Value.OnRelease();

            });
            m_IoCBindDataLinkedList.Clear();
        }

        public void RegisterInstance(Type targetType, object instance)
        {
            TargetTypeCheck(targetType);
            var bindData = GetIoCBindDataByTargetType(targetType);
            if (null == bindData)
            {
                m_IoCBindDataLinkedList.AddLast(bindData=new IoCBindData());
            }
            bindData.Bind(targetType, instance);
        }

        public void RegisterType(Type targetType,Type bindType,params object[] parameter)
        {
            TargetTypeCheck(targetType);
            IoCBindData bindData = null;
            if (targetType == bindType)
            {
                bindData = GetIoCBindDataBySelfBindType(targetType);
                if (null == bindData)
                {
                    m_IoCBindDataLinkedList.AddLast(bindData = new IoCBindData());
                }
                bindData.Bind(targetType, parameter);
            }
            else
            {
                bindData = GetIoCBindDataByTargetType(targetType);
                if (null == bindData)
                {
                    m_IoCBindDataLinkedList.AddLast(bindData = new IoCBindData());
                }
                bindData.Bind(targetType, bindType, parameter);
            }

        }

        public void SetSingleInstance(Type targetTypeOrSelfType)
        {
            TargetTypeCheck(targetTypeOrSelfType);
            var bindData = GetIoCBindDataByTargetType(targetTypeOrSelfType);
            if (null == bindData)
            {
                bindData = GetIoCBindDataBySelfBindType(targetTypeOrSelfType);
                if (null == bindData)
                {
                    throw new NullReferenceException(string.Format("Reference:bindData is nullable."));
                }
            }

            bindData.IsSingleInstance = true;
        }

        public void SetSingleInstance(object instance)
        {
            if(null==instance) throw new NullReferenceException(string.Format("Reference:instance is nullable."));
            var bindData = GetIoCBindDataByInstance(instance);
            if (null == bindData) throw new NullReferenceException(string.Format("Reference:bindData is nullable."));
            else
            {
                bindData.IsSingleInstance = true;
            }
        }

        private void TargetTypeCheck(Type targetType)
        {
            if (null == targetType) throw new ArgumentNullException(string.Format("Argument:targetType can not be nullable."));
        }

        #endregion

        #region ISparrowIoC

        private Binder m_Binder = null;
        public IBinder RegisterInstance(object instance)
        {
            m_Binder.IsRegisterType = false;
            m_Binder.CurrentInstance = instance;

            return m_Binder;
        }

        public IBinder RegisterType(Type type, params object[] parameter)
        {
            m_Binder.IsRegisterType = true;
            m_Binder.CurrentType = type;
            m_Binder.CurrentParameter = parameter;
            return m_Binder;
        }

        #endregion

    }


}