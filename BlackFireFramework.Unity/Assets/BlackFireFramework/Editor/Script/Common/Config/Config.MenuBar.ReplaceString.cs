//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.IO;
using UnityEditor;
using UnityEngine;

namespace BlackFireFramework.Editor
{
    public static partial class Config 
	{

        public static partial class MenuBar
        {
            public const string ReplaceSourceString = "#endregion Window";

            public const string ReplaceFormatString = "\n\r            #region {0}\n\r            public const string {1} = Name + \"/{2}\";\n\r            public const string {3}Tile = \"{4}\";\n\r            public const bool {5}Type = false;\n\r            #endregion\n\r\n\r            #endregion Window";


        }

    }
}
