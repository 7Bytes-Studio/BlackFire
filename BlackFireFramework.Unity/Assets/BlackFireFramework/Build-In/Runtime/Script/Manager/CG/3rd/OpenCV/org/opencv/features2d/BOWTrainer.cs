

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{
    // C++: class BOWTrainer
    //javadoc: BOWTrainer

    public class BOWTrainer : DisposableOpenCVObject
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
            try {
                if (disposing) {
                }
                if (IsEnabledDispose) {
                    if (nativeObj != IntPtr.Zero)
                        features2d_BOWTrainer_delete (nativeObj);
                    nativeObj = IntPtr.Zero;
                }
            } finally {
                base.Dispose (disposing);
            }
#else
            return;
#endif
        }

        protected internal BOWTrainer (IntPtr addr)
            : base (addr)
        {
        }


        public IntPtr getNativeObjAddr ()
        {
            return nativeObj;
        }

        // internal usage only
        public static BOWTrainer __fromPtr__ (IntPtr addr)
        {
            return new BOWTrainer (addr);
        }

        //
        // C++:  Mat cluster(Mat descriptors)
        //

        //javadoc: BOWTrainer::cluster(descriptors)
        public virtual Mat cluster (Mat descriptors)
        {
            ThrowIfDisposed ();
            if (descriptors != null)
                descriptors.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            Mat retVal = new Mat (features2d_BOWTrainer_cluster_10 (nativeObj, descriptors.nativeObj));
        
            return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  Mat cluster()
        //

        //javadoc: BOWTrainer::cluster()
        public virtual Mat cluster ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            Mat retVal = new Mat (features2d_BOWTrainer_cluster_11 (nativeObj));
        
            return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  int descriptorsCount()
        //

        //javadoc: BOWTrainer::descriptorsCount()
        public int descriptorsCount ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            int retVal = features2d_BOWTrainer_descriptorsCount_10 (nativeObj);
        
            return retVal;
#else
            return -1;
#endif
        }


        //
        // C++:  vector_Mat getDescriptors()
        //

        //javadoc: BOWTrainer::getDescriptors()
        public List<Mat> getDescriptors ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
            List<Mat> retVal = new List<Mat> ();
            Mat retValMat = new Mat (features2d_BOWTrainer_getDescriptors_10 (nativeObj));
            Converters.Mat_to_vector_Mat (retValMat, retVal);
            return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  void add(Mat descriptors)
        //

        //javadoc: BOWTrainer::add(descriptors)
        public void add (Mat descriptors)
        {
            ThrowIfDisposed ();
            if (descriptors != null)
                descriptors.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            features2d_BOWTrainer_add_10 (nativeObj, descriptors.nativeObj);
        
            return;
#else
            return;
#endif
        }


        //
        // C++:  void clear()
        //

        //javadoc: BOWTrainer::clear()
        public void clear ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            features2d_BOWTrainer_clear_10 (nativeObj);
        
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



        // C++:  Mat cluster(Mat descriptors)
        [DllImport (LIBNAME)]
        private static extern IntPtr features2d_BOWTrainer_cluster_10 (IntPtr nativeObj, IntPtr descriptors_nativeObj);

        // C++:  Mat cluster()
        [DllImport (LIBNAME)]
        private static extern IntPtr features2d_BOWTrainer_cluster_11 (IntPtr nativeObj);

        // C++:  int descriptorsCount()
        [DllImport (LIBNAME)]
        private static extern int features2d_BOWTrainer_descriptorsCount_10 (IntPtr nativeObj);

        // C++:  vector_Mat getDescriptors()
        [DllImport (LIBNAME)]
        private static extern IntPtr features2d_BOWTrainer_getDescriptors_10 (IntPtr nativeObj);

        // C++:  void add(Mat descriptors)
        [DllImport (LIBNAME)]
        private static extern void features2d_BOWTrainer_add_10 (IntPtr nativeObj, IntPtr descriptors_nativeObj);

        // C++:  void clear()
        [DllImport (LIBNAME)]
        private static extern void features2d_BOWTrainer_clear_10 (IntPtr nativeObj);

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void features2d_BOWTrainer_delete (IntPtr nativeObj);

    }
}
