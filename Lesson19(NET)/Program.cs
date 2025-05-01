using System.Net;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
//IP
IPAddress localIp = new IPAddress(new byte[] { 127, 0, 0, 1 });
Console.WriteLine(localIp);
IPAddress someIp = new IPAddress(0x0100007F);
Console.WriteLine(someIp);
IPAddress ip = IPAddress.Parse("127.0.0.1");
IPAddress anyIp = IPAddress.Any;//возвращает объект IPAddress для адреса 0.0.0.0
IPAddress loop = IPAddress.Loopback;//возвращает объект IPAddress для адреса 127.0.0.1
IPAddress broadcastIp = IPAddress.Broadcast;//возвращает объект IPAddress для адреса 255.255.255.255
Console.WriteLine(localIp.AddressFamily);
IPEndPoint endpoint1 = new IPEndPoint(ip, 8080);
IPEndPoint endpoint2 = IPEndPoint.Parse("127.0.0.1:8080");
Console.WriteLine(endpoint2.Address);
Console.WriteLine(endpoint2.Port);
//Uri
string uri = "https://mail.ru";
Uri myUri = new(uri);
Console.WriteLine(myUri.AbsolutePath);
Console.WriteLine(myUri.AbsoluteUri);
Console.WriteLine(myUri.Fragment);
Console.WriteLine(myUri.Host);
Console.WriteLine(myUri.IsAbsoluteUri);
Console.WriteLine(myUri.IsDefaultPort);
Console.WriteLine(myUri.IsFile);
Console.WriteLine(myUri.IsLoopback);
Console.WriteLine(myUri.OriginalString);
Console.WriteLine(myUri.PathAndQuery);
Console.WriteLine(myUri.Port);
Console.WriteLine(myUri.Query);
Console.WriteLine(myUri.Scheme);
Console.WriteLine(string.Join(",",myUri.Segments));
Console.WriteLine(myUri.UserInfo);

//NetworkInterface
var adapters = NetworkInterface.GetAllNetworkInterfaces();
Console.WriteLine($"Всего:{adapters.Length}");
foreach(NetworkInterface adapter in adapters)
{
    Console.WriteLine();
    Console.WriteLine(adapter.Id);
    Console.WriteLine(adapter.Name);
    Console.WriteLine(adapter.Description);
    Console.WriteLine(adapter.NetworkInterfaceType);
    Console.WriteLine(adapter.GetPhysicalAddress());
    Console.WriteLine(adapter.OperationalStatus);
    Console.WriteLine(adapter.Speed);
    IPInterfaceStatistics stats = adapter.GetIPStatistics();
    Console.WriteLine(stats.BytesReceived);
    Console.WriteLine(stats.BytesSent);
}
