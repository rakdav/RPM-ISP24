using Lab3;

Console.Write("Введите радиус окружности:");
double r = double.Parse(Console.ReadLine()!);
Circle circle = new Circle()
{
    Radius = r,
    Name = "Окружность"
};
Console.WriteLine(circle);

Console.Write("Введите длину:");
double l = double.Parse(Console.ReadLine()!);
Console.Write("Введите ширину:");
double w = double.Parse(Console.ReadLine()!);
Triangle t = new Triangle()
{
    Name = "Прямоугольник",
    Width = w,
    Height = l
};
Console.WriteLine(t);