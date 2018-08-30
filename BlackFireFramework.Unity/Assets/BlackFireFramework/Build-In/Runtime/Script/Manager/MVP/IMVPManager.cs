//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using BlackFireFramework.Pattern;

namespace BlackFireFramework.Unity
{
    public interface IMVPManager:IManager
    {
        void BindVP(Type view, IEnumerable<Type> presenters);
        void BindMP(Type model, IEnumerable<Type> presenters);
        void UnBind(Type viewOrmodelOrpresenter);
        Pattern.ModelBase AcquireModel(Type model);
        ViewBase AcquireView(Type view);
        PresenterBase AcquirePresenter(Type presenter);
    }
}