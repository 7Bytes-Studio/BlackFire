
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{

    // C++: class BackgroundSubtractorMOG
    //javadoc: BackgroundSubtractorMOG

    public class BackgroundSubtractorMOG : BackgroundSubtractor
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
try {
if (disposing) {
}
if (IsEnabledDispose) {
if (nativeObj != IntPtr.Zero)
bgsegm_BackgroundSubtractorMOG_delete(nativeObj);
nativeObj = IntPtr.Zero;
}
} finally {
base.Dispose (disposing);
}
#else
            return;
#endif
        }

        protected internal BackgroundSubtractorMOG (IntPtr addr) : base (addr) { }

        // internal usage only
        public static new BackgroundSubtractorMOG __fromPtr__ (IntPtr addr) { return new BackgroundSubtractorMOG (addr); }

        //
        // C++:  double getBackgroundRatio()
        //

        //javadoc: BackgroundSubtractorMOG::getBackgroundRatio()
        public double getBackgroundRatio ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        double retVal = bgsegm_BackgroundSubtractorMOG_getBackgroundRatio_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  double getNoiseSigma()
        //

        //javadoc: BackgroundSubtractorMOG::getNoiseSigma()
        public double getNoiseSigma ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        double retVal = bgsegm_BackgroundSubtractorMOG_getNoiseSigma_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  int getHistory()
        //

        //javadoc: BackgroundSubtractorMOG::getHistory()
        public int getHistory ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        int retVal = bgsegm_BackgroundSubtractorMOG_getHistory_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  int getNMixtures()
        //

        //javadoc: BackgroundSubtractorMOG::getNMixtures()
        public int getNMixtures ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        int retVal = bgsegm_BackgroundSubtractorMOG_getNMixtures_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  void setBackgroundRatio(double backgroundRatio)
        //

        //javadoc: BackgroundSubtractorMOG::setBackgroundRatio(backgroundRatio)
        public void setBackgroundRatio (double backgroundRatio)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bgsegm_BackgroundSubtractorMOG_setBackgroundRatio_10(nativeObj, backgroundRatio);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setHistory(int nframes)
        //

        //javadoc: BackgroundSubtractorMOG::setHistory(nframes)
        public void setHistory (int nframes)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bgsegm_BackgroundSubtractorMOG_setHistory_10(nativeObj, nframes);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setNMixtures(int nmix)
        //

        //javadoc: BackgroundSubtractorMOG::setNMixtures(nmix)
        public void setNMixtures (int nmix)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bgsegm_BackgroundSubtractorMOG_setNMixtures_10(nativeObj, nmix);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setNoiseSigma(double noiseSigma)
        //

        //javadoc: BackgroundSubtractorMOG::setNoiseSigma(noiseSigma)
        public void setNoiseSigma (double noiseSigma)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bgsegm_BackgroundSubtractorMOG_setNoiseSigma_10(nativeObj, noiseSigma);
        
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



        // C++:  double getBackgroundRatio()
        [DllImport (LIBNAME)]
        private static extern double bgsegm_BackgroundSubtractorMOG_getBackgroundRatio_10 (IntPtr nativeObj);

        // C++:  double getNoiseSigma()
        [DllImport (LIBNAME)]
        private static extern double bgsegm_BackgroundSubtractorMOG_getNoiseSigma_10 (IntPtr nativeObj);

        // C++:  int getHistory()
        [DllImport (LIBNAME)]
        private static extern int bgsegm_BackgroundSubtractorMOG_getHistory_10 (IntPtr nativeObj);

        // C++:  int getNMixtures()
        [DllImport (LIBNAME)]
        private static extern int bgsegm_BackgroundSubtractorMOG_getNMixtures_10 (IntPtr nativeObj);

        // C++:  void setBackgroundRatio(double backgroundRatio)
        [DllImport (LIBNAME)]
        private static extern void bgsegm_BackgroundSubtractorMOG_setBackgroundRatio_10 (IntPtr nativeObj, double backgroundRatio);

        // C++:  void setHistory(int nframes)
        [DllImport (LIBNAME)]
        private static extern void bgsegm_BackgroundSubtractorMOG_setHistory_10 (IntPtr nativeObj, int nframes);

        // C++:  void setNMixtures(int nmix)
        [DllImport (LIBNAME)]
        private static extern void bgsegm_BackgroundSubtractorMOG_setNMixtures_10 (IntPtr nativeObj, int nmix);

        // C++:  void setNoiseSigma(double noiseSigma)
        [DllImport (LIBNAME)]
        private static extern void bgsegm_BackgroundSubtractorMOG_setNoiseSigma_10 (IntPtr nativeObj, double noiseSigma);

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void bgsegm_BackgroundSubtractorMOG_delete (IntPtr nativeObj);

    }
}
