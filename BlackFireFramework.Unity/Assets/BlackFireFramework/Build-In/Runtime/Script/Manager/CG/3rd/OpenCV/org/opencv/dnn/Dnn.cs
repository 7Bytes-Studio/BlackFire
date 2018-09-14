#if !UNITY_WSA_10_0
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{
    // C++: class Dnn
    //javadoc: Dnn

    public class Dnn
    {

        public const int DNN_BACKEND_DEFAULT = 0;
        public const int DNN_BACKEND_HALIDE = 1;
        public const int DNN_BACKEND_INFERENCE_ENGINE = 2;
        public const int DNN_TARGET_CPU = 0;
        public const int DNN_TARGET_OPENCL = 1;
        //
        // C++:  Mat blobFromImage(Mat image, double scalefactor = 1.0, Size size = Size(), Scalar mean = Scalar(), bool swapRB = true, bool crop = true)
        //

        //javadoc: blobFromImage(image, scalefactor, size, mean, swapRB, crop)
        public static Mat blobFromImage (Mat image, double scalefactor, Size size, Scalar mean, bool swapRB, bool crop)
        {
            if (image != null)
                image.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            Mat retVal = new Mat (dnn_Dnn_blobFromImage_10 (image.nativeObj, scalefactor, size.width, size.height, mean.val [0], mean.val [1], mean.val [2], mean.val [3], swapRB, crop));
        
            return retVal;
#else
            return null;
#endif
        }

        //javadoc: blobFromImage(image)
        public static Mat blobFromImage (Mat image)
        {
            if (image != null)
                image.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            Mat retVal = new Mat (dnn_Dnn_blobFromImage_11 (image.nativeObj));
        
            return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  Mat blobFromImages(vector_Mat images, double scalefactor = 1.0, Size size = Size(), Scalar mean = Scalar(), bool swapRB = true, bool crop = true)
        //

        //javadoc: blobFromImages(images, scalefactor, size, mean, swapRB, crop)
        public static Mat blobFromImages (List<Mat> images, double scalefactor, Size size, Scalar mean, bool swapRB, bool crop)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
            Mat images_mat = Converters.vector_Mat_to_Mat (images);
            Mat retVal = new Mat (dnn_Dnn_blobFromImages_10 (images_mat.nativeObj, scalefactor, size.width, size.height, mean.val [0], mean.val [1], mean.val [2], mean.val [3], swapRB, crop));
        
            return retVal;
#else
            return null;
#endif
        }

        //javadoc: blobFromImages(images)
        public static Mat blobFromImages (List<Mat> images)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
            Mat images_mat = Converters.vector_Mat_to_Mat (images);
            Mat retVal = new Mat (dnn_Dnn_blobFromImages_11 (images_mat.nativeObj));
        
            return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  Mat readTorchBlob(String filename, bool isBinary = true)
        //

        //javadoc: readTorchBlob(filename, isBinary)
        public static Mat readTorchBlob (string filename, bool isBinary)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            Mat retVal = new Mat (dnn_Dnn_readTorchBlob_10 (filename, isBinary));
        
            return retVal;
#else
            return null;
#endif
        }

        //javadoc: readTorchBlob(filename)
        public static Mat readTorchBlob (string filename)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            Mat retVal = new Mat (dnn_Dnn_readTorchBlob_11 (filename));
        
            return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  Net readNetFromCaffe(String prototxt, String caffeModel = String())
        //

        //javadoc: readNetFromCaffe(prototxt, caffeModel)
        public static Net readNetFromCaffe (string prototxt, string caffeModel)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            Net retVal = new Net (dnn_Dnn_readNetFromCaffe_10 (prototxt, caffeModel));
        
            return retVal;
#else
            return null;
#endif
        }

        //javadoc: readNetFromCaffe(prototxt)
        public static Net readNetFromCaffe (string prototxt)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            Net retVal = new Net (dnn_Dnn_readNetFromCaffe_11 (prototxt));
        
            return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  Net readNetFromDarknet(String cfgFile, String darknetModel = String())
        //

        //javadoc: readNetFromDarknet(cfgFile, darknetModel)
        public static Net readNetFromDarknet (string cfgFile, string darknetModel)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            Net retVal = new Net (dnn_Dnn_readNetFromDarknet_10 (cfgFile, darknetModel));
        
            return retVal;
#else
            return null;
#endif
        }

        //javadoc: readNetFromDarknet(cfgFile)
        public static Net readNetFromDarknet (string cfgFile)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            Net retVal = new Net (dnn_Dnn_readNetFromDarknet_11 (cfgFile));
        
            return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  Net readNetFromTensorflow(String model, String config = String())
        //

        //javadoc: readNetFromTensorflow(model, config)
        public static Net readNetFromTensorflow (string model, string config)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            Net retVal = new Net (dnn_Dnn_readNetFromTensorflow_10 (model, config));
        
            return retVal;
#else
            return null;
#endif
        }

        //javadoc: readNetFromTensorflow(model)
        public static Net readNetFromTensorflow (string model)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            Net retVal = new Net (dnn_Dnn_readNetFromTensorflow_11 (model));
        
            return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  Net readNetFromTorch(String model, bool isBinary = true)
        //

        //javadoc: readNetFromTorch(model, isBinary)
        public static Net readNetFromTorch (string model, bool isBinary)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            Net retVal = new Net (dnn_Dnn_readNetFromTorch_10 (model, isBinary));
        
            return retVal;
#else
            return null;
#endif
        }

        //javadoc: readNetFromTorch(model)
        public static Net readNetFromTorch (string model)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            Net retVal = new Net (dnn_Dnn_readNetFromTorch_11 (model));
        
            return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  void NMSBoxes(vector_Rect bboxes, vector_float scores, float score_threshold, float nms_threshold, vector_int& indices, float eta = 1.f, int top_k = 0)
        //

        //javadoc: NMSBoxes(bboxes, scores, score_threshold, nms_threshold, indices, eta, top_k)
        public static void NMSBoxes (MatOfRect bboxes, MatOfFloat scores, float score_threshold, float nms_threshold, MatOfInt indices, float eta, int top_k)
        {
            if (bboxes != null)
                bboxes.ThrowIfDisposed ();
            if (scores != null)
                scores.ThrowIfDisposed ();
            if (indices != null)
                indices.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
            Mat bboxes_mat = bboxes;
            Mat scores_mat = scores;
            Mat indices_mat = indices;
            dnn_Dnn_NMSBoxes_10 (bboxes_mat.nativeObj, scores_mat.nativeObj, score_threshold, nms_threshold, indices_mat.nativeObj, eta, top_k);
        
            return;
#else
            return;
#endif
        }

        //javadoc: NMSBoxes(bboxes, scores, score_threshold, nms_threshold, indices)
        public static void NMSBoxes (MatOfRect bboxes, MatOfFloat scores, float score_threshold, float nms_threshold, MatOfInt indices)
        {
            if (bboxes != null)
                bboxes.ThrowIfDisposed ();
            if (scores != null)
                scores.ThrowIfDisposed ();
            if (indices != null)
                indices.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
            Mat bboxes_mat = bboxes;
            Mat scores_mat = scores;
            Mat indices_mat = indices;
            dnn_Dnn_NMSBoxes_11 (bboxes_mat.nativeObj, scores_mat.nativeObj, score_threshold, nms_threshold, indices_mat.nativeObj);
        
            return;
#else
            return;
#endif
        }


        //
        // C++:  void imagesFromBlob(Mat blob_, vector_Mat& images_)
        //

        //javadoc: imagesFromBlob(blob_, images_)
        public static void imagesFromBlob (Mat blob_, List<Mat> images_)
        {
            if (blob_ != null)
                blob_.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
            Mat images__mat = new Mat ();
            dnn_Dnn_imagesFromBlob_10 (blob_.nativeObj, images__mat.nativeObj);
            Converters.Mat_to_vector_Mat (images__mat, images_);
            images__mat.release ();
            return;
#else
            return;
#endif
        }


        //
        // C++:  void shrinkCaffeModel(String src, String dst, vector_String layersTypes = std::vector<String>())
        //

        //javadoc: shrinkCaffeModel(src, dst, layersTypes)
        public static void shrinkCaffeModel (string src, string dst, List<string> layersTypes)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
            Mat layersTypes_mat = Converters.vector_String_to_Mat (layersTypes);
            dnn_Dnn_shrinkCaffeModel_10 (src, dst, layersTypes_mat.nativeObj);
        
            return;
#else
            return;
#endif
        }

        //javadoc: shrinkCaffeModel(src, dst)
        public static void shrinkCaffeModel (string src, string dst)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            dnn_Dnn_shrinkCaffeModel_11 (src, dst);
        
            return;
#else
            return;
#endif
        }


#if (UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR
        const string LIBNAME = "__Internal";

#else
        const string LIBNAME = "opencvforunity";
#endif



        // C++:  Mat blobFromImage(Mat image, double scalefactor = 1.0, Size size = Size(), Scalar mean = Scalar(), bool swapRB = true, bool crop = true)
        [DllImport (LIBNAME)]
        private static extern IntPtr dnn_Dnn_blobFromImage_10 (IntPtr image_nativeObj, double scalefactor, double size_width, double size_height, double mean_val0, double mean_val1, double mean_val2, double mean_val3, bool swapRB, bool crop);

        [DllImport (LIBNAME)]
        private static extern IntPtr dnn_Dnn_blobFromImage_11 (IntPtr image_nativeObj);

        // C++:  Mat blobFromImages(vector_Mat images, double scalefactor = 1.0, Size size = Size(), Scalar mean = Scalar(), bool swapRB = true, bool crop = true)
        [DllImport (LIBNAME)]
        private static extern IntPtr dnn_Dnn_blobFromImages_10 (IntPtr images_mat_nativeObj, double scalefactor, double size_width, double size_height, double mean_val0, double mean_val1, double mean_val2, double mean_val3, bool swapRB, bool crop);

        [DllImport (LIBNAME)]
        private static extern IntPtr dnn_Dnn_blobFromImages_11 (IntPtr images_mat_nativeObj);

        // C++:  Mat readTorchBlob(String filename, bool isBinary = true)
        [DllImport (LIBNAME)]
        private static extern IntPtr dnn_Dnn_readTorchBlob_10 (string filename, bool isBinary);

        [DllImport (LIBNAME)]
        private static extern IntPtr dnn_Dnn_readTorchBlob_11 (string filename);

        // C++:  Net readNetFromCaffe(String prototxt, String caffeModel = String())
        [DllImport (LIBNAME)]
        private static extern IntPtr dnn_Dnn_readNetFromCaffe_10 (string prototxt, string caffeModel);

        [DllImport (LIBNAME)]
        private static extern IntPtr dnn_Dnn_readNetFromCaffe_11 (string prototxt);

        // C++:  Net readNetFromDarknet(String cfgFile, String darknetModel = String())
        [DllImport (LIBNAME)]
        private static extern IntPtr dnn_Dnn_readNetFromDarknet_10 (string cfgFile, string darknetModel);

        [DllImport (LIBNAME)]
        private static extern IntPtr dnn_Dnn_readNetFromDarknet_11 (string cfgFile);

        // C++:  Net readNetFromTensorflow(String model, String config = String())
        [DllImport (LIBNAME)]
        private static extern IntPtr dnn_Dnn_readNetFromTensorflow_10 (string model, string config);

        [DllImport (LIBNAME)]
        private static extern IntPtr dnn_Dnn_readNetFromTensorflow_11 (string model);

        // C++:  Net readNetFromTorch(String model, bool isBinary = true)
        [DllImport (LIBNAME)]
        private static extern IntPtr dnn_Dnn_readNetFromTorch_10 (string model, bool isBinary);

        [DllImport (LIBNAME)]
        private static extern IntPtr dnn_Dnn_readNetFromTorch_11 (string model);

        // C++:  void NMSBoxes(vector_Rect bboxes, vector_float scores, float score_threshold, float nms_threshold, vector_int& indices, float eta = 1.f, int top_k = 0)
        [DllImport (LIBNAME)]
        private static extern void dnn_Dnn_NMSBoxes_10 (IntPtr bboxes_mat_nativeObj, IntPtr scores_mat_nativeObj, float score_threshold, float nms_threshold, IntPtr indices_mat_nativeObj, float eta, int top_k);

        [DllImport (LIBNAME)]
        private static extern void dnn_Dnn_NMSBoxes_11 (IntPtr bboxes_mat_nativeObj, IntPtr scores_mat_nativeObj, float score_threshold, float nms_threshold, IntPtr indices_mat_nativeObj);

        // C++:  void imagesFromBlob(Mat blob_, vector_Mat& images_)
        [DllImport (LIBNAME)]
        private static extern void dnn_Dnn_imagesFromBlob_10 (IntPtr blob__nativeObj, IntPtr images__mat_nativeObj);

        // C++:  void shrinkCaffeModel(String src, String dst, vector_String layersTypes = std::vector<String>())
        [DllImport (LIBNAME)]
        private static extern void dnn_Dnn_shrinkCaffeModel_10 (string src, string dst, IntPtr layersTypes_mat_nativeObj);

        [DllImport (LIBNAME)]
        private static extern void dnn_Dnn_shrinkCaffeModel_11 (string src, string dst);

    }
}
#endif
