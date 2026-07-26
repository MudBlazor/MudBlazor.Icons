# Material Icons for MudBlazor

[![NuGet version](https://img.shields.io/nuget/v/MudBlazor.FontIcons.MaterialIcons?color=ff4081&label=nuget%20version&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialIcons/)
[![NuGet downloads](https://img.shields.io/nuget/dt/MudBlazor.FontIcons.MaterialIcons?color=ff4081&label=nuget%20downloads&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialIcons/)

`MudBlazor.FontIcons.MaterialIcons` puts [Google's classic Material Icons](https://fonts.google.com/icons?icon.set=Material+Icons) in your [MudBlazor](https://mudblazor.com/) app: 2,100+ icons in Filled, Outlined, Rounded, Sharp, and Two-Tone styles, each a strongly typed C# constant with IntelliSense, served by self-hosted fonts.

> Want Google's newer, still-growing icon set? See [MudBlazor.FontIcons.MaterialSymbols](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialSymbols/).

## Install

```bash
dotnet add package MudBlazor.FontIcons.MaterialIcons
```

Requires MudBlazor 7.0.0+ and .NET 8, 9, or 10.

## Add the stylesheet

Add this next to your MudBlazor stylesheet (in `App.razor`, `wwwroot/index.html`, or your host page):

```html
<link href="_content/MudBlazor.FontIcons.MaterialIcons/css/font.min.css" rel="stylesheet" />
```

The fonts ship in the package and are served by your app. No CDN, no internet required at runtime.

## Use an icon

Pass a constant to `MudIcon`, or to any MudBlazor component with an icon parameter:

```razor
<MudIcon Icon="@MudBlazor.FontIcons.MaterialIcons.Outlined.Chat" />

<MudIconButton Icon="@MudBlazor.FontIcons.MaterialIcons.Filled.Settings" />

<MudButton StartIcon="@MudBlazor.FontIcons.MaterialIcons.TwoTone.Download">Download</MudButton>
```

Browse [Material Icons on Google Fonts](https://fonts.google.com/icons?icon.set=Material+Icons) to find an icon, then PascalCase its name: `shopping_cart` becomes `Filled.ShoppingCart`. Names starting with a digit get an underscore: `10k` becomes `Filled._10K`.

## Available styles

| C# class | Style |
| :-- | :-- |
| `MaterialIcons.Filled` | Filled, the classic default |
| `MaterialIcons.Outlined` | Outlined |
| `MaterialIcons.Rounded` | Rounded corners |
| `MaterialIcons.Sharp` | Squared corners |
| `MaterialIcons.TwoTone` | Two-tone |

## Shorten names with an alias

The full namespace is a mouthful. Alias it in `_Imports.razor`:

```razor
@using MaterialIcons = MudBlazor.FontIcons.MaterialIcons
```

```razor
<MudIcon Icon="@MaterialIcons.Outlined.Chat" />
```

> **Note:** A [Razor compiler limitation](https://github.com/dotnet/razor/issues/7670) means aliases only work from `_Imports.razor`, not from individual `.razor` pages.

## Optional: preload fonts

Fonts download when the first icon appears, so icons can briefly flash as text. To avoid that, preload the styles you use, before the stylesheet link:

```html
<link rel="preload"
      href="_content/MudBlazor.FontIcons.MaterialIcons/font/MaterialIcons.woff2"
      as="font"
      type="font/woff2"
      crossorigin>
<link href="_content/MudBlazor.FontIcons.MaterialIcons/css/font.min.css" rel="stylesheet" />
```

The other styles follow the same pattern: `MaterialIconsOutlined.woff2`, `MaterialIconsRound.woff2`, `MaterialIconsSharp.woff2`, and `MaterialIconsTwoTone.woff2`. Preload only what you use; each preload is a download on every page load.

## Optional: Google Fonts CDN

Prefer Google's CDN? Swap the package stylesheet for:

```html
<link href="https://fonts.googleapis.com/css2?family=Material+Icons" rel="stylesheet">
<link href="https://fonts.googleapis.com/css2?family=Material+Icons+Outlined" rel="stylesheet">
<link href="https://fonts.googleapis.com/css2?family=Material+Icons+Round" rel="stylesheet">
<link href="https://fonts.googleapis.com/css2?family=Material+Icons+Sharp" rel="stylesheet">
<link href="https://fonts.googleapis.com/css2?family=Material+Icons+Two+Tone" rel="stylesheet">
```

The C# constants work the same either way.

## Troubleshooting

**Icons render as text, like "chat".** The stylesheet isn't loading. Check the `<link>` tag and watch the browser's network tab for a 404 on `font.min.css`.

**An alias won't compile.** It has to live in `_Imports.razor`. See the note above.

## Related links

- [MudBlazor.Icons repository](https://github.com/MudBlazor/MudBlazor.Icons): source, issues, contributing
- [MudBlazor.FontIcons.MaterialSymbols](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialSymbols/): companion pack for Google's current Material Symbols set
- [MudBlazor documentation](https://mudblazor.com/)
- [Browse Material Icons on Google Fonts](https://fonts.google.com/icons?icon.set=Material+Icons)
