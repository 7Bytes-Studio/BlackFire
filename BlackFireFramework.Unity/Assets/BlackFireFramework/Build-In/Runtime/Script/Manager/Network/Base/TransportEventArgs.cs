//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


namespace BlackFireFramework.Unity
{
    public class TransportEventArgs : RecyclableEventArgs
    {

        protected override void OnRecycle()
        {
            Length = 0;
        }

        protected override void OnSpawn()
        {
            if (null== Message)
            {
                Message = new byte[m_BufferSize];
            }
        }



        public byte[] Message { get; private set; }

        public int Length { get; internal set; }

        public TransportState TransportState { get; internal set; }


        private int m_BufferSize = 1024;
        private int m_LastBufferSize = 1024;
        public void AdjustBufferSize(int bufferSize)
        {
            if (0 >= m_BufferSize) throw new System.Exception("Buffer size cannot be less than or equal to 0!");
            m_BufferSize = bufferSize;
            if (m_BufferSize!=m_LastBufferSize)
            {
                //调整
                Message = new byte[m_BufferSize];
            }
            m_LastBufferSize = m_BufferSize;
        }
    }
}
