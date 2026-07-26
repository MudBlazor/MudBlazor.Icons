# Material Symbols for MudBlazor

[![NuGet version](https://img.shields.io/nuget/v/MudBlazor.FontIcons.MaterialSymbols?color=ff4081&label=nuget%20version&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialSymbols/)
[![NuGet downloads](https://img.shields.io/nuget/dt/MudBlazor.FontIcons.MaterialSymbols?color=ff4081&label=nuget%20downloads&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialSymbols/)

`MudBlazor.FontIcons.MaterialSymbols` puts [Google's Material Symbols](https://fonts.google.com/icons) in your [MudBlazor](https://mudblazor.com/) app: 3,800+ icons in Outlined, Rounded, and Sharp styles, each a strongly typed C# constant with IntelliSense, served by self-hosted fonts.

## Install

```bash
dotnet add package MudBlazor.FontIcons.MaterialSymbols
```

Requires MudBlazor 7.0.0+ and .NET 8, 9, or 10.

## Add the stylesheet

Add this next to your MudBlazor stylesheet (in `App.razor`, `wwwroot/index.html`, or your host page):

```html
<link href="_content/MudBlazor.FontIcons.MaterialSymbols/css/font.min.css" rel="stylesheet" />
```

The fonts ship in the package and are served by your app. No CDN, no internet required at runtime.

## Use an icon

Pass a constant to `MudIcon`, or to any MudBlazor component with an icon parameter:

```razor
<MudIcon Icon="@MudBlazor.FontIcons.MaterialSymbols.Outlined.Database" />

<MudIconButton Icon="@MudBlazor.FontIcons.MaterialSymbols.Rounded.Settings" />

<MudButton StartIcon="@MudBlazor.FontIcons.MaterialSymbols.Sharp.Download">Download</MudButton>
```

Browse [Google Fonts](https://fonts.google.com/icons) to find an icon, then PascalCase its name: `rocket_launch` becomes `Outlined.RocketLaunch`. Names starting with a digit get an underscore: `10k` becomes `Outlined._10K`.

## Available styles

| C# class | Style |
| :-- | :-- |
| `MaterialSymbols.Outlined` | Outlined, the Material 3 default |
| `MaterialSymbols.Rounded` | Rounded corners |
| `MaterialSymbols.Sharp` | Squared corners |

## Shorten names with an alias

The full namespace is a mouthful. Alias it in `_Imports.razor`:

```razor
@using MaterialSymbols = MudBlazor.FontIcons.MaterialSymbols
```

```razor
<MudIcon Icon="@MaterialSymbols.Outlined.Database" />
```

> **Note:** A [Razor compiler limitation](https://github.com/dotnet/razor/issues/7670) means aliases only work from `_Imports.razor`, not from individual `.razor` pages.

## Optional: preload fonts

Fonts download when the first icon appears, so icons can briefly flash as text. To avoid that, preload the styles you use, before the stylesheet link:

```html
<link rel="preload"
      href="_content/MudBlazor.FontIcons.MaterialSymbols/font/MaterialSymbolsOutlined.woff2"
      as="font"
      type="font/woff2"
      crossorigin>
<link href="_content/MudBlazor.FontIcons.MaterialSymbols/css/font.min.css" rel="stylesheet" />
```

The other styles follow the same pattern: `MaterialSymbolsRounded.woff2` and `MaterialSymbolsSharp.woff2`. Preload only what you use; each preload is a download on every page load.

## Optional: Google Fonts CDN

Prefer Google's CDN? Swap the package stylesheet for:

```html
<link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined" rel="stylesheet" />
<link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Rounded" rel="stylesheet" />
<link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Sharp" rel="stylesheet" />
```

The C# constants work the same either way.

## Troubleshooting

**Icons render as text, like "database".** The stylesheet isn't loading. Check the `<link>` tag and watch the browser's network tab for a 404 on `font.min.css`.

**An alias won't compile.** It has to live in `_Imports.razor`. See the note above.

**An icon from Google Fonts is missing.** Google adds symbols faster than releases ship. [Open an issue](https://github.com/MudBlazor/MudBlazor.Icons/issues) to request a refresh.

## Related links

- [MudBlazor.Icons repository](https://github.com/MudBlazor/MudBlazor.Icons): source, issues, contributing
- [MudBlazor.FontIcons.MaterialIcons](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialIcons/): companion pack for classic Material Icons, with Filled and Two-Tone styles
- [MudBlazor documentation](https://mudblazor.com/)
- [Browse Material Symbols on Google Fonts](https://fonts.google.com/icons)
