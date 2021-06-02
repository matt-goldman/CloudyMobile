using CloudyMobile.Client;

namespace CloudyMobile.Blazor.Services
{
    public class RecipesService
    {
        private readonly HttpClient http;

        private readonly RecipesClient recipesClient;

        public RecipesService(HttpClient http)
        {
            this.http = http;

            recipesClient = new RecipesClient(http);
        }

        public async Task<int> AddRecipe()
        {
            
        }
    }
}