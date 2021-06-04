using Blazorise;
using Blazorise.AntDesign;
using Blazorise.Icons.FontAwesome;
using CloudyMobile.Blazor.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Syncfusion.Blazor;

namespace CloudyMobile.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDU1MDU1QDMxMzkyZTMxMmUzMFpyUzRmVnBIeFc3TzR4aXZGeURaU05ndnROTDBQYldyb2R2eStVRE92ajA9;NDU1MDU2QDMxMzkyZTMxMmUzMFM2WHBBNFBibS85ajQyQXhBWXVjQTZpa2VLdzVIZEc0VzZ2VVRKdEM4eXc9");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            Constants.BaseUrl = builder.HostEnvironment.BaseAddress;

            builder.Services.AddBlazorise(opt => 
            {
                opt.ChangeTextOnKeyPress = false;
            })
            .AddAntDesignProviders()
            .AddFontAwesomeIcons();
            
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("CloudyMobile.API", client => client.BaseAddress = new Uri(Constants.BaseUrl))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CloudyMobile.API"));

            builder.Services.AddTransient<RecipesService>();

            builder.Services.AddApiAuthorization();

            builder.Services.AddSyncfusionBlazor();

            await builder.Build().RunAsync();
        }
    }
}
