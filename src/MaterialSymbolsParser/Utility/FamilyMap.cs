namespace MaterialSymbolsParser.Utility;

public static class FamilyMap
{
    public const string MaterialSymbolsPrefix = "Material Symbols";
    public const string Outlined = "Outlined";
    public const string Rounded = "Rounded";
    public const string Sharp = "Sharp";
    public const string MaterialSymbolsOutlined = $"{MaterialSymbolsPrefix} {Outlined}";
    public const string MaterialSymbolsRounded = $"{MaterialSymbolsPrefix} {Rounded}";
    public const string MaterialSymbolsSharp = $"{MaterialSymbolsPrefix} {Sharp}";
    public static readonly IReadOnlyList<string> MaterialSymbolsFamilies = new List<string>
    {
        MaterialSymbolsOutlined,
        MaterialSymbolsRounded,
        MaterialSymbolsSharp,
    };

    public static bool IsMaterialSymbolFamily(string family) => family.StartsWith(MaterialSymbolsPrefix, StringComparison.OrdinalIgnoreCase);

    public static string FamilyNameToCsharpClassName(string familyName)
    {
        ArgumentNullException.ThrowIfNull(familyName);
        return familyName switch
        {
            MaterialSymbolsOutlined => Outlined,
            MaterialSymbolsRounded => Rounded,
            MaterialSymbolsSharp => Sharp,
            _ => throw new InvalidOperationException($"Mapping for family name {familyName} not found!")
        };
    }

    public static string FamilyNameToHtmlClassName(string familyName)
    {
        ArgumentNullException.ThrowIfNull(familyName);
        return familyName switch
        {
            MaterialSymbolsOutlined => "material-symbols-outlined",
            MaterialSymbolsRounded => "material-symbols-rounded",
            MaterialSymbolsSharp => "material-symbols-sharp",
            _ => throw new InvalidOperationException($"Mapping for family name {familyName} not found!")
        };
    }
}