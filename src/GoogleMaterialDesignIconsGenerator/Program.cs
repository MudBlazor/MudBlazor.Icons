using GoogleMaterialDesignIconsGenerator.Extensions;
using GoogleMaterialDesignIconsGenerator.Model;
using GoogleMaterialDesignIconsGenerator.Service;
using Spectre.Console;

namespace GoogleMaterialDesignIconsGenerator;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var iconType = ResolveIconType(args);

        var codeGenerator = new CodeGenerationService();
        using var client = new IconHttpClientService();
        var metadata = await client.ParseIconsAsync().ConfigureAwait(false);
        var filteredIcons = Utility.IconFilter.FilterByFamily(metadata, iconType);
        var groupedIcons = Utility.IconFilter.GroupIconsByFamilies(filteredIcons, iconType);
        var outputFolder = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, $"../../../../MudBlazor.FontIcons.{iconType.GetDescription()}"));

        codeGenerator.GenerateCsFilesUsingRoslyn(iconType, groupedIcons, folder: outputFolder);

        if (iconType == IconType.MaterialSymbols)
        {
            await client.DownloadMaterialSymbolsFontsAsync(Path.Combine(outputFolder, "wwwroot", "font")).ConfigureAwait(false);
        }
    }

    private static IconType ResolveIconType(IReadOnlyList<string> args)
    {
        if (TryGetIconTypeFromArgs(args, out var iconType))
        {
            return iconType;
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

    private static bool TryGetIconTypeFromArgs(IReadOnlyList<string> args, out IconType iconType)
    {
        iconType = default;
        if (args.Count == 0)
        {
            return false;
        }

        for (var i = 0; i < args.Count; i++)
        {
            if (!args[i].Equals("--icon-type", StringComparison.OrdinalIgnoreCase) &&
                !args[i].Equals("-t", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (i + 1 >= args.Count)
            {
                throw new ArgumentException("Missing value for --icon-type.");
            }

            iconType = ParseIconType(args[i + 1]);
            return true;
        }

        iconType = ParseIconType(args[0]);
        return true;
    }

    private static IconType ParseIconType(string value)
    {
        var normalized = value
            .Replace("-", string.Empty, StringComparison.Ordinal)
            .Replace("_", string.Empty, StringComparison.Ordinal)
            .Trim();

        if (normalized.Equals("materialsymbols", StringComparison.OrdinalIgnoreCase) ||
            normalized.Equals("symbols", StringComparison.OrdinalIgnoreCase))
        {
            return IconType.MaterialSymbols;
        }

        if (normalized.Equals("materialicons", StringComparison.OrdinalIgnoreCase) ||
            normalized.Equals("icons", StringComparison.OrdinalIgnoreCase))
        {
            return IconType.MaterialIcons;
        }

        throw new ArgumentException($"Unsupported icon type '{value}'. Use 'materialsymbols' or 'materialicons'.");
    }
}
