//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

namespace BlackFireFramework.Unity
{

    using UnityEngine;
    using UnityEngine.SceneManagement;

    public sealed partial class ResourceManager
    {
        private Action m_UpdateResource_Scene;

        private void Init_Scene()
        {

        }

        private void Update_Scene()
        {
            if (null!= m_UpdateResource_Scene)
            {
                m_UpdateResource_Scene.Invoke();
            }
        }

        private void Destroy_Scene()
        {

        }





        /// <summary>
        /// 当前场景数量。
        /// </summary>
        public int SceneCount
        {
            get
            {
                return SceneManager.sceneCount;
            }
        }

        /// <summary>
        /// 活动场景。
        /// </summary>
        public string ActiveScene
        {
            get
            {
                return SceneManager.GetActiveScene().name;
            }
            set
            {

                var scene = SceneManager.GetSceneByName(value);
                if (null!= scene)
                {
                    SceneManager.SetActiveScene(scene);
                }
            }
        }

        /// <summary>
        /// 加载场景。
        /// </summary>
        /// <param name="sceneName">场景名字。</param>
        public void LoadSceneAsync(SceneInfo sceneInfo,LoadSceneComplete loadSceneComplete=null,LoadSceneProgress loadSceneProgress=null,LoadSceneFailure loadSceneFailure=null)
        {
            Scene targetScene = SceneManager.GetSceneByName(sceneInfo.SceneName);

            if (!targetScene.isLoaded)
            {
                var asyncOperation = SceneManager.LoadSceneAsync(sceneInfo.SceneName,sceneInfo.LoadSceneModle);
                Action action = () => { if (null != loadSceneProgress) loadSceneProgress.Invoke(new LoadSceneProgressEventArgs(sceneInfo.SceneName, targetScene, asyncOperation.progress)); };
                m_UpdateResource_Scene += action;
                asyncOperation.completed += ao => {
                    m_UpdateResource_Scene -= action;
                    //加载成功。
                    if (null!= loadSceneComplete)
                    {
                        loadSceneComplete.Invoke(new LoadSceneCompleteEventArgs(sceneInfo.SceneName,targetScene));
                    }
                };
            }
            else
            {
                //没有这个场景。加载失败。
                if (null != loadSceneFailure)
                {
                    loadSceneFailure.Invoke(new LoadSceneFailureEventArgs(sceneInfo.SceneName));
                }
            }
        }

        /// <summary>
        /// 卸载场景。
        /// </summary>
        public void UnloadSceneAsync(string sceneName,UnloadSceneComplete UnloadSceneComplete = null, UnloadSceneProgress UnloadSceneProgress = null, UnloadSceneFailure UnloadSceneFailure = null)
        {
            Scene targetScene = SceneManager.GetSceneByName(sceneName);
            
            if (!targetScene.isLoaded || targetScene == SceneManager.GetActiveScene())
            {
                // 场景没有被加载 或者 目标卸载场景是活动场景。
                if (null != UnloadSceneFailure)
                    UnloadSceneFailure(new UnloadSceneFailureEventArgs(sceneName));
            }
            else
            {
                AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(targetScene);
                Action action = () => { if (null != UnloadSceneProgress) UnloadSceneProgress.Invoke(new UnloadSceneProgressEventArgs(sceneName,targetScene,asyncOperation.progress)); };
                m_UpdateResource_Scene += action;
                asyncOperation.completed += ao => {
                    m_UpdateResource_Scene -= action;
                    if (null != UnloadSceneComplete)
                        UnloadSceneComplete(new UnloadSceneCompleteEventArgs(sceneName, targetScene));
                };
            }
        }


        /// <summary>
        /// 移动场景。
        /// </summary>
        public void MoveToScene(List<GameObject> gameObjectList,string sceneName,MoveToSceneComplete moveToSceneComplete = null, MoveToSceneProgress moveToSceneProgress = null, MoveToSceneFailure moveToSceneFailure = null)
        {

            Scene targetScene = SceneManager.GetSceneByName(sceneName);
            if (targetScene.IsValid())
            {
                int gameObjectCount = gameObjectList.Count;
                for (int i = 0; i < gameObjectCount; i++)
                {
                    SceneManager.MoveGameObjectToScene(gameObjectList[i], targetScene);
                    if (null != moveToSceneProgress)
                        moveToSceneProgress.Invoke(new MoveToSceneProgressEventArgs(sceneName, targetScene, 0 == i ? 0 : (float)i / gameObjectCount));
                }
                SceneManager.SetActiveScene(targetScene);
                if (null != moveToSceneComplete)
                    moveToSceneComplete.Invoke( new MoveToSceneCompleteEventArgs(sceneName,targetScene) );
            }
            else
            {
                //不是一个有效的场景
                if (null != moveToSceneFailure)
                    moveToSceneFailure.Invoke(new MoveToSceneFailureEventArgs(sceneName));
            }
        }


        /// <summary>
        /// 将原始场景合并到目标场景。
        /// </summary>
        /// <param name="fromSceneName">原始场景。</param>
        /// <param name="toSceneName">目标场景。</param>
        public void MergeScene(string fromSceneName, string toSceneName)
        {
            Scene fromScene = SceneManager.GetSceneByName(fromSceneName);
            Scene toScene = SceneManager.GetSceneByName(toSceneName);
            SceneManager.MergeScenes(fromScene, toScene);
        }




    }
}
