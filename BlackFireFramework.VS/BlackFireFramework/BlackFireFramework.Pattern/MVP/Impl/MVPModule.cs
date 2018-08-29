//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;

namespace BlackFireFramework.Pattern
{
    internal sealed class MVPModule:ModuleBase,IMVPModule
    {
        private Dictionary<Type,PatternEntityTreeNode> m_Dic = new Dictionary<Type, PatternEntityTreeNode>();
        private LinkedList<VPEntry> m_VPEntryLinkedList = new LinkedList<VPEntry>();
        private LinkedList<MPEntry> m_MPEntryLinkedList = new LinkedList<MPEntry>();


        private PatternEntityTreeNode CheckOrCreatePatternInstance(Type type)
        {
            if (!type.IsSubclassOf(typeof(PatternEntityTreeNode))) throw new SystemException(string.Format("{0} is not assignable from {1}",type,typeof(PatternEntityTreeNode)));
            
            if (!m_Dic.ContainsKey(type))
            {
                var childNode = Utility.Reflection.New(type) as PatternEntityTreeNode;
                m_Dic.Add(type,childNode);
                AddChildNode(childNode);
            }
            return m_Dic[type];
        }

        private void CheckPatternType(Type type)
        {
            if (type.IsSubclassOf(typeof(ModelBase)) || type.IsSubclassOf(typeof(ViewBase)) || type.IsSubclassOf(typeof(PresenterBase))) return;
            throw new SystemException(string.Format("Pattern type error.")); 
        }
       
        private void UnBindVP(Type view)
        {
            var target = m_VPEntryLinkedList.Find(v => v.View == view);
            if (null!=target)
            {
                foreach (var p in target.Presenters)
                {
                    if (m_Dic.ContainsKey(p))
                    {
                        (m_Dic[p] as PresenterBase).View = null;
                    }
                }
                m_VPEntryLinkedList.Remove(target);
            }
        }

        private void UnBindMP(Type model)
        {
            var target = m_MPEntryLinkedList.Find(v => v.Model == model);
            if (null!=target)
            {
                foreach (var p in target.Presenters)
                {
                    if (m_Dic.ContainsKey(p))
                    {
                        (m_Dic[p] as PresenterBase).Model = null;
                    }
                }
                
                m_MPEntryLinkedList.Remove(target);
            }
        }

        
        
        
        
        public void BindVP(Type view, IEnumerable<Type> presenters)
        {
            CheckPatternType(view);
            foreach (var tp in presenters)
            {
                CheckPatternType(tp);
            }

            //没有这个显示层的绑定。
            if (!m_VPEntryLinkedList.Contains(v=>v.View==view))
            {
                var viewIns = CheckOrCreatePatternInstance(view) as ViewBase;
                viewIns.PresenterTypeList.Clear(); //清除表示层缓存。
                foreach (var tp in presenters)
                {
                    var presenterIns = CheckOrCreatePatternInstance(tp) as PresenterBase;
                    presenterIns.View = viewIns.View;
                    viewIns.PresenterTypeList.Add(tp);
                }
                m_VPEntryLinkedList.AddLast(new VPEntry(){ View = view,Presenters = presenters}); //添加纪录。
            }
            
        }
        
        public void BindMP(Type model, IEnumerable<Type> presenters)
        {            
            CheckPatternType(model);
            foreach (var tp in presenters)
            {
                CheckPatternType(tp);
            }
           
            //没有这个模型层的绑定。
            if (!m_VPEntryLinkedList.Contains(v=>v.View==model))
            {
                var modelIns = CheckOrCreatePatternInstance(model) as ModelBase;
                foreach (var tp in presenters)
                {
                    var presenterIns = CheckOrCreatePatternInstance(tp) as PresenterBase;
                    presenterIns.Model = modelIns.Model;
                }
                m_MPEntryLinkedList.AddLast(new MPEntry(){ Model = model,Presenters = presenters}); //添加纪录。
            }
            
        }

        public void UnBind(Type modelOrViewOrPresenter)
        {
            if (!typeof(PatternEntityTreeNode).IsAssignableFrom(modelOrViewOrPresenter)) throw new SystemException(string.Format("{0} is not assignable from {1}",modelOrViewOrPresenter,typeof(PatternEntityTreeNode)));
            
            if (m_Dic.ContainsKey(modelOrViewOrPresenter))
            {
                var node = m_Dic[modelOrViewOrPresenter];
                RemoveChildNode(node);
                m_Dic.Remove(modelOrViewOrPresenter);

                if (node is ModelBase)
                {
                    UnBindMP(modelOrViewOrPresenter);
                }
                else if (node is ViewBase)
                {
                    UnBindVP(modelOrViewOrPresenter);
                }
            }
        }

        public ModelBase AcquireModel(Type model)
        {
            if (m_Dic.ContainsKey(model))
            {
                return m_Dic[model] as ModelBase;
            }
            return null;
        }

        public ViewBase AcquireView(Type view)
        {
            if (m_Dic.ContainsKey(view))
            {
                return m_Dic[view] as ViewBase;
            }
            return null;
        }

        public PresenterBase AcquirePresenter(Type presenter)
        {
            if (m_Dic.ContainsKey(presenter))
            {
                return m_Dic[presenter] as PresenterBase;
            }
            return null;
        }
    }
}