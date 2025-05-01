using System;
using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using KageKirin.Extensions.Configuration.GitConfig;
using Microsoft.Extensions.Configuration;
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

        //< finally: return
        return hostBuilder;
    }
}
