using CloudyMobile.Maui.Helpers;
using IdentityModel.OidcClient.Browser;
using TinyIoC;
using CloudyMobile.Maui.Services.Concretions;
using CloudyMobile.Maui.Services.Abstractions;

namespace CloudyMobile.Maui.ViewModels
{
    public static class ViewModelResolver
    {
        private static TinyIoCContainer _container;

        public static bool UseMockService { get; set; }

        static ViewModelResolver()
        {
            _container = new TinyIoCContainer();

            // View models - by default, TinyIoC will register concrete classes as multi-instance.
            _container.Register<BatchesViewModel>();
            _container.Register<RecipesViewModel>();
            _container.Register<AddBatchViewModel>();

            // Services - by default, TinyIoC will register interface registrations as singletons.
            _container.Register<IBrowser, AuthBrowser>();
            _container.Register<AuthService>().AsSingleton();
            _container.Register<IBatchService, BatchesService>();
            _container.Register<RecipeService>().AsSingleton();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }
    }
}
