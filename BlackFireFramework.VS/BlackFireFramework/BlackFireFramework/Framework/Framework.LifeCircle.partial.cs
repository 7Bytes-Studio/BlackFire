//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework
{
    /// <summary>
    /// 框架生命周期。
    /// </summary>
    public static partial class Framework
    {
        #region 框架主体


        /// <summary>
        /// 框架活动主体。
        /// </summary>
        private static object s_Who = null;


        /// <summary>
        /// 检查框架活动主体或者抛出异常。
        /// </summary>
        /// <param name="who">框架活动主体。</param>
        private static void CheckWhoOrThrow(object who)
        {
            if (s_Who != null && !s_Who.Equals(who))
            {
                throw new NullReferenceException("框架活动主体有且只能有一个。");
            }
        }





        /// <summary>
        /// Framework静态类被使用。
        /// </summary>
        static Framework()
        {
            Init_Info();
            Init_State();
        }

        /// <summary>
        /// 诞生框架。
        /// </summary>
        /// <param name="who">让框架诞生者(也指使用框架这件事情的活动主体是谁)。</param>
        /// <param name="realElapsedDeltaTime">真实世界流逝的时间。</param>
        /// <param name="virsulElapsedDeltaTime">虚拟世界流逝的时间。</param>
        public static void Born(object who, float realElapsedDeltaTime, float virsulElapsedDeltaTime)
        {
            State.Working = true;
            CheckWhoOrThrow(who);
            s_Who = who;
            Time.SetOriginTime(realElapsedDeltaTime, virsulElapsedDeltaTime); //设置时间轴的起点时间。
            LifeCircle.OnLifeCircleOrigin();
        }

        /// <summary>
        /// 活动框架。
        /// </summary>
        /// <param name="who">让框架诞生者(也指使用框架这件事情的活动主体是谁)。</param>
        /// <param name="realElapsedDeltaTime">真实世界流逝的时间。</param>
        /// <param name="virsulElapsedDeltaTime">虚拟世界流逝的时间。</param>
        public static void Act(object who, float realElapsedDeltaTime, float virsulElapsedDeltaTime)
        {
            CheckWhoOrThrow(who);
            Time.SetActTime(realElapsedDeltaTime, virsulElapsedDeltaTime); //设置时间轴的活动时间。
            LifeCircle.OnLifeCircleAct();
        }

        /// <summary>
        /// 销毁框架。
        /// </summary>
        /// <param name="who">让框架诞生者(也指使用框架这件事情的活动主体是谁)。</param>
        /// <param name="realElapsedDeltaTime">真实世界流逝的时间。</param>
        /// <param name="virsulElapsedDeltaTime">虚拟世界流逝的时间。</param>
        public static void Die(object who, float realElapsedDeltaTime, float virsulElapsedDeltaTime)
        {
            CheckWhoOrThrow(who);
            Time.SetEndTime(realElapsedDeltaTime, virsulElapsedDeltaTime); //设置时间轴的终点时间。
            LifeCircle.OnLifeCircleEnd();
            State.Working = false;
        }


        #endregion

        #region 框架生命周期

        public static class LifeCircle
        {

            internal static event Action OnBorn;
            internal static event Action OnAct;
            internal static event Action OnDie;

            private static EntityTree s_EntityTree = null;

            /// <summary>
            /// 生命周期的始点。
            /// </summary>
            internal static void OnLifeCircleOrigin()
            {
                if (null != OnBorn)
                {
                    OnBorn.Invoke();
                }

                s_EntityTree = new EntityTree(new UserData("Root"));
                IExportedAssemblyManager exportedAssemblyManager = new ExportedAssemblyManager();
                IModuleManager moduleManager = new ModuleManager();

                s_EntityTree.Mount(s_EntityTree.Root, exportedAssemblyManager as ExportedAssemblyManager);
                s_EntityTree.Mount(s_EntityTree.Root, moduleManager as ModuleManager);

                Framework.GlobalData["EntityTree"] = s_EntityTree;
                Framework.GlobalData["ExportedAssemblyManager"] = exportedAssemblyManager;
                Framework.GlobalData["ModuleManager"] = moduleManager;

                s_EntityTree.Born();
            }

            /// <summary>
            /// 生命周期中的活动。
            /// </summary>
            internal static void OnLifeCircleAct()
            {
                if (null != OnAct)
                {
                    OnAct.Invoke();
                }
                s_EntityTree.Act();
            }

            /// <summary>
            /// 生命周期的终点。
            /// </summary>
            internal static void OnLifeCircleEnd()
            {
                if (null != OnDie)
                {
                    OnDie.Invoke();
                }
                s_EntityTree.Die();
            }

        }

        #endregion




    }
}
