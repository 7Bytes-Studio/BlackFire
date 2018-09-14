
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{

    // C++: class LATCH
    //javadoc: LATCH

    public class LATCH : Feature2D
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
try {
if (disposing) {
}
if (IsEnabledDispose) {
if (nativeObj != IntPtr.Zero)
xfeatures2d_LATCH_delete(nativeObj);
nativeObj = IntPtr.Zero;
}
} finally {
base.Dispose (disposing);
}
#else
            return;
#endif
        }

        protected internal LATCH (IntPtr addr) : base (addr) { }

        // internal usage only
        public static new LATCH __fromPtr__ (IntPtr addr) { return new LATCH (addr); }

        //
        // C++: static Ptr_LATCH create(int bytes = 32, bool rotationInvariance = true, int half_ssd_size = 3, double sigma = 2.0)
        //

        //javadoc: LATCH::create(bytes, rotationInvariance, half_ssd_size, sigma)
        public static LATCH create (int bytes, bool rotationInvariance, int half_ssd_size, double sigma)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        LATCH retVal = LATCH.__fromPtr__(xfeatures2d_LATCH_create_10(bytes, rotationInvariance, half_ssd_size, sigma));
        
        return retVal;
#else
            return null;
#endif
        }

        //javadoc: LATCH::create()
        public static LATCH create ()
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        LATCH retVal = LATCH.__fromPtr__(xfeatures2d_LATCH_create_11());
        
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



        // C++: static Ptr_LATCH create(int bytes = 32, bool rotationInvariance = true, int half_ssd_size = 3, double sigma = 2.0)
        [DllImport (LIBNAME)]
        private static extern IntPtr xfeatures2d_LATCH_create_10 (int bytes, bool rotationInvariance, int half_ssd_size, double sigma);
        [DllImport (LIBNAME)]
        private static extern IntPtr xfeatures2d_LATCH_create_11 ();

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void xfeatures2d_LATCH_delete (IntPtr nativeObj);

    }
}
