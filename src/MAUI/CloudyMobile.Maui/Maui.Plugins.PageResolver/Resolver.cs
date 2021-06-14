using Microsoft.Extensions.DependencyInjection;
using System;

namespace Maui.Plugins.PageResolver
{
    public static class Resolver
    {
        private static IServiceScope scope;

        public static void RegisterServiceProvider(IServiceProvider sp)
        {
            scope = sp.CreateScope();
        }

        public static T Resolve<T>() where T : class
        {
            var result = scope.ServiceProvider.GetService<T>();

            return result;
        }
    }
}
