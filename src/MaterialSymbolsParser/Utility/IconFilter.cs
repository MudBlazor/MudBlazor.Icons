using MaterialSymbolsParser.Model;

namespace MaterialSymbolsParser.Utility;

public static class IconFilter
{
    public static Dictionary<string, IReadOnlyCollection<Icon>> GroupIconsByFamilies(IReadOnlyCollection<Icon> icons)
    {
        var groupedIcons = new Dictionary<string, IReadOnlyCollection<Icon>>();

        foreach (var family in FamilyMap.MaterialSymbolsFamilies)
        {
            groupedIcons[family] = icons
                .Where(icon => !icon.UnsupportedFamilies.Contains(family))
                .ToList();
        }

        return groupedIcons;
    }

    public static IReadOnlyCollection<Icon> FilterNonMaterialSymbols(Metadata metadata)
    {
        return metadata.Icons
            .Where(icon => !icon.UnsupportedFamilies.Any(FamilyMap.IsMaterialSymbolFamily))
            .ToList();
    }
}