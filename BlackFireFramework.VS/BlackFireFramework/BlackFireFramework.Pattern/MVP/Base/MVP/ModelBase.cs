//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Pattern
{
    /// <summary>
    /// 模型层。
    /// </summary>
    public abstract class ModelBase : PatternEntityTreeNode
    {
        /// <summary>
        /// 模型层接口。
        /// </summary>
        protected internal abstract IModel ModelInterface{ get; }
    }
}