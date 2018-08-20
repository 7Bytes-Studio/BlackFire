//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Text;
using BlackFireFramework.Network;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class FilterDemo:MonoBehaviour
    {
        private void Start()
        {
            var filter = new StringReceiveFilter(Encoding.UTF8);
            var cmd = Encoding.UTF8.GetBytes(" RPC FuncName 1 2 233 ");
            var packageInfo = filter.Filter(cmd, 0, cmd.Length);

            new Login().ExecuteCommand(null,packageInfo);
        }
    }


    public sealed class Login : StringCommand
    {
        public override void ExecuteCommand(TransportBase transport, StringPackageInfo packageInfo)
        {
            Debug.Log(packageInfo.Key);
            Debug.Log(packageInfo.Body);
            Debug.Log(packageInfo.Parameters[0]);
        }
    }
}