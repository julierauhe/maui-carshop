using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using FEDeksamenMaui.Data;

namespace FEDeksamenMaui
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
                });

            ConfigureServices(builder.Services);

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            //add Database as Singleton
            services.AddSingleton<IDatabase, Database>();
        }
    }
}
