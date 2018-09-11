
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{
    // C++: class Bgsegm
    //javadoc: Bgsegm

    public class Bgsegm
    {

        public const int LSBP_CAMERA_MOTION_COMPENSATION_NONE = 0;
        public const int LSBP_CAMERA_MOTION_COMPENSATION_LK = 0 + 1;
        //
        // C++:  Ptr_BackgroundSubtractorCNT createBackgroundSubtractorCNT(int minPixelStability = 15, bool useHistory = true, int maxPixelStability = 15*60, bool isParallel = true)
        //

        //javadoc: createBackgroundSubtractorCNT(minPixelStability, useHistory, maxPixelStability, isParallel)
        public static BackgroundSubtractorCNT createBackgroundSubtractorCNT (int minPixelStability, bool useHistory, int maxPixelStability, bool isParallel)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        BackgroundSubtractorCNT retVal = BackgroundSubtractorCNT.__fromPtr__(bgsegm_Bgsegm_createBackgroundSubtractorCNT_10(minPixelStability, useHistory, maxPixelStability, isParallel));
        
        return retVal;
#else
            return null;
#endif
        }

        //javadoc: createBackgroundSubtractorCNT()
        public static BackgroundSubtractorCNT createBackgroundSubtractorCNT ()
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        BackgroundSubtractorCNT retVal = BackgroundSubtractorCNT.__fromPtr__(bgsegm_Bgsegm_createBackgroundSubtractorCNT_11());
        
        return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  Ptr_BackgroundSubtractorGMG createBackgroundSubtractorGMG(int initializationFrames = 120, double decisionThreshold = 0.8)
        //

        //javadoc: createBackgroundSubtractorGMG(initializationFrames, decisionThreshold)
        public static BackgroundSubtractorGMG createBackgroundSubtractorGMG (int initializationFrames, double decisionThreshold)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        BackgroundSubtractorGMG retVal = BackgroundSubtractorGMG.__fromPtr__(bgsegm_Bgsegm_createBackgroundSubtractorGMG_10(initializationFrames, decisionThreshold));
        
        return retVal;
#else
            return null;
#endif
        }

        //javadoc: createBackgroundSubtractorGMG()
        public static BackgroundSubtractorGMG createBackgroundSubtractorGMG ()
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        BackgroundSubtractorGMG retVal = BackgroundSubtractorGMG.__fromPtr__(bgsegm_Bgsegm_createBackgroundSubtractorGMG_11());
        
        return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  Ptr_BackgroundSubtractorGSOC createBackgroundSubtractorGSOC(int mc = LSBP_CAMERA_MOTION_COMPENSATION_NONE, int nSamples = 20, float replaceRate = 0.003f, float propagationRate = 0.01f, int hitsThreshold = 32, float alpha = 0.01f, float beta = 0.0022f, float blinkingSupressionDecay = 0.1f, float blinkingSupressionMultiplier = 0.1f, float noiseRemovalThresholdFacBG = 0.0004f, float noiseRemovalThresholdFacFG = 0.0008f)
        //

        //javadoc: createBackgroundSubtractorGSOC(mc, nSamples, replaceRate, propagationRate, hitsThreshold, alpha, beta, blinkingSupressionDecay, blinkingSupressionMultiplier, noiseRemovalThresholdFacBG, noiseRemovalThresholdFacFG)
        public static BackgroundSubtractorGSOC createBackgroundSubtractorGSOC (int mc, int nSamples, float replaceRate, float propagationRate, int hitsThreshold, float alpha, float beta, float blinkingSupressionDecay, float blinkingSupressionMultiplier, float noiseRemovalThresholdFacBG, float noiseRemovalThresholdFacFG)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        BackgroundSubtractorGSOC retVal = BackgroundSubtractorGSOC.__fromPtr__(bgsegm_Bgsegm_createBackgroundSubtractorGSOC_10(mc, nSamples, replaceRate, propagationRate, hitsThreshold, alpha, beta, blinkingSupressionDecay, blinkingSupressionMultiplier, noiseRemovalThresholdFacBG, noiseRemovalThresholdFacFG));
        
        return retVal;
#else
            return null;
#endif
        }

        //javadoc: createBackgroundSubtractorGSOC()
        public static BackgroundSubtractorGSOC createBackgroundSubtractorGSOC ()
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        BackgroundSubtractorGSOC retVal = BackgroundSubtractorGSOC.__fromPtr__(bgsegm_Bgsegm_createBackgroundSubtractorGSOC_11());
        
        return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  Ptr_BackgroundSubtractorLSBP createBackgroundSubtractorLSBP(int mc = LSBP_CAMERA_MOTION_COMPENSATION_NONE, int nSamples = 20, int LSBPRadius = 16, float Tlower = 2.0f, float Tupper = 32.0f, float Tinc = 1.0f, float Tdec = 0.05f, float Rscale = 10.0f, float Rincdec = 0.005f, float noiseRemovalThresholdFacBG = 0.0004f, float noiseRemovalThresholdFacFG = 0.0008f, int LSBPthreshold = 8, int minCount = 2)
        //

        //javadoc: createBackgroundSubtractorLSBP(mc, nSamples, LSBPRadius, Tlower, Tupper, Tinc, Tdec, Rscale, Rincdec, noiseRemovalThresholdFacBG, noiseRemovalThresholdFacFG, LSBPthreshold, minCount)
        public static BackgroundSubtractorLSBP createBackgroundSubtractorLSBP (int mc, int nSamples, int LSBPRadius, float Tlower, float Tupper, float Tinc, float Tdec, float Rscale, float Rincdec, float noiseRemovalThresholdFacBG, float noiseRemovalThresholdFacFG, int LSBPthreshold, int minCount)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        BackgroundSubtractorLSBP retVal = BackgroundSubtractorLSBP.__fromPtr__(bgsegm_Bgsegm_createBackgroundSubtractorLSBP_10(mc, nSamples, LSBPRadius, Tlower, Tupper, Tinc, Tdec, Rscale, Rincdec, noiseRemovalThresholdFacBG, noiseRemovalThresholdFacFG, LSBPthreshold, minCount));
        
        return retVal;
#else
            return null;
#endif
        }

        //javadoc: createBackgroundSubtractorLSBP()
        public static BackgroundSubtractorLSBP createBackgroundSubtractorLSBP ()
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        BackgroundSubtractorLSBP retVal = BackgroundSubtractorLSBP.__fromPtr__(bgsegm_Bgsegm_createBackgroundSubtractorLSBP_11());
        
        return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  Ptr_BackgroundSubtractorMOG createBackgroundSubtractorMOG(int history = 200, int nmixtures = 5, double backgroundRatio = 0.7, double noiseSigma = 0)
        //

        //javadoc: createBackgroundSubtractorMOG(history, nmixtures, backgroundRatio, noiseSigma)
        public static BackgroundSubtractorMOG createBackgroundSubtractorMOG (int history, int nmixtures, double backgroundRatio, double noiseSigma)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        BackgroundSubtractorMOG retVal = BackgroundSubtractorMOG.__fromPtr__(bgsegm_Bgsegm_createBackgroundSubtractorMOG_10(history, nmixtures, backgroundRatio, noiseSigma));
        
        return retVal;
#else
            return null;
#endif
        }

        //javadoc: createBackgroundSubtractorMOG()
        public static BackgroundSubtractorMOG createBackgroundSubtractorMOG ()
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        BackgroundSubtractorMOG retVal = BackgroundSubtractorMOG.__fromPtr__(bgsegm_Bgsegm_createBackgroundSubtractorMOG_11());
        
        return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  Ptr_SyntheticSequenceGenerator createSyntheticSequenceGenerator(Mat background, Mat _object, double amplitude = 2.0, double wavelength = 20.0, double wavespeed = 0.2, double objspeed = 6.0)
        //

        //javadoc: createSyntheticSequenceGenerator(background, _object, amplitude, wavelength, wavespeed, objspeed)
        public static SyntheticSequenceGenerator createSyntheticSequenceGenerator (Mat background, Mat _object, double amplitude, double wavelength, double wavespeed, double objspeed)
        {
            if (background != null) background.ThrowIfDisposed ();
            if (_object != null) _object.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        SyntheticSequenceGenerator retVal = SyntheticSequenceGenerator.__fromPtr__(bgsegm_Bgsegm_createSyntheticSequenceGenerator_10(background.nativeObj, _object.nativeObj, amplitude, wavelength, wavespeed, objspeed));
        
        return retVal;
#else
            return null;
#endif
        }

        //javadoc: createSyntheticSequenceGenerator(background, _object)
        public static SyntheticSequenceGenerator createSyntheticSequenceGenerator (Mat background, Mat _object)
        {
            if (background != null) background.ThrowIfDisposed ();
            if (_object != null) _object.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        SyntheticSequenceGenerator retVal = SyntheticSequenceGenerator.__fromPtr__(bgsegm_Bgsegm_createSyntheticSequenceGenerator_11(background.nativeObj, _object.nativeObj));
        
        return retVal;
#else
            return null;
#endif
        }


#if (UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR
        const string LIBNAME = "__Internal";
#else
        const string LIBNAME = "opencvforunity";
#endif



        // C++:  Ptr_BackgroundSubtractorCNT createBackgroundSubtractorCNT(int minPixelStability = 15, bool useHistory = true, int maxPixelStability = 15*60, bool isParallel = true)
        [DllImport (LIBNAME)]
        private static extern IntPtr bgsegm_Bgsegm_createBackgroundSubtractorCNT_10 (int minPixelStability, bool useHistory, int maxPixelStability, bool isParallel);
        [DllImport (LIBNAME)]
        private static extern IntPtr bgsegm_Bgsegm_createBackgroundSubtractorCNT_11 ();

        // C++:  Ptr_BackgroundSubtractorGMG createBackgroundSubtractorGMG(int initializationFrames = 120, double decisionThreshold = 0.8)
        [DllImport (LIBNAME)]
        private static extern IntPtr bgsegm_Bgsegm_createBackgroundSubtractorGMG_10 (int initializationFrames, double decisionThreshold);
        [DllImport (LIBNAME)]
        private static extern IntPtr bgsegm_Bgsegm_createBackgroundSubtractorGMG_11 ();

        // C++:  Ptr_BackgroundSubtractorGSOC createBackgroundSubtractorGSOC(int mc = LSBP_CAMERA_MOTION_COMPENSATION_NONE, int nSamples = 20, float replaceRate = 0.003f, float propagationRate = 0.01f, int hitsThreshold = 32, float alpha = 0.01f, float beta = 0.0022f, float blinkingSupressionDecay = 0.1f, float blinkingSupressionMultiplier = 0.1f, float noiseRemovalThresholdFacBG = 0.0004f, float noiseRemovalThresholdFacFG = 0.0008f)
        [DllImport (LIBNAME)]
        private static extern IntPtr bgsegm_Bgsegm_createBackgroundSubtractorGSOC_10 (int mc, int nSamples, float replaceRate, float propagationRate, int hitsThreshold, float alpha, float beta, float blinkingSupressionDecay, float blinkingSupressionMultiplier, float noiseRemovalThresholdFacBG, float noiseRemovalThresholdFacFG);
        [DllImport (LIBNAME)]
        private static extern IntPtr bgsegm_Bgsegm_createBackgroundSubtractorGSOC_11 ();

        // C++:  Ptr_BackgroundSubtractorLSBP createBackgroundSubtractorLSBP(int mc = LSBP_CAMERA_MOTION_COMPENSATION_NONE, int nSamples = 20, int LSBPRadius = 16, float Tlower = 2.0f, float Tupper = 32.0f, float Tinc = 1.0f, float Tdec = 0.05f, float Rscale = 10.0f, float Rincdec = 0.005f, float noiseRemovalThresholdFacBG = 0.0004f, float noiseRemovalThresholdFacFG = 0.0008f, int LSBPthreshold = 8, int minCount = 2)
        [DllImport (LIBNAME)]
        private static extern IntPtr bgsegm_Bgsegm_createBackgroundSubtractorLSBP_10 (int mc, int nSamples, int LSBPRadius, float Tlower, float Tupper, float Tinc, float Tdec, float Rscale, float Rincdec, float noiseRemovalThresholdFacBG, float noiseRemovalThresholdFacFG, int LSBPthreshold, int minCount);
        [DllImport (LIBNAME)]
        private static extern IntPtr bgsegm_Bgsegm_createBackgroundSubtractorLSBP_11 ();

        // C++:  Ptr_BackgroundSubtractorMOG createBackgroundSubtractorMOG(int history = 200, int nmixtures = 5, double backgroundRatio = 0.7, double noiseSigma = 0)
        [DllImport (LIBNAME)]
        private static extern IntPtr bgsegm_Bgsegm_createBackgroundSubtractorMOG_10 (int history, int nmixtures, double backgroundRatio, double noiseSigma);
        [DllImport (LIBNAME)]
        private static extern IntPtr bgsegm_Bgsegm_createBackgroundSubtractorMOG_11 ();

        // C++:  Ptr_SyntheticSequenceGenerator createSyntheticSequenceGenerator(Mat background, Mat _object, double amplitude = 2.0, double wavelength = 20.0, double wavespeed = 0.2, double objspeed = 6.0)
        [DllImport (LIBNAME)]
        private static extern IntPtr bgsegm_Bgsegm_createSyntheticSequenceGenerator_10 (IntPtr background_nativeObj, IntPtr _object_nativeObj, double amplitude, double wavelength, double wavespeed, double objspeed);
        [DllImport (LIBNAME)]
        private static extern IntPtr bgsegm_Bgsegm_createSyntheticSequenceGenerator_11 (IntPtr background_nativeObj, IntPtr _object_nativeObj);

    }
}
