using System.Net;
using System.Net.Sockets;

IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("192.168.110.60"), 8888);
Console.WriteLine("Сервер подключен.");
while (true)
{
    using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    socket.Bind(ipPoint);
    socket.Listen(1000);
    using Socket client = await socket.AcceptAsync();
    Console.WriteLine($"Адрес подключенного клиента:{client.RemoteEndPoint}");
}

