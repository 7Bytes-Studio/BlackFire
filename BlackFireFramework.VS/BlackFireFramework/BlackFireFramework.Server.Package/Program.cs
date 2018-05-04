using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using SimpleJson;

namespace BlackFireFramework.Server.Package
{
    class Program
    {
        private const string ServerDomain = "http://localhost/packages/";

        private const string ServerAPI = ServerDomain+"api.json";

        private const string PackageReadmeFileName = "Readme.json";

        static void Main(string[] args)
        {
            string currentDir = System.Environment.CurrentDirectory;

            DirectoryInfo dirInfo = new DirectoryInfo(currentDir);

            foreach (var nextFolder in dirInfo.GetDirectories())
            {
                Console.WriteLine(nextFolder.Name);

                var json = File.ReadAllText(nextFolder.FullName+"/"+ PackageReadmeFileName);

                PackageInfo packageInfo = SimpleJson.SimpleJson.DeserializeObject(json) as PackageInfo;

            }
            Console.ReadLine();
        }
    }
}
