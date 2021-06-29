using CloudyMobile.Maui.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace CloudyMobile.Maui.Pages.Phone
{
    public partial class AddSamplePage : ContentPage, IPage
    {
        public AddBatchViewModel ViewModel { get; set; }

        public AddSamplePage(AddBatchViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            ViewModel.Navigation = Navigation;
            BindingContext = ViewModel;
        }
    }
}
