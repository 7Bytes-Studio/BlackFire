//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Diagnostics;
using System.Net.NetworkInformation;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed partial class NetworkManager
    {
        private string m_GUID=null;
        public string GUID
        {
            get { return m_GUID??(m_GUID=SystemInfo.deviceUniqueIdentifier+Process.GetCurrentProcess().Id);}
        }
    }
}
