using CloudyMobile.Client;
using CloudyMobile.Maui.Services.Abstractions;
using CloudyMobile.Maui.Services.Concretions;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Internals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CloudyMobile.Maui.ViewModels
{
    public class SearchRecipeViewModel : BaseViewModel
    {
        private readonly RecipeService recipeService;
        private readonly IBatchService batchService;

        public string NameSearchTerm { get; set; }
        public string StyleSearchTerm { get; set; }

        public List<RecipeDto> Results { get; set; } = new List<RecipeDto>();

        public RecipeDto RecipeDetails { get; set; }

        public bool ShowRecipeDetails { get; set; }// = false;

        public bool RecipeDetailsVisible { get; set; }// = false;

        public bool GotResults { get; set; }// = false;

        public ICommand SearchButtonCommand { get; set; }

        public ICommand ViewRecipeDetailsCommand { get; set; }

        public ICommand RecipeSelectedCommand { get; set; }

        public ICommand HideRecipeDetailsCommand { get; set; }

        private bool loadingRecipes = true;
        public bool LoadingRecipes
        {
            get => loadingRecipes;
            set
            {
                SetProperty(ref loadingRecipes, value);
            }
        }


        #region PendingCollectionView

        public RecipeDto? FirstResult { get; set; }
        public string FirstResultName => FirstResult?.Name;

        public RecipeDto? SecondResult { get; set; }
        public string SecondResultName => SecondResult?.Name;

        public RecipeDto? ThirdResult { get; set; }
        public string ThirdResultName => ThirdResult?.Name;

        private bool firstRecipeVisible = true;
        private bool secondRecipeVisible = true;
        private bool thirdRecipeVisible = true;

        public bool FirstResultVisible
        {
            get => firstRecipeVisible;
            set => SetProperty(ref firstRecipeVisible, value);
        }

        public bool SecondResultVisible
        {
            get => secondRecipeVisible;
            set => SetProperty(ref secondRecipeVisible, value);
        }

        public bool ThirdResultVisible
        {
            get => thirdRecipeVisible;
            set => SetProperty(ref thirdRecipeVisible, value);
        }

        #endregion

        public SearchRecipeViewModel(RecipeService recipeService, IBatchService batchService)
        {
            try
            {
                this.recipeService = recipeService;
                this.batchService = batchService;
                SearchButtonCommand = new Command(async () => await UpdateSearchResults());
                ViewRecipeDetailsCommand = new Command<RecipeDto>((recipe) => ViewRecipeDetails(recipe));
                HideRecipeDetailsCommand = new Command(() => { ShowRecipeDetails = false; OnPropertyChanged(nameof(ShowRecipeDetails)); });
                RecipeSelectedCommand = new Command(async () => await RecipeSelected());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Init()
        {
            LoadingRecipes = false;
            FirstResultVisible = false;
            SecondResultVisible = false;
            ThirdResultVisible = false;
        }

        public async Task UpdateSearchResults()
        {
            Console.WriteLine("Getting recipe search results");

            LoadingRecipes = true;
            //OnPropertyChanged(nameof(IsBusy));

            MessagingCenter.Send<object>(this, "ForceViewUpdate");

            try
            {
                Results.Clear();
                OnPropertyChanged(nameof(Results));
                var results = await recipeService.SearchRecipes(NameSearchTerm, StyleSearchTerm);

                results.Recipes.ForEach(recipe => Results.Add(recipe));

                GotResults = true;

                if (Results.Count > 0 && Results[0] is not null)
                {
                    FirstResult = Results[0];
                    FirstResultVisible = true;
                }
                else
                {
                    FirstResultVisible = false;
                }

                if (Results.Count > 1 && Results[1] is not null)
                {
                    SecondResult = Results[0];
                    SecondResultVisible = true;
                }
                else
                { 
                    SecondResult = null;
                    SecondResultVisible = false;
                }

                if (Results.Count > 2 && Results[2] is not null)
                {
                    ThirdResult = Results[0];
                    ThirdResultVisible = true;
                }
                else
                {
                    ThirdResult = null;
                    ThirdResultVisible = false;
                }

                RaisePropertyChanged(
                    nameof(FirstResult),
                    nameof(FirstResultName),
                    nameof(FirstResultVisible),
                    nameof(SecondResult),
                    nameof(SecondResultName),
                    nameof(SecondResultVisible),
                    nameof(ThirdResult),
                    nameof(ThirdResultName),
                    nameof(ThirdResultVisible));

                Console.WriteLine($"First result: {FirstResultName}, is visible: {FirstResultVisible}");
                Console.WriteLine($"Second result: {SecondResultName}, is visible: {SecondResultVisible}");
                Console.WriteLine($"Third result: {ThirdResultName}, is visible: {ThirdResultVisible}");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Failed to get recipes");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Got {Results.Count} recipes");

            LoadingRecipes = false;
            //OnPropertyChanged(nameof(IsBusy));

            OnPropertyChanged(nameof(Results));
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