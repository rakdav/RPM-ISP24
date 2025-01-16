
Person p1 = new Person("Голубчиков");
Person p2 = new Person("Габитов - прогульная дичь");
Person p3 = new Person("Хроменков - любитель туалетов");
Person[] comp = new Person[3];
comp[0] = p1;
comp[1] = p2;
comp[2] = p3;
Company company = new Company(comp);
Console.WriteLine(company.people[0].Name);
Console.WriteLine(company[10].Name);
class Person
{
    public string? Name { get; }
    public Person(string? name)=>Name = name;
}
class Company
{
    public Person[] people;
    public Company(Person[] people)=>this.people = people;
    public Person this[int index]
    {
        get
        {
            if (index >= 0 && index < people.Length)
                return people[index];
            else
                throw new ArgumentOutOfRangeException();
        }
        set
        {
            if (index >= 0 && index < people.Length)
                people[index] = value;
        }
    }
}
