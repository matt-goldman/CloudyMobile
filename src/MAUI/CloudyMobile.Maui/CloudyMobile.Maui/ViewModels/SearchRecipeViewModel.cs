using CloudyMobile.Client;
using CloudyMobile.Maui.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Internals;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CloudyMobile.Maui.ViewModels
{
    public  class SearchRecipeViewModel : BaseViewModel
    {
        private readonly RecipeService recipeService;

        public string NameSearchTerm { get; set; }
        public string StyleSearchTerm { get; set; }

        public ObservableCollection<RecipeDto> Results { get; set; } = new ObservableCollection<RecipeDto>();

        public RecipeDto RecipeDetails { get; set; }

        public bool ShowRecipeDetails { get; set; } = false;

        public bool RecipeDetailsVisible { get; set; } = false;


        public ICommand SearchButtonCommand { get; set; }

        public ICommand ViewRecipeDetailsCommand { get; set; }

        public ICommand RecipeSelectedCommand { get; set; }

        public ICommand HideRecipeDetailsCommand { get; set; }

        public SearchRecipeViewModel(RecipeService recipeService)
        {
            this.recipeService = recipeService;
            SearchButtonCommand = new Command(async () => await UpdateSearchResults());
            ViewRecipeDetailsCommand = new Command<RecipeDto>((recipe) => ViewRecipeDetails(recipe));
            HideRecipeDetailsCommand = new Command(() => { ShowRecipeDetails = false; RaisePropertyChanged(nameof(ShowRecipeDetails)); });
        }

        public async Task UpdateSearchResults()
        {
            Results.Clear();
            var results = await recipeService.SearchRecipes(NameSearchTerm, StyleSearchTerm);

            results.Recipes.ForEach(recipe => Results.Add(recipe));
        }

        public void ViewRecipeDetails(RecipeDto recipe)
        {
            RecipeDetails = recipe;
            ShowRecipeDetails = true;
            RaisePropertyChanged(nameof(RecipeDetails), nameof(ShowRecipeDetails));
        }

        public async Task RecipeSelected()
        {
            MessagingCenter.Send<object, int>(this, "RecipeSelected", RecipeDetails.Id);
            await Navigation.PopModalAsync();
        }
    }
}