//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Pattern
{
    /// <summary>
    /// 表示层。
    /// </summary>
    public abstract class PresenterBase : PatternEntityTreeNode
    {
    
        protected internal IView View { get; set; }
        protected internal IModel Model { get; set; }

      
    }
}