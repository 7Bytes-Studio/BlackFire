
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{

    // C++: class SVM
    //javadoc: SVM

    public class SVM : StatModel
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
try {
if (disposing) {
}
if (IsEnabledDispose) {
if (nativeObj != IntPtr.Zero)
ml_SVM_delete(nativeObj);
nativeObj = IntPtr.Zero;
}
} finally {
base.Dispose (disposing);
}
#else
            return;
#endif
        }

        protected internal SVM (IntPtr addr) : base (addr) { }

        // internal usage only
        public static new SVM __fromPtr__ (IntPtr addr) { return new SVM (addr); }

        public const int C_SVC = 100;
        public const int NU_SVC = 101;
        public const int ONE_CLASS = 102;
        public const int EPS_SVR = 103;
        public const int NU_SVR = 104;
        public const int CUSTOM = -1;
        public const int LINEAR = 0;
        public const int POLY = 1;
        public const int RBF = 2;
        public const int SIGMOID = 3;
        public const int CHI2 = 4;
        public const int INTER = 5;
        public const int C = 0;
        public const int GAMMA = 1;
        public const int P = 2;
        public const int NU = 3;
        public const int COEF = 4;
        public const int DEGREE = 5;
        //
        // C++:  Mat getClassWeights()
        //

        //javadoc: SVM::getClassWeights()
        public Mat getClassWeights ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        Mat retVal = new Mat(ml_SVM_getClassWeights_10(nativeObj));
        
        return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  Mat getSupportVectors()
        //

        //javadoc: SVM::getSupportVectors()
        public Mat getSupportVectors ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        Mat retVal = new Mat(ml_SVM_getSupportVectors_10(nativeObj));
        
        return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  Mat getUncompressedSupportVectors()
        //

        //javadoc: SVM::getUncompressedSupportVectors()
        public Mat getUncompressedSupportVectors ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        Mat retVal = new Mat(ml_SVM_getUncompressedSupportVectors_10(nativeObj));
        
        return retVal;
#else
            return null;
#endif
        }


        //
        // C++: static Ptr_ParamGrid getDefaultGridPtr(int param_id)
        //

        //javadoc: SVM::getDefaultGridPtr(param_id)
        public static ParamGrid getDefaultGridPtr (int param_id)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        ParamGrid retVal = ParamGrid.__fromPtr__(ml_SVM_getDefaultGridPtr_10(param_id));
        
        return retVal;
#else
            return null;
#endif
        }


        //
        // C++: static Ptr_SVM create()
        //

        //javadoc: SVM::create()
        public static SVM create ()
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        SVM retVal = SVM.__fromPtr__(ml_SVM_create_10());
        
        return retVal;
#else
            return null;
#endif
        }


        //
        // C++: static Ptr_SVM load(String filepath)
        //

        //javadoc: SVM::load(filepath)
        public static SVM load (string filepath)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        SVM retVal = SVM.__fromPtr__(ml_SVM_load_10(filepath));
        
        return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  TermCriteria getTermCriteria()
        //

        //javadoc: SVM::getTermCriteria()
        public TermCriteria getTermCriteria ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        double[] tmpArray = new double[3];
ml_SVM_getTermCriteria_10(nativeObj, tmpArray);
TermCriteria retVal = new TermCriteria (tmpArray);
        
        return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  bool trainAuto(Mat samples, int layout, Mat responses, int kFold = 10, Ptr_ParamGrid Cgrid = SVM::getDefaultGridPtr(SVM::C), Ptr_ParamGrid gammaGrid = SVM::getDefaultGridPtr(SVM::GAMMA), Ptr_ParamGrid pGrid = SVM::getDefaultGridPtr(SVM::P), Ptr_ParamGrid nuGrid = SVM::getDefaultGridPtr(SVM::NU), Ptr_ParamGrid coeffGrid = SVM::getDefaultGridPtr(SVM::COEF), Ptr_ParamGrid degreeGrid = SVM::getDefaultGridPtr(SVM::DEGREE), bool balanced = false)
        //

        //javadoc: SVM::trainAuto(samples, layout, responses, kFold, Cgrid, gammaGrid, pGrid, nuGrid, coeffGrid, degreeGrid, balanced)
        public bool trainAuto (Mat samples, int layout, Mat responses, int kFold, ParamGrid Cgrid, ParamGrid gammaGrid, ParamGrid pGrid, ParamGrid nuGrid, ParamGrid coeffGrid, ParamGrid degreeGrid, bool balanced)
        {
            ThrowIfDisposed ();
            if (samples != null) samples.ThrowIfDisposed ();
            if (responses != null) responses.ThrowIfDisposed ();
            if (Cgrid != null) Cgrid.ThrowIfDisposed ();
            if (gammaGrid != null) gammaGrid.ThrowIfDisposed ();
            if (pGrid != null) pGrid.ThrowIfDisposed ();
            if (nuGrid != null) nuGrid.ThrowIfDisposed ();
            if (coeffGrid != null) coeffGrid.ThrowIfDisposed ();
            if (degreeGrid != null) degreeGrid.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bool retVal = ml_SVM_trainAuto_10(nativeObj, samples.nativeObj, layout, responses.nativeObj, kFold, Cgrid.getNativeObjAddr(), gammaGrid.getNativeObjAddr(), pGrid.getNativeObjAddr(), nuGrid.getNativeObjAddr(), coeffGrid.getNativeObjAddr(), degreeGrid.getNativeObjAddr(), balanced);
        
        return retVal;
#else
            return false;
#endif
        }

        //javadoc: SVM::trainAuto(samples, layout, responses)
        public bool trainAuto (Mat samples, int layout, Mat responses)
        {
            ThrowIfDisposed ();
            if (samples != null) samples.ThrowIfDisposed ();
            if (responses != null) responses.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bool retVal = ml_SVM_trainAuto_11(nativeObj, samples.nativeObj, layout, responses.nativeObj);
        
        return retVal;
#else
            return false;
#endif
        }


        //
        // C++:  double getC()
        //

        //javadoc: SVM::getC()
        public double getC ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        double retVal = ml_SVM_getC_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  double getCoef0()
        //

        //javadoc: SVM::getCoef0()
        public double getCoef0 ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        double retVal = ml_SVM_getCoef0_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  double getDecisionFunction(int i, Mat& alpha, Mat& svidx)
        //

        //javadoc: SVM::getDecisionFunction(i, alpha, svidx)
        public double getDecisionFunction (int i, Mat alpha, Mat svidx)
        {
            ThrowIfDisposed ();
            if (alpha != null) alpha.ThrowIfDisposed ();
            if (svidx != null) svidx.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        double retVal = ml_SVM_getDecisionFunction_10(nativeObj, i, alpha.nativeObj, svidx.nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  double getDegree()
        //

        //javadoc: SVM::getDegree()
        public double getDegree ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        double retVal = ml_SVM_getDegree_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  double getGamma()
        //

        //javadoc: SVM::getGamma()
        public double getGamma ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        double retVal = ml_SVM_getGamma_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  double getNu()
        //

        //javadoc: SVM::getNu()
        public double getNu ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        double retVal = ml_SVM_getNu_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  double getP()
        //

        //javadoc: SVM::getP()
        public double getP ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        double retVal = ml_SVM_getP_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  int getKernelType()
        //

        //javadoc: SVM::getKernelType()
        public int getKernelType ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        int retVal = ml_SVM_getKernelType_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  int getType()
        //

        //javadoc: SVM::getType()
        public int getType ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        int retVal = ml_SVM_getType_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  void setC(double val)
        //

        //javadoc: SVM::setC(val)
        public void setC (double val)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        ml_SVM_setC_10(nativeObj, val);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setClassWeights(Mat val)
        //

        //javadoc: SVM::setClassWeights(val)
        public void setClassWeights (Mat val)
        {
            ThrowIfDisposed ();
            if (val != null) val.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        ml_SVM_setClassWeights_10(nativeObj, val.nativeObj);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setCoef0(double val)
        //

        //javadoc: SVM::setCoef0(val)
        public void setCoef0 (double val)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        ml_SVM_setCoef0_10(nativeObj, val);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setDegree(double val)
        //

        //javadoc: SVM::setDegree(val)
        public void setDegree (double val)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        ml_SVM_setDegree_10(nativeObj, val);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setGamma(double val)
        //

        //javadoc: SVM::setGamma(val)
        public void setGamma (double val)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        ml_SVM_setGamma_10(nativeObj, val);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setKernel(int kernelType)
        //

        //javadoc: SVM::setKernel(kernelType)
        public void setKernel (int kernelType)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        ml_SVM_setKernel_10(nativeObj, kernelType);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setNu(double val)
        //

        //javadoc: SVM::setNu(val)
        public void setNu (double val)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        ml_SVM_setNu_10(nativeObj, val);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setP(double val)
        //

        //javadoc: SVM::setP(val)
        public void setP (double val)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        ml_SVM_setP_10(nativeObj, val);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setTermCriteria(TermCriteria val)
        //

        //javadoc: SVM::setTermCriteria(val)
        public void setTermCriteria (TermCriteria val)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        ml_SVM_setTermCriteria_10(nativeObj, val.type, val.maxCount, val.epsilon);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setType(int val)
        //

        //javadoc: SVM::setType(val)
        public void setType (int val)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        ml_SVM_setType_10(nativeObj, val);
        
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



        // C++:  Mat getClassWeights()
        [DllImport (LIBNAME)]
        private static extern IntPtr ml_SVM_getClassWeights_10 (IntPtr nativeObj);

        // C++:  Mat getSupportVectors()
        [DllImport (LIBNAME)]
        private static extern IntPtr ml_SVM_getSupportVectors_10 (IntPtr nativeObj);

        // C++:  Mat getUncompressedSupportVectors()
        [DllImport (LIBNAME)]
        private static extern IntPtr ml_SVM_getUncompressedSupportVectors_10 (IntPtr nativeObj);

        // C++: static Ptr_ParamGrid getDefaultGridPtr(int param_id)
        [DllImport (LIBNAME)]
        private static extern IntPtr ml_SVM_getDefaultGridPtr_10 (int param_id);

        // C++: static Ptr_SVM create()
        [DllImport (LIBNAME)]
        private static extern IntPtr ml_SVM_create_10 ();

        // C++: static Ptr_SVM load(String filepath)
        [DllImport (LIBNAME)]
        private static extern IntPtr ml_SVM_load_10 (string filepath);

        // C++:  TermCriteria getTermCriteria()
        [DllImport (LIBNAME)]
        private static extern void ml_SVM_getTermCriteria_10 (IntPtr nativeObj, double[] retVal);

        // C++:  bool trainAuto(Mat samples, int layout, Mat responses, int kFold = 10, Ptr_ParamGrid Cgrid = SVM::getDefaultGridPtr(SVM::C), Ptr_ParamGrid gammaGrid = SVM::getDefaultGridPtr(SVM::GAMMA), Ptr_ParamGrid pGrid = SVM::getDefaultGridPtr(SVM::P), Ptr_ParamGrid nuGrid = SVM::getDefaultGridPtr(SVM::NU), Ptr_ParamGrid coeffGrid = SVM::getDefaultGridPtr(SVM::COEF), Ptr_ParamGrid degreeGrid = SVM::getDefaultGridPtr(SVM::DEGREE), bool balanced = false)
        [DllImport (LIBNAME)]
        private static extern bool ml_SVM_trainAuto_10 (IntPtr nativeObj, IntPtr samples_nativeObj, int layout, IntPtr responses_nativeObj, int kFold, IntPtr Cgrid_nativeObj, IntPtr gammaGrid_nativeObj, IntPtr pGrid_nativeObj, IntPtr nuGrid_nativeObj, IntPtr coeffGrid_nativeObj, IntPtr degreeGrid_nativeObj, bool balanced);
        [DllImport (LIBNAME)]
        private static extern bool ml_SVM_trainAuto_11 (IntPtr nativeObj, IntPtr samples_nativeObj, int layout, IntPtr responses_nativeObj);

        // C++:  double getC()
        [DllImport (LIBNAME)]
        private static extern double ml_SVM_getC_10 (IntPtr nativeObj);

        // C++:  double getCoef0()
        [DllImport (LIBNAME)]
        private static extern double ml_SVM_getCoef0_10 (IntPtr nativeObj);

        // C++:  double getDecisionFunction(int i, Mat& alpha, Mat& svidx)
        [DllImport (LIBNAME)]
        private static extern double ml_SVM_getDecisionFunction_10 (IntPtr nativeObj, int i, IntPtr alpha_nativeObj, IntPtr svidx_nativeObj);

        // C++:  double getDegree()
        [DllImport (LIBNAME)]
        private static extern double ml_SVM_getDegree_10 (IntPtr nativeObj);

        // C++:  double getGamma()
        [DllImport (LIBNAME)]
        private static extern double ml_SVM_getGamma_10 (IntPtr nativeObj);

        // C++:  double getNu()
        [DllImport (LIBNAME)]
        private static extern double ml_SVM_getNu_10 (IntPtr nativeObj);

        // C++:  double getP()
        [DllImport (LIBNAME)]
        private static extern double ml_SVM_getP_10 (IntPtr nativeObj);

        // C++:  int getKernelType()
        [DllImport (LIBNAME)]
        private static extern int ml_SVM_getKernelType_10 (IntPtr nativeObj);

        // C++:  int getType()
        [DllImport (LIBNAME)]
        private static extern int ml_SVM_getType_10 (IntPtr nativeObj);

        // C++:  void setC(double val)
        [DllImport (LIBNAME)]
        private static extern void ml_SVM_setC_10 (IntPtr nativeObj, double val);

        // C++:  void setClassWeights(Mat val)
        [DllImport (LIBNAME)]
        private static extern void ml_SVM_setClassWeights_10 (IntPtr nativeObj, IntPtr val_nativeObj);

        // C++:  void setCoef0(double val)
        [DllImport (LIBNAME)]
        private static extern void ml_SVM_setCoef0_10 (IntPtr nativeObj, double val);

        // C++:  void setDegree(double val)
        [DllImport (LIBNAME)]
        private static extern void ml_SVM_setDegree_10 (IntPtr nativeObj, double val);

        // C++:  void setGamma(double val)
        [DllImport (LIBNAME)]
        private static extern void ml_SVM_setGamma_10 (IntPtr nativeObj, double val);

        // C++:  void setKernel(int kernelType)
        [DllImport (LIBNAME)]
        private static extern void ml_SVM_setKernel_10 (IntPtr nativeObj, int kernelType);

        // C++:  void setNu(double val)
        [DllImport (LIBNAME)]
        private static extern void ml_SVM_setNu_10 (IntPtr nativeObj, double val);

        // C++:  void setP(double val)
        [DllImport (LIBNAME)]
        private static extern void ml_SVM_setP_10 (IntPtr nativeObj, double val);

        // C++:  void setTermCriteria(TermCriteria val)
        [DllImport (LIBNAME)]
        private static extern void ml_SVM_setTermCriteria_10 (IntPtr nativeObj, int val_type, int val_maxCount, double val_epsilon);

        // C++:  void setType(int val)
        [DllImport (LIBNAME)]
        private static extern void ml_SVM_setType_10 (IntPtr nativeObj, int val);

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void ml_SVM_delete (IntPtr nativeObj);

    }
}
