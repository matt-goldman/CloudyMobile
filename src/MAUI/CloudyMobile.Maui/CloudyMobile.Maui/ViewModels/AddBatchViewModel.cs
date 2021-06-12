using CloudyMobile.Client;
using CloudyMobile.Maui.Pages.Shared;
using CloudyMobile.Maui.Services;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CloudyMobile.Maui.ViewModels
{
    public class AddBatchViewModel : BaseViewModel
    {
        private readonly BatchesService batchesService;

        private BatchDto _batch { get; set; } = new BatchDto
        {
            HopAdditions = new List<HopAdditionDto>(),
            Samples = new List<SampleDto>()
        };

        public int RecipeId => _batch.RecipeId;
        public string RecipeName => _batch.RecipeName;
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


        public AddBatchViewModel(BatchesService batchesService)
        {
            this.batchesService = batchesService;

            MessagingCenter.Subscribe<object, int>(this, "RecipeSelected", (sender, recipeId) => SetRecipeId(recipeId));

            FindRecipeCommand = new Command(async () => await Navigation.PushModalAsync(new SearchRecipePage()));

            AddBatchCommand = new Command(async () => await SaveBatch());
        }

        private void SetRecipeId(int id)
        {
            _batch.RecipeId = id;
        }

        public async Task SaveBatch()
        {
            await batchesService.CreateBatch(_batch);
            await Navigation.PopAsync();
        }
    }
}
