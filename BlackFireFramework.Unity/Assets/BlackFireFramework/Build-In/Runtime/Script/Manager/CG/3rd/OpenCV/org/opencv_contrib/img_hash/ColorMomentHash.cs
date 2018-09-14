
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{

    // C++: class ColorMomentHash
    //javadoc: ColorMomentHash

    public class ColorMomentHash : ImgHashBase
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
try {
if (disposing) {
}
if (IsEnabledDispose) {
if (nativeObj != IntPtr.Zero)
img_1hash_ColorMomentHash_delete(nativeObj);
nativeObj = IntPtr.Zero;
}
} finally {
base.Dispose (disposing);
}
#else
            return;
#endif
        }

        protected internal ColorMomentHash (IntPtr addr) : base (addr) { }

        // internal usage only
        public static new ColorMomentHash __fromPtr__ (IntPtr addr) { return new ColorMomentHash (addr); }

        //
        // C++: static Ptr_ColorMomentHash create()
        //

        //javadoc: ColorMomentHash::create()
        public static ColorMomentHash create ()
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        ColorMomentHash retVal = ColorMomentHash.__fromPtr__(img_1hash_ColorMomentHash_create_10());
        
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



        // C++: static Ptr_ColorMomentHash create()
        [DllImport (LIBNAME)]
        private static extern IntPtr img_1hash_ColorMomentHash_create_10 ();

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void img_1hash_ColorMomentHash_delete (IntPtr nativeObj);

    }
}
