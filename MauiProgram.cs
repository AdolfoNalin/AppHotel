using Microsoft.Extensions.Logging;

namespace AppHotel
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Caveat-SemiBold.ttf", "CaveatSemiBold");
                    fonts.AddFont("Caveat-Regular.ttf", "CaveatRegular");
                    fonts.AddFont("Caveat-Medium.ttf", "CaveatMedium");
                    fonts.AddFont("Caveat-Bold.ttf", "CaveatBold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
