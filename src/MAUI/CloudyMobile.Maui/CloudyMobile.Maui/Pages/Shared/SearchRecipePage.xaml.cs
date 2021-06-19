using CloudyMobile.Maui.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace CloudyMobile.Maui.Pages.Shared
{
    public partial class SearchRecipePage : ContentPage, IPage
    {
        public SearchRecipeViewModel ViewModel { get; set; }

        public SearchRecipePage(SearchRecipeViewModel viewModel)
        {
            InitializeComponent();
            //ViewModel = ViewModelResolver.Resolve<SearchRecipeViewModel>();
            ViewModel = viewModel;
            ViewModel.Navigation = Navigation;
            BindingContext = ViewModel;
        }
    }
}
