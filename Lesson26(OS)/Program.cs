//Критическая секция
//int x = 0;
//object locker = new();
//for (int i = 1; i < 6; i++)
//{
//    Thread myThread = new(Print);
//    myThread.Name = $"Поток:{i}";
//    myThread.Start();
//}
//void Print()
//{
//    lock (locker) {
//        x = 1;
//        for (int i = 1; i < 6; i++)
//        {
//            Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
//            x++;
//            Thread.Sleep(100);
//        }
//    }
//}

//Монитор
//int x = 0;
//object locker = new();
//for (int i = 1; i < 6; i++)
//{
//    Thread myThread = new(Print);
//    myThread.Name = $"Поток:{i}";
//    myThread.Start();
//}
//void Print()
//{
//    bool acquiredLock = false;
//    try
//    {
//        Monitor.Enter(locker, ref acquiredLock);
//        x = 1;
//        for (int i = 1; i < 6; i++)
//        {
//            Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
//            x++;
//            Thread.Sleep(100);
//        }
//    }
//    finally
//    {
//        if (acquiredLock) Monitor.Exit(locker);
//    }
//}

//Класс Lock и синхронизация
//int x = 0;
//Lock lockObj = new();
//for (int i = 1; i < 6; i++)
//{
//    Thread myThread = new(Print);
//    myThread.Name = $"Поток:{i}";
//    myThread.Start();
//}
//void Print()
//{
//    //lock (lockObj)
//    //{
//    //    x = 1;
//    //    for (int i = 1; i < 6; i++)
//    //    {
//    //        Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
//    //        x++;
//    //        Thread.Sleep(100);
//    //    }
//    //}
//    //if (lockObj.TryEnter())
//    //{
//    //    try
//    //    {
//    //        x = 1;
//    //        for (int i = 1; i < 6; i++)
//    //        {
//    //            Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
//    //            x++;
//    //            Thread.Sleep(100);
//    //        }
//    //    }
//    //    finally { lockObj.Exit(); }
//    //}
//    //using(lockObj.EnterScope())
//    //{
//    //    x = 1;
//    //    for (int i = 1; i < 6; i++)
//    //    {
//    //        Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
//    //        x++;
//    //        Thread.Sleep(100);
//    //    }
//    //}
//}

//AutoResetEvent
//int x = 0;
//AutoResetEvent waitHandler = new AutoResetEvent(true);
//for (int i = 1; i < 6; i++)
//{
//    Thread myThread = new(Print);
//    myThread.Name = $"Поток:{i}";
//    myThread.Start();
//}
//void Print()
//{
//    waitHandler.WaitOne();
//        x = 1;
//        for (int i = 1; i < 6; i++)
//        {
//            Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
//            x++;
//            Thread.Sleep(100);
//        }
//    waitHandler.Set();
//}

//Мьютекс
//int x = 0;
//Mutex mutexObj = new();
//for (int i = 1; i < 6; i++)
//{
//    Thread myThread = new(Print);
//    myThread.Name = $"Поток:{i}";
//    myThread.Start();
//}
//void Print()
//{
//    mutexObj.WaitOne();
//    x = 1;
//    for (int i = 1; i < 6; i++)
//    {
//        Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
//        x++;
//        Thread.Sleep(100);
//    }
//    mutexObj.ReleaseMutex();
//}

//Семафор
for (int i = 1; i < 6; i++)
{
    Reader reader = new Reader(i);
}
class Reader
{
    static Semaphore sem = new Semaphore(3, 3);
    Thread myThread;
    int count = 3;
    public Reader(int i)
    {
        myThread = new Thread(Read);
        myThread.Name = $"Читатель:{i}";
        myThread.Start();
    }
    public void Read()
    {
        while (count > 0)
        {
            sem.WaitOne();
            Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");
            Console.WriteLine($"{Thread.CurrentThread.Name} читает");
            Thread.Sleep(1000);
            Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");
            sem.Release();
            count--;
            Thread.Sleep(1000);
        }
    }
}
