Dictionary<int, string> people = new Dictionary<int, string>();
people.Add(1, "Bob");
people.Add(2, "Tom");
people.Add(3, "Sam");
//people.Add(1, "Jerry");
people.Add(4, "Sam");
foreach(var p in people)
{
    Console.WriteLine($"{p.Key}:{p.Value}");
}
Console.WriteLine();
people.Remove(2);
foreach (var p in people)
{
    Console.WriteLine($"{p.Key}:{p.Value}");
}
Console.WriteLine(people.ContainsKey(1));
Console.WriteLine(people.ContainsValue("Bob"));
Console.WriteLine(people[1]);