Task task1 = new Task(()=>
{
    Console.WriteLine("Hello Task1!!");
    Thread.Sleep(1000);
});
task1.Start();
Task task2 = Task.Factory.StartNew(()=> 
{
    Console.WriteLine("Hello Task2!!");
    Thread.Sleep(1000);
});
Task task3 = Task.Run(() =>
{
    Thread.Sleep(1000);
    Console.WriteLine("Hello Task3!!");
});
task1.Wait();
task2.Wait();
task3.Wait();
Console.WriteLine(task1.Id);
Console.WriteLine(task1.AsyncState);
Console.WriteLine(task1.Status);
Console.WriteLine(task1.Exception);
Console.WriteLine(task1.IsCompleted);
Console.WriteLine(task1.IsCanceled);
Console.WriteLine(task1.IsFaulted);
Console.WriteLine(task1.IsCompletedSuccessfully);

