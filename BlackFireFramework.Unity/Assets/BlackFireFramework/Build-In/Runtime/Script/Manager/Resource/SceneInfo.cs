//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using UnityEngine.SceneManagement;

namespace BlackFireFramework.Unity
{
    public class SceneInfo
    {
        public SceneInfo(string sceneName, LoadSceneMode loadSceneModle = LoadSceneMode.Additive, bool allowSceneActivation = false)
        {
            SceneName = sceneName;
            LoadSceneModle = loadSceneModle;
            AllowSceneActivation = allowSceneActivation;
        }

        public string SceneName { get; private set; }
        public LoadSceneMode LoadSceneModle { get; private set; }
        public bool AllowSceneActivation { get; private set; }
    }
}
