//Queue
//Queue<string> people1 = new Queue<string>();
//Queue<string> people2 = new Queue<string>(16);
//var employees = new List<string> { "Tom", "Sam", "Bob" };
//Queue<string> people3 = new Queue<string>(employees);
//foreach(var p in people3) Console.Write(p+" ");
//Console.WriteLine(people3.Count);
//people1.Enqueue("Майорова порву на месте");
//people1.Enqueue("Лысенков спит сволочь");
//people1.Enqueue("Голубчиков стучись не достучись. Дятел");
//Console.WriteLine(people1.Peek());
//foreach (var p in people1) Console.Write(p+" ");
//Console.WriteLine();
//Console.WriteLine(people1.Dequeue());
//foreach (var p in people1) Console.Write(p + " ");
//Console.WriteLine();
//if (people1.Count > 0)
//{
//    var success=people1.TryDequeue(out var person1);
//    if(success) Console.WriteLine(person1);
//    success = people1.TryDequeue(out var person2);
//    if (success) Console.WriteLine(person2);
//    success = people1.TryDequeue(out var person3);
//    if (success) Console.WriteLine(person3);
//    success = people1.TryPeek(out var person4);
//    if (success) Console.WriteLine(person4);

//}
//Stack
Stack<string> people1 = new Stack<string>();
Stack<string> people2 = new Stack<string>(16);

var employees = new List<string> { "Tom", "Sam", "Bob" };
Stack<string> people3 = new Stack<string>(employees);
foreach(var p in people3) Console.Write(p+" ");
Console.WriteLine();
Console.WriteLine(people3.Count);
Console.WriteLine(people3.Contains("Sam"));
people1.Push("Петров - гулящее создание");
people1.Push("Соколов - летающее мимо 209 создание");
people1.Push("Колесников - подлежит колесованию");

if (people1.Count > 0)
{
    var success = people1.TryPop(out var person1);
    if(success) Console.WriteLine(person1);
    success = people1.TryPeek(out var person2);
    if (success) Console.WriteLine(person2);
    success = people1.TryPop(out var person3);
    if (success) Console.WriteLine(person3);
    success = people1.TryPop(out var person4);
    if (success) Console.WriteLine(person4);
    success = people1.TryPop(out var person5);
    if (success) Console.WriteLine(person5);

}


