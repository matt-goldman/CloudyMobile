using CloudyMobile.Client;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System.Windows.Input;

namespace CloudyMobile.Maui.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeDetails
    {
        public static readonly BindableProperty RecipeProperty = BindableProperty.Create(nameof(Recipe), typeof(RecipeDto), typeof(RecipeDetails), null);

        public static readonly BindableProperty OkCommandProperty = BindableProperty.Create(nameof(OkCommand), typeof(ICommand), typeof(RecipeDetails), null);
        public static readonly BindableProperty CancelCommandProperty = BindableProperty.Create(nameof(CancelCommand), typeof(ICommand), typeof(RecipeDetails), null);
        public static readonly BindableProperty SelectedCommandProperty = BindableProperty.Create(nameof(SelectedCommand), typeof(ICommand), typeof(RecipeDetails), null);

        public static readonly BindableProperty IsViewOnlyModeProperty = BindableProperty.Create(nameof(IsViewOnlyMode), typeof(bool), typeof(RecipeDetails), null);

        public ICommand OkCommand
        {
            get => (ICommand?)GetValue(OkCommandProperty);
            set => SetValue(OkCommandProperty, value);
        }

        public ICommand CancelCommand
        {
            get => (ICommand?)GetValue(CancelCommandProperty);
            set => SetValue(CancelCommandProperty, value);
        }

        public ICommand SelectedCommand
        {
            get => (ICommand?)GetValue(SelectedCommandProperty);
            set => SetValue(SelectedCommandProperty, value);
        }

        public RecipeDto Recipe
        { 
            get { return (RecipeDto)GetValue(RecipeProperty); }
            set { SetValue(RecipeProperty, value); }
        }

        public bool IsViewOnlyMode
        {
            get => (bool)GetValue(IsViewOnlyModeProperty);
            set => SetValue(IsViewOnlyModeProperty, value);
        }

        public bool IsNotViewOnlyMode => !IsViewOnlyMode;

        public RecipeDetails()
        {
            InitializeComponent();
        }

        private void OkClicked(object sender, System.EventArgs e)
        {
            OkCommand?.Execute(null);
        }

        private void CancelClicked(object sender, System.EventArgs e)
        {
            CancelCommand?.CanExecute(null);
        }

        private void SelectClicked(object sender, System.EventArgs e)
        {
            SelectedCommand?.Execute(null);
        }
    }
}
