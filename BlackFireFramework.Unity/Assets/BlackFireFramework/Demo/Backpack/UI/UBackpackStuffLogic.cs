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
	public sealed class UBackpackStuffLogic : UguiBehaviourBase
	{
        [SerializeField] private Text m_TextInfo;
        public BackpackStuff Data;

        public void SetInfoText()
        {
            m_TextInfo.text = Data.ToString();
        }

	}
}
