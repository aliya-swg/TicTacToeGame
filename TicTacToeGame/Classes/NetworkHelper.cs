using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace TicTacToeGame.Classes
{
    public static class NetworkHelper
    {
        public static string GetLocalIPAddress()
        {
            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    return endPoint?.Address.ToString() ?? "127.0.0.1";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Не удалось получить локальный IP адрес", ex);
                return "127.0.0.1";
            }
        }

        public static string GetLocalNetworkBase()
        {
            try
            {
                string ip = GetLocalIPAddress();
                var parts = ip.Split('.');
                if (parts.Length >= 3)
                {
                    return $"{parts[0]}.{parts[1]}.{parts[2]}";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Не удалось получить базу локальной сети", ex);
            }
            return "192.168.1"; 
        }

        public static int FindAvailablePort(int startPort = 12345)
        {
            try
            {
                for (int port = startPort; port < startPort + 100; port++)
                {
                    if (IsPortAvailable(port))
                    {
                        Logger.LogInfo($"Найден свободный порт: {port}");
                        return port;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка поиска свободного порта", ex);
            }

            Logger.LogWarning($"Не найден свободный порт, используется {startPort}");
            return startPort;
        }

        public static bool IsPortAvailable(int port)
        {
            try
            {
                using (var tcpListener = new TcpListener(IPAddress.Any, port))
                {
                    tcpListener.Start();
                    tcpListener.Stop();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> IsGameHostReachable(string host, int port, int timeoutMs = 500)
        {
            try
            {
                using (var client = new TcpClient())
                {
                    var connectTask = client.ConnectAsync(host, port);
                    var timeoutTask = Task.Delay(timeoutMs);

                    var completedTask = await Task.WhenAny(connectTask, timeoutTask);

                    if (completedTask == connectTask && client.Connected)
                    {
                        Logger.LogInfo($"Хост {host}:{port} доступен");
                        return true;
                    }
                }
            }
            catch
            {
            }

            return false;
        }

        public static List<string> GetAllLocalIPAddresses()
        {
            var ipAddresses = new List<string>();

            try
            {
                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (ni.OperationalStatus == OperationalStatus.Up &&
                        ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    {
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                ipAddresses.Add(ip.Address.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Не удалось получить все локальные IP адреса", ex);
            }

            if (!ipAddresses.Any())
                ipAddresses.Add("127.0.0.1");

            return ipAddresses;
        }
    }
}
