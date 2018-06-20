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

        private void OnGUI()
        {
            OnDrawWindow();
        }

        protected abstract void OnDrawWindow();

    }
}
