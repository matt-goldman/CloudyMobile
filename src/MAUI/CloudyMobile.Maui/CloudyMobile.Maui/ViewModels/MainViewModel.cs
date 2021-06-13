using CloudyMobile.Maui.Pages.Phone;
using CloudyMobile.Maui.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CloudyMobile.Maui.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly AuthService authService;

        public ICommand ViewRecipesCommand { get; set; }
        public ICommand AddBatchCommand { get; set; }

        public MainViewModel(AuthService authService)
        {
            this.authService = authService;
            AddBatchCommand = new Command(async () => await OpenAddBatchPage());
        }

        public async Task CheckAuthStatus()
        {
            var token = await SecureStorage.GetAsync(nameof(App.Constants.AccessToken));

            if (string.IsNullOrEmpty(token))
            {
                var loggedIn = await authService.Authenticate();

                if (!loggedIn)
                {
                    await App.Current.MainPage.DisplayAlert("Login Failed", "There was a problem logging in. Please try again later.", "Ok");
                }
            }
        }

        public async Task OpenAddBatchPage()
        {
            await Navigation.PushAsync(new AddBatchPage());
        }
    }
}
