using System.Text.RegularExpressions;

namespace MudBlazor.FontIcons.Tests;

/// <summary>
/// Guards the constants the generator writes from Google's metadata, so a bad refresh fails before it ships.
/// </summary>
public partial class IconConstantTests
{
    /// <summary>
    /// Constants pair the stylesheet class with the font ligature, e.g. <c>material-symbols-outlined/rocket_launch</c>.
    /// </summary>
    [GeneratedRegex("^[a-z0-9-]+/[a-z0-9_]+$")]
    private static partial Regex IconValuePattern();

    [Test]
    [MethodDataSource(typeof(IconPack), nameof(IconPack.AllIconClasses))]
    public async Task EveryConstantHasAValue(IconPack pack, Type iconClass)
    {
        var empty = IconPack.ConstantsOf(iconClass)
            .Where(constant => string.IsNullOrWhiteSpace(constant.Value))
            .Select(constant => constant.Name)
            .ToArray();

        await Assert.That(empty).IsEmpty();
    }

    [Test]
    [MethodDataSource(typeof(IconPack), nameof(IconPack.AllIconClasses))]
    public async Task EveryConstantHasTheExpectedShape(IconPack pack, Type iconClass)
    {
        var malformed = IconPack.ConstantsOf(iconClass)
            .Where(constant => !IconValuePattern().IsMatch(constant.Value))
            .Select(constant => $"{constant.Name} = \"{constant.Value}\"")
            .ToArray();

        await Assert.That(malformed).IsEmpty();
    }

    /// <summary>
    /// Each style maps to exactly one stylesheet class.
    /// The mapping is not derivable from the type name: MaterialIcons.Rounded is material-icons-round, MaterialSymbols.Rounded is material-symbols-rounded.
    /// </summary>
    [Test]
    [MethodDataSource(typeof(IconPack), nameof(IconPack.AllIconClasses))]
    public async Task EveryIconClassUsesExactlyOneCssClass(IconPack pack, Type iconClass)
    {
        var cssClasses = CssClassesUsedBy(iconClass);

        await Assert.That(cssClasses).Count().IsEqualTo(1);
    }

    [Test]
    [MethodDataSource(typeof(IconPack), nameof(IconPack.AllIconClasses))]
    public async Task TheCssClassIsDefinedInTheStylesheet(IconPack pack, Type iconClass)
    {
        var declared = Stylesheet.ClassNames(await File.ReadAllTextAsync(pack.StylesheetPath));

        foreach (var cssClass in CssClassesUsedBy(iconClass))
        {
            await Assert.That(declared).Contains(cssClass);
        }
    }

    /// <summary>
    /// A regeneration that fetches nothing still produces a compiling but nearly empty class.
    /// The smallest style ships over 2,000 icons, so a four-figure floor catches that without breaking when Google retires an icon.
    /// </summary>
    [Test]
    [MethodDataSource(typeof(IconPack), nameof(IconPack.AllIconClasses))]
    public async Task EveryIconClassIsFullyPopulated(IconPack pack, Type iconClass)
    {
        var constants = IconPack.ConstantsOf(iconClass);

        await Assert.That(constants.Count).IsGreaterThan(1_000);
    }

    private static HashSet<string> CssClassesUsedBy(Type iconClass) =>
        IconPack.ConstantsOf(iconClass)
            .Select(constant => constant.Value.Split('/')[0])
            .ToHashSet(StringComparer.Ordinal);
}
