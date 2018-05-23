//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace BlackFireFramework.Editor
{
    [CustomEditor(typeof(GameManager))]
    public sealed class GameInspector : InspectorBase
    {
        public override InspectorSetting Setting
        {
            get
            {
               return new InspectorSetting();
            }
        }

        private SerializedProperty m_GameSpeedSP = null; 

        private void OnEnable()
        {
            m_GameSpeedSP = serializedObject.FindProperty("m_GameSpeed");
        }



        protected override void OnDrawInspector()
        {
            var gameManager = target as GameManager;
            EditorGUILayout.PropertyField(m_GameSpeedSP);

        }
    }
}
