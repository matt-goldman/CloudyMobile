using CloudyMobile.Client;
using DevHops.Maui.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHops.Maui.Services.Concretions
{
    public class RecipesService : BaseService, IRecipeService
    {
        private RecipesClient recipesClient;

        public RecipesService()
        {
            recipesClient = new RecipesClient(apiUri, httpClient);
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
