//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BlackFireFramework.Game;
using BlackFireFramework.Pattern;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// MVP模式管家。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("BlackFire/MVP")]
	public sealed partial class MVPManager : ManagerBase, IMVPManager
    {

        /// <summary>
        /// MVP模块接口。
        /// </summary>
        private IMVPModule m_MVPModule = null;


        protected override void OnStart()
        {
            base.OnStart();
            InitModule();
        }

        
        private void InitModule()
        {
            RegisterModule<IMVPModule>();
            m_MVPModule = GetModule<IMVPModule>();
        }

        
        
        
        
        
        public void BindVP(Type view, IEnumerable<Type> presenters)
        {
            m_MVPModule.BindVP(view,presenters);
        }

        public void BindMP(Type model, IEnumerable<Type> presenters)
        {
            m_MVPModule.BindMP(model,presenters);
        }

        public void UnBind(Type viewOrmodelOrpresenter)
        {
            m_MVPModule.UnBind(viewOrmodelOrpresenter);
        }

        public Pattern.ModelBase AcquireModel(Type model)
        {
           return m_MVPModule.AcquireModel(model);
        }

        public ViewBase AcquireView(Type view)
        {
            return m_MVPModule.AcquireView(view);
        }

        public PresenterBase AcquirePresenter(Type presenter)
        {
            return m_MVPModule.AcquirePresenter(presenter);
        }
    }
}
