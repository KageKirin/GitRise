using System;
using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using KageKirin.Extensions.Configuration.GitConfig;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
            desktop.MainWindow = GlobalHost.Services.GetRequiredService<MainWindow>();
            desktop.Exit += (sender, args) =>
            {
                GlobalHost.StopAsync(TimeSpan.FromSeconds(5)).GetAwaiter().GetResult();
                GlobalHost.Dispose();
                GlobalHost = null;
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static HostApplicationBuilder CreateHostBuilder()
    {
        //< below: create HostApplicationBuilder instance
        // alternative: use Host.CreateDefaultBuilder
        var hostBuilder = Host.CreateApplicationBuilder(Environment.GetCommandLineArgs());

        //< below: configure where the Host configuration comes from
        hostBuilder.Configuration.Sources.Clear();
        hostBuilder.Configuration.SetBasePath(Environment.CurrentDirectory);
        hostBuilder.Configuration.AddTomlFile(
            Path.Join(AppDomain.CurrentDomain.BaseDirectory, "gitrise.toml"),
            optional: true,
            reloadOnChange: true
        );
        hostBuilder.Configuration.AddTomlFile(
            Path.Join(Environment.CurrentDirectory, "gitrise.toml"),
            optional: true,
            reloadOnChange: true
        );
        hostBuilder.Configuration.AddGitConfig(path: Environment.CurrentDirectory, optional: false, reloadOnChange: true);
        hostBuilder.Configuration.AddEnvironmentVariables(prefix: "GITRISE_");
        hostBuilder.Configuration.AddCommandLine(Environment.GetCommandLineArgs());

        //< below: configure how the Host should handle logging
        hostBuilder.Logging.AddConfiguration(hostBuilder.Configuration.GetSection("Logging"));
        hostBuilder.Logging.AddConsole(); //< add console as logging target
        hostBuilder.Logging.AddDebug(); //< add debug output as logging target
        hostBuilder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace); //< set minimum level to trace in Debug

        //< below: register services to be available in Host
        hostBuilder.Services.AddTransient<MainWindow>();

        //< finally: return
        return hostBuilder;
    }
}
