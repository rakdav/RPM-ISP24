using System.Diagnostics;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

//var process = Process.GetCurrentProcess();
//Console.WriteLine(process.Id);
//Console.WriteLine(process.Handle);
//Console.WriteLine(process.MachineName);
//Console.WriteLine(process.MainModule);
//Console.WriteLine(process.ProcessName);
//Console.WriteLine(process.StartTime);
//Console.WriteLine(process.PagedMemorySize64);
//Console.WriteLine(process.VirtualMemorySize64);

//foreach (Process proc in Process.GetProcesses().OrderBy(p=>p.ProcessName))
//{
//    Console.WriteLine($"Id:{proc.Id} Name:{proc.ProcessName}");
//}
//Process[] vsProcs = Process.GetProcessesByName("devenv");
//foreach(var proc in vsProcs) Console.WriteLine($"{proc.Id}:{proc.ProcessName}");
//Process[] vsProcs = Process.GetProcessesByName("CalculatorApp");

//foreach (var proc in vsProcs) proc.Kill();

//Process calcProc = new Process();
//calcProc.StartInfo = new ProcessStartInfo("calc.exe");
//calcProc.Start();
//Process[] vsProcs = Process.GetProcessesByName("devenv");
//foreach (var proc in vsProcs) proc.Kill();

//Process vsProcs = Process.GetProcessesByName("devenv")[0];
//ProcessThreadCollection processThreads = vsProcs.Threads;
//ProcessModuleCollection modules = vsProcs.Modules;
//foreach(ProcessThread thread in processThreads)
//{
//    Console.WriteLine($"ThreadId:{thread.Id}");
//}
//foreach(ProcessModule module in modules)
//{
//    Console.WriteLine($"{module.ModuleName} Filename:{module.FileName}");
//}

//Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe",
//    "https://mail.ru");
AppDomain domain = AppDomain.CurrentDomain;
Console.WriteLine(domain.FriendlyName);
Console.WriteLine(domain.BaseDirectory);
Console.WriteLine();
Assembly[] assemblies = domain.GetAssemblies();
foreach(Assembly asm in assemblies)
    Console.WriteLine(asm.GetName().Name);
 