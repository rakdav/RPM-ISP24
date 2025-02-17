using System.Collections;
//ArrayList

//ArrayList al1 = new ArrayList();
//al1.Add(56);
//al1.Add(3.14);
//al1.Add("Abkakay loh. Прогульная дичь.");
//al1.Add('l');
//al1.Add(true);
//Console.WriteLine(al1[3]);
//Console.WriteLine(al1.Count);
//Console.WriteLine(al1.Capacity);

//List

//List<string> people1 = new List<string>() { "Tom","Jerry","Golubok"};
//List<string> people2 = new List<string>(people1);
//List<string> people3 = ["Sasha", "Masha", "Golubchikov progul"];
//List<string> people4 = [];
//List<string> people5 = new List<string>(16);
//people1.Add("Sam");
//people1.AddRange(new List<string>{"Serozha","Rozha"});
//foreach (var item in people1)
//{
//    Console.Write(item+" ");
//}
//Console.WriteLine();
//people1.Insert(2, "Petrov");
//people1.InsertRange(4, new[] { "Obkaka", "Sokol" });
//foreach (var item in people1)
//{
//    Console.Write(item + " ");
//}
//Console.WriteLine();
//people1.RemoveAt(5);//удаление по индексу
//people1.Remove("Serozha");
//people1.RemoveAll(p => p.Length == 6);
//people1.RemoveRange(1, 3);
//foreach (var item in people1)
//{
//    Console.Write(item + " ");
//}
//Console.WriteLine();
//var isRozha = people1.Contains("Rozha");
//Console.WriteLine(isRozha);
//var isGolubchikov = people1.Contains("Golubchikov progul");
//Console.WriteLine(isGolubchikov);
//Console.WriteLine(people1.Exists(p=>p.Length==5));
//Console.WriteLine(people1.Find(p => p.Length == 8));
//Console.WriteLine(people1.FindLast(p => p.Length == 5));
//List<string> peopleWithLengths = people1.FindAll(p => p.Length == 5);
//foreach (var item in peopleWithLengths)
//{
//    Console.Write(item + " ");
//}
//Console.WriteLine();
//List<string> range = people1.GetRange(0, 1);
//string[] masPeople = new string[2]; 
//people1.CopyTo(0, masPeople, 0, 2);
//people1.Reverse();
//foreach (var item in people1)
//{
//    Console.Write(item + " ");
//}
//Console.WriteLine();

//LinkedList
var list = new List<string>() { "Sam", "Tom", "Boba" };
LinkedList<string> people1 = new LinkedList<string>();
//Value - значение
//Next - ссылка на следующий элемент
//Previus - cссылка на предыдущий элемент
LinkedList<string> people2 = new LinkedList<string>(list);
Console.WriteLine(people2.Count);
Console.WriteLine(people2.First?.Value);
Console.WriteLine(people2.Last?.Value);
var currentNode = people2.First;
while (currentNode != null)
{
    Console.Write(currentNode.Value+" ");
    currentNode = currentNode.Next;
}
Console.WriteLine();
currentNode = people2.Last;
while (currentNode != null)
{
    Console.Write(currentNode.Value+" ");
    currentNode = currentNode.Previous;
}
Console.WriteLine();
people2.AddAfter(people2.Last!, "Jerry");
people2.AddBefore(people2.First!, "Duck");
people2.AddFirst("Arik");
people2.AddLast("Semen");
currentNode = people2.First;
while (currentNode != null)
{
    Console.Write(currentNode.Value + " ");
    currentNode = currentNode.Next;
}
Console.WriteLine();
people2.RemoveFirst();
people2.RemoveLast();
currentNode = people2.First;
while (currentNode != null)
{
    Console.Write(currentNode.Value + " ");
    currentNode = currentNode.Next;
}

