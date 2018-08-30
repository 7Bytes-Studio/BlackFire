//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Pattern;

namespace BlackFireFramework.Unity
{
    public abstract class View : ViewBase,IView
    {

        protected override void OnInit()
        {
            
        }

        protected override void OnUpdate()
        {
            
        }

        protected override void OnDestroy()
        {
            
        }

        protected override IView ViewInterface
        {
            get { return this; }
        }
    }
}