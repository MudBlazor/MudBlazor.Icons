using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace GoogleMaterialDesignIconsGenerator.Model.Google;

public class Icon
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("version")]
    public int Version { get; set; }

    [JsonPropertyName("popularity")]
    public int Popularity { get; set; }

    [JsonPropertyName("codepoint")]
    public int Codepoint { get; set; }

    [JsonPropertyName("unsupported_families")]
    public IReadOnlyCollection<string> UnsupportedFamilies { get; set; } = ReadOnlyCollection<string>.Empty;

    [JsonPropertyName("categories")]
    public IReadOnlyCollection<string> Categories { get; set; } = ReadOnlyCollection<string>.Empty;

    [JsonPropertyName("tags")]
    public IReadOnlyCollection<string> Tags { get; set; } = ReadOnlyCollection<string>.Empty;

    [JsonPropertyName("sizes_px")]
    public IReadOnlyCollection<int> SizesPx { get; set; } = ReadOnlyCollection<int>.Empty;
}