//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BlackFireFramework.Unity
{
    public sealed class PixelImageMaker : MonoBehaviour
    {
        [SerializeField] private Image m_PixelImageTpl = null;
        [SerializeField] private int m_Width=128;
        [SerializeField] private int m_Height=128;
        private int[] m_IndexArray = null;

        
        

        private void Awake1()
        {
            var index = 0;
            var matrix = new Matrix(3,3);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i,j] = index++;
                }
            }
            
            
            Debug.Log(matrix);
            matrix = Matrix.Transpose(matrix);
         
            Debug.Log(matrix);
            
            Debug.Log(matrix.GetP());
        }


        public void SetSize(int width,int height)
        {
            m_Width=width;
            m_Height=height;
            m_IndexArray=new int[m_Width*height];
            var index = 0;
            var matrix = new Matrix(m_Width,m_Height);
            for (int i = 0; i < m_Width; i++)
            {
                for (int j = 0; j < m_Height; j++)
                {
                    matrix[i,j] = index++;
                }
            }

            matrix = Matrix.Transpose(matrix);
            index = 0;
            for (int i = 0; i < m_Height; i++)
            {
                for (int j = 0; j < m_Width; j++)
                {
                    m_IndexArray[index++]=(int)matrix[i,j];
                }
            }
            
           // Debug.Log(matrix.ToString());
           // Debug.Log((int)matrix[2,2]);
        }

        public void MakePixelImages(Color32[] color32s)
        {
            StartCoroutine(MakeGreyPixelImagesYield(color32s));
        }


        private IEnumerator MakePixelImagesYield(Color32[] color32s)
        {
            int index=0;
            for (int i = 0; i < m_Height; i++)
            {
                for (int j = 0; j < m_Width; j++)
                {
                    var img = GameObject.Instantiate<Image>(m_PixelImageTpl,m_PixelImageTpl.rectTransform.parent);
                    img.gameObject.SetActive(true);
                    img.rectTransform.anchoredPosition3D = new Vector3(j*2,-i*2,0);
                    img.color = color32s[m_IndexArray[index++]];
                }
                yield return null;
            }
        }
        
        private IEnumerator MakeGreyPixelImagesYield(Color32[] color32s)
        {
            int index=0;
            for (int i = 0; i < m_Height; i++)
            {
                for (int j = 0; j < m_Width; j++)
                {
                    var img = GameObject.Instantiate<Image>(m_PixelImageTpl,m_PixelImageTpl.rectTransform.parent);
                    img.gameObject.SetActive(true);
                    img.rectTransform.anchoredPosition3D = new Vector3(j*2,-i*2,0);
                    img.color = Utility.Graphic.Ash(color32s[index++]);
                }
                yield return null;
            }
        }
        
    }
}