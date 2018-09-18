//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class AlanNetworker : Networker
    {
        public override object this[string fieldName]
        {
            get { throw new System.NotImplementedException(); }
        }

        public override void Send(byte[] data)
        {
            throw new System.NotImplementedException();
        }
    }
}