using System.Text.Json.Serialization;

namespace GoogleMaterialDesignIconsGenerator.Model.Google;

[JsonSerializable(typeof(IconsMetadata))]
public partial class IconMetadataJsonSerializerContext : JsonSerializerContext;