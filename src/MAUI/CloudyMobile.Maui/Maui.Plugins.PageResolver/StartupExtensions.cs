using Microsoft.Extensions.DependencyInjection;

namespace Maui.Plugins.PageResolver
{
    public static class StartupExtensions
    {
        public static void UsePageResolver(this IServiceCollection sc)
        {
            var sp = sc.BuildServiceProvider();
            Resolver.RegisterServiceProvider(sp);
        }
    }
}
