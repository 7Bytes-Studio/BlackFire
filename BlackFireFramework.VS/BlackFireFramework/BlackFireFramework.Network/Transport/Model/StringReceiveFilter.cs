//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BlackFireFramework.Network
{
    public class StringReceiveFilter:ReceiveFilterBase<StringPackageInfo>
    {
        public StringReceiveFilter(Encoding encoding=null)
        {
            m_Encoding = encoding??Encoding.UTF8;
        }

        private Encoding m_Encoding = null;
        public override StringPackageInfo Filter(byte[] readBuffer, int offset, int length)
        {
            string commandStr = m_Encoding.GetString(readBuffer,offset,length);
            commandStr = commandStr.Trim();
            var s = commandStr.Split(' ');

            var key = s[0];
            var body = commandStr.Substring(key.Length,commandStr.Length-key.Length);
            var parameters = new string[s.Length-1];
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = s[i+1];
            }
            return new StringPackageInfo(){ Key = key,Body = body,Parameters = parameters };
        }
    }
}