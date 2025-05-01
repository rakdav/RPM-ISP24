using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Lesson47_TCP_Server_Chat_
{
    class ServerObject
    {
        TcpListener tcpListener = new TcpListener(IPAddress.Parse("192.168.110.60"), 8888);
        List<ClientObject> clients = new List<ClientObject>();
        protected internal void RemoveConnection(string id)
        {
            ClientObject? client = clients.FirstOrDefault(c=>c.Id==id);
            if (client != null) clients.Remove(client);
            client?.Close();
        }
    }
}
