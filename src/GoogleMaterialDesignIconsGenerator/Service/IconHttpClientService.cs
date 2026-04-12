using System.Text.Json;
using System.Text.RegularExpressions;
using GoogleMaterialDesignIconsGenerator.Model.Google;

namespace GoogleMaterialDesignIconsGenerator.Service;

public class IconHttpClientService : IDisposable
{
    public const string GoogleFontUrl = "http://fonts.google.com/";
    public const string GoogleFontsCssApiUrl = "https://fonts.googleapis.com/css2";
    private static readonly Regex Woff2UrlRegex = new(@"url\((['""]?)(?<href>https?://[^)'""]+?\.woff2)\1\)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private static readonly (string FamilyName, string TargetFileName)[] MaterialSymbolsFontFiles =
    [
        ("Material Symbols Outlined", "MaterialSymbolsOutlined.woff2"),
        ("Material Symbols Rounded", "MaterialSymbolsRounded.woff2"),
        ("Material Symbols Sharp", "MaterialSymbolsSharp.woff2")
    ];

    public IconHttpClientService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(GoogleFontUrl)
        };
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; MudBlazor.FontIcons.MaterialSymbols generator)");
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

        foreach (var (familyName, targetFileName) in MaterialSymbolsFontFiles)
        {
            try
            {
                var cssFileUrl = BuildMaterialSymbolsCssUri(familyName);
                var cssContent = await _httpClient.GetStringAsync(cssFileUrl, cancellationToken).ConfigureAwait(false);
                var fileUrl = ResolveWoff2Url(cssContent, familyName);
                var fileContent = await _httpClient.GetByteArrayAsync(fileUrl, cancellationToken).ConfigureAwait(false);
                var destinationPath = Path.Combine(destinationFolderPath, targetFileName);
                await File.WriteAllBytesAsync(destinationPath, fileContent, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex) when (ex is HttpRequestException or IOException)
            {
                throw new InvalidOperationException($"Failed to download and save Material Symbols font for '{familyName}'.", ex);
            }
        }
    }

    private static Uri BuildMaterialSymbolsCssUri(string familyName)
    {
        var encodedFamily = Uri.EscapeDataString(familyName);
        return new Uri($"{GoogleFontsCssApiUrl}?family={encodedFamily}:opsz,wght,FILL,GRAD@24,400,0,0&display=block", UriKind.Absolute);
    }

    private static Uri ResolveWoff2Url(string cssContent, string familyName)
    {
        var match = Woff2UrlRegex.Match(cssContent);
        if (!match.Success)
        {
            throw new InvalidOperationException($"Failed to resolve .woff2 URL from Google Fonts CSS for '{familyName}'.");
        }

        if (!Uri.TryCreate(match.Groups["href"].Value, UriKind.Absolute, out var uri))
        {
            throw new InvalidOperationException($"Resolved an invalid .woff2 URL from Google Fonts CSS for '{familyName}'.");
        }

        if (!uri.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase) ||
            !uri.Host.Equals("fonts.gstatic.com", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException($"Resolved an unexpected .woff2 URL host '{uri.Host}' from Google Fonts CSS for '{familyName}'.");
        }

        return uri;
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
