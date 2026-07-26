# Material Icons for MudBlazor

[![NuGet version](https://img.shields.io/nuget/v/MudBlazor.FontIcons.MaterialIcons?color=ff4081&label=nuget%20version&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialIcons/)
[![NuGet downloads](https://img.shields.io/nuget/dt/MudBlazor.FontIcons.MaterialIcons?color=ff4081&label=nuget%20downloads&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialIcons/)

`MudBlazor.FontIcons.MaterialIcons` is the official [MudBlazor](https://mudblazor.com/) icon pack for [Google's classic Material Icons](https://fonts.google.com/icons?icon.set=Material+Icons). It gives you **2,100+ icons in five styles** (Filled, Outlined, Rounded, Sharp, Two-Tone) as strongly typed C# constants with IntelliSense, backed by self-hosted icon fonts.

> Looking for Google's newer, actively growing icon set? See the companion pack [MudBlazor.FontIcons.MaterialSymbols](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialSymbols/).

## Install

```bash
dotnet add package MudBlazor.FontIcons.MaterialIcons
```

Or add it to your project file:

```xml
<PackageReference Include="MudBlazor.FontIcons.MaterialIcons" Version="*" />
```

Requires MudBlazor 7.0.0+ and .NET 8, 9, or 10.

## Add the stylesheet

Add this line wherever your app loads the MudBlazor stylesheet — `App.razor` in a Blazor Web App, `wwwroot/index.html` in Blazor WebAssembly, or your host page in older Blazor Server templates:

```html
<link href="_content/MudBlazor.FontIcons.MaterialIcons/css/font.min.css" rel="stylesheet" />
```

The fonts ship inside the package and are served from your own app — no CDN or internet connection required at runtime.

## Use an icon

Pass any icon constant to `MudIcon`, or to any MudBlazor component with an icon parameter:

```razor
<MudIcon Icon="@MudBlazor.FontIcons.MaterialIcons.Outlined.Chat" />

<MudIconButton Icon="@MudBlazor.FontIcons.MaterialIcons.Filled.Settings" />

<MudButton StartIcon="@MudBlazor.FontIcons.MaterialIcons.TwoTone.Download">Download</MudButton>
```

To find an icon, browse [Material Icons on Google Fonts](https://fonts.google.com/icons?icon.set=Material+Icons) and convert the icon name to PascalCase: `shopping_cart` becomes `Filled.ShoppingCart`. Names that start with a digit are prefixed with an underscore: `10k` becomes `Filled._10K`.

## Available styles

| C# class | Style | Example |
| :-- | :-- | :-- |
| `MaterialIcons.Filled` | Filled (the classic default) | `Filled.Home` |
| `MaterialIcons.Outlined` | Outlined | `Outlined.Home` |
| `MaterialIcons.Rounded` | Rounded corners | `Rounded.Home` |
| `MaterialIcons.Sharp` | Squared corners | `Sharp.Home` |
| `MaterialIcons.TwoTone` | Two-tone | `TwoTone.Home` |

## Shorten icon names with an alias

Typing the full namespace gets verbose. Add an alias to `_Imports.razor`:

```razor
@using MaterialIcons = MudBlazor.FontIcons.MaterialIcons
```

Then use icons like this:

```razor
<MudIcon Icon="@MaterialIcons.Outlined.Chat" />
```

> **Note:** Due to a [Razor compiler limitation](https://github.com/dotnet/razor/issues/7670), `@using` aliases only work when declared in `_Imports.razor` — declaring the alias in an individual `.razor` page does not work.

## Optional: preload fonts to reduce flicker

Browsers only download a font once the first icon appears, which can cause a brief flash of unstyled text. To avoid it, preload the fonts for the styles you use *before* the stylesheet link:

```html
<link rel="preload"
      href="_content/MudBlazor.FontIcons.MaterialIcons/font/MaterialIcons.woff2"
      as="font"
      type="font/woff2"
      crossorigin>
<link rel="preload"
      href="_content/MudBlazor.FontIcons.MaterialIcons/font/MaterialIconsOutlined.woff2"
      as="font"
      type="font/woff2"
      crossorigin>
<link rel="preload"
      href="_content/MudBlazor.FontIcons.MaterialIcons/font/MaterialIconsRound.woff2"
      as="font"
      type="font/woff2"
      crossorigin>
<link rel="preload"
      href="_content/MudBlazor.FontIcons.MaterialIcons/font/MaterialIconsSharp.woff2"
      as="font"
      type="font/woff2"
      crossorigin>
<link rel="preload"
      href="_content/MudBlazor.FontIcons.MaterialIcons/font/MaterialIconsTwoTone.woff2"
      as="font"
      type="font/woff2"
      crossorigin>
<link href="_content/MudBlazor.FontIcons.MaterialIcons/css/font.min.css" rel="stylesheet" />
```

Only preload the styles you actually use — each preload downloads that font on every page load.

## Optional: use the Google Fonts CDN instead

If you prefer loading the fonts from Google's CDN rather than self-hosting, replace the package stylesheet with:

```html
<link href="https://fonts.googleapis.com/css2?family=Material+Icons" rel="stylesheet">
<link href="https://fonts.googleapis.com/css2?family=Material+Icons+Outlined" rel="stylesheet">
<link href="https://fonts.googleapis.com/css2?family=Material+Icons+Round" rel="stylesheet">
<link href="https://fonts.googleapis.com/css2?family=Material+Icons+Sharp" rel="stylesheet">
<link href="https://fonts.googleapis.com/css2?family=Material+Icons+Two+Tone" rel="stylesheet">
```

The C# constants work the same either way.

## Troubleshooting

**The icon renders as text (e.g. "chat") instead of a glyph.**
The font stylesheet isn't loaded. Check that the `<link>` tag from [Add the stylesheet](#add-the-stylesheet) is present and that the page can reach `_content/MudBlazor.FontIcons.MaterialIcons/css/font.min.css` (watch for 404s in the browser's network tab).

**An alias like `@MaterialIcons.Outlined.X` doesn't compile.**
Make sure the alias is declared in `_Imports.razor`, not in the page itself — see the note above.

## Related links

- [MudBlazor.Icons repository](https://github.com/MudBlazor/MudBlazor.Icons) — source, issues, and contributing
- [MudBlazor.FontIcons.MaterialSymbols](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialSymbols/) — companion pack for Google's current Material Symbols set
- [MudBlazor documentation](https://mudblazor.com/)
- [Browse Material Icons on Google Fonts](https://fonts.google.com/icons?icon.set=Material+Icons)
