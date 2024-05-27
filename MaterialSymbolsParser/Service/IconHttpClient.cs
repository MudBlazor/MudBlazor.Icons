using System.Text.Json;
using MaterialSymbolsParser.Model;

namespace MaterialSymbolsParser.Service;

public class IconHttpClient : IDisposable
{
    public const string GoogleFontUrl = "http://fonts.google.com/";

    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public IconHttpClient()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(GoogleFontUrl)
        };
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            TypeInfoResolver = MetadataJsonSerializerContext.Default
        };

    }

    public async Task<Metadata?> ParseIconsAsync()
    {
        var json = await _httpClient.GetStringAsync("metadata/icons?incomplete=1&key=material_symbols");
        using var reader = new StringReader(json);
        // Skip the first line as it's illegal
        await reader.ReadLineAsync();
        var validJson = await reader.ReadToEndAsync();

        var metadata = JsonSerializer.Deserialize<Metadata>(validJson, _jsonSerializerOptions);

        return metadata;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _httpClient.Dispose();
        }
    }
}