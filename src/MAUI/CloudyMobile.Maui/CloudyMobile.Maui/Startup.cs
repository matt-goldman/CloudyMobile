using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Extensions.DependencyInjection;
using CloudyMobile.Maui.Services.Abstractions;
using CloudyMobile.Maui.Services.Concretions;
using IdentityModel.OidcClient.Browser;
using CloudyMobile.Maui.Helpers;

namespace CloudyMobile.Maui
{
    public class Startup : IStartup
    {
        public void Configure(IAppHostBuilder appBuilder)
        {
            appBuilder
                .UseFormsCompatibility()
                .UseMauiApp<App>()
                .UseMauiControlsHandlers()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IAuthService, AuthService>();
                    services.AddSingleton<IBrowser, AuthBrowser>();
                    services.AddSingleton<IBatchService, BatchesService>();
                    services.AddSingleton<RecipeService>();
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
        }
    }
}