using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TicTacToeGame.Network_classes
{
    public class GameServer
    {
        private TcpListener listener;
        private TcpClient client;
        private NetworkStream stream;

        public async Task StartAsync(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            client = await listener.AcceptTcpClientAsync();
            stream = client.GetStream();
        }

        public async Task SendMoveAsync(int row, int col)
        {
            try
            {
                if (stream == null)
                {
                    MessageBox.Show("Второй игрок не подключен! Перезапустите игру.");
                    return;
                }

                var msg = GameMessage.Move(row, col);
                byte[] data = Encoding.UTF8.GetBytes(msg);
                await stream.WriteAsync(data, 0, data.Length);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Ошибка при отправке хода: {ex.Message}");
            }
        }

        public async Task<string> ReceiveMoveAsync()
        {
            byte[] buffer = new byte[1024];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, bytesRead);
        }

        public void Stop()
        {
            stream?.Close();
            client?.Close();
            listener?.Stop();
        }
    }
}
