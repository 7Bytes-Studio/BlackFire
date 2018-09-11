
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{

    // C++: class VGG
    //javadoc: VGG

    public class VGG : Feature2D
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
try {
if (disposing) {
}
if (IsEnabledDispose) {
if (nativeObj != IntPtr.Zero)
xfeatures2d_VGG_delete(nativeObj);
nativeObj = IntPtr.Zero;
}
} finally {
base.Dispose (disposing);
}
#else
            return;
#endif
        }

        protected internal VGG (IntPtr addr) : base (addr) { }

        // internal usage only
        public static new VGG __fromPtr__ (IntPtr addr) { return new VGG (addr); }

        //
        // C++: static Ptr_VGG create(int desc = VGG::VGG_120, float isigma = 1.4f, bool img_normalize = true, bool use_scale_orientation = true, float scale_factor = 6.25f, bool dsc_normalize = false)
        //

        //javadoc: VGG::create(desc, isigma, img_normalize, use_scale_orientation, scale_factor, dsc_normalize)
        public static VGG create (int desc, float isigma, bool img_normalize, bool use_scale_orientation, float scale_factor, bool dsc_normalize)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        VGG retVal = VGG.__fromPtr__(xfeatures2d_VGG_create_10(desc, isigma, img_normalize, use_scale_orientation, scale_factor, dsc_normalize));
        
        return retVal;
#else
            return null;
#endif
        }

        //javadoc: VGG::create()
        public static VGG create ()
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        VGG retVal = VGG.__fromPtr__(xfeatures2d_VGG_create_11());
        
        return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  bool getUseNormalizeDescriptor()
        //

        //javadoc: VGG::getUseNormalizeDescriptor()
        public bool getUseNormalizeDescriptor ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bool retVal = xfeatures2d_VGG_getUseNormalizeDescriptor_10(nativeObj);
        
        return retVal;
#else
            return false;
#endif
        }


        //
        // C++:  bool getUseNormalizeImage()
        //

        //javadoc: VGG::getUseNormalizeImage()
        public bool getUseNormalizeImage ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bool retVal = xfeatures2d_VGG_getUseNormalizeImage_10(nativeObj);
        
        return retVal;
#else
            return false;
#endif
        }


        //
        // C++:  bool getUseScaleOrientation()
        //

        //javadoc: VGG::getUseScaleOrientation()
        public bool getUseScaleOrientation ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bool retVal = xfeatures2d_VGG_getUseScaleOrientation_10(nativeObj);
        
        return retVal;
#else
            return false;
#endif
        }


        //
        // C++:  float getScaleFactor()
        //

        //javadoc: VGG::getScaleFactor()
        public float getScaleFactor ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        float retVal = xfeatures2d_VGG_getScaleFactor_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  float getSigma()
        //

        //javadoc: VGG::getSigma()
        public float getSigma ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        float retVal = xfeatures2d_VGG_getSigma_10(nativeObj);
        
        return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  void setScaleFactor(float scale_factor)
        //

        //javadoc: VGG::setScaleFactor(scale_factor)
        public void setScaleFactor (float scale_factor)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        xfeatures2d_VGG_setScaleFactor_10(nativeObj, scale_factor);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setSigma(float isigma)
        //

        //javadoc: VGG::setSigma(isigma)
        public void setSigma (float isigma)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        xfeatures2d_VGG_setSigma_10(nativeObj, isigma);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setUseNormalizeDescriptor(bool dsc_normalize)
        //

        //javadoc: VGG::setUseNormalizeDescriptor(dsc_normalize)
        public void setUseNormalizeDescriptor (bool dsc_normalize)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        xfeatures2d_VGG_setUseNormalizeDescriptor_10(nativeObj, dsc_normalize);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setUseNormalizeImage(bool img_normalize)
        //

        //javadoc: VGG::setUseNormalizeImage(img_normalize)
        public void setUseNormalizeImage (bool img_normalize)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        xfeatures2d_VGG_setUseNormalizeImage_10(nativeObj, img_normalize);
        
        return;
#else
            return;
#endif
        }


        //
        // C++:  void setUseScaleOrientation(bool use_scale_orientation)
        //

        //javadoc: VGG::setUseScaleOrientation(use_scale_orientation)
        public void setUseScaleOrientation (bool use_scale_orientation)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        xfeatures2d_VGG_setUseScaleOrientation_10(nativeObj, use_scale_orientation);
        
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



        // C++: static Ptr_VGG create(int desc = VGG::VGG_120, float isigma = 1.4f, bool img_normalize = true, bool use_scale_orientation = true, float scale_factor = 6.25f, bool dsc_normalize = false)
        [DllImport (LIBNAME)]
        private static extern IntPtr xfeatures2d_VGG_create_10 (int desc, float isigma, bool img_normalize, bool use_scale_orientation, float scale_factor, bool dsc_normalize);
        [DllImport (LIBNAME)]
        private static extern IntPtr xfeatures2d_VGG_create_11 ();

        // C++:  bool getUseNormalizeDescriptor()
        [DllImport (LIBNAME)]
        private static extern bool xfeatures2d_VGG_getUseNormalizeDescriptor_10 (IntPtr nativeObj);

        // C++:  bool getUseNormalizeImage()
        [DllImport (LIBNAME)]
        private static extern bool xfeatures2d_VGG_getUseNormalizeImage_10 (IntPtr nativeObj);

        // C++:  bool getUseScaleOrientation()
        [DllImport (LIBNAME)]
        private static extern bool xfeatures2d_VGG_getUseScaleOrientation_10 (IntPtr nativeObj);

        // C++:  float getScaleFactor()
        [DllImport (LIBNAME)]
        private static extern float xfeatures2d_VGG_getScaleFactor_10 (IntPtr nativeObj);

        // C++:  float getSigma()
        [DllImport (LIBNAME)]
        private static extern float xfeatures2d_VGG_getSigma_10 (IntPtr nativeObj);

        // C++:  void setScaleFactor(float scale_factor)
        [DllImport (LIBNAME)]
        private static extern void xfeatures2d_VGG_setScaleFactor_10 (IntPtr nativeObj, float scale_factor);

        // C++:  void setSigma(float isigma)
        [DllImport (LIBNAME)]
        private static extern void xfeatures2d_VGG_setSigma_10 (IntPtr nativeObj, float isigma);

        // C++:  void setUseNormalizeDescriptor(bool dsc_normalize)
        [DllImport (LIBNAME)]
        private static extern void xfeatures2d_VGG_setUseNormalizeDescriptor_10 (IntPtr nativeObj, bool dsc_normalize);

        // C++:  void setUseNormalizeImage(bool img_normalize)
        [DllImport (LIBNAME)]
        private static extern void xfeatures2d_VGG_setUseNormalizeImage_10 (IntPtr nativeObj, bool img_normalize);

        // C++:  void setUseScaleOrientation(bool use_scale_orientation)
        [DllImport (LIBNAME)]
        private static extern void xfeatures2d_VGG_setUseScaleOrientation_10 (IntPtr nativeObj, bool use_scale_orientation);

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void xfeatures2d_VGG_delete (IntPtr nativeObj);

    }
}
