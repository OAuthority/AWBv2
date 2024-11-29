using System;
using Avalonia.Controls;

namespace AWBv2.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly Window _window;
    
    public MainWindowViewModel(Window window)
    {
        _window = window ?? throw new ArgumentNullException(nameof(window), "Window cannot be null");
    }
    
    public string Greeting => "Welcome to Avalonia!";

    /// <summary>
    /// Close the window and exit the programme when clicked
    /// </summary>
    public void CloseWindow()
    {
        _window.Close();
    }
}