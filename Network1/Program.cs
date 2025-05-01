using System.Net;

IPAddress localIp = new IPAddress(new byte[] { 127,0,0,1 });
Console.WriteLine(localIp);
IPAddress someIp = new IPAddress(0x0100007F);
Console.WriteLine(someIp);

IPAddress ip = IPAddress.Parse("192.168.113.1");
IPAddress anyIp = IPAddress.Any;
Console.WriteLine(anyIp);
IPAddress localIP = IPAddress.Loopback;
Console.WriteLine(localIP);
IPAddress broadcastIP = IPAddress.Broadcast;
Console.WriteLine(broadcastIP);
