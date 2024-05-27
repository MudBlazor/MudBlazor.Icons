using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace MaterialSymbolsParser.Extensions;

public static class SyntaxNodeExtensions
{
    private static SyntaxTrivia NewLine => Environment.NewLine == "\r\n"
        ? SyntaxFactory.CarriageReturnLineFeed
        : SyntaxFactory.LineFeed;

    public static TSyntax WithLeadingNewLines<TSyntax>(this TSyntax syntax, int count = 1)
        where TSyntax : SyntaxNode
        => syntax.WithLeadingTrivia(Enumerable.Repeat(NewLine, count));

    public static TSyntax WithTrailingNewLines<TSyntax>(this TSyntax syntax, int count = 1)
        where TSyntax : SyntaxNode
        => syntax.WithTrailingTrivia(Enumerable.Repeat(NewLine, count));
}