using GoogleMaterialDesignIconsGenerator.Model;

namespace GoogleMaterialDesignIconsGenerator;

internal static class IconTypeParser
{
    public static IconType Parse(string value)
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
