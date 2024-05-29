using GoogleMaterialDesignIconsGenerator.Generator;
using GoogleMaterialDesignIconsGenerator.Model;
using GoogleMaterialDesignIconsGenerator.Model.Google;
using Microsoft.CodeAnalysis;

namespace GoogleMaterialDesignIconsGenerator.Service;

public class CodeGenerationService
{
    public void GenerateCsFilesUsingRoslyn(IconType iconType, Dictionary<string, IReadOnlyCollection<Icon>> groupedIcons, string folder)
    {
        foreach (var group in groupedIcons)
        {
            var family = group.Key;
            var className = Utility.FamilyMap.FamilyNameToCsharpClassName(family);
            var familyPath = Utility.FamilyMap.FamilyNameToHtmlClassName(family);
            var generator = GeneratorFactory.Create(iconType);
            var namespaceDeclaration = generator.GetCompilationUnitSyntax(group, className, familyPath);
            var code = namespaceDeclaration.NormalizeWhitespace().ToFullString();

            var path = Path.Combine(folder, $"{className}.cs");
            FileInfo file = new FileInfo(path);
            file.Directory?.Create();
            File.WriteAllText(path, code);
        }
    }

}