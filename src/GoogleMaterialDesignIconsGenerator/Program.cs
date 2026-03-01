using Spectre.Console.Cli;

namespace GoogleMaterialDesignIconsGenerator;

public static class Program
{
    public static Task<int> Main(string[] args)
    {
        var app = new CommandApp<GenerateCommand>();
        app.Configure(config =>
        {
            config.SetApplicationName("GoogleMaterialDesignIconsGenerator");
        });

        return app.RunAsync(args);
    }
}
