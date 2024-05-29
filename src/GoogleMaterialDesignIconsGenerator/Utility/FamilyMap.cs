using GoogleMaterialDesignIconsGenerator.Extensions;
using GoogleMaterialDesignIconsGenerator.Model;

namespace GoogleMaterialDesignIconsGenerator.Utility;

public static class FamilyMap
{
    public const string MaterialSymbolsPrefix = "Material Symbols";
    public const string MaterialIconsPrefix = "Material Icons";
    public const string Outlined = "Outlined";
    public const string Rounded = "Rounded";
    public const string Sharp = "Sharp";
    public const string TwoTone = "Two Tone";
    public const string Filled = "Filled";
    public const string MaterialSymbolsOutlined = $"{MaterialSymbolsPrefix} {Outlined}";
    public const string MaterialSymbolsRounded = $"{MaterialSymbolsPrefix} {Rounded}";
    public const string MaterialSymbolsSharp = $"{MaterialSymbolsPrefix} {Sharp}";

    public const string MaterialIconsOutlined = $"{MaterialIconsPrefix} {Outlined}";
    public const string MaterialIconsFilled = $"{MaterialIconsPrefix}"; // this is not a typo, filled is indeed only using "Material Icons" without "Filled"
    public const string MaterialIconsRounded = $"{MaterialIconsPrefix} {Rounded}";
    public const string MaterialIconsSharp = $"{MaterialIconsPrefix} {Sharp}";
    public const string MaterialIconsTwoTone = $"{MaterialIconsPrefix} {TwoTone}";

    public static readonly IReadOnlyList<string> MaterialSymbolsFamilies = new List<string>
    {
        MaterialSymbolsOutlined,
        MaterialSymbolsRounded,
        MaterialSymbolsSharp,
    };
    public static readonly IReadOnlyList<string> MaterialIconsFamilies = new List<string>
    {
        MaterialIconsOutlined,
        MaterialIconsFilled,
        MaterialIconsRounded,
        MaterialIconsSharp,
        MaterialIconsTwoTone
    };
        
    public static IReadOnlyList<string> GetFamiliesByIconType(IconType iconType)
    {
        return iconType switch
        {
            IconType.MaterialSymbols => MaterialSymbolsFamilies,
            IconType.MaterialIcons => MaterialIconsFamilies,
            _ => throw new InvalidOperationException($"Mapping for icon type {iconType} not found!")
        };
    }

    public static IconType FromFamilyToIconType(string family)
    {
        switch (family)
        {
            // Material Symbols
            case MaterialSymbolsOutlined:
            case MaterialSymbolsRounded:
            case MaterialSymbolsSharp:
                return IconType.MaterialSymbols;

            // Material Icons
            case MaterialIconsOutlined:
            case MaterialIconsFilled:
            case MaterialIconsRounded:
            case MaterialIconsSharp:
            case MaterialIconsTwoTone:
                return IconType.MaterialIcons;
            default:
                throw new InvalidOperationException($"Mapping for family name {family} not found!");
        }
    }

    public static bool IsSelectedFamilyByIconType(IconType iconType, string family)
    {
        return iconType switch
        {
            IconType.MaterialSymbols => IsMaterialSymbolFamily(family),
            IconType.MaterialIcons => IsMaterialIconFamily(family),
            _ => throw new InvalidOperationException($"Mapping for icon type {iconType} and family {family} not found!")
        };
    }

    public static bool IsMaterialIconFamily(string family)
    {
        ArgumentNullException.ThrowIfNull(family);

        return family.StartsWith(MaterialIconsPrefix, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsMaterialSymbolFamily(string family)
    {
        ArgumentNullException.ThrowIfNull(family);

        return family.StartsWith(MaterialSymbolsPrefix, StringComparison.OrdinalIgnoreCase);
    }

    public static string FamilyNameToCsharpClassName(string familyName)
    {
        ArgumentNullException.ThrowIfNull(familyName);
        return familyName switch
        {
            // Material Symbols
            MaterialSymbolsOutlined => Outlined,
            MaterialSymbolsRounded => Rounded,
            MaterialSymbolsSharp => Sharp,

            // Material Icons
            MaterialIconsOutlined => Outlined,
            MaterialIconsFilled => Filled,
            MaterialIconsRounded => Rounded,
            MaterialIconsSharp => Sharp,
            MaterialIconsTwoTone => TwoTone.RemoveWhitespace(), //Remove space in between.
            _ => throw new InvalidOperationException($"Mapping for family name {familyName} not found!")
        };
    }

    public static string FamilyNameToHtmlClassName(string familyName)
    {
        ArgumentNullException.ThrowIfNull(familyName);
        return familyName switch
        {
            // Material Symbols
            MaterialSymbolsOutlined => "material-symbols-outlined",
            MaterialSymbolsRounded => "material-symbols-rounded",
            MaterialSymbolsSharp => "material-symbols-sharp",

            // Material Icons
            MaterialIconsOutlined => "material-icons-outlined",
            MaterialIconsFilled => "material-icons",
            MaterialIconsRounded => "material-icons-round",
            MaterialIconsSharp => "material-icons-sharp",
            MaterialIconsTwoTone => "material-icons-two-tone",
            _ => throw new InvalidOperationException($"Mapping for family name {familyName} not found!")
        };
    }
}