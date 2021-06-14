using CloudyMobile.Client;
using CloudyMobile.Maui.Services.Abstractions;
using System;
using System.Threading.Tasks;

namespace CloudyMobile.Maui.Services.Concretions
{
    public class BatchesService : BaseService, IBatchService
    {
        private BatchesClient batchesClient;

        public BatchesService() : base()
        {
            Console.WriteLine("Batch service constructor called");
            batchesClient = new BatchesClient(apiUri, httpClient);
            Console.WriteLine("Batch client initialised, batch service constructed");
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