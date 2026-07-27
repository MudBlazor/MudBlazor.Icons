using System.Reflection;

namespace MudBlazor.FontIcons.Tests;

/// <summary>
/// One shipping icon pack, and the source assets the generator produces for it.
/// </summary>
public sealed class IconPack(string name, params Type[] iconClasses)
{
    private static readonly string RepoRoot = typeof(IconPack).Assembly
        .GetCustomAttributes<AssemblyMetadataAttribute>()
        .Single(attribute => attribute.Key == "RepoRoot")
        .Value ?? throw new InvalidOperationException("The RepoRoot assembly metadata is present but has no value.");

    public string Name { get; } = name;

    public IReadOnlyList<Type> IconClasses { get; } = iconClasses;

    public string ProjectDirectory { get; } = Path.Combine(RepoRoot, "src", name);

    public string StylesheetPath => Path.Combine(ProjectDirectory, "wwwroot", "css", "font.css");

    public string MinifiedStylesheetPath => Path.Combine(ProjectDirectory, "wwwroot", "css", "font.min.css");

    public string FontDirectory => Path.Combine(ProjectDirectory, "wwwroot", "font");

    public override string ToString() => Name;

    /// <summary>
    /// The generator emits every icon as a public const string, so the constants are the literal string fields.
    /// </summary>
    public static IReadOnlyList<(string Name, string Value)> ConstantsOf(Type iconClass) =>
        [.. iconClass
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Where(field => field is { IsLiteral: true, IsInitOnly: false } && field.FieldType == typeof(string))
            .Select(field => (field.Name, Value: field.GetRawConstantValue() as string ?? string.Empty))];

    public static IEnumerable<Func<IconPack>> All() =>
    [
        () => new IconPack(
            "MudBlazor.FontIcons.MaterialIcons",
            typeof(MaterialIcons.Filled),
            typeof(MaterialIcons.Outlined),
            typeof(MaterialIcons.Rounded),
            typeof(MaterialIcons.Sharp),
            typeof(MaterialIcons.TwoTone)),
        () => new IconPack(
            "MudBlazor.FontIcons.MaterialSymbols",
            typeof(MaterialSymbols.Outlined),
            typeof(MaterialSymbols.Rounded),
            typeof(MaterialSymbols.Sharp)),
    ];

    public static IEnumerable<Func<(IconPack Pack, Type IconClass)>> AllIconClasses() =>
        All()
            .Select(packFactory => packFactory())
            .SelectMany(pack => pack.IconClasses.Select(iconClass => new Func<(IconPack, Type)>(() => (pack, iconClass))));
}
