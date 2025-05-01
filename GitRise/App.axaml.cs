using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Hosting;

namespace GitRise;

public partial class App : Application
{
    public IHost? GlobalHost { get; private set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var hostBuilder = CreateHostBuilder();
        GlobalHost = hostBuilder.Build();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static HostApplicationBuilder CreateHostBuilder()
    {
        //< below: create HostApplicationBuilder instance
        // alternative: use Host.CreateDefaultBuilder
        var hostBuilder = Host.CreateApplicationBuilder(Environment.GetCommandLineArgs());

        //< finally: return
        return hostBuilder;
    }
}
