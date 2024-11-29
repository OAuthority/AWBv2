using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using ReactiveUI;

namespace AWBv2.ViewModels;

public partial class MainWindowViewModel : ReactiveObject
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
    
    public string LblUsername { get => _lblUsername; set => _lblUsername = this.RaiseAndSetIfChanged(ref _lblUsername, value); }
    public string LblProject { get => _lblProject; set => _lblProject = this.RaiseAndSetIfChanged(ref _lblProject, value); }
    public int LblNewArticles { get => _lblNewArticles; set => _lblNewArticles = this.RaiseAndSetIfChanged(ref _lblNewArticles, value); }
    public int LblIgnoredArticles { get => _lblIgnoredArticles; set => _lblIgnoredArticles = this.RaiseAndSetIfChanged(ref _lblIgnoredArticles, value); }
    public int LblEditCount { get => _lblEditCount; set => _lblEditCount = this.RaiseAndSetIfChanged(ref _lblEditCount, value); }
    public int LblEditsPerMin { get => _lblEditsPerMin; set => _lblEditsPerMin = this.RaiseAndSetIfChanged(ref _lblEditsPerMin, value); }
    public int LblPagesPerMin { get => _lblPagesPerMin; set => _lblPagesPerMin = this.RaiseAndSetIfChanged(ref _lblPagesPerMin, value); }
    public int LblTimer { get => _lblTimer; set => _lblTimer = this.RaiseAndSetIfChanged(ref _lblTimer, value); }
    
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