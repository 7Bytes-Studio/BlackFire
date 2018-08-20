//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;

namespace BlackFireFramework.Network
{
    public class CommandDispatcher<TPackageInfo> :ICommandDispatcher<TPackageInfo> where TPackageInfo : IPackageInfo
    {
        public virtual void Dispatch(TransportBase transport,TPackageInfo info, List<CommandBase<TPackageInfo>> commands)
        {
            var sInfo = info as IPackageInfo<string>;
            for (int i = 0; i < commands.Count; i++)
            {
                if (commands[i].GetType().Name==sInfo.Key)
                {
                    commands[i].ExecuteCommand(transport,info);
                }
            }
        }
    }
}