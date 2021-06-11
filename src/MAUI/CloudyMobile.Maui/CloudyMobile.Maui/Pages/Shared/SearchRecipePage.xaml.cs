using System;
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

		int count = 0;
		private void OnCounterClicked(object sender, EventArgs e)
		{
			count++;
			CounterLabel.Text = $"Current count: {count}";
		}
	}
}
