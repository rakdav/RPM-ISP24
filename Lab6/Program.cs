Console.Write("Введите число n:");
int n = int.Parse(Console.ReadLine()!);
List<double> list = new List<double>();
Random random = new Random();
for (int i = 0; i < n; i++)
{
    list.Add(random.NextDouble() * 50-25);
    Console.Write($"{list[i]:F2} ");
}
Console.WriteLine();
Console.WriteLine(list.FindAll(p=>p>-15&&p<6).Count);