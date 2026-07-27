namespace MudBlazor.FontIcons.Tests;

/// <summary>
/// The stylesheet is what links a constant to a glyph, and it ships as a static web asset.
/// A class or font that goes missing here breaks every icon in that style at runtime.
/// </summary>
public class StylesheetTests
{
    [Test]
    [MethodDataSource(typeof(IconPack), nameof(IconPack.All))]
    public async Task EveryReferencedFontFileExists(IconPack pack)
    {
        var css = await File.ReadAllTextAsync(pack.StylesheetPath);

        var missing = Stylesheet.ReferencedFontFiles(css)
            .Where(fontFile => !File.Exists(Path.Combine(pack.FontDirectory, fontFile)))
            .ToArray();

        await Assert.That(missing).IsEmpty();
    }

    /// <summary>
    /// An orphaned font means the stylesheet stopped pointing at a file the package still ships.
    /// </summary>
    [Test]
    [MethodDataSource(typeof(IconPack), nameof(IconPack.All))]
    public async Task EveryFontFileIsReferencedByTheStylesheet(IconPack pack)
    {
        var css = await File.ReadAllTextAsync(pack.StylesheetPath);
        var referenced = Stylesheet.ReferencedFontFiles(css);

        var orphaned = Directory.EnumerateFiles(pack.FontDirectory, "*.woff2")
            .Select(fontPath => Path.GetFileName(fontPath))
            .Where(fontFile => !referenced.Contains(fontFile))
            .ToArray();

        await Assert.That(orphaned).IsEmpty();
    }

    /// <summary>
    /// Consumers link font.min.css, so drift between the two would ship a stylesheet nothing here validates.
    /// </summary>
    [Test]
    [MethodDataSource(typeof(IconPack), nameof(IconPack.All))]
    public async Task TheMinifiedStylesheetDefinesTheSameClasses(IconPack pack)
    {
        var source = Stylesheet.ClassNames(await File.ReadAllTextAsync(pack.StylesheetPath));
        var minified = Stylesheet.ClassNames(await File.ReadAllTextAsync(pack.MinifiedStylesheetPath));

        await Assert.That(minified).IsEquivalentTo(source);
    }

    [Test]
    [MethodDataSource(typeof(IconPack), nameof(IconPack.All))]
    public async Task TheMinifiedStylesheetReferencesTheSameFonts(IconPack pack)
    {
        var source = Stylesheet.ReferencedFontFiles(await File.ReadAllTextAsync(pack.StylesheetPath));
        var minified = Stylesheet.ReferencedFontFiles(await File.ReadAllTextAsync(pack.MinifiedStylesheetPath));

        await Assert.That(minified).IsEquivalentTo(source);
    }
}
