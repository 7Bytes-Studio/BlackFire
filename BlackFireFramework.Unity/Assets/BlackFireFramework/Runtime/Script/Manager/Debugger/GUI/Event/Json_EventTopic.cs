//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;

namespace BlackFireFramework.Unity
{
    [System.Serializable]
	public sealed class Json_EventTopic 
	{
        public string topic;

        public string sender;

        public List<Json_Var> args; 
	}
}
