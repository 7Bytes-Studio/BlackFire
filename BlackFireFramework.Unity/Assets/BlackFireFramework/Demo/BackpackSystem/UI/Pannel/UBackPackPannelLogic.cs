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
	public class UBackPackPannelLogic:UguiPanelLogicBase
	{
        [SerializeField] UBackpackStuffLogic m_BackpackStuffLogic = null;

        private List<BackpackStuff> m_BackpackStuffList = new List<BackpackStuff>();

        public virtual void PutIn(BackpackStuff backpackStuff)
        {
            var clone = GameObject.Instantiate<UBackpackStuffLogic>(m_BackpackStuffLogic, m_BackpackStuffLogic.transform.parent);
            clone.gameObject.SetActive(true);
            clone.Data = backpackStuff;
            clone.SetInfoText();
        }

        public virtual void PutIn(BackpackStuff[] backpackStuffs)
        {
            for (int i = 0; i < backpackStuffs.Length; i++)
            {
                PutIn(backpackStuffs[i]);
            }
        }

    }
}
