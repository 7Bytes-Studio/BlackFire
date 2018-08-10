//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.IO;

namespace BlackFireFramework
{
    public static partial class Utility
    {
        public static class IO
        {
            public static void ExistsOrCreateFile(string path)
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
            }

            public static void ExistsOrCreateFolder(string path)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }


            public static void SaveFile(string filePath,byte[] data,Action saveCompleteCallback)
            {
                var fs = File.Open(filePath, FileMode.Create);
                fs.BeginWrite(data, 0, data.Length, new AsyncCallback(iar =>
                {
                    using (var _fs = iar.AsyncState as FileStream)
                    {
                        _fs.EndWrite(iar);
                        if (null!=saveCompleteCallback)
                        {
                            saveCompleteCallback.Invoke();
                        }
                    }
                }), fs);
            }

        }

    }
}
