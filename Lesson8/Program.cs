var tom = new Person("Надя", 18, new Company("Microsoft"));
var jerry = (Person)tom.Clone();
jerry.Work.Name = "Google";
jerry.Name = "Вася";
jerry.Age = 23;
Console.WriteLine(tom.Work.Name);
var sam = new Person("Боря", 24, new Company("Yandex"));
Person[] mas = new Person[3] { tom, jerry,sam };
Array.Sort(mas);
foreach (var item in mas)
{
    Console.WriteLine(item);
}
Console.WriteLine();
Array.Sort(mas, new PeopleNameComparer());
foreach (var item in mas)
{
    Console.WriteLine(item);
}
Console.WriteLine();
Array.Sort(mas, new PeopleAgeComparer());
foreach (var item in mas)
{
    Console.WriteLine(item);
}

class Person:ICloneable,IComparable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Company Work { get; set; }
    public Person(string name, int age,Company company)
    {
        Name = name;
        Age = age;
        Work = company;
    }
    public object Clone()
    {
       return new Person(Name, Age, new Company(Work.Name));
       // return MemberwiseClone();
    }
    public int CompareTo(object? obj)
    {
        if (obj is Person)
        {
            var person = obj as Person;
            var res = this.Work.Name.CompareTo(person?.Work.Name);
            if (res != 0) return res;
            return this.Name.CompareTo(person?.Name);
        }
        else throw new Exception("Невозможно сравнить два объекта");
    }
    public override string? ToString()
    {
        return this.Name + " " + this.Age + " " + this.Work.Name;
    }
}
class PeopleNameComparer : IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        if (x is null || y is null)
            throw new ArgumentException("Некоректное значение параметра");
        return x.Name.CompareTo(y.Name);
    }
}
class PeopleAgeComparer : IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        if (x is null || y is null)
            throw new ArgumentException("Некоректное значение параметра");
        return x.Age-y.Age;
    }
}
class Company
{
    public string Name { get; set; }
    public Company(string name)=>Name = name;
}
