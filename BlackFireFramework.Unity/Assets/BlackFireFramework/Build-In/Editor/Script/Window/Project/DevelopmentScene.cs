//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

// ScriptMainLogicWriter : https://github.com/Yawpp

using System.Collections.Generic;
using UnityEngine;

namespace BlackFireFramework.Editor
{

	public sealed class DevelopmentScene : ScriptableObject
	{				
		[SerializeField] private List<Object> m_Scenes;

		public List<Object> Scenes
		{
			get { return m_Scenes; }
		}
	}
	
}