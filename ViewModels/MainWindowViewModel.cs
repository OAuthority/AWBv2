using System;
using Avalonia.Controls;

namespace AWBv2.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly Window _window;

    private string _lblUsername;
    private string _lblProject;
    private int _lblNewArticles;
    private int _lblIgnoredArticles;
    private int _lblEditCount;
    private int _lblEditsPerMin;
    private int _lblPagesPerMin;
    private int _lblTimer;
    
    public string LblUsername { get => _lblUsername; set => _lblUsername = value; }
    public string LblProject { get => _lblProject; set => _lblProject = value; }
    public int LblNewArticles { get => _lblNewArticles; set => _lblNewArticles = value; }
    public int LblIgnoredArticles { get => _lblIgnoredArticles; set => _lblIgnoredArticles = value; }
    public int LblEditCount { get => _lblEditCount; set => _lblEditCount = value; }
    public int LblEditsPerMin { get => _lblEditsPerMin; set => _lblEditsPerMin = value; }
    public int LblPagesPerMin { get => _lblPagesPerMin; set => _lblPagesPerMin = value; }
    public int LblTimer { get => _lblTimer; set => _lblTimer = value; }
    
    public MainWindowViewModel(Window window)
    {
        _window = window ?? throw new ArgumentNullException(nameof(window), "Window cannot be null");
        _lblUsername = string.Empty;
        _lblProject = "Wikipedia";
        _lblNewArticles = 0;
        _lblIgnoredArticles = 0;
        _lblEditCount = 0;
        _lblEditsPerMin = 0;
        _lblPagesPerMin = 0;
        _lblTimer = 0;
    }

    /// <summary>
    /// Close the window and exit the programme when clicked
    /// </summary>
    public void CloseWindow()
    {
        _window.Close();
    }
   
}