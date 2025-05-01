//int z=0;
//try
//{

//    Console.Write("Введите переменную:");
//    if (int.TryParse(Console.ReadLine(), out z))
//    {
//        int x = 8;
//        int y = x / z;
//        Console.WriteLine(y);
//        int w = z / x;
//        Console.WriteLine(w);
//    }
//    int[] mas = { 1, 2, 3 };
//    mas[2] = 67;
//    object str = "Raul";
//    int g = (int)str;
//}
//catch(DivideByZeroException) when (z==0)
//{
//    Console.WriteLine("Нельзя z ноль");
//}
//catch (DivideByZeroException)
//{
//    Console.WriteLine("Нельзя x ноль");
//}
//catch (IndexOutOfRangeException)
//{
//    Console.WriteLine("Длина массива меньше");
//}
//catch (Exception e)
//{
//    Console.WriteLine(e.Message);
//}
//finally
//{
//    Console.WriteLine("Блок завершил работу");
//}

//try
//{
//    Console.Write("Введите сложный пароль");
//    string password = Console.ReadLine()!;
//    if (password == null || password.Length < 4)
//    {
//        throw new Exception("Длина пароля не больжна быть меньше 4 символов");
//    }
//    else
//    {
//        Console.WriteLine("Ваш пароль:"+password);
//    }
//}
//catch(Exception e)
//{
//    Console.WriteLine($"Ошибка:{e.Message}");
//}
try
{
    Console.Write("Введите число:");
    int n = int.Parse(Console.ReadLine()!);
    if (n < 0) throw new FactorialException("Факториал не может быть меньше нуля", n);
}
catch(FactorialException e)
{
    Console.WriteLine(e.Message+","+e.Value);
}

class FactorialException : Exception
{
    public int Value { get; }
    public FactorialException(string? message,int val) : base(message)
    {
        Value = val;
    }
}