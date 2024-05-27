using MaterialSymbolsParser.Service;

namespace MaterialSymbolsParser;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var codeGenerator = new CodeGenerationService();
        using var client = new IconHttpClientService();
        var metadata = await client.ParseIconsAsync().ConfigureAwait(false);
        var filteredIcons = Utility.IconFilter.FilterNonMaterialSymbols(metadata!);
        var groupedIcons = Utility.IconFilter.GroupIconsByFamilies(filteredIcons);

        codeGenerator.GenerateCsFilesUsingRoslyn(groupedIcons, folder: "../../../../MudBlazor.Icons.MaterialSymbols");
    }
}