using System.Text.Json.Serialization;
using MaterialSymbolsParser.Model;

namespace MaterialSymbolsParser.Service;

[JsonSerializable(typeof(Metadata))]
public partial class MetadataJsonSerializerContext : JsonSerializerContext
{
}