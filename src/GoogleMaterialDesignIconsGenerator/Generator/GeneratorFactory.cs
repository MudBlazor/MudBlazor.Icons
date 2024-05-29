using GoogleMaterialDesignIconsGenerator.Model;

namespace GoogleMaterialDesignIconsGenerator.Generator;

public static class GeneratorFactory
{
    public static IGenerator Create(IconType iconType)
    {
        return iconType switch
        {
            IconType.MaterialIcons => new MaterialIconsGenerator(),
            IconType.MaterialSymbols => new MaterialSymbolsGenerator(),
            _ => throw new InvalidOperationException($"No generator found for icon type {iconType}!")
        };
    } 
}