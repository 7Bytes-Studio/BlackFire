//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework.Pattern
{
    public interface IMVPModule:IModule
    {
        void Bind(string bindName,Type model,Type view,Type presenter);

        void UnBind(string bindName);

        void UnBind(Type modelOrViewOrPresenter);
    }
}