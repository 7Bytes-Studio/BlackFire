//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------



using UnityEditor;

namespace BlackFireFramework.Editor
{
    /// <summary>
    /// Inspector基类。
    /// </summary>
    public abstract class InspectorBase : UnityEditor.Editor
    {
        /// <summary>
        /// 是否在编译。
        /// </summary>
        private bool m_IsCompiling = false;

        #region Events

        /// <summary>
        /// 渲染Inspector面板事件。
        /// </summary>
        protected abstract void OnDrawInspector();
        /// <summary>
        /// 渲染Inspector面板前的事件。
        /// </summary>
        protected virtual void OnBeginDrawInspector() {  }
        /// <summary>
        /// 渲染Inspector面板后的事件。
        /// </summary>
        protected virtual void OnEndDrawInspector() { serializedObject.ApplyModifiedProperties(); }
        /// <summary>
        /// 编译开始事件。
        /// </summary>
        protected virtual void OnCompileStart()
        {

        }
        /// <summary>
        /// 编译完成事件。
        /// </summary>
        protected virtual void OnCompileDone()
        {

        }

        #endregion

        /// <summary>
        /// Inspector设置。
        /// </summary>
        public abstract InspectorSetting Setting { get; }

        /// <summary>
        /// 检查设置或者绘制提示框。
        /// </summary>
        /// https://github.com/GarfieldJiang
        /// <returns>检查结果。</returns>
        private bool CheckSettingOrDrawHelpBox()
        {
            if (!Setting.NotPlayingDrawing && !EditorApplication.isPlaying)
            {
                EditorGUILayout.HelpBox("Only drawing when playing.", MessageType.Info);
            }
            else if (!Setting.PlayingDrawing && EditorApplication.isPlayingOrWillChangePlaymode)
            {
                EditorGUILayout.HelpBox("Can not drawing when playing.", MessageType.Info);
            }
            else if (!Setting.CompilingDrawing && EditorApplication.isCompiling)
            {
                EditorGUILayout.HelpBox("Can not drawing when compiling.", MessageType.Info);
            }
            else if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
            {
                EditorGUILayout.HelpBox("Changing play mode...", MessageType.Info);
            }
            else
            {
                return true;
            }
            return false;
        }



        /// <summary>
        /// 绘制事件。
        /// </summary>
        public override void OnInspectorGUI()
        {
            CheckCompileStateAndFire();

            if (Setting.DrawDefaultGUI)
            {
                base.OnInspectorGUI();
            }

            if (!CheckSettingOrDrawHelpBox())
            {
                return;
            }
            OnBeginDrawInspector();
            OnDrawInspector();
            OnEndDrawInspector();
        }

        /// <summary>
        /// 检查编译状态并触发事件。
        /// </summary>
        private void CheckCompileStateAndFire()
        {
            if (m_IsCompiling && !EditorApplication.isCompiling)
            {
                m_IsCompiling = false;
                OnCompileDone();
            }
            else if (!m_IsCompiling && EditorApplication.isCompiling)
            {
                m_IsCompiling = true;
                OnCompileStart();
            }
        }


    }
}
