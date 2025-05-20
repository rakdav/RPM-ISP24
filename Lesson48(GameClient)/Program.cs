﻿using System.Net;
using System.Net.Sockets;
using System.Text;

using var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
Console.Write("Введите сооющение");
string message = Console.ReadLine()!;
byte[] data = Encoding.UTF8.GetBytes(message);
EndPoint remotePoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);
int bytes = await udpSocket.SendToAsync(data, remotePoint);
Console.WriteLine($"Отправлено {bytes} байт");