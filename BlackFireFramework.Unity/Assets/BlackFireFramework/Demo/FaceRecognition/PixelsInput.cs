//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Threading;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class PixelsInput : MonoBehaviour
    {
        [SerializeField] private Color m_Tnit;
        
        [SerializeField] private PixelImageMaker m_Maker;
        
        [SerializeField] private Texture2D m_T2dLeft;
        [SerializeField] private Texture2D m_T2dMiddle;
        [SerializeField] private Texture2D m_T2dRight;
        
        
        
        private void Start()
        {
            m_Maker.SetSize(m_T2dLeft.width,m_T2dLeft.height);
            m_Maker.MakePixelImages(m_T2dLeft.GetPixels32());
            var width = m_T2dLeft.width;
            var height = m_T2dLeft.height;
            var ps1 = m_T2dLeft.GetPixels32();
            var ps2 = m_T2dMiddle.GetPixels32();
            var ps3 = m_T2dRight.GetPixels32();
            
//            new Thread(() =>
//            {

                var tree = new PixelCellTree(width,width);
                tree.SetPixels(Utility.Graphic.GetAshPixels32(ps1,width,height));
                Debug.Log(tree.Direction);
                Debug.Log(tree);
            tree.SetPixels(Utility.Graphic.GetAshPixels32(ps1,width,height));
            Debug.Log(tree.Direction);
            Debug.Log(tree);
            tree.SetPixels(Utility.Graphic.GetAshPixels32(ps1,width,height));
            Debug.Log(tree.Direction);
            Debug.Log(tree);
            
                tree.SetPixels(Utility.Graphic.GetAshPixels32(ps2,width,height));
                Debug.Log(tree.Direction);
                Debug.Log(tree);
                tree.SetPixels(Utility.Graphic.GetAshPixels32(ps3,width,height));
                Debug.Log(tree.Direction);
                Debug.Log(tree);
                
            tree.SetPixels(Utility.Graphic.GetAshPixels32(ps1,width,height));
            Debug.Log(tree.Direction);
            Debug.Log(tree);
            tree.SetPixels(Utility.Graphic.GetAshPixels32(ps2,width,height));
            Debug.Log(tree.Direction);
            Debug.Log(tree);
            tree.SetPixels(Utility.Graphic.GetAshPixels32(ps3,width,height));
            Debug.Log(tree.Direction);
            Debug.Log(tree);
            
//            }).Start();
            

        }

       

    }
}