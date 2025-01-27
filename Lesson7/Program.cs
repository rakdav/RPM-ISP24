//class PersonInt
//{
//    public int Id { get; }
//    public string? Name { get; }
//    public PersonInt(int id, string? name)
//    {
//        Id = id;
//        Name = name;
//    }
//}

//class PersonString
//{
//    public string Id { get; }
//    public string? Name { get; }
//    public PersonString(string id, string? name)
//    {
//        Id = id;
//        Name = name;
//    }
//}
//class Person
//{
//    public object Id { get; }
//    public string? Name { get; }
//    public Person(object id, string? name)
//    {
//        Id = id;
//        Name = name;
//    }
//}
Person<int,int> tom = new Person<int,int>(457, "Tom",1213);
Person<int,string> bob = new Person<int,string>(12, "Bob","qwerty");
int id = tom.Id;
int idbob = bob.Id;
Company<Person<int,int>> hromenSoft = new Company<Person<int,int>>(tom);
Console.WriteLine(hromenSoft.CEO.Id);
Console.WriteLine(hromenSoft.CEO.Name);
IUser<int> user1 = new User<int>(1234);
Console.WriteLine(user1.id);
IUser<string> user2 = new User<string>("qwerty");
Console.WriteLine(user2.id);
class Person<T,K>
{
    public T Id { get; }
    public K Password { get; set; }
    public string? Name { get; }
    public Person(T id, string? name,K password)
    {
        Id = id;
        Name = name;
        Password = password;
    }
}
class Company<P>
{
    public P CEO { get; set; }
    public Company(P ceo) { CEO = ceo; }
}
class UniversalPerson<T, K> : Person<T, K>
{
    public UniversalPerson(T id, string? name, K password) : 
        base(id, name, password)
    {
    }
}
interface IUser<T>
{
    T id { get; }
}
class User<T> : IUser<T>
{
    public T id { get; }
    public User(T id)
    {
        this.id = id;
    }
}