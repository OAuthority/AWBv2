using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using AWBv2.Controls;
using ReactiveUI;

namespace AWBv2.ViewModels;

public partial class MainWindowViewModel(Window window) : ReactiveObject
{
    private readonly Window _window = window ?? throw new ArgumentNullException(nameof(window), "Window cannot be null");
    private AWBWebBrowser _webBrowser;
    private string _lblUsername = string.Empty;
    private string _lblProject = "Wikipedia";
    private int _lblNewArticles = 0;
    private int _lblIgnoredArticles = 0;
    private int _lblEditCount = 0;
    private int _lblEditsPerMin = 0;
    private int _lblPagesPerMin = 0;
    private int _lblTimer = 0;

    public AWBWebBrowser WebBrowser
    {
        get => _webBrowser;
        set => this.RaiseAndSetIfChanged(ref _webBrowser, value);
    }


    public string LblUsername { get => _lblUsername; set => _lblUsername = this.RaiseAndSetIfChanged(ref _lblUsername, value); }
    public string LblProject { get => _lblProject; set => _lblProject = this.RaiseAndSetIfChanged(ref _lblProject, value); }
    public int LblNewArticles { get => _lblNewArticles; set => _lblNewArticles = this.RaiseAndSetIfChanged(ref _lblNewArticles, value); }
    public int LblIgnoredArticles { get => _lblIgnoredArticles; set => _lblIgnoredArticles = this.RaiseAndSetIfChanged(ref _lblIgnoredArticles, value); }
    public int LblEditCount { get => _lblEditCount; set => _lblEditCount = this.RaiseAndSetIfChanged(ref _lblEditCount, value); }
    public int LblEditsPerMin { get => _lblEditsPerMin; set => _lblEditsPerMin = this.RaiseAndSetIfChanged(ref _lblEditsPerMin, value); }
    public int LblPagesPerMin { get => _lblPagesPerMin; set => _lblPagesPerMin = this.RaiseAndSetIfChanged(ref _lblPagesPerMin, value); }
    public int LblTimer { get => _lblTimer; set => _lblTimer = this.RaiseAndSetIfChanged(ref _lblTimer, value); }

    /// <summary>
    /// Close the window and exit the programme when clicked
    /// </summary>
    public void CloseWindow()
    {
        _window.Close();
    }
   
}