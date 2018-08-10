//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public static partial class Utility
    {
        /// <summary>
        /// Texture工具类。
        /// </summary>
        public static class Texture
        {
            /// <summary>
            /// 转换成JPG。
            /// </summary>
            /// <param name="quality">JPG的质量(0-100)。</param>
            /// <returns>JPG字节流。</returns>
            public static byte[] ToJPG(Texture2D texture2D,int quality)
            {
               return texture2D.EncodeToJPG(quality);
            }
            
            /// <summary>
            /// 转换成JPG。
            /// </summary>
            /// <returns>JPG字节流。</returns>
            public static byte[] ToJPG(Texture2D texture2D)
            {
                return texture2D.EncodeToJPG();
            }
            
            
            /// <summary>
            /// 转换成PNG。
            /// </summary>
            /// <returns>PNG字节流。</returns>
            public static byte[] ToPNG(Texture2D texture2D)
            {
                return texture2D.EncodeToPNG();
            }
            
            
            /// <summary>
            /// 转换成EXR。
            /// </summary>
            /// <returns>EXR字节流。</returns>
            public static byte[] ToEXR(Texture2D texture2D)
            {
                return texture2D.EncodeToEXR();
            }
            
            

            /// <summary>
            /// 转换成为JPG文件。
            /// </summary>
            /// <param name="filePath">文件路径。</param>
            /// <param name="texture2D">2D材质。</param>
            /// <param name="saveCompleteCallback">保存成文件后的成功回调。</param>
            /// <returns>文件大小。</returns>
            public static ulong ToJPGFile(string filePath,Texture2D texture2D,Action saveCompleteCallback=null)
            {
                var data = ToJPG(texture2D);
                BlackFireFramework.Utility.IO.SaveFile(filePath,data,saveCompleteCallback);
                return (ulong)data.Length;
            }
            
            /// <summary>
            /// 转换成为PNG文件。
            /// </summary>
            /// <param name="filePath">文件路径。</param>
            /// <param name="texture2D">2D材质。</param>
            /// <param name="saveCompleteCallback">保存成文件后的成功回调。</param>
            /// <returns>文件大小。</returns>
            public static ulong ToPNGFile(string filePath,Texture2D texture2D,Action saveCompleteCallback=null)
            {
                var data = ToPNG(texture2D);
                BlackFireFramework.Utility.IO.SaveFile(filePath,data,saveCompleteCallback);
                return (ulong)data.Length;
            }
            
            /// <summary>
            /// 转换成为EXR文件。
            /// </summary>
            /// <param name="filePath">文件路径。</param>
            /// <param name="texture2D">2D材质。</param>
            /// <param name="saveCompleteCallback">保存成文件后的成功回调。</param>
            /// <returns>文件大小。</returns>
            public static ulong ToEXRFile(string filePath,Texture2D texture2D,Action saveCompleteCallback=null)
            {
                var data = ToEXR(texture2D);
                BlackFireFramework.Utility.IO.SaveFile(filePath,data,saveCompleteCallback);
                return (ulong)data.Length;
            }
            
            

            /// <summary>
            /// 获取指定目录下的所有图片文件路径。
            /// </summary>
            /// <param name="dirPath">文件目录。</param>
            /// <returns>文件路径字典(key:不包括后缀名的文件名,value:文件路径名。)。</returns>
            public static Dictionary<string, string> AcquireImageFiles(string dirPath,string[] exs)
            {
                Dictionary<string, string> imagefilesDic = new Dictionary<string, string>();
                var checkReuslt = true;
                foreach (var file in Directory.GetFiles(dirPath))
                {
                    for (int i = 0; i < exs.Length; i++)
                    {
                        checkReuslt = checkReuslt && Path.GetExtension(file) == exs[i];
                    }
                    if (checkReuslt)
                        imagefilesDic.Add(Path.GetFileNameWithoutExtension(file), file);
                }
                return imagefilesDic;
            }
        }
    }
}
