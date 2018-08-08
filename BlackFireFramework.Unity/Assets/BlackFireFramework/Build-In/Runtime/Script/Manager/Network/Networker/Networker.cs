//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 网络使用者。
    /// </summary>
    public abstract class Networker : MonoBehaviour
    {
        [SerializeField] private bool m_SyncPosition;
        public bool SyncPosition
        {
            get { return m_SyncPosition; }
            set { m_SyncPosition = value; }
        }
        [SerializeField] private bool m_SyncRotation;
        public bool SyncRotation
        {
            get { return m_SyncRotation; }
            set { m_SyncRotation = value; }
        }
        [SerializeField] private bool m_SyncScale;
        public bool SyncScale
        {
            get { return m_SyncScale; }
            set { m_SyncScale = value; }
        }

        /// <summary>
        /// 获取状态信息。
        /// </summary>
        public abstract object this[string fieldName] { get; }


        private JObject m_JObject = new JObject();
        
        private string m_Data = string.Empty;
        protected virtual void Awake()
        {
            
        }


        protected virtual void Update()
        {
            SyncState();
        }

        //1.状态同步。
        protected virtual void SyncState()
        {
            if (m_SyncPosition)
            {
                m_JObject["PX"] = transform.position.x;
                m_JObject["PY"] = transform.position.y;
                m_JObject["PZ"] = transform.position.z;
            }
            
            if (m_SyncRotation)
            {
                m_JObject["RX"] = transform.eulerAngles.x;
                m_JObject["RY"] = transform.eulerAngles.y;
                m_JObject["RZ"] = transform.eulerAngles.z;
            }
            
            if (m_SyncScale)
            {
                m_JObject["SX"] = transform.localScale.x;
                m_JObject["SY"] = transform.localScale.y;
                m_JObject["SZ"] = transform.localScale.z;
            }
            
            Debug.Log(m_JObject.ToString());
        }

        //2.沟通。
        public abstract void Send(byte[] data);

        
    }
}