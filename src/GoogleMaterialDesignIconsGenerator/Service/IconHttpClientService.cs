using System.Text.Json;
using GoogleMaterialDesignIconsGenerator.Model.Google;

namespace GoogleMaterialDesignIconsGenerator.Service;

public class IconHttpClientService : IDisposable
{
    public const string GoogleFontUrl = "http://fonts.google.com/";
    public const string GoogleMaterialDesignIconsRawUrl = "https://github.com/google/material-design-icons/raw/refs/heads/master/variablefont/";

    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private static readonly (string SourceFileName, string TargetFileName)[] MaterialSymbolsFontFiles =
    [
        ("MaterialSymbolsOutlined[FILL,GRAD,opsz,wght].woff2", "MaterialSymbolsOutlined.woff2"),
        ("MaterialSymbolsRounded[FILL,GRAD,opsz,wght].woff2", "MaterialSymbolsRounded.woff2"),
        ("MaterialSymbolsSharp[FILL,GRAD,opsz,wght].woff2", "MaterialSymbolsSharp.woff2")
    ];

    public IconHttpClientService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(GoogleFontUrl)
        };
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            TypeInfoResolver = IconMetadataJsonSerializerContext.Default
        };

    }

    public async Task<IconsMetadata> ParseIconsAsync()
    {
        var json = await _httpClient.GetStringAsync(new Uri("metadata/icons?incomplete=1&key=material_symbols", UriKind.Relative)).ConfigureAwait(false);
        using var reader = new StringReader(json);
        // Skip the first line as it's illegal
        await reader.ReadLineAsync().ConfigureAwait(false);
        var validJson = await reader.ReadToEndAsync().ConfigureAwait(false);

        var metadata = JsonSerializer.Deserialize<IconsMetadata>(validJson, _jsonSerializerOptions);
        if (metadata is null)
        {
            throw new InvalidOperationException("Response is null");
        }

        return metadata;
    }

    public async Task DownloadMaterialSymbolsFontsAsync(string destinationFolderPath, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(destinationFolderPath);

        try
        {
            Directory.CreateDirectory(destinationFolderPath);
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            throw new InvalidOperationException($"Failed to prepare destination folder '{destinationFolderPath}' for Material Symbols fonts.", ex);
        }

        foreach (var (sourceFileName, targetFileName) in MaterialSymbolsFontFiles)
        {
            var fileUrl = new Uri($"{GoogleMaterialDesignIconsRawUrl}{sourceFileName}");
            try
            {
                var fileContent = await _httpClient.GetByteArrayAsync(fileUrl, cancellationToken).ConfigureAwait(false);
                var destinationPath = Path.Combine(destinationFolderPath, targetFileName);
                await File.WriteAllBytesAsync(destinationPath, fileContent, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex) when (ex is HttpRequestException or IOException)
            {
                throw new InvalidOperationException($"Failed to download and save Material Symbols font '{sourceFileName}' from '{fileUrl}'.", ex);
            }
        }
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
