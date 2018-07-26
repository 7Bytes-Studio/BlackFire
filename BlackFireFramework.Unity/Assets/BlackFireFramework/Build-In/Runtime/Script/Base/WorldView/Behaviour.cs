//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 游戏世界观中物的基本表现抽象类。
    /// </summary>
    public abstract class Behaviour<T> : MonoBehaviour where T: ILogic
    {
        /// <summary>
        /// 逻辑接口。
        /// </summary>
        public abstract T Logic { get;  }

    }
}
