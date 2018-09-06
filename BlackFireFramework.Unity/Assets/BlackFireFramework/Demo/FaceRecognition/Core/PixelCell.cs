//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using UnityEngine.Experimental.AI;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 像素归一化单元格。
    /// </summary>
    public sealed class PixelCell
    {
        public Color32[,] Pixels;
        public int X;
        public int Y;
        public int Width;
        public int Height;

        private Rect? m_Rect;
        public Rect? Rect
        {
            get { return m_Rect??(m_Rect = new Rect(X-Width/2,Y-Height/2,X+Width/2,Y+Height/2)); }
        }

        public int Weight
        {
            get
            {
                var ilen = Rect.Value.width - Rect.Value.x;
                var jlen = Rect.Value.height - Rect.Value.y;
                var value = 0;
                var count = 0;
                for (int i = (int)Rect.Value.x; i < (int)Rect.Value.width; i++)
                {
                    for (int j = (int)Rect.Value.y; j < (int)Rect.Value.height; j++)
                    {
                        if (Pixels[i,j].r<=100)
                        {
                            value+=Pixels[i,j].r;
                            count++;
                        }
                    }
                }
                //Debug.Log(0!=count?(int)(value/count):0);
                return 0!=count?(int)(value/count):0;
            }
        }

        public Vector2 Direction
        {
            get { return DeepCalcDirection(); }
        }
        
        public PixelCell[,] PixelCells = null;
        
        //计算自身的方向
        private int[,] m_LastDirections= new int[3,3]; //上一次的方向矩阵
        private int[,] m_LastDirectionCellWeights= new int[3,3]; //上一次的
        public Vector2 CalcDirection()
        {
            if (null == PixelCells) return Vector2.zero;
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var result = PixelCells[i,j].Weight - m_LastDirectionCellWeights[i, j];
                    if (0<result)
                    {
                        m_LastDirections[i, j] = 1;
                    }
                    else if(0>result)
                    {
                        m_LastDirections[i, j] = -1;
                    }
                    else
                    {
                        m_LastDirections[i, j] = 0;
                    }
                    
                    m_LastDirectionCellWeights[i, j] = PixelCells[i,j].Weight;
                }
            }            
            
            //判断东西
            var lr = m_LastDirections[0, 0] + m_LastDirections[0, 1] + m_LastDirections[0, 2] +
                     m_LastDirections[2, 0] + m_LastDirections[2, 1] + m_LastDirections[2, 2];
            var vlr = new Vector2(lr,0);
            //判断南北
            var ud = m_LastDirections[0, 0] + m_LastDirections[0, 1] + m_LastDirections[0, 2] +
                     m_LastDirections[2, 0] + m_LastDirections[2, 1] + m_LastDirections[2, 2];
            var vud = new Vector2(0,ud);
//            //判断西北和东南
//            var wnes = m_LastDirections[0,2] + m_LastDirections[2,0];
//            //判断东北和西南
//            var enws = m_LastDirections[0,0] + m_LastDirections[2,2];
//            
//            var veswn = new Vector2(wnes,enws);
            
            return (vlr+vud).normalized;
        }

        Vector2 v = Vector2.zero;
        //计算自身内的所有方向和
        private Vector2 DeepCalcDirection()
        {
            if (null == PixelCells)
            {
               v+=Vector2.zero;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                         v+=PixelCells[i, j].Direction;
                    }
                }
            }            
            return v;
        }

        public void BuildSubCells()
        {
            PixelCells = new PixelCell[3,3];
            
            var width = Width / 3;
            var height = Height / 3;
            
            PixelCells[0,0] = new PixelCell()
            {
                X=X-width,
                Y=Y-height,
                Width = width,
                Height = height
            };
            PixelCells[0,1] = new PixelCell()
            {
                X=X,
                Y=Y-height,
                Width = width,
                Height = height
            };
            PixelCells[0,2] = new PixelCell()
            {
                X=X+width,
                Y=Y-height,
                Width = width,
                Height = height
            };
            
            PixelCells[1,0] = new PixelCell()
            {
                X=X-width,
                Y=Y,
                Width = width,
                Height = height
            };
            PixelCells[1,1] = new PixelCell()
            {
                X=X,
                Y=Y,
                Width = width,
                Height = height
            };
            PixelCells[1,2] = new PixelCell()
            {
                X=X+width,
                Y=Y,
                Width = width,
                Height = height
            };
            
            PixelCells[2,0] = new PixelCell()
            {
                X=X-width,
                Y=Y+height,
                Width = width,
                Height = height
            };
            PixelCells[2,1] = new PixelCell()
            {
                X=X,
                Y=Y+height,
                Width = width,
                Height = height
            };
            PixelCells[2,2] = new PixelCell()
            {
                X=X+width,
                Y=Y+height,
                Width = width,
                Height = height
            };
        }
        
       

        public void SetPixels(Color32[,] pixels)
        {
            //Debug.Log("::::: "+Rect);

            Pixels = pixels;
            if (null != PixelCells)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        PixelCells[i, j].SetPixels(pixels);
                    }
                }
            }
            
      
            
           

//            
//
//            var ilen = Rect.Value.width - Rect.Value.x;
//            var jlen = Rect.Value.height - Rect.Value.y;
//            
//            Debug.Log("::::: "+ilen);
//            Debug.Log("::::: "+jlen);
//            Debug.Log("::::: "+Rect.Value.x);
//            Debug.Log("::::: "+Rect.Value.width);
//            Debug.Log("::::: "+Rect.Value.y);
//            Debug.Log("::::: "+Rect.Value.height);
//            
//            var value = 0;
//            var count = 0;
//            for (int i = (int)Rect.Value.x; i < (int)Rect.Value.width; i++)
//            {
//                for (int j = (int)Rect.Value.y; j < (int)Rect.Value.height; j++)
//                {
//                    Debug.Log("::::: "+Pixels[i,j].r);
//                }
//            }
//            
            
        }
        
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 2; i >=0; i--)
            {
                for (int j = 0; j < 3; j++)
                {
                    sb.Append(string.Format("[ x:{0} y:{1} w:{2} h:{3} v:{4}] ",PixelCells[i,j].X,PixelCells[i,j].Y,PixelCells[i,j].Weight,PixelCells[i,j].Height,PixelCells[i,j].Weight));
                    //Debug.Log(string.Format("[ x:{0} y:{1} ]",m_PixelCells[i,j].X,m_PixelCells[i,j].Y));
                }
                sb.Append("\n");
            }            
            return sb.ToString();
        }
    }
}