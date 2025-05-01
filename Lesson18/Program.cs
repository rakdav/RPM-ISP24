int[] arrayInt = { 5, 34, 67, 12, 94, 42 };
IEnumerable<int> query = from i in arrayInt
                         where i%2==0
                         orderby i descending
                         select i;
foreach (var item in query)
{
    Console.Write(item+" ");
}
Console.WriteLine();
var people = new List<Person>
{ 
    new Person(){Name="Tom",Age=25},
    new Person(){Name="Bob",Age=28},
    new Person(){Name="Sam",Age=31},
    new Person(){Name="Alice",Age=17}
};
//var names = from p in people select p.Name;
var names = people.Select(p => p.Name);
foreach (var item in names)
{
    Console.Write(item + " ");
}
Console.WriteLine();
//var ages = from p in people
//           select new
//           {
//               Name=p.Name,
//               Year=DateTime.Now.Year-p.Age
//           };
//var ages = people.Select(
//           p=>new
//           {
//               Name = p.Name,
//               Year = DateTime.Now.Year - p.Age
//           });
var ages = from p in people
           let name=$"Mr.{p.Name}"
           let year= DateTime.Now.Year - p.Age
           select new
           {
               Name = name,
               Year = year
           };
foreach (var item in ages)
{
    Console.WriteLine(item.Name + " "+item.Year);
}
Console.WriteLine();
int[] mas1 = { 5, 2, 8, 1, 9, 4,1 };
int[] mas2 = { 7, 2, 3, 4, 5, 10};
//разность последовательностей
var res1 = mas1.Except(mas2);
var res2 = mas1.Intersect(mas2);
var res3 = mas1.Distinct();
var res4 = mas1.Union(mas2);
foreach (var item in res4)
{
    Console.Write(item+" ");
}
Console.WriteLine();
//агрегатные функции
int q = mas1.Aggregate((x, y) => x * y);
Console.WriteLine(q);
int countMas1 = mas1.Count();
Console.WriteLine(countMas1);
int count2 = mas1.Count(i => i % 2 != 0 && i > 3);
Console.WriteLine(count2);
int sum1 = mas1.Sum();
Console.WriteLine(sum1);
int sum2 = mas1.Where(p=>p%2!=0).Sum();
Console.WriteLine(sum2);
Console.WriteLine(mas1.Max(p=>p%2!=0));
Console.WriteLine(mas1.Min(p => p % 2 == 0));
Console.WriteLine(mas1.Where(p => p % 2 == 0).Average());
Console.WriteLine(mas1.Where((m,n)=>n%2==0).Sum());
int[] mas = new int[100];
Random random = new Random();
mas=mas.Select((i, j) => i = random.Next(10, 100)).ToArray();
foreach (var item in mas) Console.Write(item+" ");
//skip - прпустить 
int s1 = mas.Skip(4).Sum();
int s2 = mas.SkipLast(4).Sum();
int s3 = mas.SkipWhile(p=>p%2!=0).Sum();
//take - получить
int s4 = mas.Take(4).Sum();
int s5 = mas.TakeLast(4).Sum();
int s6 = mas.TakeWhile(p => p % 2 != 0).Sum();
Console.Clear();
for (int i = 0; i < mas.Length; i+=10)
{
    Console.Clear();
    int[]temp=mas.Skip(i).Take(10).ToArray();
    foreach(int item in temp) Console.WriteLine(item);
    Console.ReadKey();
}
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
} 
