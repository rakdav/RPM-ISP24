//анонимный тип
using System.Text.RegularExpressions;

//var car = new { Make = "VW", Model = "Bug" };
string mail = "golubchikov@mail.ru";
Console.WriteLine(mail.IsValidEmailAddress());
Console.WriteLine(mail.CountWord('u'));

List<Car> cars = GetCars();
List<Car> filtered = new List<Car>();
//foreach (Car car in cars)
//{
//    if (car.Year > 1990 && car.Model.StartsWith("F"))
//    {
//        filtered.Add(car);
//    }
//}
//foreach (Car car in cars)
//{
//    if (FilterYear(car) && FilterModel(car))
//    {
//        filtered.Add(car);
//    }
//}
List<FilterPredicate> predicates = new List<FilterPredicate>();
//predicates.Add(delegate (Car car) { return car.Year > 1990; });
//predicates.Add(delegate (Car car) { return car.Model.StartsWith("F"); });

//predicates.Add((Car car) => car.Year > 1990);
//predicates.Add((Car car) => car.Model.StartsWith("F"));

predicates.Add(car => car.Year > 1990);
predicates.Add(car => car.Model.StartsWith("F"));
foreach (Car car in cars)
{
    if (CheckPredicates(car, predicates)) { filtered.Add(car); }
}
foreach (var i in filtered) Console.Write(i.Model+" ");
Console.WriteLine();
bool FilterYear(Car car) { return car.Year > 1990; }
bool FilterModel(Car car) { return car.Model.StartsWith("F"); }

bool CheckPredicates(Car car, IList<FilterPredicate> predicates)
{
    foreach (FilterPredicate p in predicates)
    {
        if (!p(car)) { return false; }
    }

    return true;
}



List<Car> GetCars()
{
    return new List<Car>
                {
                    new Car { VIN = "ABC123", Make = "Ford",
                            Model = "F-250", Year = 2000 },
                    new Car { VIN = "DEF123", Make = "BMW",
                            Model = "Z-3", Year = 2005 },
                    new Car { VIN = "ABC456", Make = "Audi",
                            Model = "TT", Year = 2008 },
                    new Car { VIN = "HIJ123", Make = "VW",
                            Model = "Bug",  Year = 1956  },
                    new Car { VIN = "DEF456", Make = "Ford",
                            Model = "F-150", Year = 1998 }
                };
}

public class Car
{
    public string VIN { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
}
public static class MyExtension
{
    public static bool IsValidEmailAddress(this string s)
    {
        Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        return regex.IsMatch(s);
    }
    public static int CountWord(this string stroka,char ch)
    {
        int count = 0;
        foreach(char i in stroka)
        {
            if (i == ch) count++;
        }
        return count;
    }
}
public delegate bool FilterPredicate(Car car);