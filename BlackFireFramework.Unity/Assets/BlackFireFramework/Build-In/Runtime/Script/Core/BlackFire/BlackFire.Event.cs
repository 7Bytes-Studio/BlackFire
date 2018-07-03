//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using BlackFireFramework;
using System.Collections.Generic;
using UnityEngine;

public sealed partial class BlackFire
{
    private static BlackFireFramework.Event.IEventHandler[] GetEventHandlersCallback(object root)
    {
        if (null != root)
        {
            List<BlackFireFramework.Event.IEventHandler> list = new List<BlackFireFramework.Event.IEventHandler>();
            Transform current = null;

            if (root is GameObject) current = (root as GameObject).transform;
            else if (root is Component) current = (root as Component).transform;
            else return root is BlackFireFramework.Event.IEventHandler ? new BlackFireFramework.Event.IEventHandler[] { root as BlackFireFramework.Event.IEventHandler } : null;
             
            while (null != current)
            {
                var cmp = current.GetComponent<BlackFireFramework.Event.IEventHandler>();
                if (null != cmp)
                    list.Add(cmp);
                current = current.parent;
            }
            return list.ToArray();
        }
        return null;
    }
}