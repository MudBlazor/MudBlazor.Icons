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
                .Title("What icon pack to [green]generate[/]?")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices([
                    IconType.MaterialIcons,
                    IconType.MaterialSymbols
                ]));

        //var iconType = IconType.MaterialIcons;
        var codeGenerator = new CodeGenerationService();
        using var client = new IconHttpClientService();
        var metadata = await client.ParseIconsAsync().ConfigureAwait(false);
        var filteredIcons = Utility.IconFilter.FilterByFamily(metadata, iconType);
        var groupedIcons = Utility.IconFilter.GroupIconsByFamilies(filteredIcons, iconType);

        codeGenerator.GenerateCsFilesUsingRoslyn(iconType, groupedIcons, folder: $"../../../../MudBlazor.FontIcons.{iconType.GetDescription()}");
    }
}