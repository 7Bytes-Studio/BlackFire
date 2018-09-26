/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.Collections.Generic;

namespace BlackFire
{
    /// <summary>
    /// 组织。
    /// </summary>
    public static partial class Organize
    {

        public delegate void CommandCallback<T>(T i) where T:Event.IEventHandler;


        internal static class Command
        {
            private static readonly Dictionary<Type, int> s_CommandPermissonDic = new Dictionary<Type, int>();

            public static void SetCommandPermission<T>(int permission) where T : Event.IEventHandler
            {
                if (!s_CommandPermissonDic.ContainsKey(typeof(T)))
                {
                    s_CommandPermissonDic.Add(typeof(T), permission);
                    return;
                }
                s_CommandPermissonDic[typeof(T)] = permission;
            }

            public static int GetCommandPermission<T>() where T : Event.IEventHandler
            {
                if (s_CommandPermissonDic.ContainsKey(typeof(T)))
                {
                    return s_CommandPermissonDic[typeof(T)];
                }
                return int.MaxValue;
            }

        }
        
    }
}
