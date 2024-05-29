using GoogleMaterialDesignIconsGenerator.Model;
using GoogleMaterialDesignIconsGenerator.Model.Google;

namespace GoogleMaterialDesignIconsGenerator.Utility;

public static class IconFilter
{
    public static Dictionary<string, IReadOnlyCollection<Icon>> GroupIconsByFamilies(IReadOnlyCollection<Icon> icons, IconType iconType)
    {
        var groupedIcons = new Dictionary<string, IReadOnlyCollection<Icon>>();

        foreach (var family in FamilyMap.GetFamiliesByIconType(iconType))
        {
            groupedIcons[family] = icons
                .Where(icon => !icon.UnsupportedFamilies.Contains(family))
                .ToList();
        }

        return groupedIcons;
    }

    public static IReadOnlyCollection<Icon> FilterByFamily(Metadata metadata, IconType iconType)
    {
        return metadata.Icons
            .Where(icon => !icon.UnsupportedFamilies.Any(family => FamilyMap.IsSelectedFamilyByIconType(iconType, family)))
            .ToList();
    }
}