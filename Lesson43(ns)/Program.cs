using System.Net;
using System.Net.Sockets;
using System.Text;

var tcpListener = new TcpListener(IPAddress.Parse("192.168.110.60"), 8888);
try
{
    tcpListener.Start();
    Console.WriteLine("Сервер запущен. Ожидание подключений...");
    while (true)
    {
        using var tcpClient = await tcpListener.AcceptTcpClientAsync();
        //Console.WriteLine($"Входящее подключение:{tcpClient.Client.RemoteEndPoint}");
        var stream = tcpClient.GetStream();
        byte[] data = Encoding.UTF8.GetBytes(DateTime.Now.ToLongTimeString());
        await stream.WriteAsync(data);
        Console.WriteLine($"Клиенту {tcpClient.Client.RemoteEndPoint} данные" +
            $"отправлены");
    }
}
finally
{
    tcpListener.Stop();
}
