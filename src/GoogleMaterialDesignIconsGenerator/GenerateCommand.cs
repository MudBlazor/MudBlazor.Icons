using GoogleMaterialDesignIconsGenerator.Extensions;
using GoogleMaterialDesignIconsGenerator.Model;
using GoogleMaterialDesignIconsGenerator.Service;
using Spectre.Console;
using Spectre.Console.Cli;

namespace GoogleMaterialDesignIconsGenerator;

public sealed class GenerateCommand : AsyncCommand<GenerateCommandSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, GenerateCommandSettings settings, CancellationToken cancellationToken)
    {
        _ = context;
        ArgumentNullException.ThrowIfNull(settings);
        var iconType = ResolveIconType(settings);

        var codeGenerator = new CodeGenerationService();
        using var client = new IconHttpClientService();
        var metadata = await client.ParseIconsAsync().ConfigureAwait(false);
        var filteredIcons = Utility.IconFilter.FilterByFamily(metadata, iconType);
        var groupedIcons = Utility.IconFilter.GroupIconsByFamilies(filteredIcons, iconType);
        var outputFolder = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, $"../../../../MudBlazor.FontIcons.{iconType.GetDescription()}"));

        codeGenerator.GenerateCsFilesUsingRoslyn(iconType, groupedIcons, folder: outputFolder);

        if (iconType == IconType.MaterialSymbols)
        {
            await client.DownloadMaterialSymbolsFontsAsync(Path.Combine(outputFolder, "wwwroot", "font"), cancellationToken).ConfigureAwait(false);
        }

        return 0;
    }

    private static IconType ResolveIconType(GenerateCommandSettings settings)
    {
        if (settings.IconType is { } iconTypeFromOption)
        {
            return iconTypeFromOption;
        }

        return AnsiConsole.Prompt(
            new SelectionPrompt<IconType>()
                .Title("What [green]icon[/] pack to generate?")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices([
                    IconType.MaterialIcons,
                    IconType.MaterialSymbols
                ]));
    }
}
