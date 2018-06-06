//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@gmail.com
//Website: http://www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// Ugui的Canvas逻辑类。
    /// </summary>
    [RequireComponent(typeof(Canvas))]
    public abstract class UguiCanvasLogicBase : UguiLogicBase
    {
        private Canvas m_Canvas = null;
        public Canvas Canvas { get { return m_Canvas ?? (m_Canvas = GetComponent<Canvas>()); } }

        private UguiCanvasViewBase m_CachedUguiCanvasView = null;
        public UguiCanvasViewBase CanvasView { get { return m_CachedUguiCanvasView ?? (m_CachedUguiCanvasView = GetComponent<UguiCanvasViewBase>()); } }

        private LinkedList<UguiPanelLogicBase> m_UguiPanelLogicLinkedList = new LinkedList<UguiPanelLogicBase>();

        #region Canvas Logic

        private UguiPanelLogicBase CheckOrUpdateManagedUguiPanelsLogics(string assetsId)
        {
            UguiPanelLogicBase result = null;
            m_UguiPanelLogicLinkedList.PredicateForeach(current => {

                if (null != current.Value && current.Value.Id == assetsId)
                {
                    result = current.Value;
                    return true;
                }

                return false;
            });

            if (null==result)
            {
                //var forms = GetComponentsInChildren<UguiFormLogic>();
                List<UguiPanelLogicBase> forms = new List<UguiPanelLogicBase>();
                Unity.Utility.Transform.TraverseChilds(transform,tf=> {
                    var form = tf.GetComponent<UguiPanelLogicBase>();
                    if (null!=form)
                    {
                        forms.Add(form);
                    }
                });

                for (int i = 0; i < forms.Count; i++)
                {
                    if (!m_UguiPanelLogicLinkedList.Contains(forms[i]))
                    {
                        m_UguiPanelLogicLinkedList.AddLast(forms[i]);

                        if (forms[i].Id == assetsId)
                        {
                            result = forms[i];
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 获取Canvas下所有的Pannel逻辑类。
        /// </summary>
        /// <returns></returns>
        public virtual UguiPanelLogicBase[] GetAllPanels()
        {
            CheckOrUpdateManagedUguiPanelsLogics(string.Empty);
            return m_UguiPanelLogicLinkedList.ToArray<UguiPanelLogicBase>();
        }

        /// <summary>
        /// 通过Pannel Id 获取Pannel 逻辑类。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual UguiPanelLogicBase GetPanel(string id)
        {
           return CheckOrUpdateManagedUguiPanelsLogics(id);
        }

        /// <summary>
        /// 打开目标Pannel。
        /// </summary>
        /// <param name="id"></param>
        public virtual void OpenPanel(string id)
        {
            var result = CheckOrUpdateManagedUguiPanelsLogics(id);
            if (null!=result)
            {
                result.Open();
            }
        }

        /// <summary>
        /// 关闭目标Panel。
        /// </summary>
        /// <param name="id"></param>
        public virtual void ClosePanel(string id)
        {
            var result = CheckOrUpdateManagedUguiPanelsLogics(id);
            if (null != result)
            {
                result.Close();
            }
        }

        /// <summary>
        /// 将目标Panel置顶。
        /// </summary>
        /// <param name="id">Panel Id。</param>
        public virtual void TopMostPanel(string id)
        {
            var result = CheckOrUpdateManagedUguiPanelsLogics(id);
            if (null != result)
            {
                result.CachedRectTransform.SetAsLastSibling();
            }
        }

        /// <summary>
        /// 将目标Panel置底。
        /// </summary>
        /// <param name="id">Panel Id。</param>
        public virtual void BottomMostPanel(string id)
        {
            var result = CheckOrUpdateManagedUguiPanelsLogics(id);
            if (null != result)
            {
                result.CachedRectTransform.SetAsFirstSibling();
            }
        }

        #endregion
    }
}