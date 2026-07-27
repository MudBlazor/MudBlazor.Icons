using System.Text.RegularExpressions;

namespace MudBlazor.FontIcons.Tests;

/// <summary>
/// The parts of a generated font stylesheet the icon constants depend on.
/// </summary>
public static partial class Stylesheet
{
    /// <summary>
    /// Class selectors at the start of a rule, e.g. <c>.material-symbols-outlined {</c>.
    /// </summary>
    public static IReadOnlySet<string> ClassNames(string css) =>
        ClassSelectorPattern().Matches(css).Select(match => match.Groups[1].Value).ToHashSet(StringComparer.Ordinal);

    /// <summary>
    /// Font file names referenced by <c>src: url(...)</c>, without their directory.
    /// </summary>
    public static IReadOnlySet<string> ReferencedFontFiles(string css) =>
        FontUrlPattern().Matches(css)
            .Select(match => Path.GetFileName(match.Groups[1].Value.Trim('\'', '"')))
            .ToHashSet(StringComparer.Ordinal);

    [GeneratedRegex(@"(?:^|})\s*\.([a-z0-9-]+)\s*(?:,[^{]*)?{", RegexOptions.Multiline)]
    private static partial Regex ClassSelectorPattern();

    [GeneratedRegex(@"url\(([^)]+\.woff2)\)")]
    private static partial Regex FontUrlPattern();
}
