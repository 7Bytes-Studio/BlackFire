//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using BlackFireFramework.Unity;
using UnityEditor;
using UnityEngine;

namespace BlackFireFramework.Editor
{
    public static class StorageWindowMenu
    {
        public const string TopMenuName = "BlackFire/";


        [MenuItem(TopMenuName + "Copy Sqlite Plugin")]
        private static void OnMenuItemClickConfig()
        {
            var sourcePath = BlackFireEditor.PluginsPath + "/BlackFire-Sqlite";
            var destPath = Application.dataPath + "/Plugins/BlackFire-Sqlite";
            
            if (Directory.Exists(sourcePath))
            {
                if (Directory.Exists(destPath))
                {
                    DirectoryInfo di =new DirectoryInfo(destPath);
                    di.Delete(true);
                }
                
                try
                {
                    Directory.CreateDirectory(destPath);
                }
                catch (Exception ex)
                {
                    throw new Exception("创建目标目录失败：" + ex.Message);
                }
            }
            else
            {
                throw new DirectoryNotFoundException("源目录不存在！");
            } 
            
            CopyFolder(sourcePath,destPath);
            AssetDatabase.Refresh();
        }

        /// <summary> //转载请注明来自 http://www.shang11.com
        /// 复制文件夹中的所有文件夹与文件到另一个文件夹
        /// </summary>
        /// <param name="sourcePath">源文件夹</param>
        /// <param name="destPath">目标文件夹</param>
        public static void CopyFolder(string sourcePath,string destPath)
        {
            if (Directory.Exists(sourcePath))
            {
                if (!Directory.Exists(destPath))
                {
                    try
                    {
                        Directory.CreateDirectory(destPath);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("创建目标目录失败：" + ex.Message);
                    }
                }
                
                //获得源文件下所有文件
                List<string> files = new List<string>(Directory.GetFiles(sourcePath));                
                files.ForEach(c =>
                {         
                    string destFile = Path.Combine(destPath,Path.GetFileName(c));
                    File.Copy(c, destFile,true);//覆盖模式
                });
                //获得源文件下所有目录文件
                List<string> folders = new List<string>(Directory.GetDirectories(sourcePath));                
                folders.ForEach(c =>
                {
                    string destDir = Path.Combine(destPath,Path.GetFileName(c));
                    //采用递归的方法实现
                    CopyFolder(c, destDir);
                });   
            }
            else
            {
                throw new DirectoryNotFoundException("源目录不存在！");
            } 
             
        }
            
    }
}
