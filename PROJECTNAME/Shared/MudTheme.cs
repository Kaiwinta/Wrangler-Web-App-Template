using MudBlazor;

namespace PROJECTNAME.Shared
{
    public static class AppTheme
    {
        private static readonly string[] DefaultFontFamily = { "Roboto", "Helvetica", "Arial", "sans-serif" };

        public static MudTheme Theme = new MudTheme()
        {
            PaletteLight = new PaletteLight
            {
                Primary = Colors.Blue.Darken2,
                Secondary = Colors.Orange.Default,
                Background = Colors.Blue.Lighten5,
                AppbarBackground = Colors.Blue.Darken3,
                AppbarText = Colors.Shades.White,
                TextPrimary = Colors.BlueGray.Darken4,
                ActionDefault = Colors.Blue.Darken2,
            },
            PaletteDark = new PaletteDark
            {
                Primary = Colors.Blue.Lighten2,
                Secondary = Colors.Orange.Lighten2,
                Background = Colors.BlueGray.Darken4,
                AppbarBackground = Colors.Blue.Darken4,
                AppbarText = Colors.Shades.White,
                TextPrimary = Colors.Shades.White,
                ActionDefault = Colors.Blue.Lighten2,
            },
            Typography = new Typography()
            {
                H1 = new H1Typography()
                {
                    FontFamily = DefaultFontFamily,
                    FontSize = "clamp(2rem, 8vw, 4rem)",
                    FontWeight = "1000",
                    LineHeight = "1.6",
                    LetterSpacing = ".0075em"
                },
                H2 = new H2Typography()
                {
                    FontFamily = DefaultFontFamily,
                    FontSize = "clamp(1.5rem, 6vw, 3rem)",
                    FontWeight = "700",
                    LineHeight = "1.5"
                },
                H3 = new H3Typography()
                {
                    FontFamily = DefaultFontFamily,
                    FontSize = "clamp(1.2rem, 5vw, 2.5rem)",
                    FontWeight = "600",
                    LineHeight = "1.5"
                },
                Body1 = new Body1Typography()
                {
                    FontFamily = DefaultFontFamily,
                    FontSize = "1rem",
                    FontWeight = "400",
                    LineHeight = "1.6",
                    LetterSpacing = "0.00938em"
                },
                Body2 = new Body2Typography()
                {
                    FontFamily = DefaultFontFamily,
                    FontSize = "0.875rem",
                    FontWeight = "400",
                    LineHeight = "1.6"
                }
            }
        };
    }
}