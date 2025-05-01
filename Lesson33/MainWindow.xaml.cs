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

namespace Lesson33;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        //button.Click += Button_Click1;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Hi from button_click");
    }
    private void Button_Click1(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Hi from button_click1");
    }

    private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
    {
        //textBlock.Text =textBlock.Text+ "Sender:" + sender.ToString() + "\n";
        //textBlock.Text =textBlock.Text+ "Source:" + e.Source.ToString() + "\n\n";
    }
    private void Radio_click(object sender,RoutedEventArgs e)
    {
        RadioButton selectedRadio = (RadioButton)e.Source;
        MessageBox.Show(selectedRadio.Content.ToString());
    }

    private void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key >= Key.D0 && e.Key <= Key.D9) return;
        e.Handled = true;
    }
}