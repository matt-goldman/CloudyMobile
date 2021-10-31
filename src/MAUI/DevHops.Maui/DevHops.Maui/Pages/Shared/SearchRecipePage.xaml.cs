using DevHops.Maui.ViewModels;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHops.Maui.Pages.Shared
{
    public partial class SearchRecipePage : ContentPage
    {
        public SearchRecipeViewModel ViewModel { get; set; }

        public SearchRecipePage(SearchRecipeViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            ViewModel.Navigation = Navigation;
            BindingContext = ViewModel;
        }
    }
}
