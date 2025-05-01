//Работа с дисками
//DriveInfo[] drives = DriveInfo.GetDrives();
//foreach(DriveInfo drive in drives)
//{
//    Console.WriteLine(drive.Name);
//    Console.WriteLine(drive.DriveType);
//    Console.WriteLine(drive.RootDirectory);
//    if (drive.IsReady)
//    {
//        Console.WriteLine(drive.TotalSize);
//        Console.WriteLine(drive.TotalFreeSpace);
//        Console.WriteLine(drive.VolumeLabel);
//        Console.WriteLine(drive.AvailableFreeSpace);
//        Console.WriteLine(drive.DriveFormat);
//    }
//}

//Работа с каталогами Directory, DirectoryInfo
//Directory выполняют дополнительные проверки безопасности. А для класса DirectoryInfo такие проверки не всегда обязательны.
//Directory
//string dirName = "D:\\laravel";
//if (Directory.Exists(dirName))
//{
//    Console.WriteLine("Подкаталоги:");
//    string[] dirs = Directory.GetDirectories(dirName);
//    foreach(string s in dirs)
//    {
//        Console.WriteLine(s);
//    }
//    Console.WriteLine();
//    Console.WriteLine("Файлы:");
//    string[] files = Directory.GetFiles(dirName);
//    foreach (string s in files)
//    {
//        Console.WriteLine(s);
//    }
//}
//DirectoryInfo
//string dirName = "D:\\laravel";
//var directory = new DirectoryInfo(dirName);
//if (directory.Exists)
//{
//    Console.WriteLine("Подкаталоги:");
//    DirectoryInfo[] dirs = directory.GetDirectories();
//    foreach (DirectoryInfo s in dirs)
//    {
//        Console.WriteLine(s);
//    }
//    Console.WriteLine();
//    Console.WriteLine("Файлы:");
//    FileInfo[] files = directory.GetFiles();
//    foreach (FileInfo s in files)
//    {
//        Console.WriteLine(s);
//    }
//}
//Фильтрация папок и файлов
// * или символ-звездочка (соответствует любому количеству символов)
// ? или вопросительный знак (соответствует одному символу)
string dirName = @"D:\Наука\Технические и естественные науки";
//string[] dirs = Directory.GetDirectories(dirName, "КБ*");
//foreach(string s in dirs) Console.WriteLine(s);
//var directory = new DirectoryInfo(dirName);
//DirectoryInfo[] dirs = directory.GetDirectories("КБ*");
//foreach(DirectoryInfo d in dirs) Console.WriteLine(d.Name);

//string[] files = Directory.GetFiles(dirName, "*.pdf");
//foreach(string f in files) Console.WriteLine(f);
//var directory = new DirectoryInfo(dirName);
//FileInfo[] files = directory.GetFiles("*.pdf");
//foreach (FileInfo f in files) Console.WriteLine(f.Name);

//Создание каталога
//Console.Write("Введите название каталога:");
//string path = Console.ReadLine()!;
//if(!Directory.Exists(@"D:\"+path))
//{
//    Directory.CreateDirectory(@"D:\" + path);
//}
//DirectoryInfo dirInfo = new DirectoryInfo(@"D:\" + path);
//if (!dirInfo.Exists) dirInfo.Create();

//Получение информации о каталоге
//DirectoryInfo dir = new DirectoryInfo(@"D:\Наука");
//Console.WriteLine(dir.Name);
//Console.WriteLine(dir.FullName);
//Console.WriteLine(dir.Parent);
//Console.WriteLine(dir.Root);
//Console.WriteLine(dir.CreationTime);
//Console.WriteLine(dir.Attributes);

//Удаление каталога
//DirectoryInfo dirInfo = new DirectoryInfo(@"D:\folder");
//if (dirInfo.Exists)
//{
//    dirInfo.Delete(true);
//    Console.WriteLine("Каталог удален");
//}
//else
//{
//    Console.WriteLine("Каталог не существует");
//}
//if (Directory.Exists("D:\folder"))
//{
//    Directory.Delete("D:\folder", true);
//    Console.WriteLine("Каталог удален");
//}
//else
//{
//    Console.WriteLine("Каталог не существует");
//}

//Перемещение каталога
string oldPath = @"D:\SomeFolder";
string newPath = @"D:\SomeDir";
DirectoryInfo dirInfo = new DirectoryInfo(oldPath);
if (dirInfo.Exists && !Directory.Exists(newPath))
{
    dirInfo.MoveTo(newPath);
}