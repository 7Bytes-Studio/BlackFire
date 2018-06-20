//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using Ionic.Zip;
using System;
using System.IO;
using System.Text;

namespace BlackFireFramework.Editor
{
    public static partial class Utility
    {
        /// <summary>
        /// Zip.(require: Libraries/3rd/DotNetZip)
        /// </summary>
        public static class Zip
        {
            public static void ZipFiles(string[] fileNames, string zipFileName)
            {
                if (null == fileNames) return;
                using (ZipFile zip = new ZipFile())
                {
                    for (int i = 0; i < fileNames.Length; i++)
                    {
                        zip.AddFile(fileNames[i]);
                    }
                    zip.Save(zipFileName);
                }
            }

            public static void ZipDirectorys(string[] directoryNames, string zipFileName)
            {
                if (null == directoryNames) return;
                using (ZipFile zip = new ZipFile())
                {
                    for (int i = 0; i < directoryNames.Length; i++)
                    {
                        zip.AddDirectory(directoryNames[i]);
                    }
                    zip.Save(zipFileName);
                }
            }

            public static void ZipFile(string fileName, string zipFileName)
            {
                ZipFiles(new string[] { fileName }, zipFileName);
            }

            public static void ZipDirectory(string directoryName, string zipFileName)
            {
                ZipDirectorys(new string[] { directoryName }, zipFileName);
            }

            public static void UnZipFile(string filePath, string unZipPath, EventHandler<UnZipProgressEventArgs> progressCallback = null, EventHandler completeCallback = null)
            {
                //BlackFire.Log.Info(Directory.Exists(unZipPath));
                if (Directory.Exists(unZipPath))
                {
                    Directory.Delete(unZipPath, true);
                }
                using (ZipFile zip = Ionic.Zip.ZipFile.Read(filePath, new ReadOptions() { Encoding = Encoding.Default }))
                {
                    bool forOnceCompleteCallback = false;
                    zip.ExtractProgress += (sender, args) => {

                        if (null != progressCallback)
                        {
                            if (0 == args.EntriesTotal)
                            {
                                return;
                            }

                            double progress = (double)args.EntriesExtracted / args.EntriesTotal;

                            //UnityEngine.Debug.LogErrorFormat("{0}  {1}  {2}",progress,args.EntriesExtracted,args.EntriesTotal);
                            //UnityEngine.Debug.LogWarning(args.EntriesTotal);

                            //正常解压进度。
                            if (1.0f >= progress && !forOnceCompleteCallback)
                            {
                                progressCallback.Invoke(sender, new UnZipProgressEventArgs(progress));
                            }

                            //正常解压进度的完成事件。
                            if (1.0f <= progress && !forOnceCompleteCallback)
                            {
                                if (null != completeCallback)
                                {
                                    completeCallback.Invoke(sender, EventArgs.Empty);
                                }
                                forOnceCompleteCallback = true;
                            }

                        }

                    };
                    zip.ExtractAll(unZipPath);
                }
            }

            public sealed class UnZipProgressEventArgs : EventArgs
            {
                public UnZipProgressEventArgs(double unZipProgress)
                {
                    UnZipProgress = unZipProgress;
                }
                public double UnZipProgress { get; private set; }
            }

        }
    }
}


    


