using CloudyMobile.Maui.Helpers;
using CloudyMobile.Maui.Services;
using IdentityModel.OidcClient.Browser;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Essentials;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;

namespace CloudyMobile.Maui
{
	public class Startup : IStartup
	{
		public void Configure(IAppHostBuilder appBuilder)
		{
			appBuilder
				.UseFormsCompatibility()
				.UseMauiApp<App>()
				.ConfigureServices(services => 
				{
					services.AddTransient<IBrowser, AuthBrowser>();
				})
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});
		}
	}
}