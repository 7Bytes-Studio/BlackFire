//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;

namespace BlackFireFramework.Unity
{
    public static partial class Utility
    {
        public static class Transform
        {
            /// <summary>
            /// 查找子物体（递归查找）
            /// </summary>
            /// <param name="trans">父物体</param>
            /// <param name="goName">子物体的名称</param>
            /// <returns>找到的相应子物体</returns>
            public static UnityEngine.Transform FindChild(UnityEngine.Transform trans, string goName)
            {
                UnityEngine.Transform child = trans.Find(goName);
                if (child != null)
                    return child;

                UnityEngine.Transform go = null;
                for (int i = 0; i < trans.childCount; i++)
                {
                    child = trans.GetChild(i);
                    go = FindChild(child, goName);
                    if (go != null)
                        return go;
                }
                return null;

            }

            /// <summary>
            /// 通过被查找子物体名字的一部分字符获取相关集合
            /// </summary>
            /// <param name="trans"></param>
            /// <param name="containString"></param>
            /// <param name="outList"></param>
            public static void FindChilds(UnityEngine.Transform trans, string containString, List<UnityEngine.Transform> outList)
            {

                for (int i = 0; i < trans.childCount; i++)
                {
                    FindChilds(trans.GetChild(i), containString, outList);
                }

                if (trans.name.Contains(containString))
                {
                    if (!outList.Contains(trans))
                        outList.Add(trans);
                }

            }

            /// <summary>
            /// 遍历孩子并且在递推归遍历时回调
            /// </summary>
            /// <param name="callbackHandler"></param>
            public static void TraverseChilds(UnityEngine.Transform trans, Action<UnityEngine.Transform> callbackHandler)
            {
                for (int i = 0; i < trans.childCount; i++)
                {
                    TraverseChilds(trans.GetChild(i), callbackHandler);
                }
                callbackHandler(trans); //如果要排除根物体，那么可以在回调上判断
            }

            /// <summary>
            /// 遍历孩子并且如果满足回调的返回值的时候才会继续遍历他的孩子
            /// </summary>
            /// <param name="callbackHandler"></param>
            public static void TraverseChilds(UnityEngine.Transform trans, Func<UnityEngine.Transform, bool> callbackHandler)
            {
                if (callbackHandler(trans)) return; //如果要排除根物体，那么可以在回调上判断

                for (int i = 0; i < trans.childCount; i++)
                {

                    TraverseChilds(trans.GetChild(i), callbackHandler);

                }
            }


        }

    }
}
