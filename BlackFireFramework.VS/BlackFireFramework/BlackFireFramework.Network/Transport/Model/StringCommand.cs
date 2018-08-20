//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Network
{
    public abstract class StringCommand:CommandBase<StringPackageInfo>
    {
        public abstract override void ExecuteCommand(TransportBase transport, StringPackageInfo packageInfo);
    }
}