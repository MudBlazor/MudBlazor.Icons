using System.Text.Json;
using MaterialSymbolsParser.Model.Google;

namespace MaterialSymbolsParser.Service;

public class IconHttpClientService : IDisposable
{
    public const string GoogleFontUrl = "http://fonts.google.com/";

    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public IconHttpClientService()
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

    public async Task<Metadata> ParseIconsAsync()
    {
        var json = await _httpClient.GetStringAsync(new Uri("metadata/icons?incomplete=1&key=material_symbols", UriKind.Relative)).ConfigureAwait(false);
        using var reader = new StringReader(json);
        // Skip the first line as it's illegal
        await reader.ReadLineAsync().ConfigureAwait(false);
        var validJson = await reader.ReadToEndAsync().ConfigureAwait(false);

        var metadata = JsonSerializer.Deserialize<Metadata>(validJson, _jsonSerializerOptions);
        if (metadata is null)
        {
            throw new InvalidOperationException("Response is null");
        }

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