Console.Write("Введите радиус:");
double radius = double.Parse(Console.ReadLine()!);
Circle circle = new Circle()
{
    Name = "Окружность",
    Radius=radius
};
Console.WriteLine(circle);

Console.Write("Введите ширину:");
double w = double.Parse(Console.ReadLine()!);
Console.Write("Введите длину:");
double length = double.Parse(Console.ReadLine()!);
Rectangle rectangle = new Rectangle
{
    Name = "Прямоугольник",
    Length = length,
    Width = w
};
Console.WriteLine(rectangle);
abstract class Figure
{
    public string? Name { get; set; }
    public abstract double GetArea();
    public abstract double GetPerimetr();
}
class Circle : Figure
{
    public double Radius { get; set; }
    public override double GetArea()=> Math.PI * Radius * Radius;   
    public override double GetPerimetr()=>2 * Math.PI * Radius;
    public override string? ToString()
    {
        return $"Площадь:{GetArea():F2}, периметр:{GetPerimetr():F2}";
    }
}
class Rectangle : Figure
{
    public double Width { get; set; }
    public double Length { get; set; }
    public override double GetArea() => Width * Length;
    public override double GetPerimetr() => 2 * (Width + Length);

    public override string? ToString()
    {
        return $"Площадь:{GetArea():F2}, периметр:{GetPerimetr():F2}";
    }
}

class Parallelepiped : Figure
{
    public double Width { get; set; }
    public double Length { get; set; }
    public double Height { get; set; }
    public override double GetArea() => (Width + Length) * Height + 2 * (Width * Length);
    public override double GetPerimetr() => (Width + Length + Height) *4;
    public double GetVolume() => Width * Height * Length;

    public override string? ToString()
    {
        return $"Площадь:{GetArea():F2}, периметр:{GetPerimetr():F2}, объем:{GetVolume():F2}";
    }
}
