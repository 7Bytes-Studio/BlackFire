//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Net;
using System.Text.RegularExpressions;

namespace BlackFireFramework
{
    /// <summary>
    /// Magic Utilities.
    /// </summary>
    public static partial class Utility
    {
        /// <summary>
        /// IP地址助手
        /// </summary>
        public static class IP
        {
            //匹配IP的正则表达式
            private static Regex g_IpRegex = new Regex("((25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]\\d|\\d)\\.){3}(25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]\\d|[1-9])", RegexOptions.None);

            //公网Ip缓存，防止正则的多次使用造成的GC
            private static string g_CachePublicIp = string.Empty;

            /// <summary>
            /// 获取主机的公网IP
            /// </summary>
            /// <returns>公网IP</returns>
            public static string GetPublicIP()
            {
                if (!string.IsNullOrEmpty(g_CachePublicIp))
                {
                    return g_CachePublicIp;
                }

                var hostName = Dns.GetHostName();
                var addresses = Dns.GetHostAddresses(hostName);
                string ip = string.Empty;
                for (int i = 0; i < addresses.Length; i++)
                {
                    if (!string.IsNullOrEmpty(ip = g_IpRegex.Match(addresses[i].ToString()).Groups[0].Value))
                    {
                        return ip.Trim();
                    }
                }
                return string.Empty;
            }

            /// <summary>
            /// 实时获取主机的公网IP
            /// </summary>
            /// <returns>公网IP</returns>
            public static string GetRealPublicIP()
            {
                var hostName = Dns.GetHostName();
                var addresses = Dns.GetHostAddresses(hostName);
                string ip = string.Empty;
                for (int i = 0; i < addresses.Length; i++)
                {
                    if (!string.IsNullOrEmpty(ip = g_IpRegex.Match(addresses[i].ToString()).Groups[0].Value))
                    {
                        return ip.Trim();
                    }
                }
                return string.Empty;
            }

        }
    }

}

