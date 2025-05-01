int a = 79;
Console.WriteLine(a.GetHashCode());
string str1 = "fdsfdsfds";
Console.WriteLine(str1.GetHashCode());
string str2 = "fdsfdsfd";
Console.WriteLine(str2.GetHashCode());
//HashSet
HashSet<string> stringHash = new HashSet<string>();
stringHash.Add("Sam");
stringHash.Add("Tom");
stringHash.Add("Bob");
stringHash.Add("Tom");
foreach (var item in stringHash)
{
    Console.Write(item+" ");
}
Console.WriteLine();
SortedSet<int> intSet1 = new SortedSet<int>();
Random random = new Random();
for (int i = 0; i < 20; i++)
{
    intSet1.Add(random.Next(10));
}
foreach (var item in intSet1)
{
    Console.Write(item+" ");
}
Console.WriteLine();
List<int> list = new List<int>();
for (int i = 0; i < 30; i++)
{
    list.Add(random.Next(20));
}
SortedSet<int> intSet2 = new SortedSet<int>(list);
foreach (var item in intSet2)
{
    Console.Write(item + " ");
}
Console.WriteLine();
HashSet<int> intSet3 = new HashSet<int>(list);
foreach (var item in intSet3)
{
    Console.Write(item + " ");
}
Console.WriteLine();
//операции над множествами
SortedSet<int> intSet4 = new SortedSet<int>();
intSet4.Add(4);
intSet4.Add(1);
intSet4.Add(3);
intSet4.Add(5);
intSet4.Add(7);
SortedSet<int> intSet5 = new SortedSet<int>();
intSet5.Add(5);
intSet5.Add(1);
intSet5.Add(4);
intSet5.Add(8);
intSet5.Add(9);
//симметрическая разность
//intSet4.SymmetricExceptWith(intSet5);
//foreach (var item in intSet4)
//{
//    Console.Write(item+" ");
//}
//Console.WriteLine();

////объединение
//intSet4.Union(intSet5);
//foreach (var item in intSet4)
//{
//    Console.Write(item + " ");
//}
//Console.WriteLine();

//пересечение
//intSet4.IntersectWith(intSet5);
//foreach (var item in intSet4)
//{
//    Console.Write(item + " ");
//}
//Console.WriteLine();

//разность множеств
//intSet4.ExceptWith(intSet5);
//foreach (var item in intSet4)
//{
//    Console.Write(item + " ");
//}
//Console.WriteLine();