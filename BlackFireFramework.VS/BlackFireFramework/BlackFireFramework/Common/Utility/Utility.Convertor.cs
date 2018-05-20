//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;

namespace BlackFireFramework
{
    /// <summary>
    /// Magic Utilities.
    /// </summary>
    public static partial class Utility
    {
        /// <summary>
        /// 类型转换。
        /// </summary>
        public static class Convertor
        {

            public static Type Convert(string typeStr)
            {
                if (typeStr == "int") typeStr = "Int32";
                else if (typeStr == "float") typeStr = "Single";
                else if (typeStr == "double") typeStr = "Double";
                else if (typeStr == "decimal") typeStr = "Decimal";
                else if (typeStr == "char") typeStr = "Char";
                else if (typeStr == "string") typeStr = "String";

                if (typeStr.Contains("int")) typeStr=typeStr.Replace("int", "Int32");
                if (typeStr.Contains("float")) typeStr=typeStr.Replace("float", "Single");
                if (typeStr.Contains("double")) typeStr=typeStr.Replace("double", "Double");
                if (typeStr.Contains("decimal")) typeStr=typeStr.Replace("decimal", "Decimal");
                if (typeStr.Contains("char")) typeStr=typeStr.Replace("char", "Char");
                if (typeStr.Contains("string")) typeStr=typeStr.Replace("string", "String");

                

                if (typeStr.StartsWith("List"))
                {
                    return Type.GetType(string.Format("System.Collections.Generic.List`1[System.{0}]", typeStr.Slice('<','>')));
                }
                else if (typeStr.StartsWith("Dictionary"))
                {
                    var str = typeStr.Slice('<', '>');
                    var s = str.Split(',');
                    return Type.GetType(string.Format("System.Collections.Generic.Dictionary`2[System.{0},System.{1}]", s[0], s[1]));
                }
                else
                {
                    return  Type.GetType(string.Format("System.{0}", typeStr));
                }
            }


            public static object Convert(string typeStr,string typeValue)
            {
                Type type = Convert(typeStr);
                if (null!=type)
                {
                    var typeObject = Reflection.New(type);
                    if (type==typeof(int))
                    {
                        int v;
                        if (int.TryParse(typeValue,out v))
                        {
                            typeObject = v;
                        }
                    }
                    else if (type == typeof(Int16))
                    {
                        Int16 v;
                        if (Int16.TryParse(typeValue, out v))
                        {
                            typeObject = v;
                        }
                    }
                    else if (type == typeof(Int64))
                    {
                        Int64 v;
                        if (Int64.TryParse(typeValue, out v))
                        {
                            typeObject = v;
                        }
                    }
                    else if (type == typeof(float))
                    {
                        float v;
                        if (float.TryParse(typeValue, out v))
                        {
                            typeObject = v;
                        }
                    }
                    else if (type == typeof(double))
                    {
                        double v;
                        if (double.TryParse(typeValue, out v))
                        {
                            typeObject = v;
                        }
                    }
                    else if (type == typeof(decimal))
                    {
                        decimal v;
                        if (decimal.TryParse(typeValue, out v))
                        {
                            typeObject = v;
                        }
                    }
                    else if (type == typeof(char))
                    {
                        char v;
                        if (char.TryParse(typeValue, out v))
                        {
                            typeObject = v;
                        }
                    }
                    else if (type == typeof(string))
                    {
                        typeObject = typeValue;
                    }
                }
                return null;
            }
           

        }

    }
}

