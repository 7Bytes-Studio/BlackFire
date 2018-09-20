//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework.Unity
{
    public abstract class Plane : LogicalForm , ILogic
    {
        public override ILogic Logic
        {
            get { return this; }
        }
    }
}