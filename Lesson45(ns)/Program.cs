using System.Net;
using System.Net.Sockets;
using System.Text;

var tcpListener = new TcpListener(IPAddress.Parse("192.168.110.60"),8888);
try
{
    tcpListener.Start();
    Console.WriteLine("Сервер запущен. Ожидание подключений...");
    while (true)
    {
        var tcpClient = await tcpListener.AcceptTcpClientAsync();
        Task.Run(async()=>await ProcessClientAsync(tcpClient));
        //new Thread(async () => await ProcessClientAsync(tcpClient)).Start();
    }
}
finally
{
    tcpListener.Stop();
}

async Task ProcessClientAsync(TcpClient tcpClient)
{
    var words = new Dictionary<string, string>()
    {
        {"red","красный"},
        {"blue","синий"},
        {"green","зеленый"}
    };
    var stream = tcpClient.GetStream();
    var response = new List<byte>();
    int bytesRead = 10;
    while (true)
    {
        while ((bytesRead = stream.ReadByte()) != '\n')
        {
            response.Add((byte)bytesRead);
        }
        var word = Encoding.UTF8.GetString(response.ToArray());
        if (word == "END") break;
        Console.WriteLine($"Клиент {tcpClient.Client.RemoteEndPoint} запросил перевод слова {word}");
        if (!words.TryGetValue(word, out var translation)) translation = "Не найдено в словаре";
        translation += "\n";
        await stream.WriteAsync(Encoding.UTF8.GetBytes(translation));
        response.Clear();
    }
    tcpClient.Close();
}