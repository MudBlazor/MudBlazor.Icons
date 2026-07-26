# Material Symbols for MudBlazor

[![NuGet version](https://img.shields.io/nuget/v/MudBlazor.FontIcons.MaterialSymbols?color=ff4081&label=nuget%20version&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialSymbols/)
[![NuGet downloads](https://img.shields.io/nuget/dt/MudBlazor.FontIcons.MaterialSymbols?color=ff4081&label=nuget%20downloads&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialSymbols/)

`MudBlazor.FontIcons.MaterialSymbols` is the official [MudBlazor](https://mudblazor.com/) icon pack for [Google's Material Symbols](https://fonts.google.com/icons) — the current, actively growing Material Design icon set. It gives you **3,800+ icons in three styles** (Outlined, Rounded, Sharp) as strongly typed C# constants with IntelliSense, backed by self-hosted icon fonts.

## Install

```bash
dotnet add package MudBlazor.FontIcons.MaterialSymbols
```

Or add it to your project file:

```xml
<PackageReference Include="MudBlazor.FontIcons.MaterialSymbols" Version="*" />
```

Requires MudBlazor 7.0.0+ and .NET 8, 9, or 10.

## Add the stylesheet

Add this line wherever your app loads the MudBlazor stylesheet — `App.razor` in a Blazor Web App, `wwwroot/index.html` in Blazor WebAssembly, or your host page in older Blazor Server templates:

```html
<link href="_content/MudBlazor.FontIcons.MaterialSymbols/css/font.min.css" rel="stylesheet" />
```

The fonts ship inside the package and are served from your own app — no CDN or internet connection required at runtime.

## Use an icon

Pass any icon constant to `MudIcon`, or to any MudBlazor component with an icon parameter:

```razor
<MudIcon Icon="@MudBlazor.FontIcons.MaterialSymbols.Outlined.Database" />

<MudIconButton Icon="@MudBlazor.FontIcons.MaterialSymbols.Rounded.Settings" />

<MudButton StartIcon="@MudBlazor.FontIcons.MaterialSymbols.Sharp.Download">Download</MudButton>
```

To find an icon, browse [Google Fonts icons](https://fonts.google.com/icons) and convert the icon name to PascalCase: `rocket_launch` becomes `Outlined.RocketLaunch`. Names that start with a digit are prefixed with an underscore: `10k` becomes `Outlined._10K`.

## Available styles

| C# class | Style | Example |
| :-- | :-- | :-- |
| `MaterialSymbols.Outlined` | Outlined (default Material 3 look) | `Outlined.Home` |
| `MaterialSymbols.Rounded` | Rounded corners | `Rounded.Home` |
| `MaterialSymbols.Sharp` | Squared corners | `Sharp.Home` |

## Shorten icon names with an alias

Typing the full namespace gets verbose. Add an alias to `_Imports.razor`:

```razor
@using MaterialSymbols = MudBlazor.FontIcons.MaterialSymbols
```

Then use icons like this:

```razor
<MudIcon Icon="@MaterialSymbols.Outlined.Database" />
```

> **Note:** Due to a [Razor compiler limitation](https://github.com/dotnet/razor/issues/7670), `@using` aliases only work when declared in `_Imports.razor` — declaring the alias in an individual `.razor` page does not work.

## Optional: preload fonts to reduce flicker

Browsers only download a font once the first icon appears, which can cause a brief flash of unstyled text. To avoid it, preload the fonts for the styles you use *before* the stylesheet link:

```html
<link rel="preload"
      href="_content/MudBlazor.FontIcons.MaterialSymbols/font/MaterialSymbolsOutlined.woff2"
      as="font"
      type="font/woff2"
      crossorigin>
<link rel="preload"
      href="_content/MudBlazor.FontIcons.MaterialSymbols/font/MaterialSymbolsRounded.woff2"
      as="font"
      type="font/woff2"
      crossorigin>
<link rel="preload"
      href="_content/MudBlazor.FontIcons.MaterialSymbols/font/MaterialSymbolsSharp.woff2"
      as="font"
      type="font/woff2"
      crossorigin>
<link href="_content/MudBlazor.FontIcons.MaterialSymbols/css/font.min.css" rel="stylesheet" />
```

Only preload the styles you actually use — each preload downloads that font on every page load.

## Optional: use the Google Fonts CDN instead

If you prefer loading the fonts from Google's CDN rather than self-hosting, replace the package stylesheet with:

```html
<link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined" rel="stylesheet" />
<link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Rounded" rel="stylesheet" />
<link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Sharp" rel="stylesheet" />
```

The C# constants work the same either way.

## Troubleshooting

**The icon renders as text (e.g. "database") instead of a glyph.**
The font stylesheet isn't loaded. Check that the `<link>` tag from [Add the stylesheet](#add-the-stylesheet) is present and that the page can reach `_content/MudBlazor.FontIcons.MaterialSymbols/css/font.min.css` (watch for 404s in the browser's network tab).

**An alias like `@MaterialSymbols.Outlined.X` doesn't compile.**
Make sure the alias is declared in `_Imports.razor`, not in the page itself — see the note above.

**An icon I found on Google Fonts is missing.**
Google adds new symbols continuously; the package is regenerated regularly, but very recent icons may not be in the latest release yet. Open an issue on [GitHub](https://github.com/MudBlazor/MudBlazor.Icons/issues) to request a refresh.

## Related links

- [MudBlazor.Icons repository](https://github.com/MudBlazor/MudBlazor.Icons) — source, issues, and contributing
- [MudBlazor.FontIcons.MaterialIcons](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialIcons/) — companion pack for the classic Material Icons set (includes Filled and Two-Tone styles)
- [MudBlazor documentation](https://mudblazor.com/)
- [Browse Material Symbols on Google Fonts](https://fonts.google.com/icons)
