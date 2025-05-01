using System.Net.Sockets;
using System.Text;

using TcpClient tcpClient = new TcpClient();
await tcpClient.ConnectAsync("192.168.110.60", 8888);

byte[] data = new byte[512];
var stream = tcpClient.GetStream();
int bytes = await stream.ReadAsync(data);
string time = Encoding.UTF8.GetString(data, 0, bytes);
Console.WriteLine($"Текущее время: {time}");