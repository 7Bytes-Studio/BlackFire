//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using SuperSocket.ProtoBase;
using System;
using System.Text;

namespace BlackFireFramework.Unity
{
    public sealed class DefaultReceiveFilter : IReceiveFilter<DefaultPackageInfo>
    {
        public IReceiveFilter<DefaultPackageInfo> NextReceiveFilter { get { return null; } }

        public FilterState State { get; private set; }

        public DefaultPackageInfo Filter(BufferList data, out int rest)
        {
            rest = 0;
            State = FilterState.Normal;
            byte[] dist = new byte[data.Last.Count];
            int dist_i = 0;
            for (int i = data.Last.Offset; i < data.Last.Count; i++)
            {
                dist[dist_i++] = data.Last.Array[i];
            }
            return new DefaultPackageInfo(dist);
        }

        public void Reset()
        {
            State = FilterState.Normal;
        }
    }
}
