using System.Net.Sockets;
using System.Text;

using var mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
var server = "www.google.com";
mySocket.Connect(server, 80);
using var stream = new NetworkStream(mySocket);
Console.WriteLine(stream.Socket.LocalEndPoint);
Console.WriteLine(stream.Socket.RemoteEndPoint);
var message = $"GET / HTTP/1.1\r\nHost: {server}\r\nConnection: Close\r\n\r\n";
var data = Encoding.UTF8.GetBytes(message);
await stream.WriteAsync(data);
Console.WriteLine("Отправили данные на:"+server);
var responseData = new byte[4096];
var bytes = await stream.ReadAsync(responseData);
string response = Encoding.UTF8.GetString(responseData, 0, bytes);
Console.WriteLine(response);