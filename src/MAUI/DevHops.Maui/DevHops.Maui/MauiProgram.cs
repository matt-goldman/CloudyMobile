using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Extensions.DependencyInjection;
using IdentityModel.OidcClient.Browser;
using DevHops.Maui.Helpers;
using DevHops.Maui.Services.Abstractions;
using DevHops.Maui.Services.Concretions;
using DevHops.Maui.ViewModels;
using DevHops.Maui.Pages.Mobile;
using DevHops.Maui.Pages.Shared;
using Maui.Plugins.PageResolver;

namespace DevHops.Maui
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
				});

			// register services
			builder.Services.AddSingleton<IBrowser, AuthBrowser>();
			builder.Services.AddSingleton<RetryHandler>();
			builder.Services.AddSingleton<IAuthService, AuthService>();
			builder.Services.AddSingleton<IBatchService, BatchService>();
			builder.Services.AddSingleton<IRecipeService, RecipesService>();
			builder.Services.AddSingleton<BaseService>();

			// register viewmodels
			builder.Services.AddTransient<AddBatchViewModel>();
			builder.Services.AddTransient<BatchesViewModel>();
			builder.Services.AddTransient<MainViewModel>();
			builder.Services.AddTransient<RecipeViewModel>();
			builder.Services.AddTransient<SearchRecipeViewModel>();
			builder.Services.AddTransient<AddSampleViewModel>();
			builder.Services.AddTransient<MainViewModel>();

			// register pages
			builder.Services.AddTransient<AddBatchPage>();
			builder.Services.AddTransient<RecipeDetailPage>();
			builder.Services.AddTransient<SearchRecipePage>();
			builder.Services.AddTransient<AddSamplePage>();
			builder.Services.AddTransient<MainPage>();

			// register PageResolver
			builder.Services.UsePageResolver();

			return builder.Build();
		}
	}
}