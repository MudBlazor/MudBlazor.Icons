using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace MaterialSymbolsParser.Model.Google;

public class Metadata
{
    [JsonPropertyName("host")]
    public string Host { get; set; } = string.Empty;

    [JsonPropertyName("asset_url_pattern")]
    public string AssetUrlPattern { get; set; } = string.Empty;

    [JsonPropertyName("families")]
    public IReadOnlyCollection<string> Families { get; set; } = ReadOnlyCollection<string>.Empty;

    [JsonPropertyName("icons")]
    public IReadOnlyCollection<Icon> Icons { get; set; } = ReadOnlyCollection<Icon>.Empty;
}