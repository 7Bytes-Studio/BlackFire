//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework.Unity
{
	public static class StringExtension
    {
        public static string HexColor(this string text,string hexColor)
        {
            return string.Format("<color={0}>{1}</color>", hexColor, text);
        }

        public static string HexColor(this int intText, string hexColor)
        {
            return string.Format("<color={0}>{1}</color>", hexColor, intText);
        }

    }
}
