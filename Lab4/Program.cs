Order<int>[] mas = new Order<int>[3];
for (int i = 0; i < mas.Length; i++)
{
    Console.Write("Введите р/с плательщика:");
    int rsp = int.Parse(Console.ReadLine()!);
    Console.Write("Введите р/с получателя:");
    int rsd = int.Parse(Console.ReadLine()!);
    Console.Write("Введите сумму перевода:");
    decimal summa = decimal.Parse(Console.ReadLine()!);
    mas[i] = new Order<int>(rsp, rsd, summa);
}
Array.Sort(mas);
foreach (var item in mas)
{
    Console.WriteLine(item);
}
Console.WriteLine();
Array.Sort(mas, new SortBySumma());
foreach (var item in mas)
{
    Console.WriteLine(item);
}
class Order<T>:ICloneable,IComparable
{
    public T RSPayment { get; set; }
    public T RSDestination { get; set; }
    public decimal Summa { get; set; }
    public Order(T rSPayment, T rSDestination, decimal summa)
    {
        RSPayment = rSPayment;
        RSDestination = rSDestination;
        Summa = summa;
    }
    public override string? ToString()
    {
        return $"Плательщик:{RSPayment}, получатель:{RSDestination}," +
            $" сумма:{Summa}";
    }
    public object Clone()=>new Order<T>(RSPayment, RSDestination, Summa);
    public int CompareTo(object? obj)
    {
        if (obj is Order<int>)
        {
            Order<int> temp = (obj as Order<int>)!;
            return int.Parse(RSPayment!.ToString()!) - int.Parse(temp.RSPayment.ToString());
        }
        else if(obj is Order<string>)
        {
            Order<string> temp = (obj as Order<string>)!;
            return RSPayment!.ToString()!.CompareTo(temp.RSPayment);
        }
        else throw new ArgumentException("Некорректное значение параметра");
    }
}
class SortBySumma : System.Collections.IComparer
{
    public int Compare(object? x, object? y)
    {
        if (x is Order<int>)
        {
            Order<int> X = (x as Order<int>)!;
            Order<int> Y = (y as Order<int>)!;
            if (X.Summa - Y.Summa > 0) return 1;
            else if (X.Summa - Y.Summa == 0) return 0;
            return -1;
        }
        else if (x is Order<string>)
        {
            Order<string> X = (x as Order<string>)!;
            Order<string> Y = (y as Order<string>)!;
            if (X.Summa - Y.Summa > 0) return 1;
            else if (X.Summa - Y.Summa == 0) return 0;
            return -1;
        }
        else throw new ArgumentException("Некорректное значение параметра");
    }
}
