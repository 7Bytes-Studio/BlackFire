using System;
using System.Collections.Generic;
using System.IO;

namespace BlackFireFramework.Server.Package
{
    class Program
    {
        private const string ServerDomain = "http://localhost/packages/";

        private const string PackageAPIFileName = "api.json";

        private const string ServerAPI = ServerDomain+ PackageAPIFileName;

        private const string PackageReadmeFileName = "Readme.json";


        static void Main(string[] args)
        {
            var packageInfoList = MakePackageInfoList();
            BuildAPI(packageInfoList);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("成功构建api.json!");
            Console.ReadLine();
        }

        private static void BuildAPI(PackageInfoList packageInfoList)
        {
            var json = SimpleJson.SimpleJson.SerializeObject(packageInfoList);
            if (!File.Exists(PackageAPIFileName))
            {
                File.Create(PackageAPIFileName);
            }
            File.WriteAllText(PackageAPIFileName,json);
        }


        private static PackageInfoList MakePackageInfoList()
        {
            string currentDir = System.Environment.CurrentDirectory;
            PackageInfoList packageInfoList = new PackageInfoList();
            packageInfoList.packages = new List<PackageInfo>();

            DirectoryInfo dirInfo = new DirectoryInfo(currentDir);
            foreach (var nextFolder in dirInfo.GetDirectories())
            {
                var json = File.ReadAllText(nextFolder.FullName + "/" + PackageReadmeFileName);
                PackageInfo packageInfo = SimpleJson.SimpleJson.DeserializeObject<PackageInfo>(json);
                packageInfo.url = ServerDomain + nextFolder.Name + "/" + GetZipFileFullName(nextFolder.FullName);
                packageInfoList.packages.Add(packageInfo);
                Console.WriteLine(packageInfo.ToString()+"\n");
            }
            return packageInfoList;
        }

        private static string GetZipFileFullName(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            foreach (var file in dirInfo.GetFiles())
            {
                if (file.Extension==".zip")
                {
                    return file.Name;
                }
            }
            return string.Empty;
        }

    }
}
