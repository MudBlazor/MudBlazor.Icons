# MudBlazor Icons — Material Icons & Material Symbols for Blazor

[![License](https://img.shields.io/github/license/MudBlazor/MudBlazor.Icons?color=%23594ae2&style=flat-square)](https://github.com/MudBlazor/MudBlazor.Icons/blob/master/LICENSE)
[![Discord](https://img.shields.io/discord/786656789310865418?color=%237289da&label=Discord&logo=discord&logoColor=%237289da&style=flat-square)](https://discord.gg/mudblazor)
[![Twitter](https://img.shields.io/twitter/follow/MudBlazor?color=1DA1F2&label=Twitter&logo=Twitter&style=flat-square)](https://twitter.com/MudBlazor)

The official icon packs for [MudBlazor](https://mudblazor.com/), the Material Design component library for Blazor. These NuGet packages bring Google's complete **Material Icons** and **Material Symbols** collections — over 22,000 icon constants — to your Blazor app with full IntelliSense support.

```razor
<MudIcon Icon="@MudBlazor.FontIcons.MaterialSymbols.Outlined.Rocket" />
```

## Why use these packs?

- **Every icon, every style** — the complete Google icon collections, including thousands of icons and styles not available in MudBlazor's built-in icon set.
- **IntelliSense instead of magic strings** — every icon is a strongly typed C# constant, so typos become build-time errors and your editor autocompletes icon names.
- **Self-hosted fonts** — WOFF2 font files ship inside the package and are served from your app. No Google CDN calls, which means they work offline, in air-gapped environments, and without third-party requests (helpful for GDPR compliance).
- **Trimming and AOT compatible** — safe to use with Blazor WebAssembly trimming and Native AOT.
- **Works everywhere Blazor runs** — Blazor Server, Blazor WebAssembly, and Blazor Hybrid (.NET MAUI).

## Quick start

1. Install a package:

```bash
dotnet add package MudBlazor.FontIcons.MaterialSymbols
```

2. Add the stylesheet next to your existing MudBlazor stylesheet (in `App.razor`, `index.html`, or your host page):

```html
<link href="_content/MudBlazor.FontIcons.MaterialSymbols/css/font.min.css" rel="stylesheet" />
```

3. Use any icon with `MudIcon` — or any other MudBlazor component that accepts an icon:

```razor
<MudIcon Icon="@MudBlazor.FontIcons.MaterialSymbols.Outlined.Database" />
<MudIconButton Icon="@MudBlazor.FontIcons.MaterialSymbols.Rounded.Settings" />
```

That's it. See the usage guides below for aliases, font preloading, CDN options, and troubleshooting.

## Choosing a pack

| | [MudBlazor.FontIcons.MaterialSymbols](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialSymbols/) | [MudBlazor.FontIcons.MaterialIcons](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialIcons/) |
| :-- | :-- | :-- |
| **Icon set** | Material Symbols — Google's current icon set, actively growing | Material Icons — the classic set, stable but no longer expanded |
| **Styles** | Outlined, Rounded, Sharp | Filled, Outlined, Rounded, Sharp, Two-Tone |
| **Icons per style** | 3,800+ | 2,100+ |
| **Usage guide** | [Material Symbols guide](documentation/material_symbols_usage.md) | [Material Icons guide](documentation/material_icons_usage.md) |

**Not sure which to pick?** Use **Material Symbols** — it's Google's actively maintained set and receives new icons regularly. Choose Material Icons if you need the Filled or Two-Tone styles, or want to match an existing Material Icons design. You can also install both packs side by side.

## Packages

### MudBlazor.FontIcons.MaterialSymbols

[![NuGet version](https://img.shields.io/nuget/v/MudBlazor.FontIcons.MaterialSymbols?color=ff4081&label=nuget%20version&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialSymbols/)
[![NuGet downloads](https://img.shields.io/nuget/dt/MudBlazor.FontIcons.MaterialSymbols?color=ff4081&label=nuget%20downloads&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialSymbols/)

Google's Material Symbols in Outlined, Rounded, and Sharp styles. Full setup and examples in the [Material Symbols usage guide](documentation/material_symbols_usage.md).

### MudBlazor.FontIcons.MaterialIcons

[![NuGet version](https://img.shields.io/nuget/v/MudBlazor.FontIcons.MaterialIcons?color=ff4081&label=nuget%20version&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialIcons/)
[![NuGet downloads](https://img.shields.io/nuget/dt/MudBlazor.FontIcons.MaterialIcons?color=ff4081&label=nuget%20downloads&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialIcons/)

Google's classic Material Icons in Filled, Outlined, Rounded, Sharp, and Two-Tone styles. Full setup and examples in the [Material Icons usage guide](documentation/material_icons_usage.md).

## Compatibility

Both packages support:

| Requirement | Version |
| :-- | :-- |
| MudBlazor | 7.0.0 and up |
| .NET | 8, 9, and 10 |

## FAQ

### How is this different from MudBlazor's built-in icons?

MudBlazor ships with a built-in set of Material SVG icons (`Icons.Material.Filled.Home` and friends). These packs complement it with the **complete** Google collections as icon fonts — including Material Symbols, which isn't part of MudBlazor core, and thousands of icons the built-in set doesn't cover. You can freely mix built-in SVG icons and font icons in the same app.

### Do I need an internet connection or Google's CDN?

No. The fonts are bundled in the NuGet package and served as static web assets from your own app. A Google Fonts CDN option exists if you prefer it — see the usage guides.

### Can I browse the available icons?

Yes — browse [Google Fonts icons](https://fonts.google.com/icons) to find an icon visually, then use the matching constant. For example, the symbol named `rocket_launch` is `MudBlazor.FontIcons.MaterialSymbols.Outlined.RocketLaunch`.

### How are the packs kept up to date?

Icon classes and fonts are generated automatically from Google's official icon metadata by the generator in this repository, and updated releases are published to NuGet.

## Contributing

Contributions are welcome! See the [contributing guide](CONTRIBUTING.md) to get started, and the [code of conduct](CODE_OF_CONDUCT.md) for community standards.

## Community & support

- [MudBlazor documentation](https://mudblazor.com/)
- [Discord server](https://discord.gg/mudblazor) — ask questions and chat with the community
- [GitHub issues](https://github.com/MudBlazor/MudBlazor.Icons/issues) — report bugs or request features

## License

This project is licensed under the [MIT License](LICENSE). The Material Icons and Material Symbols fonts are created by Google and distributed under the [Apache License 2.0](https://github.com/google/material-design-icons/blob/master/LICENSE).
