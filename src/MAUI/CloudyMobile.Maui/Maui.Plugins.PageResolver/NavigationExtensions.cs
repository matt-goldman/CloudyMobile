using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using System;

namespace Maui.Plugins.PageResolver
{
    public static class NavigationExtensions
    {
        public static async Task PushAsync<T>(this INavigation navigation) where T: ContentPage
        {
            var resolvedPage = Resolver.Resolve<T>();

            if(resolvedPage is null)
            {
                Console.WriteLine("Resolved page is null");
            }
            else
            {
                Console.WriteLine("Resolved page is NOT null");
                Console.WriteLine("Got page:");
                Console.WriteLine(resolvedPage.GetType().ToString());
            }

            await navigation.PushAsync(resolvedPage);
        }
    }
}
