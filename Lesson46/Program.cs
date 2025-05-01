using System.Net.Sockets;
using System.Text;

while (true)
{
    using TcpClient tcpClient = new TcpClient();
    await tcpClient.ConnectAsync("127.0.0.1", 8888);
    Console.WriteLine("Введите слово для первода:");
    string word = Console.ReadLine()!;
    var stream = tcpClient.GetStream();
    int bytesRead = 10;
    byte[] data = Encoding.UTF8.GetBytes(word + "\n");
    await stream.WriteAsync(data);
    var response = new List<byte>();
    while ((bytesRead = stream.ReadByte()) != '\n')
    {
        response.Add((byte)bytesRead);
    }
    var translation = Encoding.UTF8.GetString(response.ToArray());
    Console.WriteLine($"Слово {word}:{translation}");
    response.Clear();
    await Task.Delay(2000);
    await stream.WriteAsync(Encoding.UTF8.GetBytes("END\n"));
}
