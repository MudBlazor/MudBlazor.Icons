using System.Text.Json.Serialization;

namespace MaterialSymbolsParser.Model.Google;

[JsonSerializable(typeof(Metadata))]
public partial class MetadataJsonSerializerContext : JsonSerializerContext;