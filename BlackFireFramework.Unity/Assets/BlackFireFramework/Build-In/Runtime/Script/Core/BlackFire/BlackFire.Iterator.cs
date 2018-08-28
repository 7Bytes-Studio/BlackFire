//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using System;
using System.Collections;
using BlackFireFramework;
using System.Collections.Generic;
using UnityEngine;

public sealed partial class BlackFire
{

    private static MonoBehaviour m_Mono;
    private static void SetIterator(MonoBehaviour mono)
    {
        m_Mono = mono;
        BlackFireFramework.Iterator.IteratorStartCallback = BlackFire_IteratorStartCallback;
        BlackFireFramework.Iterator.IteratorCancelCallback = BlackFire_IteratorCancelCallback;
    }


    private static void BlackFire_IteratorStartCallback(string name,IEnumerator enumerator)
    {
        m_Mono.StartCoroutine(enumerator);
    }
    

    private static void BlackFire_IteratorCancelCallback(string name,IEnumerator enumerator)
    {
        m_Mono.StopCoroutine(enumerator);
    }
    
}

