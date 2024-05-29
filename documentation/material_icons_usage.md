# MudBlazor Material Icons
[![NuGet version](https://img.shields.io/nuget/v/MudBlazor.FontIcons.MaterialIcons?color=ff4081&label=nuget%20version&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialIcons/)
[![NuGet downloads](https://img.shields.io/nuget/dt/MudBlazor.FontIcons.MaterialIcons?color=ff4081&label=nuget%20downloads&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.FontIcons.MaterialIcons/)

## Supported MudBlazor Versions

| MudBlazor.FontIcons.MaterialIcons  |    MudBlazor    |      .NET       |
| :------------- | :-------------: | :-------------: |
| 1.0.0  => |     7.0.0-preview.4 =>      |     .NET 7 & NET 8      |


To use the icons in your MudBlazor project, you can add the following CSS link to your HTML or Razor layout:

```html
<link href="_content/MudBlazor.FontIcons.MaterialIcons/css/font.min.css" rel="stylesheet" />
```

Alternatively, you can use the following CDN links:

```html
<link href="https://fonts.googleapis.com/css2?family=Material+Icons" rel="stylesheet">
<link href="https://fonts.googleapis.com/css2?family=Material+Icons+Outlined" rel="stylesheet">
<link href="https://fonts.googleapis.com/css2?family=Material+Icons+Round" rel="stylesheet">
<link href="https://fonts.googleapis.com/css2?family=Material+Icons+Sharp" rel="stylesheet">
<link href="https://fonts.googleapis.com/css2?family=Material+Icons+Two+Tone" rel="stylesheet">
```

## Example Usage

To use an icon in your MudBlazor component, you can use the `<MudIcon>` component and specify the icon using the `Icon` parameter. For example:

```html
<MudIcon Icon="@MudBlazor.FontIcons.MaterialIcons.Outlined.Chat"></MudIcon>
```

This will render an icon representing a chat, using the Material Icons Outlined style.

## Using Aliases

If you prefer not to use the full qualifier every time, you can create an alias in `_Imports.razor` by adding the following line:

```razor
@using MaterialIcons = MudBlazor.FontIcons.MaterialIcons
```

This allows you to access the icons like this:

```html
<MudIcon Icon="@MaterialIcons.Outlined.Database"></MudIcon>
```

**NB!** Please note that aliases do not work in normal Razor pages (https://github.com/dotnet/razor/issues/7670)!
