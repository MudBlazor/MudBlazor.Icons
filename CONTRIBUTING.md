# Contributing to MudBlazor Icons

Thank you for your interest in contributing to MudBlazor Icons! We welcome contributions from the community and appreciate your efforts to improve this project.

## Project layout

Knowing where things live will save you time:

| Path | What it is |
| :-- | :-- |
| `src/MudBlazor.FontIcons.MaterialIcons/` | The Material Icons NuGet package — **auto-generated** icon classes plus bundled fonts and CSS |
| `src/MudBlazor.FontIcons.MaterialSymbols/` | The Material Symbols NuGet package — **auto-generated** icon classes plus bundled fonts and CSS |
| `src/GoogleMaterialDesignIconsGenerator/` | Console tool that downloads Google's icon metadata and regenerates the icon classes and fonts |
| `documentation/` | Usage guides — these files are also packed as the NuGet package READMEs |

**Important:** the `Filled.cs`, `Outlined.cs`, `Rounded.cs`, `Sharp.cs`, and `TwoTone.cs` files in the package projects are generated. Don't edit them by hand — run the generator instead:

```bash
dotnet run --project src/GoogleMaterialDesignIconsGenerator
```

The tool prompts for which icon pack to regenerate (or pass it as an argument) and writes the updated classes — and, for Material Symbols, the updated fonts — into the corresponding package project.

## Reporting issues

If you encounter a bug or have a feature request, please [create an issue on GitHub](https://github.com/MudBlazor/MudBlazor.Icons/issues). Include:

- A clear and descriptive title.
- A detailed description of the problem or suggestion.
- Steps to reproduce the issue (if applicable).
- Any relevant logs or screenshots.

## Submitting changes

1. **Fork the repository.** Go to the [MudBlazor.Icons repository](https://github.com/MudBlazor/MudBlazor.Icons) and click "Fork".

2. **Clone your fork:**

```bash
git clone https://github.com/<your-username>/MudBlazor.Icons.git
cd MudBlazor.Icons
```

3. **Create a branch** with a descriptive name:

```bash
git checkout -b feature/your-feature-name
```

4. **Make your changes.** Follow the existing code style, and remember that icon classes must be changed through the generator, not by hand.

5. **Commit and push:**

```bash
git commit -am "Add new feature: your feature description"
git push origin feature/your-feature-name
```

6. **Open a pull request** against `master` in the [pull requests section](https://github.com/MudBlazor/MudBlazor.Icons/pulls), with a clear title and description of what you changed and why.

## Code of Conduct

This project adheres to the Contributor Covenant [code of conduct](CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code. Please report unacceptable behavior to the project maintainers.

## License

By contributing to MudBlazor Icons, you agree that your contributions will be licensed under the [MIT License](LICENSE).

## Getting help

If you need help or have questions, open an issue on GitHub or ask in the [MudBlazor Discord](https://discord.gg/mudblazor).
