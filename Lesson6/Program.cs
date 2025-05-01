int x = 7, y = 9;
Console.WriteLine($"x={x} y={y}");
Swap<int>(ref x, ref y);
Console.WriteLine($"x={x} y={y}");

double z = 13, w = 18;
Console.WriteLine($"x={z} y={w}");
Swap<double>(ref z, ref w);
Console.WriteLine($"x={z} y={w}");
Messanger<Message> email = new Messanger<Message>();
email.SendMessage(new EmailMessage("Hello from email"));
Messanger<Message> telegram = new Messanger<Message>();
telegram.SendMessage(new TelegramMessage("Hello from telegram"));
//SendMessage(new Haker("Hahahhahahah"));
//void Swap(ref int a,ref int b)
//{
//    int temp = a;
//    a = b;
//    b = temp;
//}
//void SwapDouble(ref double a, ref double b)
//{
//    double temp = a;
//    a = b;
//    b = temp;
//}
void Swap<T>(ref T a,ref T b)
{
    T temp = a;
    a = b;
    b = temp;
}

class Message
{
    public string Text { get; set; }
    public Message(string text)
    {
        Text = text;
    }
}
class Messanger<T> where T : Message
{
    public void SendMessage(T message)
    {
        Console.WriteLine($"Отправляется ссобщение:{message.Text}");
    }
}
class EmailMessage : Message
{
    public EmailMessage(string text) : base(text){}
}
class TelegramMessage : Message
{
    public TelegramMessage(string text) : base(text){}
}

class Haker
{
    public string Text { get; set; }
    public Haker(string text)
    {
        Text = text;
    }
    public void Destroy() { }
}


