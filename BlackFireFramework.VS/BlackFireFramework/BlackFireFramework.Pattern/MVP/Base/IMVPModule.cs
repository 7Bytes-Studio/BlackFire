//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

namespace BlackFireFramework.Pattern
{
    public interface IMVPModule:IModule
    {

        void BindVP(Type view,IEnumerable<Type> presenters);
        
        void BindMP(Type model,IEnumerable<Type> presenters);
        
        void UnBind(Type viewOrmodel);

        ModelBase AcquireModel(Type model);
        ViewBase AcquireView(Type view);
        PresenterBase AcquirePresenter(Type presenter);
    }
}