using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson31_NS_TCP_client_socket_;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async Task Button_Click(object sender, RoutedEventArgs e)
    {
        var port = int.Parse(TextBoxPort.Text);
        var url = TextBoxAddress.Text;
        using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
            ProtocolType.Tcp);
        try
        {
            await socket.ConnectAsync(url, port);
            var message = $"GET / HTTP/1.1\r\nHost: {url}\r\n\r\n";
            var messageBytes = Encoding.UTF8.GetBytes(message);
            socket.Shutdown(SocketShutdown.Send);
            var responseBytes = new byte[512];
            var builder = new StringBuilder();
            int bytes;
            do
            {
                bytes = await socket.ReceiveAsync(responseBytes);
                string responsePart = Encoding.UTF8.GetString(responseBytes, 0, bytes);
                builder.Append(responsePart);
            }
            while (bytes > 0);
            TextBlockResponse.Text =builder.ToString();
        }
        catch(SocketException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}