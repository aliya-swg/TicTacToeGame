using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TicTacToeGame.Classes
{
    public static class AutoNetworkManager
    {
        private const int DEFAULT_PORT = 12345;
        private const int BROADCAST_PORT = 12346;
        private const string GAME_SIGNATURE = "TICTACTOE_GAME";

        public static int GetAvailablePort()
        {
            int port = DEFAULT_PORT;
            while (!NetworkHelper.IsPortAvailable(port) && port < 65535)
            {
                port++;
            }
            return port;
        }

        public static async Task<string> StartHostAndGetIP()
        {
            try
            {
                string localIP = NetworkHelper.GetLocalIPAddress();
                int port = GetAvailablePort();

                _ = Task.Run(() => StartDiscoveryServer(localIP, port));

                Logger.LogInfo($"Хост запущен автоматически на {localIP}:{port}");
                return $"{localIP}:{port}";
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка автозапуска хоста", ex);
                return "127.0.0.1:12345";
            }
        }

        public static async Task<string> FindAvailableHost()
        {
            try
            {
                Logger.LogInfo("Поиск доступных хостов...");

                using (var udpClient = new UdpClient())
                {
                    udpClient.EnableBroadcast = true;
                    udpClient.Client.ReceiveTimeout = 3000;

                    var broadcastEndpoint = new IPEndPoint(IPAddress.Broadcast, BROADCAST_PORT);
                    var message = Encoding.UTF8.GetBytes($"{GAME_SIGNATURE}_DISCOVER");

                    await udpClient.SendAsync(message, message.Length, broadcastEndpoint);

                    try
                    {
                        var result = await udpClient.ReceiveAsync();
                        string response = Encoding.UTF8.GetString(result.Buffer);

                        if (response.StartsWith($"{GAME_SIGNATURE}_HOST:"))
                        {
                            string hostInfo = response.Substring($"{GAME_SIGNATURE}_HOST:".Length);
                            Logger.LogInfo($"Найден хост: {hostInfo}");
                            return hostInfo;
                        }
                    }
                    catch (SocketException)
                    {
                        Logger.LogInfo("Хосты не найдены, используется localhost");
                    }
                }

                return "127.0.0.1:12345";
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка поиска хостов", ex);
                return "127.0.0.1:12345";
            }
        }

        private static async Task StartDiscoveryServer(string hostIP, int gamePort)
        {
            try
            {
                using (var udpListener = new UdpClient(BROADCAST_PORT))
                {
                    Logger.LogInfo($"Сервер обнаружения запущен на порту {BROADCAST_PORT}");

                    while (true)
                    {
                        try
                        {
                            var result = await udpListener.ReceiveAsync();
                            string message = Encoding.UTF8.GetString(result.Buffer);

                            if (message == $"{GAME_SIGNATURE}_DISCOVER")
                            {
                                string response = $"{GAME_SIGNATURE}_HOST:{hostIP}:{gamePort}";
                                byte[] responseBytes = Encoding.UTF8.GetBytes(response);

                                await udpListener.SendAsync(responseBytes, responseBytes.Length, result.RemoteEndPoint);
                                Logger.LogInfo($"Отправлен ответ клиенту: {result.RemoteEndPoint}");
                            }
                        }
                        catch (ObjectDisposedException)
                        {
                            break;
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError("Ошибка в сервере обнаружения", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка запуска сервера обнаружения", ex);
            }
        }

        public static (string ip, int port) ParseHostInfo(string hostInfo)
        {
            try
            {
                var parts = hostInfo.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[1], out int port))
                {
                    return (parts[0], port);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка парсинга информации о хосте", ex);
            }

            return ("127.0.0.1", 12345);
        }
    }
}
