﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson34;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
    {
        Point p = e.GetPosition(this);
        MessageBox.Show("X=" + p.X.ToString() + " Y=" + p.Y.ToString());
    }

    private void textBox_MouseDown(object sender, MouseButtonEventArgs e)
    {
        DragDrop.DoDragDrop(textBox, textBox.Text, DragDropEffects.Copy);
    }

    private void button_Drop(object sender, DragEventArgs e)
    {
        button.Content = e.Data.GetData(DataFormats.Text);
    }
}