
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{

    // C++: class ContourFitting
    //javadoc: ContourFitting

    public class ContourFitting : Algorithm
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
try {
if (disposing) {
}
if (IsEnabledDispose) {
if (nativeObj != IntPtr.Zero)
ximgproc_ContourFitting_delete(nativeObj);
nativeObj = IntPtr.Zero;
}
} finally {
base.Dispose (disposing);
}
#else
            return;
#endif
        }

        protected internal ContourFitting (IntPtr addr) : base (addr) { }

        // internal usage only
        public static new ContourFitting __fromPtr__ (IntPtr addr) { return new ContourFitting (addr); }

        //
        // C++:  int getCtrSize()
        //

        //javadoc: ContourFitting::getCtrSize()
        public int getCtrSize ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        int retVal = ximgproc_ContourFitting_getCtrSize_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  int getFDSize()
        //

        //javadoc: ContourFitting::getFDSize()
        public int getFDSize ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        int retVal = ximgproc_ContourFitting_getFDSize_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  void estimateTransformation(Mat src, Mat dst, Mat& alphaPhiST, double& dist, bool fdContour = false)
        //

        //javadoc: ContourFitting::estimateTransformation(src, dst, alphaPhiST, dist, fdContour)
        public void estimateTransformation (Mat src, Mat dst, Mat alphaPhiST, double[] dist, bool fdContour)
        {
            ThrowIfDisposed ();
            if (src != null) src.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
            if (alphaPhiST != null) alphaPhiST.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        double[] dist_out = new double[1];
        ximgproc_ContourFitting_estimateTransformation_10(nativeObj, src.nativeObj, dst.nativeObj, alphaPhiST.nativeObj, dist_out, fdContour);
        if(dist!=null) dist[0] = (double)dist_out[0];
        return;
#else
            return;
#endif
        }

        //javadoc: ContourFitting::estimateTransformation(src, dst, alphaPhiST, dist)
        public void estimateTransformation (Mat src, Mat dst, Mat alphaPhiST, double[] dist)
        {
            ThrowIfDisposed ();
            if (src != null) src.ThrowIfDisposed ();
            if (dst != null) dst.ThrowIfDisposed ();
            if (alphaPhiST != null) alphaPhiST.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        double[] dist_out = new double[1];
        ximgproc_ContourFitting_estimateTransformation_11(nativeObj, src.nativeObj, dst.nativeObj, alphaPhiST.nativeObj, dist_out);
        if(dist!=null) dist[0] = (double)dist_out[0];
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setCtrSize(int n)
        //

        //javadoc: ContourFitting::setCtrSize(n)
        public void setCtrSize (int n)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        ximgproc_ContourFitting_setCtrSize_10(nativeObj, n);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setFDSize(int n)
        //

        //javadoc: ContourFitting::setFDSize(n)
        public void setFDSize (int n)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        ximgproc_ContourFitting_setFDSize_10(nativeObj, n);
        
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



        // C++:  int getCtrSize()
        [DllImport (LIBNAME)]
        private static extern int ximgproc_ContourFitting_getCtrSize_10 (IntPtr nativeObj);

        // C++:  int getFDSize()
        [DllImport (LIBNAME)]
        private static extern int ximgproc_ContourFitting_getFDSize_10 (IntPtr nativeObj);

        // C++:  void estimateTransformation(Mat src, Mat dst, Mat& alphaPhiST, double& dist, bool fdContour = false)
        [DllImport (LIBNAME)]
        private static extern void ximgproc_ContourFitting_estimateTransformation_10 (IntPtr nativeObj, IntPtr src_nativeObj, IntPtr dst_nativeObj, IntPtr alphaPhiST_nativeObj, double[] dist_out, bool fdContour);
        [DllImport (LIBNAME)]
        private static extern void ximgproc_ContourFitting_estimateTransformation_11 (IntPtr nativeObj, IntPtr src_nativeObj, IntPtr dst_nativeObj, IntPtr alphaPhiST_nativeObj, double[] dist_out);

        // C++:  void setCtrSize(int n)
        [DllImport (LIBNAME)]
        private static extern void ximgproc_ContourFitting_setCtrSize_10 (IntPtr nativeObj, int n);

        // C++:  void setFDSize(int n)
        [DllImport (LIBNAME)]
        private static extern void ximgproc_ContourFitting_setFDSize_10 (IntPtr nativeObj, int n);

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void ximgproc_ContourFitting_delete (IntPtr nativeObj);

    }
}
