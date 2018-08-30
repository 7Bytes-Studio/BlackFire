//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework.Unity
{
	public interface ILoginWindowLogic
	{
		event EventHandler<OnLoginEventArgs> OnLogin;

		void SetLoginState(string state);
		
	}


	public sealed class OnLoginEventArgs:EventArgs
	{
		public string Account;

		public string Password;
	}

}