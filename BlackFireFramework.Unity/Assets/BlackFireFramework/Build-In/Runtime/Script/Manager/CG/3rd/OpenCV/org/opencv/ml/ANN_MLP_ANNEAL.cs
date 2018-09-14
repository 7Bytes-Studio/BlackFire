
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{

    // C++: class ANN_MLP_ANNEAL
    //javadoc: ANN_MLP_ANNEAL

    public class ANN_MLP_ANNEAL : ANN_MLP
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
            try {
                if (disposing) {
                }
                if (IsEnabledDispose) {
                    if (nativeObj != IntPtr.Zero)
                        ml_ANN_1MLP_1ANNEAL_delete (nativeObj);
                    nativeObj = IntPtr.Zero;
                }
            } finally {
                base.Dispose (disposing);
            }
#else
            return;
#endif
        }

        protected internal ANN_MLP_ANNEAL (IntPtr addr)
            : base (addr)
        {
        }

        // internal usage only
        public static new ANN_MLP_ANNEAL __fromPtr__ (IntPtr addr)
        {
            return new ANN_MLP_ANNEAL (addr);
        }

        //
        // C++:  double getAnnealCoolingRatio()
        //

        //javadoc: ANN_MLP_ANNEAL::getAnnealCoolingRatio()
        public override double getAnnealCoolingRatio ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            double retVal = ml_ANN_1MLP_1ANNEAL_getAnnealCoolingRatio_10 (nativeObj);
        
            return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  double getAnnealFinalT()
        //

        //javadoc: ANN_MLP_ANNEAL::getAnnealFinalT()
        public override double getAnnealFinalT ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            double retVal = ml_ANN_1MLP_1ANNEAL_getAnnealFinalT_10 (nativeObj);
        
            return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  double getAnnealInitialT()
        //

        //javadoc: ANN_MLP_ANNEAL::getAnnealInitialT()
        public override double getAnnealInitialT ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            double retVal = ml_ANN_1MLP_1ANNEAL_getAnnealInitialT_10 (nativeObj);
        
            return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  int getAnnealItePerStep()
        //

        //javadoc: ANN_MLP_ANNEAL::getAnnealItePerStep()
        public override int getAnnealItePerStep ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            int retVal = ml_ANN_1MLP_1ANNEAL_getAnnealItePerStep_10 (nativeObj);
        
            return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  void setAnnealCoolingRatio(double val)
        //

        //javadoc: ANN_MLP_ANNEAL::setAnnealCoolingRatio(val)
        public override void setAnnealCoolingRatio (double val)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            ml_ANN_1MLP_1ANNEAL_setAnnealCoolingRatio_10 (nativeObj, val);
        
            return;
#else
            return;
#endif
        }


        //
        // C++:  void setAnnealFinalT(double val)
        //

        //javadoc: ANN_MLP_ANNEAL::setAnnealFinalT(val)
        public override void setAnnealFinalT (double val)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            ml_ANN_1MLP_1ANNEAL_setAnnealFinalT_10 (nativeObj, val);
        
            return;
#else
            return;
#endif
        }


        //
        // C++:  void setAnnealInitialT(double val)
        //

        //javadoc: ANN_MLP_ANNEAL::setAnnealInitialT(val)
        public override void setAnnealInitialT (double val)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            ml_ANN_1MLP_1ANNEAL_setAnnealInitialT_10 (nativeObj, val);
        
            return;
#else
            return;
#endif
        }


        //
        // C++:  void setAnnealItePerStep(int val)
        //

        //javadoc: ANN_MLP_ANNEAL::setAnnealItePerStep(val)
        public override void setAnnealItePerStep (int val)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            ml_ANN_1MLP_1ANNEAL_setAnnealItePerStep_10 (nativeObj, val);
        
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



        // C++:  double getAnnealCoolingRatio()
        [DllImport (LIBNAME)]
        private static extern double ml_ANN_1MLP_1ANNEAL_getAnnealCoolingRatio_10 (IntPtr nativeObj);

        // C++:  double getAnnealFinalT()
        [DllImport (LIBNAME)]
        private static extern double ml_ANN_1MLP_1ANNEAL_getAnnealFinalT_10 (IntPtr nativeObj);

        // C++:  double getAnnealInitialT()
        [DllImport (LIBNAME)]
        private static extern double ml_ANN_1MLP_1ANNEAL_getAnnealInitialT_10 (IntPtr nativeObj);

        // C++:  int getAnnealItePerStep()
        [DllImport (LIBNAME)]
        private static extern int ml_ANN_1MLP_1ANNEAL_getAnnealItePerStep_10 (IntPtr nativeObj);

        // C++:  void setAnnealCoolingRatio(double val)
        [DllImport (LIBNAME)]
        private static extern void ml_ANN_1MLP_1ANNEAL_setAnnealCoolingRatio_10 (IntPtr nativeObj, double val);

        // C++:  void setAnnealFinalT(double val)
        [DllImport (LIBNAME)]
        private static extern void ml_ANN_1MLP_1ANNEAL_setAnnealFinalT_10 (IntPtr nativeObj, double val);

        // C++:  void setAnnealInitialT(double val)
        [DllImport (LIBNAME)]
        private static extern void ml_ANN_1MLP_1ANNEAL_setAnnealInitialT_10 (IntPtr nativeObj, double val);

        // C++:  void setAnnealItePerStep(int val)
        [DllImport (LIBNAME)]
        private static extern void ml_ANN_1MLP_1ANNEAL_setAnnealItePerStep_10 (IntPtr nativeObj, int val);

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void ml_ANN_1MLP_1ANNEAL_delete (IntPtr nativeObj);

    }
}
