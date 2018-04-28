//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEditor;

namespace BlackFireFramework.Editor
{
    public abstract class EditorWindowBase<T>: EditorWindow where T: EditorWindow
    {

        public virtual bool Utility { get { return false; } }
        public virtual string Title { get { return GetType().Name;} }


        protected virtual void OnShowWindow()
        {
            EditorWindow.GetWindow(typeof(T), Utility, Title);
        }




    }
}
