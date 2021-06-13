using CloudyMobile.Maui.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace CloudyMobile.Maui
{
    public partial class MainPage : ContentPage, IPage
	{
        public MainViewModel ViewModel { get; set; }

		public MainPage()
		{
			InitializeComponent();
			ViewModel = ViewModelResolver.Resolve<MainViewModel>();
			ViewModel.Navigation = Navigation;
			BindingContext = ViewModel;
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
			await ViewModel.CheckAuthStatus();
        }
    }
}
