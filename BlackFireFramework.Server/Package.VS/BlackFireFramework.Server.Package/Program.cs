using System;
using System.Collections.Generic;
using System.IO;

namespace BlackFireFramework.Server.Package
{
    class Program
    {
        private static string ServerDomain = "http://localhost";

        private static string ServerPackageUrl = "/packages/";

        private static string PackageAPIFileName = "api.json";

        private static string ServerAPI = ServerDomain + ServerPackageUrl + PackageAPIFileName;

        private static string PackageReadmeFileName = "readme.json";


        static void Main(string[] args)
        {
            if (0<args.Length&&!string.IsNullOrEmpty(args[0]))
            {
                ServerDomain = args[0];
            }

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
            packageInfoList.packages = new List<PackageInfoDic>();

            DirectoryInfo dirInfo = new DirectoryInfo(currentDir);
            foreach (var nextFolder in dirInfo.GetDirectories())
            {
                var json = File.ReadAllText(nextFolder.FullName + "/" + PackageReadmeFileName);
                PackageInfo packageInfo = SimpleJson.SimpleJson.DeserializeObject<PackageInfo>(json);
                packageInfo.url = ServerDomain + ServerPackageUrl + nextFolder.Name + "/" + GetZipFileFullName(nextFolder.FullName);

                var result = packageInfoList.packages.Find(value=>value.classify== packageInfo.classify);
                if (null != result)
                {
                    result.packageInfos.Add(packageInfo);
                }
                else
                {
                    packageInfoList.packages.Add(new PackageInfoDic() { classify = packageInfo.classify,packageInfos = new List<PackageInfo>() { packageInfo } });
                }
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
