
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{

    // C++: class BackgroundSubtractorGMG
    //javadoc: BackgroundSubtractorGMG

    public class BackgroundSubtractorGMG : BackgroundSubtractor
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
try {
if (disposing) {
}
if (IsEnabledDispose) {
if (nativeObj != IntPtr.Zero)
bgsegm_BackgroundSubtractorGMG_delete(nativeObj);
nativeObj = IntPtr.Zero;
}
} finally {
base.Dispose (disposing);
}
#else
            return;
#endif
        }

        protected internal BackgroundSubtractorGMG (IntPtr addr) : base (addr) { }

        // internal usage only
        public static new BackgroundSubtractorGMG __fromPtr__ (IntPtr addr) { return new BackgroundSubtractorGMG (addr); }

        //
        // C++:  bool getUpdateBackgroundModel()
        //

        //javadoc: BackgroundSubtractorGMG::getUpdateBackgroundModel()
        public bool getUpdateBackgroundModel ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bool retVal = bgsegm_BackgroundSubtractorGMG_getUpdateBackgroundModel_10(nativeObj);
        
        return retVal;
#else
            return false;
#endif
        }


        //
        // C++:  double getBackgroundPrior()
        //

        //javadoc: BackgroundSubtractorGMG::getBackgroundPrior()
        public double getBackgroundPrior ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        double retVal = bgsegm_BackgroundSubtractorGMG_getBackgroundPrior_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  double getDecisionThreshold()
        //

        //javadoc: BackgroundSubtractorGMG::getDecisionThreshold()
        public double getDecisionThreshold ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        double retVal = bgsegm_BackgroundSubtractorGMG_getDecisionThreshold_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  double getDefaultLearningRate()
        //

        //javadoc: BackgroundSubtractorGMG::getDefaultLearningRate()
        public double getDefaultLearningRate ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        double retVal = bgsegm_BackgroundSubtractorGMG_getDefaultLearningRate_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  double getMaxVal()
        //

        //javadoc: BackgroundSubtractorGMG::getMaxVal()
        public double getMaxVal ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        double retVal = bgsegm_BackgroundSubtractorGMG_getMaxVal_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  double getMinVal()
        //

        //javadoc: BackgroundSubtractorGMG::getMinVal()
        public double getMinVal ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        double retVal = bgsegm_BackgroundSubtractorGMG_getMinVal_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  int getMaxFeatures()
        //

        //javadoc: BackgroundSubtractorGMG::getMaxFeatures()
        public int getMaxFeatures ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        int retVal = bgsegm_BackgroundSubtractorGMG_getMaxFeatures_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  int getNumFrames()
        //

        //javadoc: BackgroundSubtractorGMG::getNumFrames()
        public int getNumFrames ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        int retVal = bgsegm_BackgroundSubtractorGMG_getNumFrames_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  int getQuantizationLevels()
        //

        //javadoc: BackgroundSubtractorGMG::getQuantizationLevels()
        public int getQuantizationLevels ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        int retVal = bgsegm_BackgroundSubtractorGMG_getQuantizationLevels_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  int getSmoothingRadius()
        //

        //javadoc: BackgroundSubtractorGMG::getSmoothingRadius()
        public int getSmoothingRadius ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        int retVal = bgsegm_BackgroundSubtractorGMG_getSmoothingRadius_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  void setBackgroundPrior(double bgprior)
        //

        //javadoc: BackgroundSubtractorGMG::setBackgroundPrior(bgprior)
        public void setBackgroundPrior (double bgprior)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bgsegm_BackgroundSubtractorGMG_setBackgroundPrior_10(nativeObj, bgprior);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setDecisionThreshold(double thresh)
        //

        //javadoc: BackgroundSubtractorGMG::setDecisionThreshold(thresh)
        public void setDecisionThreshold (double thresh)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bgsegm_BackgroundSubtractorGMG_setDecisionThreshold_10(nativeObj, thresh);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setDefaultLearningRate(double lr)
        //

        //javadoc: BackgroundSubtractorGMG::setDefaultLearningRate(lr)
        public void setDefaultLearningRate (double lr)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bgsegm_BackgroundSubtractorGMG_setDefaultLearningRate_10(nativeObj, lr);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setMaxFeatures(int maxFeatures)
        //

        //javadoc: BackgroundSubtractorGMG::setMaxFeatures(maxFeatures)
        public void setMaxFeatures (int maxFeatures)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bgsegm_BackgroundSubtractorGMG_setMaxFeatures_10(nativeObj, maxFeatures);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setMaxVal(double val)
        //

        //javadoc: BackgroundSubtractorGMG::setMaxVal(val)
        public void setMaxVal (double val)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bgsegm_BackgroundSubtractorGMG_setMaxVal_10(nativeObj, val);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setMinVal(double val)
        //

        //javadoc: BackgroundSubtractorGMG::setMinVal(val)
        public void setMinVal (double val)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bgsegm_BackgroundSubtractorGMG_setMinVal_10(nativeObj, val);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setNumFrames(int nframes)
        //

        //javadoc: BackgroundSubtractorGMG::setNumFrames(nframes)
        public void setNumFrames (int nframes)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bgsegm_BackgroundSubtractorGMG_setNumFrames_10(nativeObj, nframes);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setQuantizationLevels(int nlevels)
        //

        //javadoc: BackgroundSubtractorGMG::setQuantizationLevels(nlevels)
        public void setQuantizationLevels (int nlevels)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bgsegm_BackgroundSubtractorGMG_setQuantizationLevels_10(nativeObj, nlevels);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setSmoothingRadius(int radius)
        //

        //javadoc: BackgroundSubtractorGMG::setSmoothingRadius(radius)
        public void setSmoothingRadius (int radius)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bgsegm_BackgroundSubtractorGMG_setSmoothingRadius_10(nativeObj, radius);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setUpdateBackgroundModel(bool update)
        //

        //javadoc: BackgroundSubtractorGMG::setUpdateBackgroundModel(update)
        public void setUpdateBackgroundModel (bool update)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bgsegm_BackgroundSubtractorGMG_setUpdateBackgroundModel_10(nativeObj, update);
        
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



        // C++:  bool getUpdateBackgroundModel()
        [DllImport (LIBNAME)]
        private static extern bool bgsegm_BackgroundSubtractorGMG_getUpdateBackgroundModel_10 (IntPtr nativeObj);

        // C++:  double getBackgroundPrior()
        [DllImport (LIBNAME)]
        private static extern double bgsegm_BackgroundSubtractorGMG_getBackgroundPrior_10 (IntPtr nativeObj);

        // C++:  double getDecisionThreshold()
        [DllImport (LIBNAME)]
        private static extern double bgsegm_BackgroundSubtractorGMG_getDecisionThreshold_10 (IntPtr nativeObj);

        // C++:  double getDefaultLearningRate()
        [DllImport (LIBNAME)]
        private static extern double bgsegm_BackgroundSubtractorGMG_getDefaultLearningRate_10 (IntPtr nativeObj);

        // C++:  double getMaxVal()
        [DllImport (LIBNAME)]
        private static extern double bgsegm_BackgroundSubtractorGMG_getMaxVal_10 (IntPtr nativeObj);

        // C++:  double getMinVal()
        [DllImport (LIBNAME)]
        private static extern double bgsegm_BackgroundSubtractorGMG_getMinVal_10 (IntPtr nativeObj);

        // C++:  int getMaxFeatures()
        [DllImport (LIBNAME)]
        private static extern int bgsegm_BackgroundSubtractorGMG_getMaxFeatures_10 (IntPtr nativeObj);

        // C++:  int getNumFrames()
        [DllImport (LIBNAME)]
        private static extern int bgsegm_BackgroundSubtractorGMG_getNumFrames_10 (IntPtr nativeObj);

        // C++:  int getQuantizationLevels()
        [DllImport (LIBNAME)]
        private static extern int bgsegm_BackgroundSubtractorGMG_getQuantizationLevels_10 (IntPtr nativeObj);

        // C++:  int getSmoothingRadius()
        [DllImport (LIBNAME)]
        private static extern int bgsegm_BackgroundSubtractorGMG_getSmoothingRadius_10 (IntPtr nativeObj);

        // C++:  void setBackgroundPrior(double bgprior)
        [DllImport (LIBNAME)]
        private static extern void bgsegm_BackgroundSubtractorGMG_setBackgroundPrior_10 (IntPtr nativeObj, double bgprior);

        // C++:  void setDecisionThreshold(double thresh)
        [DllImport (LIBNAME)]
        private static extern void bgsegm_BackgroundSubtractorGMG_setDecisionThreshold_10 (IntPtr nativeObj, double thresh);

        // C++:  void setDefaultLearningRate(double lr)
        [DllImport (LIBNAME)]
        private static extern void bgsegm_BackgroundSubtractorGMG_setDefaultLearningRate_10 (IntPtr nativeObj, double lr);

        // C++:  void setMaxFeatures(int maxFeatures)
        [DllImport (LIBNAME)]
        private static extern void bgsegm_BackgroundSubtractorGMG_setMaxFeatures_10 (IntPtr nativeObj, int maxFeatures);

        // C++:  void setMaxVal(double val)
        [DllImport (LIBNAME)]
        private static extern void bgsegm_BackgroundSubtractorGMG_setMaxVal_10 (IntPtr nativeObj, double val);

        // C++:  void setMinVal(double val)
        [DllImport (LIBNAME)]
        private static extern void bgsegm_BackgroundSubtractorGMG_setMinVal_10 (IntPtr nativeObj, double val);

        // C++:  void setNumFrames(int nframes)
        [DllImport (LIBNAME)]
        private static extern void bgsegm_BackgroundSubtractorGMG_setNumFrames_10 (IntPtr nativeObj, int nframes);

        // C++:  void setQuantizationLevels(int nlevels)
        [DllImport (LIBNAME)]
        private static extern void bgsegm_BackgroundSubtractorGMG_setQuantizationLevels_10 (IntPtr nativeObj, int nlevels);

        // C++:  void setSmoothingRadius(int radius)
        [DllImport (LIBNAME)]
        private static extern void bgsegm_BackgroundSubtractorGMG_setSmoothingRadius_10 (IntPtr nativeObj, int radius);

        // C++:  void setUpdateBackgroundModel(bool update)
        [DllImport (LIBNAME)]
        private static extern void bgsegm_BackgroundSubtractorGMG_setUpdateBackgroundModel_10 (IntPtr nativeObj, bool update);

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void bgsegm_BackgroundSubtractorGMG_delete (IntPtr nativeObj);

    }
}
