using CloudyMobile.Maui.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace CloudyMobile.Maui.Pages.Phone
{
    public partial class AddBatchPage : ContentPage, IPage
    {
        public AddBatchViewModel ViewModel { get; set; }

        public AddBatchPage(AddBatchViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            //ViewModel = ViewModelResolver.Resolve<AddBatchViewModel>();
            ViewModel.Navigation = Navigation;
            BindingContext = ViewModel;
        }
    }
}
