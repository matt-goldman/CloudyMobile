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

namespace CloudyMobile.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
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

            await builder.Build().RunAsync();
        }
    }
}
