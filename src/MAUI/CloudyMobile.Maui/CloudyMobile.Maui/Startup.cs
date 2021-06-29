using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Extensions.DependencyInjection;
using CloudyMobile.Maui.Helpers;
using CloudyMobile.Maui.Services.Abstractions;
using CloudyMobile.Maui.Services.Concretions;
using CloudyMobile.Maui.ViewModels;
using CloudyMobile.Maui.Pages.Phone;
using CloudyMobile.Maui.Pages.Shared;
using Maui.Plugins.PageResolver;
using IdentityModel.OidcClient.Browser;

namespace CloudyMobile.Maui
{
	public class Startup : IStartup
	{
		public void Configure(IAppHostBuilder appBuilder)
		{
			appBuilder
				.UseMauiApp<App>()
				.ConfigureServices(services =>
                {
					// register services
					services.AddSingleton<IBrowser, AuthBrowser>();
					services.AddSingleton<RetryHandler>();
					services.AddSingleton<IAuthService, AuthService>();
					services.AddSingleton<IBatchService, BatchService>();
					services.AddSingleton<RecipeService>();
					services.AddSingleton<BaseService>();

					// register viewmodels
					services.AddTransient<AddBatchViewModel>();
					services.AddTransient<BatchesViewModel>();
					services.AddTransient<MainViewModel>();
					services.AddTransient<RecipesViewModel>();
					services.AddTransient<SearchRecipeViewModel>();
					services.AddTransient<AddSampleViewModel>();

					// register pages
					services.AddTransient<AddBatchPage>();
					services.AddTransient<RecipeDetailPage>();
					services.AddTransient<SearchRecipePage>();
					services.AddTransient<AddSamplePage>();

					// register PageResolver
					services.UsePageResolver();
                })
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});
		}
	}
}