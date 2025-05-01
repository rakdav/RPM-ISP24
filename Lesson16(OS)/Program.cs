//Thread current = Thread.CurrentThread;
//Console.WriteLine($"Name:{current.Name}");
//current.Name = "Main";
//Console.WriteLine($"Name:{current.Name}");
//Console.WriteLine($"Запущен ли поток: {current.IsAlive}");
//Console.WriteLine($"Id потока: {current.ManagedThreadId}");
//Console.WriteLine($"Приоритет потока: {current.Priority}");
//Виды приоритетов:
//Lowest
//BelowNormal
//Normal
//AboveNormal
//Highest
//current.Priority = ThreadPriority.Highest;
//Console.WriteLine($"Приоритет потока: {current.Priority}");
//Console.WriteLine($"Статус потока: {current.ThreadState}");
//Aborted: поток остановлен, но пока еще окончательно не завершен
//AbortRequested: для потока вызван метод Abort, но остановка потока еще не произошла
//Background: поток выполняется в фоновом режиме
//Running: поток запущен и работает (не приостановлен)
//Stopped: поток завершен
//StopRequested: поток получил запрос на остановку
//Suspended: поток приостановлен
//SuspendRequested: поток получил запрос на приостановку
//Unstarted: поток еще не был запущен
//WaitSleepJoin: поток заблокирован в результате действия методов Sleep или Join
//Console.WriteLine($"Является ли поток фоновым:{current.IsBackground}");
//Thread myThread1 = new Thread(Print);
//Thread myThread2 = new Thread(new ThreadStart(Print));
//Thread myThread3 = new Thread(()=> Console.WriteLine("Hello"));
//myThread1.Start();
//myThread2.Start();
//myThread3.Start();
//void Print() => Console.WriteLine("Hello Threads");
//Thread myThread4 = new Thread(PrintNumbers);
//myThread4.Start();
//for (int i = 0; i < 5; i++)
//{
//    Console.WriteLine($"Главный поток:{i}");
//    Thread.Sleep(1000);
//}
//void PrintNumbers()
//{
//	for (int i = 0; i < 5; i++)
//	{
//        Console.WriteLine($"Второй поток:{i}");
//		Thread.Sleep(1000);
//	}
//}

//Потоки с параметрами
//Console.Write("Введите число:");
//int n = int.Parse(Console.ReadLine()!);
//Thread myThread = new Thread(Print);
//myThread.Start(n);
//int[] mas = new int[10];
//Random random = new Random();
//for (int i = 0; i < mas.Length; i++)
//{
//    mas[i] = random.Next(10, 100);
//    Console.Write(mas[i]+" ");
//}
//Console.WriteLine();
//Thread thread = new Thread(AvgMas);
//thread.Start(mas);
Random random = new Random();
for (int i = 1; i < 1000; i++)
{
    Thread thread = new Thread(PrintSnow);
    thread.Start();
}

void Print(object? obj)
{
    if(obj is int n) Console.WriteLine($"{n}*{n}={n*n}");
}
void AvgMas(object? obj)
{
    if (obj is int[] n) 
    {
        double s = 0;
        for (int i = 0; i < n.Length; i++) s += n[i];
        Console.SetCursorPosition(10, 10);
        Console.WriteLine($"Среднее арифметическое:{s/n.Length:F2}");
    }
}
void PrintSnow()
{
        while (true)
        {
            Random random = new Random(); 
            Console.SetCursorPosition(random.Next(100), random.Next(30));
        Thread.Sleep(500);
            Console.WriteLine("*");
        }
}