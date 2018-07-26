//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;
using UnityEngine.EventSystems;

namespace BlackFireFramework.Unity
{
    public class UIBehaviourEx : UIBehaviour 
	{
        #region Transform

        /// <summary>
        /// The child's count of transform.
        /// </summary>
        public int ChildCount { get { return CachedTransform.childCount; } }

        private Transform m_CachedTransform = null;
        /// <summary>
        /// The cached transform component.
        /// </summary>
	    public Transform CachedTransform { get { return m_CachedTransform ?? (m_CachedTransform = GetComponent<Transform>()); } }

        private Transform m_FirstChild = null;
        /// <summary>
        /// The first child of this node.
        /// </summary>
        public Transform FirstChild { get { return m_FirstChild ?? (m_FirstChild = CachedTransform.GetChild(0)); } }

        private Transform m_LastChild = null;
        /// <summary>
        /// The last child of this node.
        /// </summary>
        public Transform LastChild { get { return m_LastChild ?? (m_LastChild = CachedTransform.GetChild(CachedTransform.childCount - 1)); } }

        /// <summary>
        /// The SiblingIndex of transform property.
        /// </summary>
        public int SiblingIndex { get { return CachedTransform.GetSiblingIndex(); } set { CachedTransform.SetSiblingIndex(value); } }


        /// <summary>
        /// The last transform of this node.
        /// </summary>
        public Transform LastTransform
        {
            get
            {

                if (null != CachedTransform.parent)
                {
                    var index = SiblingIndex - 1;
                    if (index < CachedTransform.parent.childCount)
                    {
                        return CachedTransform.parent.GetChild(index);
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// The next transform of this node.
        /// </summary>
        public Transform NextTransform
        {
            get
            {
                if (null != CachedTransform.parent)
                {
                    var index = SiblingIndex + 1;
                    if (index < CachedTransform.parent.childCount)
                    {
                        return CachedTransform.parent.GetChild(index);
                    }
                }
                return null;
            }
        }




        #endregion

        #region RectTransform


        private RectTransform m_CachedRectTransform = null;

        /// <summary>
        /// The cached rect transform component.
        /// </summary>
        public RectTransform CachedRectTransform { get { return m_CachedRectTransform ?? (m_CachedRectTransform = GetComponent<RectTransform>()); } }


        #endregion
    }
}
