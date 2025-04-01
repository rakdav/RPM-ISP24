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

namespace Lesson36;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    public static readonly DependencyProperty MyPropProperty;
    public string MyProp
    {
        get { return (string)GetValue(MyPropProperty); }
        set { SetValue(MyPropProperty, value); }
    }
    static MainWindow()
    {
        FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata("Начальное значение");
        metadata.BindsTwoWayByDefault = true;
        metadata.Inherits = false;
        metadata.AffectsRender = true;
        metadata.AffectsMeasure = false;
        MyPropProperty = DependencyProperty.Register("MyProp", 
            typeof(string), typeof(MainWindow), metadata);
    }
}