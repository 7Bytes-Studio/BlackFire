
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{

    // C++: class BlockMeanHash
    //javadoc: BlockMeanHash

    public class BlockMeanHash : ImgHashBase
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
try {
if (disposing) {
}
if (IsEnabledDispose) {
if (nativeObj != IntPtr.Zero)
img_1hash_BlockMeanHash_delete(nativeObj);
nativeObj = IntPtr.Zero;
}
} finally {
base.Dispose (disposing);
}
#else
            return;
#endif
        }

        protected internal BlockMeanHash (IntPtr addr) : base (addr) { }

        // internal usage only
        public static new BlockMeanHash __fromPtr__ (IntPtr addr) { return new BlockMeanHash (addr); }

        //
        // C++: static Ptr_BlockMeanHash create(int mode = BLOCK_MEAN_HASH_MODE_0)
        //

        //javadoc: BlockMeanHash::create(mode)
        public static BlockMeanHash create (int mode)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        BlockMeanHash retVal = BlockMeanHash.__fromPtr__(img_1hash_BlockMeanHash_create_10(mode));
        
        return retVal;
#else
            return null;
#endif
        }

        //javadoc: BlockMeanHash::create()
        public static BlockMeanHash create ()
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        BlockMeanHash retVal = BlockMeanHash.__fromPtr__(img_1hash_BlockMeanHash_create_11());
        
        return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  vector_double getMean()
        //

        //javadoc: BlockMeanHash::getMean()
        public MatOfDouble getMean ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        MatOfDouble retVal = MatOfDouble.fromNativeAddr(img_1hash_BlockMeanHash_getMean_10(nativeObj));
        
        return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  void setMode(int mode)
        //

        //javadoc: BlockMeanHash::setMode(mode)
        public void setMode (int mode)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        img_1hash_BlockMeanHash_setMode_10(nativeObj, mode);
        
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



        // C++: static Ptr_BlockMeanHash create(int mode = BLOCK_MEAN_HASH_MODE_0)
        [DllImport (LIBNAME)]
        private static extern IntPtr img_1hash_BlockMeanHash_create_10 (int mode);
        [DllImport (LIBNAME)]
        private static extern IntPtr img_1hash_BlockMeanHash_create_11 ();

        // C++:  vector_double getMean()
        [DllImport (LIBNAME)]
        private static extern IntPtr img_1hash_BlockMeanHash_getMean_10 (IntPtr nativeObj);

        // C++:  void setMode(int mode)
        [DllImport (LIBNAME)]
        private static extern void img_1hash_BlockMeanHash_setMode_10 (IntPtr nativeObj, int mode);

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void img_1hash_BlockMeanHash_delete (IntPtr nativeObj);

    }
}
