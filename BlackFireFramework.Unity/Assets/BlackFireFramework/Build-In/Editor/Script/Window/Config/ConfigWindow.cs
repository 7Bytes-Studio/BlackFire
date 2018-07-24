//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace BlackFireFramework.Editor
{
    public sealed class ConfigWindow : EditorWindowBase<ConfigWindow>
    {
        private string m_PackageServerUrl = "http://0x69h.com/packages/API.json"; //默认测试路径。

        private BlackFireFrameworkConfig m_Configuration = null;

        private void OnEnable()
        {
            m_Configuration = Resources.Load<BlackFireFrameworkConfig>("BlackFireFrameworkConfig");
#if BLACKFIRE_EDITOR
            Debug.Log(m_PackageServerUrl);
#endif
            if (null!= m_Configuration)
            {
                m_PackageServerUrl = m_Configuration.PackageServerAPIUrl;
            }
#if BLACKFIRE_EDITOR
            Debug.Log(null != m_Configuration);
            Debug.Log(m_PackageServerUrl);
#endif
        }


        protected override void OnDrawWindow()
        {
            BlackFireEditorGUI.BoxHorizontalLayout(()=> {

                BlackFireEditorGUI.Label("PackageServerUrl",Color.green,120,13);
                m_PackageServerUrl = GUILayout.TextField(m_PackageServerUrl);

            });

            BlackFireEditorGUI.Space(12);

            BlackFireEditorGUI.HorizontalLayout(() => {

                BlackFireEditorGUI.Button("Save",()=> {

                    if (null != m_Configuration)
                    {
                        m_Configuration.PackageServerAPIUrl = m_PackageServerUrl;
                    }
                    else
                    {
                        m_Configuration = BlackFireFrameworkConfig.CreateInstance<BlackFireFrameworkConfig>();
                        BlackFireFramework.Utility.IO.ExistsOrCreateFolder(BlackFireEditor.FrameworkCustomRelativePath + "/Resources");
                        m_Configuration.PackageServerAPIUrl = m_PackageServerUrl;
                        AssetDatabase.CreateAsset(m_Configuration, BlackFireEditor.FrameworkCustomRelativePath + "/Resources/BlackFireFrameworkConfig.asset");
                    }

                });

            });




        }
     }
}
