# MudBlazor Material Symbols
[![NuGet version](https://img.shields.io/nuget/v/MudBlazor.FontIcons.MaterialSymbols?color=ff4081&label=nuget%20version&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialSymbols/)
[![NuGet downloads](https://img.shields.io/nuget/dt/MudBlazor.FontIcons.MaterialSymbols?color=ff4081&label=nuget%20downloads&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialSymbols/)

## Supported MudBlazor Versions

| MudBlazor.FontIcons.MaterialSymbols  |    MudBlazor    |      .NET       |
| :------------- | :-------------: | :-------------: |
| 1.0.0  => |     7.0.0-preview.4 =>      |     .NET 7 & NET 8      |


To use the icons in your MudBlazor project, you can add the following CSS link to your HTML or Razor layout:

```html
<link href="_content/MudBlazor.FontIcons.MaterialSymbols/css/font.min.css" rel="stylesheet" />
```

The package is self-hosted and serves its font assets from `_content/MudBlazor.FontIcons.MaterialSymbols/`.

For above-the-fold icons, preloading the style(s) you use can reduce first-paint delay:

```html
<link rel="preload" href="_content/MudBlazor.FontIcons.MaterialSymbols/font/MaterialSymbolsRounded.woff2" as="font" type="font/woff2" crossorigin />
```

Alternatively, you can use the following CDN links:

```html
<link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined" rel="stylesheet" />
<link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Rounded" rel="stylesheet" />
<link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Sharp" rel="stylesheet" />
```

## Example Usage

To use an icon in your MudBlazor component, you can use the `<MudIcon>` component and specify the icon using the `Icon` parameter. For example:

```html
<MudIcon Icon="@MudBlazor.FontIcons.MaterialSymbols.Outlined.Database"></MudIcon>
```

This will render an icon representing a database, using the Material Symbols Outlined style.

## Using Aliases

If you prefer not to use the full qualifier every time, you can create an alias in `_Imports.razor` by adding the following line:

```razor
@using MaterialSymbols = MudBlazor.FontIcons.MaterialSymbols
```

This allows you to access the icons like this:

```html
<MudIcon Icon="@MaterialSymbols.Outlined.Database"></MudIcon>
```

**NB!** Please note that aliases do not work in normal Razor pages (https://github.com/dotnet/razor/issues/7670)!

## Loading tradeoffs

Material Symbols constants in this package are ligature-based strings (for example `material-symbols-rounded/weight`).
Ligature rendering can still show readable fallback text briefly on very first load in some environments.

If your UI requires a strict "never show fallback text" behavior, prefer SVG icons.
