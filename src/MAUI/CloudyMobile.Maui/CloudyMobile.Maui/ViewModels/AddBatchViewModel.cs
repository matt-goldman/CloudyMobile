using CloudyMobile.Client;
using CloudyMobile.Maui.Pages.Shared;
using CloudyMobile.Maui.Services.Abstractions;
using Maui.Plugins.PageResolver;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CloudyMobile.Maui.ViewModels
{
    public class AddBatchViewModel : BaseViewModel
    {
        private readonly IBatchService batchesService;

        private BatchDto _batch { get; set; } = new BatchDto
        {
            HopAdditions = new List<HopAdditionDto>(),
            Samples = new List<SampleDto>()
        };

        public int RecipeId => _batch.RecipeId;
        private string recipeName;
        public string RecipeName
        {
            get => recipeName;
            set => SetProperty(ref recipeName, value);
        }

        public DateTimeOffset BrewDay => _batch.BrewDay;
        public DateTimeOffset? BottleOrKegDate => _batch.BottleOrKegDate;
        public long PitchTemp => _batch.PitchTemp;
        public float Og => _batch.Og;
        public float? Fg => _batch.Og;
        public decimal? BrewQuantity => _batch.BrewQuantity;
        public ICollection<HopAdditionDto> HopAdditions => _batch.HopAdditions;
        public string Notes => _batch.Notes;
        public DateTimeOffset? ServingDate => _batch.ServingDate;
        public ICollection<SampleDto> Samples => _batch.Samples;
        public double? AverageRating => _batch.AverageRating;


        public ICommand AddBatchCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand FindRecipeCommand { get; set; }

        public string ErrorMessage { get; set; }

        public AddBatchViewModel(IBatchService batchService)
        {
            Title = "Add a sample";

            this.batchesService = batchService;

            MessagingCenter.Subscribe<object>(this, "RecipeSelected", (sender) => SetRecipeId());

            FindRecipeCommand = new Command(async () => await FindRecipe());

            AddBatchCommand = new Command(async () => await SaveBatch());

            _batch.BrewDay = DateTime.Now;
        }

        private void SetRecipeId()
        {
            _batch.RecipeId = batchesService.SelectedRecipe.Id;
            RecipeName = batchesService.SelectedRecipe.Name;
            ErrorMessage = string.Empty;
            RaisePropertyChanged(nameof(ErrorMessage));
        }

        public async Task SaveBatch()
        {
            await batchesService.CreateBatch(_batch);
            await Navigation.PopAsync();
        }

        public async Task FindRecipe()
        {
            ErrorMessage = "Finding recipe...";
            RaisePropertyChanged(nameof(ErrorMessage));

            try
            {
                await Navigation.PushAsync<SearchRecipePage>();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                RaisePropertyChanged(nameof(ErrorMessage));
            }
        }
    }
}
