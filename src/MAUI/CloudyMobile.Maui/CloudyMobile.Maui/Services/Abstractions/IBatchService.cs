using CloudyMobile.Client;
using System.Threading.Tasks;

namespace CloudyMobile.Maui.Services.Abstractions
{
    public interface IBatchService
    {
        RecipeDto SelectedRecipe { get; set; }
        Task<int> CreateBatch(BatchDto batch);

        Task<BatchListVm> GetAll();

        Task<int> SampleBatch(SampleDto sample);

        Task<BatchDto> GetBatch(int id);

        Task<BatchListVm> Search(SearchBatchQuery query);

        Task<int> RateBatch(AddBatchRatingCommand command);

        Task<int> AddHops(AddBatchHopAdditionCommand command);
    }
}
