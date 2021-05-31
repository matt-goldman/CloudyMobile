using CloudyMobile.Application.Recipes.Common;
using System.Collections.Generic;

namespace CloudyMobile.Application.Recipes.Queries.SearchRecipes
{
    public class RecipeSearchResultsVm
    {
        public IList<RecipeDto> Recipes { get; set; }

        public RecipeSearchResultsVm()
        {
            Recipes = new List<RecipeDto>();
        }
    }
}
