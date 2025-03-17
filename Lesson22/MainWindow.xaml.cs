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

namespace Lesson22;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //string text = textBoxMessage.Text;
        //labelMessage.Content = text;
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        string op = (sender as Button)!.Content.ToString()!;
        double var1 = double.Parse(first.Text);
        double var2 = double.Parse(second.Text);
        double result = 0;
        switch (op)
        {
            case "+": result = var1 + var2;break;
            case "-": result = var1 - var2;break;
            case "*": result = var1 * var2;break;
            case "/": result = var1 / var2;break;
        }
        Result.Content = $"{var1}{op}{var2}={result:F2}";
    }
}