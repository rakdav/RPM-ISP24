Console.Write("Введите x:");
double x1 = double.Parse(Console.ReadLine()!);
Console.Write("Введите y:");
double y1 = double.Parse(Console.ReadLine()!);
Number n1 = new Number(x1,y1);
Console.WriteLine($"{n1.X}+{n1.Y}={n1.Add()}");
Console.WriteLine($"{n1.X}-{n1.Y}={n1.Sub()}");
Console.WriteLine($"{n1.X}*{n1.Y}={n1.Mult()}");
Console.WriteLine($"{n1.X}/{n1.Y}={n1.Div():F2}");
Console.Write("Введите x:");
double x2 = double.Parse(Console.ReadLine()!);
Console.Write("Введите y:");
double y2 = double.Parse(Console.ReadLine()!);
Number n2 = new Number(x2,y2);
double n3 = n1 + n2;


public interface IArOperation
{
    double Add();
    double Sub();
    double Mult();
    double Div();
}
public interface ISqrSqrt
{
    double Sqr();
    double Sqrt();
}
class Number : IArOperation,ISqrSqrt
{
    double x, y;
    public double X
    {
        get => x;
        set { x = value; }
    }
    public double Y
    {
        get => y;
        set { y = value; }
    }
    public Number(double x, double y)
    {
        X = x;
        Y = y;
    }
    public double Add() => x + y;
    public double Sub() => x - y;
    public double Mult() => x * y;
    public double Div() => x / y;
    public double Sqr() => x * x + y * y;
    public double Sqrt()=> Math.Sqrt(x * x + y * y);
    public static double operator +(Number a, Number b)
    {
        return a.X * b.X + a.Y * b.Y;
    }
}
