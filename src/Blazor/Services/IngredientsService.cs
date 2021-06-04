using System.Net.Http;
using System.Threading.Tasks;
using CloudyMobile.Client;

namespace CloudyMobile.Blazor.Services
{
    public class IngredientsService
    {
        private readonly IngredientsClient client;

        public IngredientsService(HttpClient httpClient)
        {
            client = new IngredientsClient(Constants.BaseUrl, httpClient);
        }

        public async Task<int> AddIngredient(IngredientDto ingredientDto)
        {
            return await client.CreateAsync(ingredientDto);
        }

        public async Task<IngredientsVm> GetAll()
        {
            return await client.GetAsync();
        }

        public async Task<IngredientsVm> Search(string searchTerm)
        {
            return await client.SearchAsync(searchTerm);
        }
    }
}