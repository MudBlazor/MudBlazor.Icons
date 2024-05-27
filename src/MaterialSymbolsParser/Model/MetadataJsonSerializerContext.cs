using System.Text.Json.Serialization;

namespace MaterialSymbolsParser.Model;

[JsonSerializable(typeof(Metadata))]
public partial class MetadataJsonSerializerContext : JsonSerializerContext;