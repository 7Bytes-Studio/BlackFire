//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace BlackFireFramework.Unity
{
    public interface IUIEventDataHelper
	{
        PointerEventData PointerEventData { get; }
        List<RaycastResult> RaycastResultList { get; }
    }
}
