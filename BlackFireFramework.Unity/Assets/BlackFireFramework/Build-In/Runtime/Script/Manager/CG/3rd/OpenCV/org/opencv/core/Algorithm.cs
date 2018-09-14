

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{
    // C++: class Algorithm
    //javadoc: Algorithm

    public class Algorithm : DisposableOpenCVObject
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
            try {
                if (disposing) {
                }
                if (IsEnabledDispose) {
                    if (nativeObj != IntPtr.Zero)
                        core_Algorithm_delete (nativeObj);
                    nativeObj = IntPtr.Zero;
                }
            } finally {
                base.Dispose (disposing);
            }
#else
            return;
#endif
        }

        protected internal Algorithm (IntPtr addr)
            : base (addr)
        {
        }


        public IntPtr getNativeObjAddr ()
        {
            return nativeObj;
        }

        // internal usage only
        public static Algorithm __fromPtr__ (IntPtr addr)
        {
            return new Algorithm (addr);
        }

        //
        // C++:  String getDefaultName()
        //

        //javadoc: Algorithm::getDefaultName()
        public virtual string getDefaultName ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            string retVal = Marshal.PtrToStringAnsi (core_Algorithm_getDefaultName_10 (nativeObj));
        
            return retVal;
#else
            return null;
#endif
        }


        //
        // C++:  bool empty()
        //

        //javadoc: Algorithm::empty()
        public virtual bool empty ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            bool retVal = core_Algorithm_empty_10 (nativeObj);
        
            return retVal;
#else
            return false;
#endif
        }


        //
        // C++:  void clear()
        //

        //javadoc: Algorithm::clear()
        public virtual void clear ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            core_Algorithm_clear_10 (nativeObj);
        
            return;
#else
            return;
#endif
        }


        //
        // C++:  void read(FileNode fn)
        //

        // Unknown type 'FileNode' (I), skipping the function


        //
        // C++:  void save(String filename)
        //

        //javadoc: Algorithm::save(filename)
        public void save (string filename)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            core_Algorithm_save_10 (nativeObj, filename);
        
            return;
#else
            return;
#endif
        }


        //
        // C++:  void write(Ptr_FileStorage fs, String name = String())
        //

        // Unknown type 'Ptr_FileStorage' (I), skipping the function


#if (UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR
        const string LIBNAME = "__Internal";
        


#else
        const string LIBNAME = "opencvforunity";
#endif



        // C++:  String getDefaultName()
        [DllImport (LIBNAME)]
        private static extern IntPtr core_Algorithm_getDefaultName_10 (IntPtr nativeObj);

        // C++:  bool empty()
        [DllImport (LIBNAME)]
        private static extern bool core_Algorithm_empty_10 (IntPtr nativeObj);

        // C++:  void clear()
        [DllImport (LIBNAME)]
        private static extern void core_Algorithm_clear_10 (IntPtr nativeObj);

        // C++:  void save(String filename)
        [DllImport (LIBNAME)]
        private static extern void core_Algorithm_save_10 (IntPtr nativeObj, string filename);

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void core_Algorithm_delete (IntPtr nativeObj);

    }
}
