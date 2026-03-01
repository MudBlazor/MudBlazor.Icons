using Spectre.Console.Cli;
using GoogleMaterialDesignIconsGenerator.Model;

namespace GoogleMaterialDesignIconsGenerator;

public sealed class GenerateCommandSettings : CommandSettings
{
    [CommandOption("-t|--icon-type <ICON_TYPE>")]
    public IconType? IconType { get; init; }
}
