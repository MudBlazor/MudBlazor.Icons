using Spectre.Console.Cli;

namespace GoogleMaterialDesignIconsGenerator;

public sealed class GenerateCommandSettings : CommandSettings
{
    [CommandOption("-t|--icon-type <ICON_TYPE>")]
    public string? IconType { get; init; }

    [CommandArgument(0, "[ICON_TYPE]")]
    public string? LegacyIconType { get; init; }
}
