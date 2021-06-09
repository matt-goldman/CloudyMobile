using CloudyMobile.Client;

namespace CloudyMobile.Maui.Services
{
    public class RecipeService : BaseService
    {
        private RecipesClient recipesClient;

        public RecipeService()
        {
            this.recipesClient = new RecipesClient(httpClient);
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