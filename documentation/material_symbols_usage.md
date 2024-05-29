# MudBlazor Material Symbols Icons
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
