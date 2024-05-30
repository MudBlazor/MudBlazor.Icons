using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace GoogleMaterialDesignIconsGenerator.Model.Google;

public class Icon : IEquatable<Icon>
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("version")]
    public int Version { get; init; }

    [JsonPropertyName("popularity")]
    public int Popularity { get; init; }

    [JsonPropertyName("codepoint")]
    public int Codepoint { get; init; }

    [JsonPropertyName("unsupported_families")]
    public IReadOnlyCollection<string> UnsupportedFamilies { get; init; } = ReadOnlyCollection<string>.Empty;

    [JsonPropertyName("categories")]
    public IReadOnlyCollection<string> Categories { get; init; } = ReadOnlyCollection<string>.Empty;

    [JsonPropertyName("tags")]
    public IReadOnlyCollection<string> Tags { get; init; } = ReadOnlyCollection<string>.Empty;

    [JsonPropertyName("sizes_px")]
    public IReadOnlyCollection<int> SizesPx { get; init; } = ReadOnlyCollection<int>.Empty;

    public bool Equals(Icon? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Name == other.Name
               && Version == other.Version
               && Popularity == other.Popularity
               && Codepoint == other.Codepoint
               && UnsupportedFamilies.Equals(other.UnsupportedFamilies)
               && Categories.Equals(other.Categories)
               && Tags.Equals(other.Tags)
               && SizesPx.Equals(other.SizesPx);
    }

    public override bool Equals(object? obj) => obj is Icon icon && Equals(icon);

    public override int GetHashCode() => HashCode.Combine(Name, Version, Popularity, Codepoint, UnsupportedFamilies, Categories, Tags, SizesPx);
}