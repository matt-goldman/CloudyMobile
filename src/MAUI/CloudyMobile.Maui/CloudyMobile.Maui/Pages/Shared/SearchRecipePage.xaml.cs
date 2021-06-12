using CloudyMobile.Maui.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace CloudyMobile.Maui.Pages.Shared
{
    public partial class SearchRecipePage : ContentPage, IPage
	{
        public SearchRecipeViewModel ViewModel { get; set; }

        public SearchRecipePage()
		{
			InitializeComponent();
			ViewModel = ViewModelResolver.Resolve<SearchRecipeViewModel>();
			ViewModel.Navigation = Navigation;
			BindingContext = ViewModel;
		}

        private void RecipeDetails_Dismissed(object sender, System.EventArgs e)
        {

        }
    }
}
