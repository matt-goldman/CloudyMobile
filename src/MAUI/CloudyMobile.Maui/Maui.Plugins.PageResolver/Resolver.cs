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

            if (scope is null)
            {
                Console.WriteLine("Scope is null");
            }
            else
            {
                Console.WriteLine("Scope is NOT null");

                Console.WriteLine(scope.ServiceProvider.ToString());
            }
        }

        public static T Resolve<T>() where T : class
        {
            Console.WriteLine($"Type to resolve is: {typeof(T)}");

            var result = scope.ServiceProvider.GetService<T>();

            if(result is null)
            {
                Console.WriteLine("Result is null");
            }
            else
            {
                Console.WriteLine("Result is NOT null. Resolved:");
                Console.WriteLine(result.GetType().ToString());
            }

            return result;
        }
    }
}
