//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework.Unity
{
	public class GatewayWorkerClient 
	{
        #region API


        public void Login(string uid,string password) { }

        public void CreateGroup(string groupName) { }

        public void JoinGroup(string groupName) { }

        public void GetGroupList() { }

        public void GetGroupCount() { }

        public void LeaveGroup(string groupName) { }

        public void SendTo(string uid,string message) { }

        public void SendToOtherGroupMembers(string groupName, string message) { }


        #endregion

        #region Events




        #endregion


    }
}
