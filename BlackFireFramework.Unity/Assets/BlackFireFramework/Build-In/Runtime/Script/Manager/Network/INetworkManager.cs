using System.Text;
using BlackFireFramework.Network;

namespace BlackFireFramework.Unity
{
    public interface INetworkManager:IManager
    {
        TransportBase CreateWebSocketClient(string transportAlias, string uri, Encoding encoding);
        TransportBase CreateWebSocketClient(string transportAlias, string uri);
        TransportBase CreateUnityWebSocketClient(string transportAlias,string uri,Encoding encoding);
        TransportBase CreateUnityWebSocketClient(string transportAlias,string uri);
        bool HasTransport(string transportAlias);
        TransportBase GetTransport(string transportAlias);
        TransportBase CreateTcpClient(string transportAlias,string uri);
        TransportBase CreateUnityTcpClient(string transportAlias, string uri);
        DownloadTaskInfo GetDownloadTask(string taskName);
        bool HasTaskDone(string taskName);
        void StartDownloadTask(DownloadTaskInfo downloadTaskInfo);
        void StopDownloadTask(string taskName);
        TransportBase CreateUdpClient(string transportAlias,string uri);
        TransportBase CreateUnityUdpClient(string transportAlias, string uri);
    }
}