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

string[] colors = { "Red", "Brown", "Orange", "Yellow", "Black", "Green", "White", "Violet", "Blue" };

var results = from c in colors
              where c.StartsWith("B")
              orderby c
              select c;
colors[4] = "Slate";
foreach (var item in results)
{
    Console.Write(item+" ");
}
Console.WriteLine();

var numbers1 = Enumerable.Empty<long>();
var numbers2 = Enumerable.Range(1, 5);
var numbers3 = Enumerable.Repeat(10, 5);

foreach (var item in numbers3)
{
    Console.Write(item+" ");
}
Console.WriteLine();
bool result1 = GetCars().All(c => c.Year > 1960);
Console.WriteLine(result1);
bool result2 = GetCars().Any(c => c.Year <= 1960);
Console.WriteLine(result2);
var strings = new MyStringList { "orange", "apple", "grape", "pear" };
foreach (var item in strings.AsEnumerable().Where(s => s.Length == 5))
{
    Console.Write(item + " ");
}
Console.WriteLine();
var querable = strings.AsQueryable();
Console.WriteLine(querable.ElementType);
Console.WriteLine(querable.Expression);
Console.WriteLine(querable.Provider);
int[] scores = { 88, 56, 23, 99, 65, 93, 78, 23, 99, 90 };
var evenScore = scores.Where(p => p % 2 == 0).ToList();
foreach (var item in evenScore)
{
    Console.Write(item + " ");
}
Console.WriteLine();
var cars = GetCars();
var carsByVin = cars.ToDictionary(c => c.VIN);
Car car = carsByVin["ABC123"];
Console.WriteLine(car.Year+" "+car.Make+" "+car.Color);
IEnumerable<Object> objects = scores.Cast<object>();
object[] items = new object[] { 55, "Hello", 22, "Goodbye" };
foreach (var intItem in items.OfType<int>())
{
    Console.Write(intItem+" ");
}
Console.WriteLine("Max: " + scores.Max());
Console.WriteLine("Min: " + scores.Min());
Console.WriteLine("Average: " + scores.Average());
Console.WriteLine("Sum: " + scores.Sum());
Console.WriteLine("Count: " + scores.Count());
Console.WriteLine(scores.ElementAtOrDefault(24));
Console.WriteLine(scores.FirstOrDefault());
Console.WriteLine(scores.LastOrDefault());
int score1 = scores.Where(x => x > 50 && x < 60).Single();
Console.WriteLine(score1);
int score2 = scores.Where(x => x > 100).SingleOrDefault();
Console.WriteLine(score2);

public class Car
{
    public string VIN { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
}
public class MyStringList : List<string>
{
    public IEnumerable<string> Where(Predicate<string> filter)
    {
        return this.Select(s => filter(s) ? s.ToUpper() : s);
    }
}




