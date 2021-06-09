using CloudyMobile.Client;
using System.Threading.Tasks;

namespace CloudyMobile.Maui.Services
{
    public class BatchesService : BaseService
    {
        private BatchesClient batchesClient;

        public BatchesService()
        {
            batchesClient = new BatchesClient(apiUri, httpClient);
        }

        public async Task<int> CreateBatch(BatchDto batch)
        {
            return await batchesClient.CreateAsync(batch);
        }

        public async Task<BatchListVm> GetAll()
        {
            return await batchesClient.GetAsync();
        }

        public async Task<int> SampleBatch(SampleDto sample)
        {
            return await batchesClient.SampleAsync(sample);
        }

        public async Task<BatchDto> GetBatch(int id)
        {
            return await batchesClient.Get2Async(id);
        }

        public async Task<BatchListVm> Search(SearchBatchQuery query)
        {
            return await batchesClient.SearchAsync(query);
        }

        public async Task<int> RateBatch(AddBatchRatingCommand command)
        {
            return await batchesClient.RateAsync(command);
        }

        public async Task<int> AddHops(AddBatchHopAdditionCommand command)
        {
            return await batchesClient.AddHopsAsync(command);
        }
    }
}