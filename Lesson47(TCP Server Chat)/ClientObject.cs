using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lesson47_TCP_Server_Chat_
{
    class ClientObject
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public StreamWriter? Writer { get; }
        public StreamReader? Reader { get; }
        private TcpClient? client;
        private ServerObject? server;

        protected internal void Close()
        {
            Writer!.Close();
            Reader!.Close();
            client!.Close();
        }
    }
}
