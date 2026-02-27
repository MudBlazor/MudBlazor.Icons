using GoogleMaterialDesignIconsGenerator.Extensions;
using GoogleMaterialDesignIconsGenerator.Model;
using GoogleMaterialDesignIconsGenerator.Service;
using Spectre.Console;

namespace GoogleMaterialDesignIconsGenerator;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var iconType = AnsiConsole.Prompt(
            new SelectionPrompt<IconType>()
                .Title("What [green]icon[/] pack to generate?")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices([
                    IconType.MaterialIcons,
                    IconType.MaterialSymbols
                ]));

        var codeGenerator = new CodeGenerationService();
        using var client = new IconHttpClientService();
        var metadata = await client.ParseIconsAsync().ConfigureAwait(false);
        var filteredIcons = Utility.IconFilter.FilterByFamily(metadata, iconType);
        var groupedIcons = Utility.IconFilter.GroupIconsByFamilies(filteredIcons, iconType);
        var outputFolder = $"../../../../MudBlazor.FontIcons.{iconType.GetDescription()}";

        codeGenerator.GenerateCsFilesUsingRoslyn(iconType, groupedIcons, folder: outputFolder);

        if (iconType == IconType.MaterialSymbols)
        {
            await client.DownloadMaterialSymbolsFontsAsync(Path.Combine(outputFolder, "wwwroot", "font")).ConfigureAwait(false);
        }
    }
}
