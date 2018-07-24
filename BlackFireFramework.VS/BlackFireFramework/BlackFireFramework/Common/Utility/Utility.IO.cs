//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

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



        }

    }
}
