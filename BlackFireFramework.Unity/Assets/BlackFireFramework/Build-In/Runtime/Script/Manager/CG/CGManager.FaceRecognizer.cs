//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using OpenCVForUnity;
using UnityEngine;
using BlackFireFramework;

namespace BlackFireFramework.Unity
{
	public sealed partial class CGManager
    {

        private void Init_FaceRecognizer()
        {
            
        }



        private IEnumerable<string> m_Paths;
        public void LoadFaceImages(IEnumerable<string> uris,Action loadCompleted=null)
        {
            m_Paths = uris;
            StartCoroutine(LoadFaceImagesYield(loadCompleted));
        }

        
        private sealed class MatInfo
        {
            public int Label;
            public string ImageName;
            public Mat Mat;
        }
        
        private LinkedList<MatInfo> m_MatInfoLinkList = new LinkedList<MatInfo>();
        private List<Mat> m_MatList = new List<Mat>();
        private MatOfInt m_Labels = new MatOfInt(); //标签列表（OpenCV内部的MatOfInt）
        private List<int> m_LabelsList = new List<int>(); //图片的标签列表（整数）。
        private int m_Label=1994; //如果内部识别不出来，默认索引为0。
        private IEnumerator LoadFaceImagesYield(Action loadCompleted)
        {
            foreach (var path in m_Paths)
            {
                var matInfo = new MatInfo();
                matInfo.Mat = Imgcodecs.imread(path,0);
                matInfo.Label = m_Label;
                matInfo.ImageName = GetFileName(path);
                m_MatInfoLinkList.AddLast(matInfo); //通过OpenCV的IMRead读取添加OpenCV的图片。
                m_MatList.Add(matInfo.Mat);
                m_LabelsList.Add (m_Label++); //为图片打上标签。
                yield return null;
            }
            
            m_Labels.fromList(m_LabelsList); //标签列表。
            
            if (null!=loadCompleted)
            {
                loadCompleted.Invoke();
            }
        }

        private MatInfo GetMatInfo(int label)
        {
            for (var current=m_MatInfoLinkList.First; null!=current; current=current.Next)
            {
                if (current.Value.Label==label)
                {
                    return current.Value;
                }
            }
            return null;
        }

        private string GetFileName(string path)
        {
            FileInfo fi = new FileInfo(path);
            return fi.Name.Substring(0,fi.Name.Length-fi.Extension.Length);
        }

        private Mat MatRead(string uri) //成功
        {
            return Imgcodecs.imread(uri,0);
        }

        private Mat MatRead(WebCamDevice webCamDevice,WebCamTexture webCamTexture) //失败
        {
            Mat rgbaMat = new Mat(webCamTexture.height, webCamTexture.width, CvType.CV_8UC4);
            Color32[] color32s = new Color32[webCamTexture.height*webCamTexture.width];
            Utils.webCamTextureToMat(webCamTexture,rgbaMat,color32s);
            FlipMat(webCamDevice,webCamTexture,rgbaMat,false,true);
            return rgbaMat;
        }
        
        private Mat MatRead(Texture2D texture2D) //失败
        {
            Mat rgbaMat = new Mat(texture2D.height,texture2D.width, CvType.CV_8UC4);
            Utils.texture2DToMat(texture2D,rgbaMat);
            return rgbaMat;
        }
        
        private void FlipMat(WebCamDevice webCamDevice,WebCamTexture webCamTexture,Mat mat,bool flipVertical=false,bool flipHorizontal=false)
        {
            int flipCode = int.MinValue;

            if (webCamDevice.isFrontFacing)
            {
                if (webCamTexture.videoRotationAngle == 0)
                {
                    flipCode = 1;
                } else if (webCamTexture.videoRotationAngle == 90)
                {
                    flipCode = 1;
                }
                if (webCamTexture.videoRotationAngle == 180)
                {
                    flipCode = 0;
                } else if (webCamTexture.videoRotationAngle == 270)
                {
                    flipCode = 0;
                }
            } else
            {
                if (webCamTexture.videoRotationAngle == 180)
                {
                    flipCode = -1;
                } else if (webCamTexture.videoRotationAngle == 270)
                {
                    flipCode = -1;
                }
            }

            if (flipVertical)
            {
                if (flipCode == int.MinValue)
                {
                    flipCode = 0;
                } else if (flipCode == 0)
                {
                    flipCode = int.MinValue;
                } else if (flipCode == 1)
                {
                    flipCode = -1;
                } else if (flipCode == -1)
                {
                    flipCode = 1;
                }
            }

            if (flipHorizontal)
            {
                if (flipCode == int.MinValue)
                {
                    flipCode = 1;
                } else if (flipCode == 0)
                {
                    flipCode = -1;
                } else if (flipCode == 1)
                {
                    flipCode = int.MinValue;
                } else if (flipCode == -1)
                {
                    flipCode = 0;
                }
            }

            if (flipCode > int.MinValue)
            {
                Core.flip(mat, mat, flipCode);
            }
        }

        private FaceRecognitionEventArgs _FaceRecognition(Mat sampleMat)
        {            
            int[] predictedLabel = new int[1]; //预判标签
            double[] predictedConfidence = new double[1]; //预判可信度

            BasicFaceRecognizer faceRecognizer = EigenFaceRecognizer.create();
            
            faceRecognizer.train(m_MatList,m_Labels);
            faceRecognizer.predict (sampleMat,predictedLabel,predictedConfidence);
            var label = predictedLabel[0];

            Debug.Log ("Predicted class: " + label + " | " + "Confidence: " + predictedConfidence[0] );

            
            if (0==label)
            {
                return new FaceRecognitionEventArgs(){ RecognitionFailure = true};
            }
            
            var targetMat = GetMatInfo(label);
            Mat predictedMat = targetMat.Mat; //找到匹配的那张图

            Mat baseMat = new Mat(sampleMat.rows(), predictedMat.cols() + sampleMat.cols(), CvType.CV_8UC1);
            predictedMat.copyTo(baseMat.submat (new OpenCVForUnity.Rect(0, 0, predictedMat.cols (), predictedMat.rows ())));
            sampleMat.copyTo(baseMat.submat (new OpenCVForUnity.Rect(predictedMat.cols (), 0, sampleMat.cols (), sampleMat.rows ())));

//            Imgproc.putText(baseMat, "Predicted", new Point (10, 15), Core.FONT_HERSHEY_SIMPLEX, 0.4, new Scalar (255), 1, Imgproc.LINE_AA, false);
//            Imgproc.putText(baseMat, "Confidence:", new Point (5, 25), Core.FONT_HERSHEY_SIMPLEX, 0.2, new Scalar (255), 1, Imgproc.LINE_AA, false);
//            Imgproc.putText(baseMat, "   " + predictedConfidence [0], new Point (5, 33), Core.FONT_HERSHEY_SIMPLEX, 0.2, new Scalar (255), 1, Imgproc.LINE_AA, false);
//            Imgproc.putText(baseMat, "Sample", new Point (predictedMat.cols () + 10, 15), Core.FONT_HERSHEY_SIMPLEX, 0.4, new Scalar (255), 1, Imgproc.LINE_AA, false);

            Texture2D texture = new Texture2D(baseMat.cols (), baseMat.rows (), TextureFormat.RGBA32, false);

            Utils.matToTexture2D(baseMat,texture);
            
            return new FaceRecognitionEventArgs()
            {
                PredictedLabel = predictedLabel[0],
                Confidence = predictedConfidence[0],
                FaceRecTexture = texture
            };
        }
        
        
        
        
        
        
        public FaceRecognitionEventArgs FaceRecognition(string sampleImageuri)
        {
            return _FaceRecognition(MatRead(sampleImageuri));
        }
        
        
    }


    public sealed class FaceRecognitionEventArgs:EventArgs
    {
        public bool RecognitionFailure; //识别失败
        public int PredictedLabel; //预判等级
        public double Confidence; //可信度，也就是差异度
        public Texture2D FaceRecTexture; //对比后的图片
    }

}
