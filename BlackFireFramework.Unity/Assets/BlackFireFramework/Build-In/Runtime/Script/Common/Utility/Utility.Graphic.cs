//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework.Unity
{
    public static partial class Utility
    {

        /// <summary>
        /// 图形工具类。
        /// </summary>
        public static class Graphic
        {
            /// <summary>
            /// 图片置灰。
            /// </summary>
            /// <param name="color">需要置灰的目标颜色。</param>
            /// <returns>输出的置灰颜色。</returns>
            public static Color Ash(Color color)
            {
                var ashValue = Vector3.Dot(new Vector3(color.r, color.g, color.b), new Vector3(0.299f, 0.587f, 0.114f));
                return new Color(ashValue,ashValue,ashValue,color.a);
            }
            

            /// <summary>
            /// 获取二维像素矩阵。
            /// </summary>
            public static Color32[,] GetPixels32(Color32[] color32s,int width,int height)
            {
                int index = 0;
                var result = new Color32[width,height];
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        result[i, j] = color32s[index++];
                    }  
                }
                return result;
            }
            
            /// <summary>
            /// 获取二维像素矩阵。
            /// </summary>
            public static Color32[,] GetAshPixels32(Color32[] color32s,int width,int height)
            {
                int index = 0;
                var result = new Color32[width,height];
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        result[i, j] = Ash(color32s[index++]);
                    }  
                }
                return result;
            }

        }

    }
}
