using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace GoogleMaterialDesignIconsGenerator.Model.Google;

public class IconsMetadata
{
    [JsonPropertyName("host")]
    public string Host { get; init; } = string.Empty;

#pragma warning disable CA1056 // URI-like properties should not be strings
    [JsonPropertyName("asset_url_pattern")]
    public string AssetUrlPattern { get; init; } = string.Empty;
#pragma warning restore CA1056 // URI-like properties should not be strings

    [JsonPropertyName("families")]
    public IReadOnlyCollection<string> Families { get; init; } = ReadOnlyCollection<string>.Empty;

    [JsonPropertyName("icons")]
    public IReadOnlyCollection<Icon> Icons { get; init; } = ReadOnlyCollection<Icon>.Empty;
}