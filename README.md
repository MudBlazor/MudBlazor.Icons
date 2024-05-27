# MudBlazor Material Symbols Icons

To use the icons in your MudBlazor project, you can add the following CSS link to your HTML or Razor layout:

```html
<link href="_content/MudBlazor.Icons.MaterialSymbols/css/font.min.css" rel="stylesheet" />
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
<MudIcon Icon="material-symbols-outlined/database"></MudIcon>
```

This will render an icon representing a database, using the Material Symbols Outlined style.