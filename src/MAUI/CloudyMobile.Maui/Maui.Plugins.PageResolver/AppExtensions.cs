using Microsoft.Maui.Controls;
using System;

namespace Maui.Plugins.PageResolver
{
    public static class AppExtensions
    {
        public static void UsePageResolver(this Application App, IServiceProvider sp)
        {
            Resolver.RegisterServiceProvider(sp);
        }
    }
}
