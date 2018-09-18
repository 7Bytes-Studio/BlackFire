//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class PixelCellTree
    {
        private Color32[,] m_Pixels=null;
        private PixelCell m_Root=null;
        public PixelCellTree(int width,int height)
        {
            m_Root = new PixelCell();
            m_Root.Width = width;
            m_Root.Height = height;
            m_Root.X = width/2;
            m_Root.Y = height/2;
            m_Root.BuildSubCells();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    m_Root.PixelCells[i,j].BuildSubCells();
                }
            }
           
            m_Root.SetPixels(m_Pixels);
        }

        public void SetPixels(Color32[,] color32s)
        {
            m_Pixels = color32s;
            m_Root.SetPixels(color32s);
        }

        public Vector2 Direction
        {
            get { return m_Root.Direction; }
        }

        public override string ToString()
        {
            return m_Root.ToString();
        }

    }
}