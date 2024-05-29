using System.Text.Json.Serialization;

namespace GoogleMaterialDesignIconsGenerator.Model.Google;

[JsonSerializable(typeof(Metadata))]
public partial class MetadataJsonSerializerContext : JsonSerializerContext;