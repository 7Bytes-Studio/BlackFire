//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework.Unity
{
    public sealed class DefaultReferenceCounter : IReferenceCounter
    {
        public int RefCount { get; private set; }

        public int CumulativeCount { get; private set; }

        public int RegressiveCount { get; private set; }

        public event Action OnRefCountIsZero;

        public void Cumulative(object ref_owner)
        {
            ++CumulativeCount;
            ++RefCount;
        }

        public void Regressive(object ref_owner)
        {
            if (RefCount <= 0) return;
            --RefCount;
            ++RegressiveCount;
            if (0==RefCount && null!= OnRefCountIsZero)
            {
                OnRefCountIsZero.Invoke();
            }
        }
    }
}
