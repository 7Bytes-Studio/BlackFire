//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;

namespace BlackFireFramework.Network
{
    public class PackageHelper<TPackageInfo> where TPackageInfo : IPackageInfo
    {
        public PackageHelper(TransportBase transport,IReceiveFilter<TPackageInfo> receiveFilter,string[] reflectionAssemblies,ICommandDispatcher<TPackageInfo> commandDispatcher=null)
        {
            m_Transport = transport;
            m_ReceiveFilter = receiveFilter;
            m_CommandDispatcher = commandDispatcher??new CommandDispatcher<TPackageInfo>();
            
            m_Transport.OnMessage += PackageHander_OnMessage;
            m_Transport.OnClose += PackageHander_OnClose;
            
            var tps = Utility.Reflection.GetImplTypes(reflectionAssemblies,typeof(CommandBase<TPackageInfo>));
            for (int i = 0; i < tps.Length; i++)
            {
                var ins = Utility.Reflection.New(tps[i]);
                if (null!=ins)
                {
                    m_CommandList.Add(ins as CommandBase<TPackageInfo>);
                }
            }
        }

        private TransportBase m_Transport;
        private IReceiveFilter<TPackageInfo> m_ReceiveFilter;
        private List<CommandBase<TPackageInfo>> m_CommandList = new List<CommandBase<TPackageInfo>>();
        private ICommandDispatcher<TPackageInfo> m_CommandDispatcher;
        
        private void PackageHander_OnMessage(object sender,TransportEventArgs args)
        {
            var info = m_ReceiveFilter.Filter(args.Message, 0, args.Length);
            m_CommandDispatcher.Dispatch(m_Transport,info,m_CommandList);
        }
        
        private void PackageHander_OnClose(object sender,TransportEventArgs args)
        {
            m_Transport.OnMessage -= PackageHander_OnMessage;
            m_Transport.OnClose -= PackageHander_OnClose;
        }
    }
}