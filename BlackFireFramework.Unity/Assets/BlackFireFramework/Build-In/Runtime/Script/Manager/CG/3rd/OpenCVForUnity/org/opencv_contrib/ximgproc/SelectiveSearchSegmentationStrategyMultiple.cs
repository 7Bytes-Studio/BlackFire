
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{

    // C++: class SelectiveSearchSegmentationStrategyMultiple
    //javadoc: SelectiveSearchSegmentationStrategyMultiple

    public class SelectiveSearchSegmentationStrategyMultiple : SelectiveSearchSegmentationStrategy
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
try {
if (disposing) {
}
if (IsEnabledDispose) {
if (nativeObj != IntPtr.Zero)
ximgproc_SelectiveSearchSegmentationStrategyMultiple_delete(nativeObj);
nativeObj = IntPtr.Zero;
}
} finally {
base.Dispose (disposing);
}
#else
            return;
#endif
        }

        protected internal SelectiveSearchSegmentationStrategyMultiple (IntPtr addr) : base (addr) { }

        // internal usage only
        public static new SelectiveSearchSegmentationStrategyMultiple __fromPtr__ (IntPtr addr) { return new SelectiveSearchSegmentationStrategyMultiple (addr); }

        //
        // C++:  void addStrategy(Ptr_SelectiveSearchSegmentationStrategy g, float weight)
        //

        //javadoc: SelectiveSearchSegmentationStrategyMultiple::addStrategy(g, weight)
        public void addStrategy (SelectiveSearchSegmentationStrategy g, float weight)
        {
            ThrowIfDisposed ();
            if (g != null) g.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        ximgproc_SelectiveSearchSegmentationStrategyMultiple_addStrategy_10(nativeObj, g.getNativeObjAddr(), weight);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void clearStrategies()
        //

        //javadoc: SelectiveSearchSegmentationStrategyMultiple::clearStrategies()
        public void clearStrategies ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        ximgproc_SelectiveSearchSegmentationStrategyMultiple_clearStrategies_10(nativeObj);
        
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



        // C++:  void addStrategy(Ptr_SelectiveSearchSegmentationStrategy g, float weight)
        [DllImport (LIBNAME)]
        private static extern void ximgproc_SelectiveSearchSegmentationStrategyMultiple_addStrategy_10 (IntPtr nativeObj, IntPtr g_nativeObj, float weight);

        // C++:  void clearStrategies()
        [DllImport (LIBNAME)]
        private static extern void ximgproc_SelectiveSearchSegmentationStrategyMultiple_clearStrategies_10 (IntPtr nativeObj);

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void ximgproc_SelectiveSearchSegmentationStrategyMultiple_delete (IntPtr nativeObj);

    }
}
