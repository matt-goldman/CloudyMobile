using System.Net.Http;
using System.Threading.Tasks;
using CloudyMobile.Client;

namespace CloudyMobile.Blazor.Services
{
    public class RecipesService
    {
        private readonly RecipesClient recipesClient;

        public RecipesService(HttpClient http)
        {
            recipesClient = new RecipesClient(Constants.BaseUrl, http);
        }

        public async Task<int> AddRecipe(RecipeDto recipe)
        {
            return await recipesClient.CreateAsync(recipe);
        }

        public async Task<RecipeDto> GetRecipe(int id)
        {
            return await recipesClient.GetAsync(id);
        }

        public async Task<BeerStylesVm> GetBeerStyles()
        {
            return await recipesClient.StylesAsync();
        }

        public async Task<RecipeSearchResultsVm> SearchRecipes(string name, string style)
        {
            var query = new SearchRecipeQuery
            {
                Name = name,
                Style = style
            };

            return await recipesClient.SearchAsync(query);
        }
    }
}