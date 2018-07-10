//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BlackFireFramework.Unity;


namespace Alan 
{
	public sealed class TestCanvas : UguiCanvasLogicBase 
	{

        private float m_Time;
        protected override void Update()
        {
            base.Update();
            if ((m_Time+=Time.deltaTime)>=3f)
            {
                BlackFireFramework.Event.Fire("Topic://TestCanvas",this,null);
                m_Time = -1000000000;
            }
        }


    }
}
