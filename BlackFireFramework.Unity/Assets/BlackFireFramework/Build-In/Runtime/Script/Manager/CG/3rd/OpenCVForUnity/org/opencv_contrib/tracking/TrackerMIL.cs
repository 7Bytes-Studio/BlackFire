
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{

    // C++: class TrackerMIL
    //javadoc: TrackerMIL

    public class TrackerMIL : Tracker
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
try {
if (disposing) {
}
if (IsEnabledDispose) {
if (nativeObj != IntPtr.Zero)
tracking_TrackerMIL_delete(nativeObj);
nativeObj = IntPtr.Zero;
}
} finally {
base.Dispose (disposing);
}
#else
            return;
#endif
        }

        protected internal TrackerMIL (IntPtr addr) : base (addr) { }

        // internal usage only
        public static new TrackerMIL __fromPtr__ (IntPtr addr) { return new TrackerMIL (addr); }

        //
        // C++: static Ptr_TrackerMIL create()
        //

        //javadoc: TrackerMIL::create()
        public static TrackerMIL create ()
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        TrackerMIL retVal = TrackerMIL.__fromPtr__(tracking_TrackerMIL_create_10());
        
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



        // C++: static Ptr_TrackerMIL create()
        [DllImport (LIBNAME)]
        private static extern IntPtr tracking_TrackerMIL_create_10 ();

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void tracking_TrackerMIL_delete (IntPtr nativeObj);

    }
}
