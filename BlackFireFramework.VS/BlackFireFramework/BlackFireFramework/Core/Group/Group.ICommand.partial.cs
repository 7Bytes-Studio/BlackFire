//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework
{
    /// <summary>
    /// 组管理类。
    /// </summary>
    public static partial class Group
    {
        public delegate void ActionCommandCallback<T>(T command) where T : ICommand;

        public delegate bool FuncCommandCallback<T>(T command) where T : ICommand;

        public delegate object ChainCommandCallback<T>(T command,object lastHandleResult) where T : ICommand;



        /// <summary>
        /// 小组成员命令接口。
        /// </summary>
        public interface ICommand
        {

        }
    }
}
