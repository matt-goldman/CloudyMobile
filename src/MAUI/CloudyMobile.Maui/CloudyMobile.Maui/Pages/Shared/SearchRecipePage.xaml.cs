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

            MessagingCenter.Subscribe<object>(this, "ShowLabel", (obj) => ShowLabel());

            RecipesLabel.IsVisible = false;
        }

        public void ShowLabel()
        {
            Console.WriteLine("Attempting to show label");
            RecipesLabel.IsVisible = true;
        }
    }
}
