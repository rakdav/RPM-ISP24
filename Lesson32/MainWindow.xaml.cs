using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson32;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private CancellationTokenSource cancelToken = new CancellationTokenSource();
    public MainWindow()
    {
        InitializeComponent();
    }
    private void cmdCancel_Click(object sender, RoutedEventArgs e)
    {
        cancelToken.Cancel();
    }
    private void cmdProcess_Click(object sender, RoutedEventArgs e)
    {
        Task.Factory.StartNew(()=>ProcessFiles());
        this.Title = "Обработка завершена";
    }
    private void ProcessFiles()
    {
        ParallelOptions parOpts = new ParallelOptions();
        parOpts.CancellationToken = cancelToken.Token;
        parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
        var basePath = Directory.GetCurrentDirectory();
        var pictureDirectory = System.IO.Path.Combine(basePath, "Images");
        var outputDirectory = System.IO.Path.Combine(basePath, "ModifiedImages");
        if (Directory.Exists(outputDirectory)) Directory.Delete(outputDirectory, true);
        Directory.CreateDirectory(outputDirectory);
        string[] files = Directory.GetFiles(pictureDirectory, "*.jpg", SearchOption.AllDirectories);
        //foreach(string currentFile in files)
        //{
        try
        {
            Parallel.ForEach(files, currentFile =>
            {
                parOpts.CancellationToken.ThrowIfCancellationRequested();
                string fileName = System.IO.Path.GetFileName(currentFile);
                Dispatcher?.Invoke(() =>
                {
                    this.Title = $"Обработка {fileName} в потоке {Thread.CurrentThread.ManagedThreadId}";
                });
                using (Bitmap bitmap = new Bitmap(currentFile))
                {
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(System.IO.Path.Combine(outputDirectory, fileName));
                }
                Dispatcher?.Invoke(() => this.Title = "Готово!");
            });
        }
        catch(OperationCanceledException ex)
        {
            Dispatcher?.Invoke(()=>this.Title=ex.Message);
        }
        //}
    }
}