using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace Maui.Plugins.PageResolver
{
    public static class NavigationExtensions
    {
        public static async Task PushAsync<T>(this INavigation navigation) where T: ContentPage
        {
            var resolvedPage = Resolver.Resolve<T>();

            await navigation.PushAsync(resolvedPage);
        }
    }
}
