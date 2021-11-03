using CloudyMobile.Client;
using DevHops.Maui.Services.Abstractions;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DevHops.Maui.ViewModels
{
    public class SearchRecipeViewModel : BaseViewModel
    {
        private readonly IRecipeService recipeService;
        private readonly IBatchService batchService;

        public ObservableCollection<RecipeDto> Results { get; set; } = new ObservableCollection<RecipeDto>();

        public string NameSearchTerm { get; set; }
        public string StyleSearchTerm { get; set; }

        public RecipeDto RecipeDetails { get; set; }

        public bool ShowRecipeDetails { get; set; } = false;

        public bool RecipeDetailsVisible { get; set; } = false;

        public ICommand SearchButtonCommand { get; set; }

        public ICommand ViewRecipeDetailsCommand { get; set; }

        public ICommand RecipeSelectedCommand { get; set; }

        public ICommand HideRecipeDetailsCommand { get; set; }

        public string ResultNames { get; set; }

        public SearchRecipeViewModel(IRecipeService recipeService, IBatchService batchService)
        {
            this.recipeService = recipeService;
            this.batchService = batchService;

            IsBusy = true;

            SearchButtonCommand = new Command(async () => await UpdateSearchResults());
            ViewRecipeDetailsCommand = new Command<RecipeDto>((recipe) => ViewRecipeDetails(recipe));
            HideRecipeDetailsCommand = new Command(() => { ShowRecipeDetails = false; OnPropertyChanged(nameof(ShowRecipeDetails)); });
            RecipeSelectedCommand = new Command(async () => await RecipeSelected());
        }

        public async Task UpdateSearchResults()
        {
            Console.WriteLine("Getting recipe search results");

            IsBusy = true;
            OnPropertyChanged(nameof(IsBusy));            

            try
            {
                Results.Clear();
                OnPropertyChanged(nameof(Results));
                var results = await recipeService.SearchRecipes(NameSearchTerm, StyleSearchTerm);

                foreach(var rescipe in results.Recipes)
                {
                    Results.Add(rescipe);
                    ResultNames += $"{rescipe.Name}, ";
                    Console.WriteLine($"Got recipe {rescipe.Name}");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Failed to get recipes");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Got {Results.Count} recipes");

            IsBusy = false;
            OnPropertyChanged(nameof(IsBusy));

            OnPropertyChanged(nameof(Results));
            OnPropertyChanged(nameof(ResultNames));
        }

        public void ViewRecipeDetails(RecipeDto recipe)
        {
            Console.WriteLine($"Recipe {recipe.Name} tapped");
            RecipeDetails = recipe;
            ShowRecipeDetails = true;
            RaisePropertyChanged(nameof(RecipeDetails), nameof(ShowRecipeDetails));
        }

        public async Task RecipeSelected()
        {
            batchService.SelectedRecipe = RecipeDetails;
            MessagingCenter.Send<object>(this, "RecipeSelected");
            await Navigation.PopAsync();
        }
    }
}
