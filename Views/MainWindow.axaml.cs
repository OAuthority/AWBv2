using System;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace AWBv2.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        WebBrowser.Navigate("https://en.wikipedia.org");
    }
}