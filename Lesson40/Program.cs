
//абсолютный путь
//string? path1 = @"G:\MyFolder\file1.txt";
////относительный путь
//string path2 = @"MyDir\content.txt";
//FileInfo fileInfo = new FileInfo(path2);
//if (fileInfo.Exists)
//{
//    Console.WriteLine(fileInfo.FullName);
//    Console.WriteLine(fileInfo.Name);
//    Console.WriteLine(fileInfo.Length);
//    Console.WriteLine(fileInfo.CreationTime);
//    Console.WriteLine(fileInfo.CreationTimeUtc);
//    Console.WriteLine(fileInfo.Directory);
//    Console.WriteLine(fileInfo.DirectoryName);
//    Console.WriteLine(fileInfo.Extension);
//    Console.WriteLine(fileInfo.IsReadOnly);
//    Console.WriteLine(fileInfo.LastAccessTime);
//}
////создание
//FileInfo f1 = new FileInfo(@"MyDir\myfile.txt");
//if (!f1.Exists) f1.Create();
////перемещение
//string newPath = @"myfile.txt";
////f1.MoveTo(newPath,true);
////File.Move(@"MyDir\myfile.txt", @"myfile.txt");
////копирование
//string copyPath = @"MyDir\myfile.txt";
//FileInfo f2 = new FileInfo(@"myfile.txt");
//if(f2.Exists)
//{
//    // f2.CopyTo(copyPath, true);
//    //File.Copy(@"myfile.txt", copyPath);
//    f2.Delete();
//    //File.Delete(newPath);
//}
using System.Text;
//запись в  файл
//Console.Write("Введите текст:");
//string text = Console.ReadLine()!;
//using (FileStream fstream=new FileStream(@"myfile.txt",FileMode.OpenOrCreate))
//{
//    byte[] buffer = Encoding.Default.GetBytes(text);
//    await fstream.WriteAsync(buffer, 0, buffer.Length);
//}
//

//чтение из файла
//using(FileStream fstream = File.OpenRead(@"myfile.txt"))
//{
//    byte[] buffer = new byte[fstream.Length];
//    await fstream.ReadAsync(buffer, 0, buffer.Length);
//    string text = Encoding.Default.GetString(buffer);
//    Console.WriteLine(text);
//}

//Произвольный доступ к файлам
//С помощью метода Seek() мы можем управлять положением курсора потока, начиная с которого производится считывание или запись в файл. Этот метод принимает два параметра: offset(смещение) и позиция в файле. Позиция в файле описывается тремя значениями:
//SeekOrigin.Begin: начало файла
//SeekOrigin.End: конец файла
//SeekOrigin.Current: текущая позиция в файле
//using (FileStream fstream = new FileStream(@"myfile.txt", FileMode.OpenOrCreate))
//{
//    string replaceText = "house";
//    fstream.Seek(-5, SeekOrigin.End);
//    byte[] input = Encoding.Default.GetBytes(replaceText);
//    await fstream.WriteAsync(input, 0, input.Length);

//    fstream.Seek(0, SeekOrigin.Begin);
//    byte[] output = new byte[fstream.Length];
// }

//Чтение и запись текстовых файлов. StreamReader и StreamWriter
Console.Write("Введите название файла:");
string path = Console.ReadLine()!;
//Console.WriteLine("Введите текст:");
//string text = Console.ReadLine()!;
//using(StreamWriter writer=new StreamWriter(path, false))
//{
//    await writer.WriteLineAsync(text);
//}
//using (StreamWriter writer = new StreamWriter(path, true))
//{
//    await writer.WriteLineAsync("Additional");
//    await writer.WriteLineAsync("4,8");
//}

//1
//using (StreamReader reader=new StreamReader(path))
//{
//    string text = await reader.ReadToEndAsync();
//    Console.WriteLine(text);
//}

//2. Считаем текст из файла построчно:
using (StreamReader reader = new StreamReader(path))
{
    string? line;
    while ((line = await reader.ReadLineAsync()) != null)
    {
        Console.WriteLine(line);
    }
}