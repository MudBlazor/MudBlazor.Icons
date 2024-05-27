using System.Globalization;

namespace MaterialSymbolsParser.Extensions;

public static class StringExtensions
{
    public static string ConvertToCamelCase(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var words = input.Split('_');

        for (var i = 0; i < words.Length; i++)
        {
            words[i] = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(words[i]);
        }

        return string.Join(string.Empty, words);
    }
}