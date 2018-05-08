//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework
{
    public static class StringExtension
    {
        public static string Slice(this string str,string sliceOp)
        {
            sliceOp = sliceOp.Trim();
            if (!sliceOp.Contains(":")) throw new System.Exception("操作必需符合 lop:rop");

            if (sliceOp == ":") // ":"
            {
                return str;
            }
            else if (sliceOp[0] == ':') //":xxx"
            {
                var s = sliceOp.Split(':');
                int rop = int.Parse(s[1]);
                char[] charArr = new char[rop];

                for (int i = 0; i < charArr.Length; i++)
                {
                    charArr[i] = str[i];
                }

                return new string(charArr);
            }
            else if (sliceOp[sliceOp.Length - 1] == ':') //"xxx:"
            {
                var s = sliceOp.Split(':');
                int lop = int.Parse(s[0]);
                lop = 0>lop?str.Length+lop:lop;
                char[] charArr = new char[str.Length-lop];

                for (int i = 0; i < charArr.Length; i++)
                {
                    charArr[i] = str[lop+i];
                }

                return new string(charArr);
            }
            else//"xxx:xxx"
            {
                var s = sliceOp.Split(':');
                int lop = int.Parse(s[0]);
                int rop = int.Parse(s[1]);
                char[] charArr = new char[rop - lop];

                for (int i = 0; i < charArr.Length; i++)
                {
                    charArr[i] = str[lop+i];
                }

                return new string(charArr);
            }
        }


        public static string Replace(this string str,string replaceOp)
        {
            if (!replaceOp.Contains(":") || !replaceOp.Contains("|")) throw new System.Exception("操作必需符合 lop:rop|your replace string");

            string sliceOp = replaceOp.Split('|')[0].Trim();
            string replaceStr = replaceOp.Slice(string.Format("{0}:", sliceOp.Length+1));

            var strArr = str.ToCharArray();

            if (sliceOp == ":") // ":"
            {
                return replaceStr;
            }
            else if (sliceOp[0] == ':') //":xxx"
            {
                var s = sliceOp.Split(':');
                int lop = 0;
                int rop = int.Parse(s[1]);
                int replaceStrIndex = 0;
                for (int i = lop; i < rop; i++)
                {
                    if (replaceStrIndex < replaceStr.Length)
                    {
                        strArr[i] = replaceStr[replaceStrIndex++];
                    }
                }

                return new string(strArr);
            }
            else if (sliceOp[sliceOp.Length - 1] == ':') //"xxx:"
            {
                var s = sliceOp.Split(':');
                int lop = int.Parse(s[0]);
                lop = 0 > lop ? strArr.Length + lop : lop;
                int rop = strArr.Length;
                int replaceStrIndex = 0;
                for (int i = lop; i < rop; i++)
                {
                    if (replaceStrIndex < replaceStr.Length)
                    {
                        strArr[i] = replaceStr[replaceStrIndex++];
                    }
                }

                return new string(strArr);
            }
            else//"xxx:xxx"
            {
                var s = sliceOp.Split(':');
                int lop = int.Parse(s[0]);
                int rop = int.Parse(s[1]);
                int replaceStrIndex = 0;
                for (int i = lop; i < rop; i++)
                {
                    if (replaceStrIndex < replaceStr.Length)
                    {
                        strArr[i] = replaceStr[replaceStrIndex++];
                    }           
                }

                return new string(strArr);
            }
        }

    }
}
