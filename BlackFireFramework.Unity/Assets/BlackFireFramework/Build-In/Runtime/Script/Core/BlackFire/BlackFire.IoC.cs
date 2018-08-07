//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using System;
using BlackFireFramework;
using System.Collections.Generic;
using UnityEngine;

public sealed partial class BlackFire
{
    [SerializeField] private string[] m_IoCRegisters;
    [SerializeField] private string[] m_AvailableIoCRegisters;
    
    private static ISparrowIoC s_IoC;
    public static ISparrowIoC IoC
    {
        get { return s_IoC??(s_IoC=Framework.CreateIoC()); }
    }

    private static void StartIoC()
    {
        var list = s_Instance.m_AvailableIoCRegisters;
        for (int i = 0; i < list.Length; i++)
        {
            var ins = Utility.Reflection.New(Type.GetType(list[i])) as IIoCRegister;
            ins.OnRegister(IoC);
        }
    }
}

