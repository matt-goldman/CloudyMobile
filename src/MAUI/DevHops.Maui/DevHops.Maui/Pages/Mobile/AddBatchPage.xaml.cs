using DevHops.Maui.ViewModels;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHops.Maui.Pages.Mobile
{
    public partial class AddBatchPage : ContentPage
    {
        public AddBatchViewModel ViewModel { get; set; }

        public AddBatchPage(AddBatchViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            ViewModel.Navigation = Navigation;
            BindingContext = ViewModel;
        }
    }
}
