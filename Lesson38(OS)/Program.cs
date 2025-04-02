using System.Linq.Expressions;

void Print()
{
    Thread.Sleep(3000);
    Console.WriteLine("Hello, Nadia");
}
async Task PrintAsync()
{
    Console.WriteLine("Начало метода PrintAsync");
    await Task.Run(Print);
    Console.WriteLine("Конец метода PrintAsync");
}
async Task PrintNameAsync(string name)
{
    await Task.Delay(3000);
    Console.WriteLine(name);
}

async void VoidPrintAsync(string mes)
{
    await Task.Delay(1000);
    Console.WriteLine(mes);
}

//await PrintAsync();
//await PrintNameAsync("Tom");
//await PrintNameAsync("Bob");
//await PrintNameAsync("Serozha");

//void
//VoidPrintAsync("Nadya");
//await Task.Delay(2000);

//Task<T>
async Task<int> SquareAsync(int n)
{
    await Task.Delay(0);
    return n * n;
}
//int n1 = await SquareAsync(7);
//int n2 = await SquareAsync(9);
//Console.WriteLine($"n1={n1} n2={n2}");

//ValueTask<T>
ValueTask<int> AddAsync(int a,int b)
{
    return new ValueTask<int>(a + b);
}
//var result = await AddAsync(4, 9);
//Console.WriteLine(result);

//Последовательное и параллельное выполнение. Task.WhenAll и Task.WhenAny
//var task1 = PrintNameAsync("first");
//var task2 = PrintNameAsync("second");
//var task3 = PrintNameAsync("third");

//await task1;
//await task2;
//await task3;

//await Task.WhenAll(task1, task2, task3);
//await Task.WhenAny(task1, task2, task3);

async Task<int> SquareAsyncResult(int n)
{
    await Task.Delay(1000);
    return n * n;
}
//var task1 = SquareAsyncResult(3);
//var task2 = SquareAsyncResult(8);
//var task3 = SquareAsyncResult(5);
//int[] result = await Task.WhenAll(task1, task2, task3);
//foreach(int res in result) Console.WriteLine(res);
//await Task.WhenAll(task1, task2, task3);
//Console.WriteLine(task2.Result);

async IAsyncEnumerable<int> GetNumbersAsync()
{
    for(int i = 0; i < 10; i++)
    {
        await Task.Delay(100);
        yield return i;
    }
}
//await foreach(var num in GetNumbersAsync())
//{
//    Console.WriteLine(num);
//}

//Обработка ошибок в асинхронных методах
async Task PrintException(string news)
{
    if (news.Length < 3)
        throw new ArgumentException($"Invalid string");
    await Task.Delay(100);
    Console.WriteLine(news);
}
try
{
    await PrintException("heeeel");
    await PrintException("hi");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}