# Contributing to MudBlazor Icons

Thanks for helping improve MudBlazor Icons! Contributions of all kinds are welcome.

## Project layout

| Path | What it is |
| :-- | :-- |
| `src/MudBlazor.FontIcons.MaterialIcons/` | The Material Icons package: generated icon classes plus bundled fonts and CSS |
| `src/MudBlazor.FontIcons.MaterialSymbols/` | The Material Symbols package: generated icon classes plus bundled fonts and CSS |
| `src/GoogleMaterialDesignIconsGenerator/` | Console tool that regenerates the icon classes and fonts from Google's icon metadata |
| `documentation/` | Usage guides, also packed as the NuGet package READMEs |

**The icon classes are generated.** Never hand-edit `Filled.cs`, `Outlined.cs`, and friends. Run the generator instead:

```bash
dotnet run --project src/GoogleMaterialDesignIconsGenerator
```

It prompts for which pack to regenerate (or takes it as an argument) and writes the updated classes and fonts into the package project.

## Reporting issues

Found a bug or want a feature? [Open an issue](https://github.com/MudBlazor/MudBlazor.Icons/issues) with a descriptive title, what happened (or what you'd like), steps to reproduce if applicable, and any relevant logs or screenshots.

## Submitting changes

1. [Fork the repository](https://github.com/MudBlazor/MudBlazor.Icons) and clone your fork:

```bash
git clone https://github.com/<your-username>/MudBlazor.Icons.git
```

2. Create a descriptively named branch, such as `feature/your-feature-name`.

3. Make your changes. Follow the existing code style, and remember: icon classes go through the generator.

4. Push the branch to your fork and [open a pull request](https://github.com/MudBlazor/MudBlazor.Icons/pulls) against `master`, explaining what you changed and why.

## Code of Conduct

This project follows the Contributor Covenant [code of conduct](CODE_OF_CONDUCT.md). By participating, you agree to uphold it.

## License

By contributing, you agree that your contributions are licensed under the [MIT License](LICENSE).

## Getting help

Open an issue, or ask in the [MudBlazor Discord](https://discord.gg/mudblazor).
