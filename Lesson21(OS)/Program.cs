//Task task1 = new Task(()=>
//{
//    Console.WriteLine("Hello Task1!!");
//    Thread.Sleep(1000);
//});
//task1.Start();
//Task task2 = Task.Factory.StartNew(()=> 
//{
//    Console.WriteLine("Hello Task2!!");
//    Thread.Sleep(1000);
//});
//Task task3 = Task.Run(() =>
//{
//    Thread.Sleep(1000);
//    Console.WriteLine("Hello Task3!!");
//});
//task1.Wait();
//task2.Wait();
//task3.Wait();
//Console.WriteLine(task1.Id);
//Console.WriteLine(task1.AsyncState);
//Console.WriteLine(task1.Status);
//Console.WriteLine(task1.Exception);
//Console.WriteLine(task1.IsCompleted);
//Console.WriteLine(task1.IsCanceled);
//Console.WriteLine(task1.IsFaulted);
//Console.WriteLine(task1.IsCompletedSuccessfully);

//Вложенные задачи
//var outer = Task.Factory.StartNew(() =>
//{
//    Console.WriteLine("Outer task starting ...");
//    var inner = Task.Factory.StartNew(() =>
//    {
//        Console.WriteLine("Inner task starting ...");
//        Thread.Sleep(2000);
//        Console.WriteLine("Inner task finished ...");
//    }, TaskCreationOptions.AttachedToParent);
//});
//outer.Wait();
//Console.WriteLine("End of main");

//Массив задач
//Task[] tasks1 = new Task[3]
//{
//    new Task(()=>Console.WriteLine("First task")),
//    new Task(()=>Console.WriteLine("Second task")),
//    new Task(()=>Console.WriteLine("Third task"))
//};
//foreach(var t in tasks1) t.Start();
//Task.WaitAll(tasks1);

//Возвращение результатов из задач
//int Sum(int x, int y) => x + y;
//int n = 6, m = 7;
//Task<int> sumTask = new Task<int>(()=>Sum(n,m));
//sumTask.Start();
//int res = sumTask.Result;
//Console.WriteLine($"{n}+{m}={res}");

//Задачи продолжения continuation task
//int Sum(int x, int y) => x + y;
//void PrintResult(int sum) => Console.WriteLine($"Sum:{sum}");
//Task<int> sumTask = new Task<int>(() =>Sum(4,8));
//Task printTask = sumTask.ContinueWith(task => PrintResult(task.Result));
//sumTask.Start();
//printTask.Wait();

//Класс Parallel
//void Print()
//{
//    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
//    Thread.Sleep(1000);
//}
//void Square(int n)
//{
//    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
//    Thread.Sleep(3000);
//    Console.WriteLine($"Результат {n*n}");
//}
//Parallel.Invoke(
//    Print,
//    () =>
//    {
//        Console.WriteLine($"Выполняется задача {Task.CurrentId}");
//        Thread.Sleep(3000);
//    },
//    ()=>Square(10)
//);

//void Square(int n,ParallelLoopState pls)
//{
//    if (n == 4) pls.Break();
//    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
//    Thread.Sleep(2000);
//    Console.WriteLine($"Результат {n * n}");
//}
//Parallel.For
//Parallel.For(1, 5, Square);

//Parallel.ForEach
//ParallelLoopResult result = Parallel.ForEach<int>(
//    new List<int>() { 5,2,9,4},Square);
//ParallelLoopResult result = Parallel.For(1, 10, Square);
//if (!result.IsCompleted) Console.WriteLine($"Завершение на итерации {result.LowestBreakIteration}");

//Отмена задач и параллельных операций. CancellationToken
//1.Создание объекта CancellationTokenSource, который управляет и посылает уведомление об отмене токену.
//2.С помощью свойства CancellationTokenSource.Token получаем собственно токен - объект структуры CancellationToken и передаем его в задачу, которая может быть отменена.
//3.Определяем в задаче действия на случай ее отмены.
//4.Вызываем метод CancellationTokenSource.Cancel(), который устанавливает для свойства CancellationToken.IsCancellationRequested значение true. Стоит понимать, что сам по себе метод CancellationTokenSource.Cancel() не отменяет задачу, он лишь посылает уведомление об отмене через установку свойства CancellationToken.IsCancellationRequested. Каким образом будет происходить выход из задачи, это решает сам разработчик.
//5.Класс CancellationTokenSource реализует интерфейс IDisposable. И когда работа с объектом CancellationTokenSource завершена, у него следует вызвать метод Dispose для освобождения всех связанных с ним используемых ресурсов. (Вместо явного вызова метода Dispose можно использовать конструкцию using).

//Мягкий выход из задачи без исключения OperationCanceledException
//CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
//CancellationToken token = cancelTokenSource.Token;
//Task task = new Task(() =>
//{
//    for (int i = 1; i < 10; i++)
//    {
//        if (i==5&&token.IsCancellationRequested)
//        {
//            Console.WriteLine("Операция прервана");
//            return;
//        }
//        Console.WriteLine($"Квадрат числа {i} равен {i * i}");
//        Thread.Sleep(200);
//    }
//},token);
//task.Start();
//cancelTokenSource.Cancel();
//Thread.Sleep(1000);
//Console.WriteLine($"Task Status: {task.Status}");
//cancelTokenSource.Dispose();

//Отмена задачи с помощью генерации исключения
//CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
//CancellationToken token = cancelTokenSource.Token;
//Task task = new Task(() =>
//{
//    for (int i = 1; i < 10; i++)
//    {
//        if (token.IsCancellationRequested)
//            token.ThrowIfCancellationRequested();
//        Console.WriteLine($"Квадрат числа {i} равен {i * i}");
//        Thread.Sleep(200);
//    }
//}, token);
//try
//{
//    task.Start();
//    Thread.Sleep(1000);
//    cancelTokenSource.Cancel();
//    task.Wait();
//}
//catch (AggregateException ae)
//{
//    foreach (Exception e in ae.InnerExceptions)
//    {
//        if (e is TaskCanceledException)
//            Console.WriteLine("Операция прервана");
//        else
//            Console.WriteLine(e.Message);
//    }
//}
//finally
//{
//    cancelTokenSource.Dispose();
//}

//Регистрация обработчика отмены задачи
//CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
//CancellationToken token = cancelTokenSource.Token;
//Task task = new Task(() =>
//{
//    int i = 1;
//    token.Register(() =>
//    {
//        Console.WriteLine("Операция прервана");
//        i = 10;
//    });
//    for (; i < 10; i++)
//    {
//        Console.WriteLine($"Квадрат числа {i} равен {i * i}");
//        Thread.Sleep(400);
//    }
//}, token);
//task.Start();
//Thread.Sleep(1000);
//cancelTokenSource.Cancel();
//Thread.Sleep(1000);
//Console.WriteLine($"Task Status: {task.Status}");
//cancelTokenSource.Dispose();

//Передача токена во внешний метод
//CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
//CancellationToken token = cancelTokenSource.Token;

//void PrintSquares(CancellationToken token)
//{
//    for (int i = 1; i < 10; i++)
//    {
//        if (token.IsCancellationRequested)
//            token.ThrowIfCancellationRequested(); // генерируем исключение
//        Console.WriteLine($"Квадрат числа {i} равен {i * i}");
//        Thread.Sleep(200);
//    }
//}
//Task task = new Task(() => PrintSquares(token), token);
//try
//{
//    task.Start();
//    Thread.Sleep(1000);
//    cancelTokenSource.Cancel();
//    task.Wait();
//}
//catch (AggregateException ae)
//{
//    foreach (Exception e in ae.InnerExceptions)
//    {
//        if (e is TaskCanceledException)
//            Console.WriteLine("Операция прервана");
//        else
//            Console.WriteLine(e.Message);
//    }
//}
//finally
//{
//    cancelTokenSource.Dispose();
//}
//Console.WriteLine($"Task Status: {task.Status}");

//Отмена параллельных операций Parallel
CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
CancellationToken token = cancelTokenSource.Token;

new Task(() =>
{
    Thread.Sleep(400);
    cancelTokenSource.Cancel();
}).Start();
try
{
    Parallel.ForEach<int>(new List<int>() { 1, 2, 3, 4, 5 },
                                new ParallelOptions { CancellationToken = token }, Square);
    // или так
    //Parallel.For(1, 5, new ParallelOptions { CancellationToken = token }, Square);
}
catch (OperationCanceledException)
{
    Console.WriteLine("Операция прервана");
}
finally
{
    cancelTokenSource.Dispose();
}
void Square(int n)
{
    Thread.Sleep(3000);
    Console.WriteLine($"Квадрат числа {n} равен {n * n}");
}