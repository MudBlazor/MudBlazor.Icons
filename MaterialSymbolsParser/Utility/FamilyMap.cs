namespace MaterialSymbolsParser.Utility;

public static class FamilyMap
{
    public static string FamilyNameToCsharpClassName(string familyName)
    {
        ArgumentNullException.ThrowIfNull(familyName);
        return familyName switch
        {
            "Material Symbols Outlined" => "Outlined",
            "Material Symbols Rounded" => "Rounded",
            "Material Symbols Sharp" => "Sharp",
            _ => throw new InvalidOperationException($"Mapping for family name {familyName} not found!")
        };
    }

    public static string FamilyNameToHtmlClassName(string familyName)
    {
        ArgumentNullException.ThrowIfNull(familyName);
        return familyName switch
        {
            "Material Symbols Outlined" => "material-symbols-outlined",
            "Material Symbols Rounded" => "material-symbols-rounded",
            "Material Symbols Sharp" => "material-symbols-sharp",
            _ => throw new InvalidOperationException($"Mapping for family name {familyName} not found!")
        };
    }
}