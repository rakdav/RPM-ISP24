using System.Net.Sockets;
using System.Text;
//TCP client
using TcpClient tcpClient = new TcpClient();
try
{
    await tcpClient.ConnectAsync("www.google.com", 80);
    Console.WriteLine("Подключение установлено");
    Console.WriteLine(tcpClient.Connected);
    NetworkStream stream = tcpClient.GetStream();
    var requestMessage = $"GET / HTTP/1.1\r\nHost: www.google.com \r\nConnection: Close\r\n\r\n";
    var requestData = Encoding.UTF8.GetBytes(requestMessage);
    await stream.WriteAsync(requestData);
    var responseData = new byte[512];
    var response = new StringBuilder();
    int bytes;
    do
    {
        bytes = await stream.ReadAsync(responseData);
        response.Append(Encoding.UTF8.GetString(responseData, 0, bytes));
    }
    // while (bytes > 0);
    //while (tcpClient.Available>0);
    while (stream.DataAvailable);
    Console.WriteLine(response);
}
catch(SocketException ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    tcpClient.Close();
    Console.WriteLine(tcpClient.Connected);
}
