
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{

    // C++: class GrayCodePattern
    //javadoc: GrayCodePattern

    public class GrayCodePattern : StructuredLightPattern
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
try {
if (disposing) {
}
if (IsEnabledDispose) {
if (nativeObj != IntPtr.Zero)
structured_1light_GrayCodePattern_delete(nativeObj);
nativeObj = IntPtr.Zero;
}
} finally {
base.Dispose (disposing);
}
#else
            return;
#endif
        }

        protected internal GrayCodePattern (IntPtr addr) : base (addr) { }

        // internal usage only
        public static new GrayCodePattern __fromPtr__ (IntPtr addr) { return new GrayCodePattern (addr); }

        //
        // C++: static Ptr_GrayCodePattern create(int width, int height)
        //

        //javadoc: GrayCodePattern::create(width, height)
        public static GrayCodePattern create (int width, int height)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        GrayCodePattern retVal = GrayCodePattern.__fromPtr__(structured_1light_GrayCodePattern_create_10(width, height));
        
        return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  bool getProjPixel(vector_Mat patternImages, int x, int y, Point projPix)
        //

        //javadoc: GrayCodePattern::getProjPixel(patternImages, x, y, projPix)
        public bool getProjPixel (List<Mat> patternImages, int x, int y, Point projPix)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        Mat patternImages_mat = Converters.vector_Mat_to_Mat(patternImages);
        bool retVal = structured_1light_GrayCodePattern_getProjPixel_10(nativeObj, patternImages_mat.nativeObj, x, y, projPix.x, projPix.y);
        
        return retVal;
#else
            return false;
#endif
        }


        //
        // C++:  size_t getNumberOfPatternImages()
        //

        //javadoc: GrayCodePattern::getNumberOfPatternImages()
        public long getNumberOfPatternImages ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        long retVal = structured_1light_GrayCodePattern_getNumberOfPatternImages_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  void getImagesForShadowMasks(Mat& blackImage, Mat& whiteImage)
        //

        //javadoc: GrayCodePattern::getImagesForShadowMasks(blackImage, whiteImage)
        public void getImagesForShadowMasks (Mat blackImage, Mat whiteImage)
        {
            ThrowIfDisposed ();
            if (blackImage != null) blackImage.ThrowIfDisposed ();
            if (whiteImage != null) whiteImage.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        structured_1light_GrayCodePattern_getImagesForShadowMasks_10(nativeObj, blackImage.nativeObj, whiteImage.nativeObj);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setBlackThreshold(size_t value)
        //

        //javadoc: GrayCodePattern::setBlackThreshold(value)
        public void setBlackThreshold (long value)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        structured_1light_GrayCodePattern_setBlackThreshold_10(nativeObj, value);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setWhiteThreshold(size_t value)
        //

        //javadoc: GrayCodePattern::setWhiteThreshold(value)
        public void setWhiteThreshold (long value)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        structured_1light_GrayCodePattern_setWhiteThreshold_10(nativeObj, value);
        
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



        // C++: static Ptr_GrayCodePattern create(int width, int height)
        [DllImport (LIBNAME)]
        private static extern IntPtr structured_1light_GrayCodePattern_create_10 (int width, int height);

        // C++:  bool getProjPixel(vector_Mat patternImages, int x, int y, Point projPix)
        [DllImport (LIBNAME)]
        private static extern bool structured_1light_GrayCodePattern_getProjPixel_10 (IntPtr nativeObj, IntPtr patternImages_mat_nativeObj, int x, int y, double projPix_x, double projPix_y);

        // C++:  size_t getNumberOfPatternImages()
        [DllImport (LIBNAME)]
        private static extern long structured_1light_GrayCodePattern_getNumberOfPatternImages_10 (IntPtr nativeObj);

        // C++:  void getImagesForShadowMasks(Mat& blackImage, Mat& whiteImage)
        [DllImport (LIBNAME)]
        private static extern void structured_1light_GrayCodePattern_getImagesForShadowMasks_10 (IntPtr nativeObj, IntPtr blackImage_nativeObj, IntPtr whiteImage_nativeObj);

        // C++:  void setBlackThreshold(size_t value)
        [DllImport (LIBNAME)]
        private static extern void structured_1light_GrayCodePattern_setBlackThreshold_10 (IntPtr nativeObj, long value);

        // C++:  void setWhiteThreshold(size_t value)
        [DllImport (LIBNAME)]
        private static extern void structured_1light_GrayCodePattern_setWhiteThreshold_10 (IntPtr nativeObj, long value);

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void structured_1light_GrayCodePattern_delete (IntPtr nativeObj);

    }
}
