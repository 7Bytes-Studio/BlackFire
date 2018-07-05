//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using UnityEngine.SceneManagement;

namespace BlackFireFramework.Unity
{
    public sealed partial class ResourceManager
	{

        public delegate void LoadResourceFailure(LoadResourceFailureEventArgs loadResourceFailureEventArgs);
        public delegate void LoadResourceProgress(LoadResourceProgressEventArgs loadResourceProgressEventArgs);
        public delegate void LoadResourceComplete(LoadResourceCompleteEventArgs loadResourceCompleteEventArgs);


        public delegate void LoadSceneFailure(LoadSceneFailureEventArgs loadSceneFailureEventArgs);
        public delegate void LoadSceneProgress(LoadSceneProgressEventArgs loadSceneProgressEventArgs);
        public delegate void LoadSceneComplete(LoadSceneCompleteEventArgs loadSceneCompleteEventArgs);


        public delegate void UnloadSceneFailure(UnloadSceneFailureEventArgs UnloadSceneFailureEventArgs);
        public delegate void UnloadSceneProgress(UnloadSceneProgressEventArgs UnloadSceneProgressEventArgs);
        public delegate void UnloadSceneComplete(UnloadSceneCompleteEventArgs UnloadSceneCompleteEventArgs);


        public delegate void MoveToSceneFailure(MoveToSceneFailureEventArgs moveToSceneFailureEventArgs);
        public delegate void MoveToSceneProgress(MoveToSceneProgressEventArgs moveToSceneProgressEventArgs);
        public delegate void MoveToSceneComplete(MoveToSceneCompleteEventArgs moveToSceneCompleteEventArgs);



        public class ResourceEventArgs : EventArgs
        {
            public ResourceEventArgs(string resourceName)
            {
                ResourceName = resourceName;
            }

            /// <summary>
            /// 资源名称。
            /// </summary>
            public string ResourceName { get; private set; }
        }




        public class LoadResourceFailureEventArgs : ResourceEventArgs
        {
            public LoadResourceFailureEventArgs(string resourceName) : base(resourceName)
            {
            }
        }

        public class LoadResourceProgressEventArgs : ResourceEventArgs
        {
            public LoadResourceProgressEventArgs(string resourceName, float process) : base(resourceName)
            {
                Process = process;
            }

            /// <summary>
            ///  进度。
            /// </summary>
            public float Process { get; private set; }
        }

        public class LoadResourceCompleteEventArgs : ResourceEventArgs
        {
            public LoadResourceCompleteEventArgs(string resourceName, AssetAgency assetAgency) : base(resourceName)
            {
                AssetAgency = assetAgency;
            }

            public AssetAgency AssetAgency { get;private set; }
        }





        public class SceneEventArgs : EventArgs
        {
            public SceneEventArgs(string sceneName)
            {
                SceneName = sceneName;
            }

            /// <summary>
            /// 场景名。
            /// </summary>
            public string SceneName { get; private set; }
        }



        public class LoadSceneCompleteEventArgs : SceneEventArgs
        {
            public LoadSceneCompleteEventArgs(string sceneName,Scene scene):base(sceneName)
            {
                Scene = scene;
            }


            /// <summary>
            /// 场景。
            /// </summary>
            public Scene Scene { get; private set; }

        }

        public class LoadSceneFailureEventArgs : SceneEventArgs
        {
            public LoadSceneFailureEventArgs(string sceneName) : base(sceneName)
            {
            }
        }

        public class LoadSceneProgressEventArgs : SceneEventArgs
        {
            public LoadSceneProgressEventArgs(string sceneName,Scene scene,float process) : base(sceneName)
            {
                Scene = scene;
                Process = process;
            }

            /// <summary>
            /// 场景。
            /// </summary>
            public Scene Scene { get; private set; }

            /// <summary>
            ///  进度。
            /// </summary>
            public float Process { get; private set; }
        }



        public class UnloadSceneCompleteEventArgs : SceneEventArgs
        {
            public UnloadSceneCompleteEventArgs(string sceneName, Scene scene) : base(sceneName)
            {
                Scene = scene;
            }


            /// <summary>
            /// 场景。
            /// </summary>
            public Scene Scene { get; private set; }

        }

        public class UnloadSceneFailureEventArgs : SceneEventArgs
        {
            public UnloadSceneFailureEventArgs(string sceneName) : base(sceneName)
            {
            }
        }

        public class UnloadSceneProgressEventArgs : SceneEventArgs
        {
            public UnloadSceneProgressEventArgs(string sceneName, Scene scene, float process) : base(sceneName)
            {
                Scene = scene;
                Process = process;
            }

            /// <summary>
            /// 场景。
            /// </summary>
            public Scene Scene { get; private set; }

            /// <summary>
            ///  进度。
            /// </summary>
            public float Process { get; private set; }
        }



        public class MoveToSceneCompleteEventArgs : SceneEventArgs
        {
            public MoveToSceneCompleteEventArgs(string sceneName, Scene scene) : base(sceneName)
            {
                Scene = scene;
            }


            /// <summary>
            /// 场景。
            /// </summary>
            public Scene Scene { get; private set; }

        }

        public class MoveToSceneFailureEventArgs : SceneEventArgs
        {
            public MoveToSceneFailureEventArgs(string sceneName) : base(sceneName)
            {
            }
        }

        public class MoveToSceneProgressEventArgs : SceneEventArgs
        {
            public MoveToSceneProgressEventArgs(string sceneName, Scene scene, float process) : base(sceneName)
            {
                Scene = scene;
                Process = process;
            }

            /// <summary>
            /// 场景。
            /// </summary>
            public Scene Scene { get; private set; }

            /// <summary>
            ///  进度。
            /// </summary>
            public float Process { get; private set; }
        }


    }
}
