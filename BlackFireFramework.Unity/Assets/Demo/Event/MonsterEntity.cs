//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Alan 
{
    public sealed class MonsterEntity : MonoBehaviour, IBeShotHandler
    {
        private int m_Hp = 1000;

        public void BeShot(int hurt)
        {
            m_Hp = Mathf.Clamp(m_Hp-=hurt,0,m_Hp); 
            Debug.Log(name+"::Monster::Hp "+ m_Hp);
        }
    }
}
