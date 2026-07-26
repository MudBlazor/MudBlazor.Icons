# MudBlazor Icons: Material Icons & Material Symbols for Blazor

[![License](https://img.shields.io/github/license/MudBlazor/MudBlazor.Icons?color=%23594ae2&style=flat-square)](https://github.com/MudBlazor/MudBlazor.Icons/blob/master/LICENSE)
[![Discord](https://img.shields.io/discord/786656789310865418?color=%237289da&label=Discord&logo=discord&logoColor=%237289da&style=flat-square)](https://discord.gg/mudblazor)
[![Twitter](https://img.shields.io/twitter/follow/MudBlazor?color=1DA1F2&label=Twitter&logo=Twitter&style=flat-square)](https://twitter.com/MudBlazor)

Every Google Material icon, ready for [MudBlazor](https://mudblazor.com/). Two official NuGet packages cover the complete Material Icons and Material Symbols collections, over 22,000 icons in total, each one a strongly typed C# constant.

```razor
<MudIcon Icon="@MudBlazor.FontIcons.MaterialSymbols.Outlined.Rocket" />
```

## Why these packs?

- **Every icon, every style.** Thousands of icons MudBlazor's built-in set doesn't include, plus the entire Material Symbols collection.
- **IntelliSense, not magic strings.** Your editor autocompletes icon names, and typos become build errors.
- **Self-hosted fonts.** No Google CDN, no third-party requests. Works offline and in air-gapped environments.
- **Trimming and AOT compatible.** Safe for Blazor WebAssembly trimming and Native AOT.
- **Runs everywhere Blazor does.** Server, WebAssembly, and Hybrid (.NET MAUI).

## Quick start

1. Install a package:

```bash
dotnet add package MudBlazor.FontIcons.MaterialSymbols
```

2. Add the stylesheet next to your MudBlazor stylesheet (in `App.razor`, `index.html`, or your host page):

```html
<link href="_content/MudBlazor.FontIcons.MaterialSymbols/css/font.min.css" rel="stylesheet" />
```

3. Use any icon, anywhere MudBlazor accepts one:

```razor
<MudIcon Icon="@MudBlazor.FontIcons.MaterialSymbols.Outlined.Database" />
<MudIconButton Icon="@MudBlazor.FontIcons.MaterialSymbols.Rounded.Settings" />
```

That's it. The usage guides cover aliases, font preloading, CDN options, and troubleshooting.

## Choosing a pack

| | [MudBlazor.FontIcons.MaterialSymbols](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialSymbols/) | [MudBlazor.FontIcons.MaterialIcons](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialIcons/) |
| :-- | :-- | :-- |
| **Icon set** | Material Symbols, Google's current set, still growing | Material Icons, the classic set, stable but frozen |
| **Styles** | Outlined, Rounded, Sharp | Filled, Outlined, Rounded, Sharp, Two-Tone |
| **Icons per style** | 3,800+ | 2,100+ |
| **NuGet** | [![NuGet version](https://img.shields.io/nuget/v/MudBlazor.FontIcons.MaterialSymbols?color=ff4081&label=version&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialSymbols/) [![NuGet downloads](https://img.shields.io/nuget/dt/MudBlazor.FontIcons.MaterialSymbols?color=ff4081&label=downloads&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialSymbols/) | [![NuGet version](https://img.shields.io/nuget/v/MudBlazor.FontIcons.MaterialIcons?color=ff4081&label=version&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialIcons/) [![NuGet downloads](https://img.shields.io/nuget/dt/MudBlazor.FontIcons.MaterialIcons?color=ff4081&label=downloads&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialIcons/) |
| **Guide** | [Material Symbols guide](documentation/material_symbols_usage.md) | [Material Icons guide](documentation/material_icons_usage.md) |

Undecided? Pick **Material Symbols**. It's the set Google still adds to. Choose Material Icons if you want the Filled or Two-Tone styles, or install both; they coexist happily.

Both packages require MudBlazor 7.0.0+ and .NET 8, 9, or 10.

## FAQ

### How is this different from MudBlazor's built-in icons?

The built-in `Icons.Material` classes cover a curated subset of Material Icons as SVGs. These packs deliver the complete collections as icon fonts, including Material Symbols, which MudBlazor core doesn't ship at all. Mix them freely in the same app.

### Do I need an internet connection or Google's CDN?

No. The fonts live in the NuGet package and are served by your own app. A Google Fonts CDN option exists if you prefer it; see the usage guides.

### Where do I browse the icons?

[Google Fonts](https://fonts.google.com/icons). Find `rocket_launch` there, use `Outlined.RocketLaunch` here.

### How do the packs stay current?

A generator in this repository rebuilds the icon classes and fonts from Google's official metadata, and updates ship to NuGet.

## Contributing and support

- [Contributing guide](CONTRIBUTING.md) and [code of conduct](CODE_OF_CONDUCT.md)
- [Discord](https://discord.gg/mudblazor) for questions and chat
- [GitHub issues](https://github.com/MudBlazor/MudBlazor.Icons/issues) for bugs and feature requests
- [MudBlazor documentation](https://mudblazor.com/)

## License

[MIT](LICENSE). The Material Icons and Material Symbols fonts are created by Google under the [Apache License 2.0](https://github.com/google/material-design-icons/blob/master/LICENSE).
