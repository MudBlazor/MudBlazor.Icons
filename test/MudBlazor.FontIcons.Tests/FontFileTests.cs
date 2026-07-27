using System.Buffers.Binary;

namespace MudBlazor.FontIcons.Tests;

/// <summary>
/// The generator downloads the fonts from Google, so a truncated or half-written response is a realistic failure.
/// The WOFF2 header carries its own total length, which makes that cheap to detect without decoding the font.
/// </summary>
public class FontFileTests
{
    /// <summary>
    /// "wOF2", the WOFF2 signature. See https://www.w3.org/TR/WOFF2/#woff20Header.
    /// </summary>
    private const uint Woff2Signature = 0x774F4632;

    private const int Woff2HeaderLength = 20;

    public static IEnumerable<Func<(IconPack Pack, string FontPath)>> AllFonts() =>
        IconPack.All()
            .Select(packFactory => packFactory())
            .SelectMany(pack => Directory
                .EnumerateFiles(pack.FontDirectory, "*.woff2")
                .Order(StringComparer.Ordinal)
                .Select(fontPath => new Func<(IconPack, string)>(() => (pack, fontPath))));

    [Test]
    [MethodDataSource(nameof(AllFonts))]
    public async Task EveryFontStartsWithTheWoff2Signature(IconPack pack, string fontPath)
    {
        var header = await ReadHeaderAsync(fontPath);

        await Assert.That(BinaryPrimitives.ReadUInt32BigEndian(header)).IsEqualTo(Woff2Signature);
    }

    /// <summary>
    /// The header's length field covers the whole file, so a mismatch means the download was cut short.
    /// </summary>
    [Test]
    [MethodDataSource(nameof(AllFonts))]
    public async Task EveryFontIsTheLengthItsHeaderDeclares(IconPack pack, string fontPath)
    {
        var header = await ReadHeaderAsync(fontPath);
        var declaredLength = BinaryPrimitives.ReadUInt32BigEndian(header.AsSpan(8));

        await Assert.That(declaredLength).IsEqualTo((uint)new FileInfo(fontPath).Length);
    }

    [Test]
    [MethodDataSource(nameof(AllFonts))]
    public async Task EveryFontContainsTables(IconPack pack, string fontPath)
    {
        var header = await ReadHeaderAsync(fontPath);
        var tableCount = BinaryPrimitives.ReadUInt16BigEndian(header.AsSpan(12));

        await Assert.That(tableCount).IsGreaterThan((ushort)0);
    }

    private static async Task<byte[]> ReadHeaderAsync(string fontPath)
    {
        var header = new byte[Woff2HeaderLength];
        await using var stream = File.OpenRead(fontPath);
        await stream.ReadExactlyAsync(header);

        return header;
    }
}
