using CloudyMobile.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHops.Maui.Services.Abstractions
{
    public interface IRecipeService
    {
        Task<int> AddRecipe(RecipeDto recipe);

        Task<RecipeDto> GetRecipe(int id);

        Task<BeerStylesVm> GetBeerStyles();

        Task<RecipeSearchResultsVm> SearchRecipes(string name, string style);
    }
}
