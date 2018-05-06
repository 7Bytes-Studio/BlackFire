//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@gmail.com
//Website: http://www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;

namespace BlackFireFramework
{
    internal sealed class IoCBindData
    {
        public Type TargetType { get; private set; }
        public object Instance { get; private set; }
        public object SingleInstance { get; private set; }
        public bool IsSingleInstance { get; set; }
        public Type SelfBindType { get; private set; }
        public Type BindType { get; private set; }

        public object[] BindTypeParameter;

        private List<object> m_InstanceList = new List<object>();

        public object Build(Type targetType)
        {
            if (null != SelfBindType && targetType==SelfBindType)
            {
                return SelfBindTypeBuild();
            }
            else
            {
                return NormalBuild();
            }
        }

        private object SelfBindTypeBuild()
        {
            if (IsSingleInstance)
            {
                return SingleInstance ?? (SingleInstance = Activator.CreateInstance(SelfBindType, BindTypeParameter));
            }
            else
            {
                var instance = Activator.CreateInstance(SelfBindType, BindTypeParameter);
                if (null != instance)
                {
                    m_InstanceList.Add(instance);
                    return instance;
                }
            }
            return null;
        }

        private object NormalBuild()
        {
            if (null != Instance)
            {
                if (IsSingleInstance)
                {
                    return SingleInstance ?? (SingleInstance = Instance);
                }
                else
                {
                    var clone = (Instance as ICloneable).Clone();
                    if (null!=clone)
                    {
                        m_InstanceList.Add(clone);
                        return clone;
                    }
                }

            }
            else
            {
                if (IsSingleInstance)
                {
                    return SingleInstance ?? (SingleInstance = Activator.CreateInstance(BindType, BindTypeParameter));
                }
                else
                {
                    var instance = Activator.CreateInstance(BindType, BindTypeParameter);
                    if (null != instance)
                    {
                        m_InstanceList.Add(instance);
                        return instance;
                    }
                }
            }
            return null;
        }

        public void Bind(Type targetType,object[] typeParameter)
        {
            TargetType = targetType;
            SelfBindType = targetType;
            BindTypeParameter = typeParameter;
        }

        public void Bind(Type targetType,Type bindType,object[] typeParameter)
        {
            TargetType = targetType;
            BindType = bindType;
            BindTypeParameter = typeParameter;
        }

        public void Bind(Type targetType,object instance)
        {
            TargetType = targetType;
            Instance = instance;
        }

        public void OnRelease()
        {
            IDisposable disposableInstance = null;
            if (null!=Instance)
            {
                disposableInstance = Instance as IDisposable;
                if (null != disposableInstance)
                {
                    disposableInstance.Dispose();
                }
                Instance = null;
            }

            if (null != SingleInstance)
            {
                disposableInstance = SingleInstance as IDisposable;
                if (null != disposableInstance)
                {
                    disposableInstance.Dispose();
                }
                SingleInstance = null;
            }

            if (0<m_InstanceList.Count)
            {
                for (int i = 0; i < m_InstanceList.Count; i++)
                {
                    disposableInstance = m_InstanceList[i] as IDisposable;
                    if (null != disposableInstance)
                    {
                        disposableInstance.Dispose();
                    }
                }
            }
            m_InstanceList.Clear();
        }
    }
}