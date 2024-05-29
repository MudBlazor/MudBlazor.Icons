using GoogleMaterialDesignIconsGenerator.Model;
using GoogleMaterialDesignIconsGenerator.Model.Google;
using System.Linq;

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



    public static IReadOnlyCollection<Icon> FilterByFamily(IconsMetadata metadata, IconType iconType)
    {
        ArgumentNullException.ThrowIfNull(metadata);

        var prefix = FamilyMap.GetFamilyPrefixByIconType(iconType);
        var filter = metadata.Icons.Where(icon => !icon.UnsupportedFamilies.Contains(prefix)).ToList();

        return filter;
    }
}