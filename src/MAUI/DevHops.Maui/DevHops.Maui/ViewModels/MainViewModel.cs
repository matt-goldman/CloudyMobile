using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DevHops.Maui.Services.Abstractions;
using Maui.Plugins.PageResolver;

namespace DevHops.Maui.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IAuthService authService;

        public ICommand ViewRecipesCommand { get; set; }
        public ICommand AddBatchCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand AddSampleCommand { get; set; }

        public string ErrorMessage { get; set; }

        public string StackTrace { get; set; }

        public MainViewModel(IAuthService authService)
        {
            this.authService = authService;
            AddBatchCommand = new Command(async () => await OpenAddBatchPage());
            LoginCommand = new Command(async () => await Login());
            AddSampleCommand = new Command(async () => await OpenAddSamplePage());
        }

        public async Task CheckAuthStatus()
        {
            try
            {
                var token = await SecureStorage.GetAsync(nameof(App.Constants.AccessToken));

                if (string.IsNullOrEmpty(token))
                {
                    var loggedIn = await authService.Authenticate();

                    if (!loggedIn)
                    {
                        ErrorMessage = "Not logged in";
                        RaisePropertyChanged(nameof(ErrorMessage));
                        await App.Current.MainPage.DisplayAlert("Login Failed", "There was a problem logging in. Please try again later.", "Ok");
                    }
                }
            }
            catch (System.Exception ex)
            {
                ErrorMessage = ex.Message;
                RaisePropertyChanged(nameof(ErrorMessage));
            }
        }

        public async Task OpenAddBatchPage()
        {
            await Navigation.PushAsync<AddBatchPage>();
        }

        public async Task OpenAddSamplePage()
        {
            await Navigation.PushAsync<AddSamplePage>();
        }

        public async Task Login()
        {
            ErrorMessage = "Trying to log in...";
            RaisePropertyChanged(nameof(ErrorMessage));
            try
            {
                await authService.Authenticate();
            }
            catch (System.Exception ex)
            {
                ErrorMessage = ex.Message;
                RaisePropertyChanged(nameof(ErrorMessage));
            }
        }
    }
}
