//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework;
using System.Collections.Generic;


public sealed partial class BlackFire
{
    private static LinkedList<IManager> s_ManagerLinkedList = new LinkedList<IManager>();

    public static void RegisterManager(IManager manager)
    {
        if (!s_ManagerLinkedList.Contains(manager))
        {
            s_ManagerLinkedList.AddLast(manager);
        }
        else
        {
            throw new System.Exception("请勿重复注册管家，每一个管家有且只有一个实例！");
        }
    }

    public static void UnRegisterManager(IManager manager)
    {
        if (s_ManagerLinkedList.Contains(manager))
        {
            s_ManagerLinkedList.Remove(manager);
        }
    }

    private static void InitManager(BlackFire instance)
    {
        if (null != instance)
        {
            BlackFireFramework.Unity.Utility.Transform.TraverseChilds(instance.transform, trans =>
            {
                var manager = trans.GetComponent<IManager>();
                if (null!=manager)
                {
                    manager.InitManager();
                }
            });
        }
    }

    public static T GetManager<T>() where T:IManager
    {
        var current = s_ManagerLinkedList.First;
        while (null!=current)
        {
            if (current.Value is T)
            {
                return (T)current.Value;
            }
            current = current.Next;
        }
        return default(T);
    }



}
