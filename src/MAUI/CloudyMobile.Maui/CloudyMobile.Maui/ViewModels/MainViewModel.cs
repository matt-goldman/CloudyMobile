using CloudyMobile.Maui.Pages.Phone;
using CloudyMobile.Maui.Pages.Shared;
using CloudyMobile.Maui.Pages;
using CloudyMobile.Maui.Services.Abstractions;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Maui.Plugins.PageResolver;

namespace CloudyMobile.Maui.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IAuthService authService;

        public ICommand ViewRecipesCommand { get; set; }
        public ICommand AddBatchCommand { get; set; }

        public ICommand ScratchCommand { get; set; }

        public MainViewModel(IAuthService authService)
        {
            Console.WriteLine("Main viewmodel constructed");
            this.authService = authService;
            AddBatchCommand = new Command(async () => await OpenAddBatchPage());
            ViewRecipesCommand = new Command(async () => await Navigation.PushAsync(new SearchRecipePage()));
            ScratchCommand = new Command(async () => await Navigation.PushAsync(new Scratch()));
        }

        public async Task CheckAuthStatus()
        {
            Console.WriteLine("Checking auth status");
            var token = await SecureStorage.GetAsync(nameof(App.Constants.AccessToken));
            Console.WriteLine("Got token from secure storage");
            if (string.IsNullOrEmpty(token))
            {
                Console.WriteLine("Not logged in - token is empty")
;
                var loggedIn = await authService.Authenticate();

                Console.WriteLine("Called login service successfully");
                if (!loggedIn)
                {
                    await App.Current.MainPage.DisplayAlert("Login Failed", "There was a problem logging in. Please try again later.", "Ok");
                }
            }
        }

        public async Task OpenAddBatchPage()
        {
            await Navigation.PushAsync<AddBatchPage>();
        }
    }
}
