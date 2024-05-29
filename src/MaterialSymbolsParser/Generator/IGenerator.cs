using MaterialSymbolsParser.Model.Google;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MaterialSymbolsParser.Generator;

public interface IGenerator
{
    public string Namespace { get; }

    CompilationUnitSyntax GetCompilationUnitSyntax(KeyValuePair<string, IReadOnlyCollection<Icon>> group, string className, string familyPath);
}