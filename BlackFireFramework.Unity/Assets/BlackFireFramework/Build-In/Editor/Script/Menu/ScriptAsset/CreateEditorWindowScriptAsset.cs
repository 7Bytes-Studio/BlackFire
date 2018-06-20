//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEditor;

namespace BlackFireFramework.Editor
{
    class CreateEditorWindowScriptAsset : EndNameEditActionBase
    {
        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            UnityEngine.Object obj = CreateScriptAssetFromTemplate(pathName, resourceFile);
            ProjectWindowUtil.ShowCreatedAsset(obj);
        }


    }
}
