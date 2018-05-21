//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


namespace BlackFireFramework
{
    [System.Serializable]
	public sealed class Json_Instruction
    {
        public string instruction; //FireEvent,RemoveEventTopic and so on...

        public string platform; //platform...

        public Json_EventTopic eventTopic;
    }
}
