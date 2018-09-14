
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{

    // C++: class MarrHildrethHash
    //javadoc: MarrHildrethHash

    public class MarrHildrethHash : ImgHashBase
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
try {
if (disposing) {
}
if (IsEnabledDispose) {
if (nativeObj != IntPtr.Zero)
img_1hash_MarrHildrethHash_delete(nativeObj);
nativeObj = IntPtr.Zero;
}
} finally {
base.Dispose (disposing);
}
#else
            return;
#endif
        }

        protected internal MarrHildrethHash (IntPtr addr) : base (addr) { }

        // internal usage only
        public static new MarrHildrethHash __fromPtr__ (IntPtr addr) { return new MarrHildrethHash (addr); }

        //
        // C++: static Ptr_MarrHildrethHash create(float alpha = 2.0f, float scale = 1.0f)
        //

        //javadoc: MarrHildrethHash::create(alpha, scale)
        public static MarrHildrethHash create (float alpha, float scale)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        MarrHildrethHash retVal = MarrHildrethHash.__fromPtr__(img_1hash_MarrHildrethHash_create_10(alpha, scale));
        
        return retVal;
#else
            return null;
#endif
        }

        //javadoc: MarrHildrethHash::create()
        public static MarrHildrethHash create ()
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        MarrHildrethHash retVal = MarrHildrethHash.__fromPtr__(img_1hash_MarrHildrethHash_create_11());
        
        return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  float getAlpha()
        //

        //javadoc: MarrHildrethHash::getAlpha()
        public float getAlpha ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        float retVal = img_1hash_MarrHildrethHash_getAlpha_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  float getScale()
        //

        //javadoc: MarrHildrethHash::getScale()
        public float getScale ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        float retVal = img_1hash_MarrHildrethHash_getScale_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  void setKernelParam(float alpha, float scale)
        //

        //javadoc: MarrHildrethHash::setKernelParam(alpha, scale)
        public void setKernelParam (float alpha, float scale)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        img_1hash_MarrHildrethHash_setKernelParam_10(nativeObj, alpha, scale);
        
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



        // C++: static Ptr_MarrHildrethHash create(float alpha = 2.0f, float scale = 1.0f)
        [DllImport (LIBNAME)]
        private static extern IntPtr img_1hash_MarrHildrethHash_create_10 (float alpha, float scale);
        [DllImport (LIBNAME)]
        private static extern IntPtr img_1hash_MarrHildrethHash_create_11 ();

        // C++:  float getAlpha()
        [DllImport (LIBNAME)]
        private static extern float img_1hash_MarrHildrethHash_getAlpha_10 (IntPtr nativeObj);

        // C++:  float getScale()
        [DllImport (LIBNAME)]
        private static extern float img_1hash_MarrHildrethHash_getScale_10 (IntPtr nativeObj);

        // C++:  void setKernelParam(float alpha, float scale)
        [DllImport (LIBNAME)]
        private static extern void img_1hash_MarrHildrethHash_setKernelParam_10 (IntPtr nativeObj, float alpha, float scale);

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void img_1hash_MarrHildrethHash_delete (IntPtr nativeObj);

    }
}
