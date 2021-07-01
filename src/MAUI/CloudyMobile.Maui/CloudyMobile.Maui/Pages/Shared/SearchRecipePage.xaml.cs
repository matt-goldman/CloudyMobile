using CloudyMobile.Maui.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;

namespace CloudyMobile.Maui.Pages.Shared
{
    public partial class SearchRecipePage : ContentPage, IPage
    {
        public SearchRecipeViewModel ViewModel { get; set; }

        public SearchRecipePage(SearchRecipeViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            ViewModel.Navigation = Navigation;
            BindingContext = ViewModel;

            MessagingCenter.Subscribe<object>(this, "ForceViewUpdate", (obj) => ForceViewUpdate());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.Init();
        }

        private void ForceViewUpdate()
        {
            SearchNameEntry.Focus();
            SearchNameEntry.Unfocus();
        }
    }
}
