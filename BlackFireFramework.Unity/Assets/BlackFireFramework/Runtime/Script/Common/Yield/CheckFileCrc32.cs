//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework.Unity 
{
    /// <summary>
    /// 文件Crc32校验协程指令。
    /// </summary>
    public sealed class CheckFileCrc32 : CustomYieldInstruction
    {

        private FileStream m_FileStream = null;
        private CRC m_Crc = new CRC();
        private byte[] m_Buffer;
        private int m_BufferSize;
        private int m_ReadSize;
        private long m_Addition;
        private long FileSize;
        public uint Crc32 { get; private set; }
        public float Progress { get { return (float)m_Addition/ FileSize; } }

        public CheckFileCrc32(string path, int bufferSize)
        {
            m_BufferSize = bufferSize;
            m_FileStream = new FileStream(path, FileMode.Open);
            FileSize = m_FileStream.Length;
            m_Buffer = new byte[m_BufferSize];
        }


        public override bool keepWaiting
        {
            get
            {
                m_ReadSize = m_FileStream.Read(m_Buffer, 0, m_BufferSize);
                m_Addition += m_ReadSize;
                m_Crc.Update(m_Buffer, 0, (uint)m_ReadSize);
                //Debug.Log(m_ReadSize+"   " +m_Addition+"   "+ FileSize + "    "+Progress);
                if (m_ReadSize == m_BufferSize)
                {
                    return true;
                }
                else
                {
                    Crc32 = m_Crc.GetDigest();
                    m_FileStream.Close();
                    return false;
                }
            }
        }






    }
}
