using System;
using CloudyMobile.Maui.ViewModels;
using Maui.Plugins.PageResolver;
using Microsoft.Maui.Controls;

namespace CloudyMobile.Maui
{
	public partial class MainPage : ContentPage
	{
        public MainViewModel ViewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();
            ViewModel = Resolver.Resolve<MainViewModel>();
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
