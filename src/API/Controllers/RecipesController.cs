using CloudyMobile.Application.Recipes.Commands.AddRecipe;
using CloudyMobile.Application.Recipes.Common;
using CloudyMobile.Application.Recipes.Queries.GetBeerStyles;
using CloudyMobile.Application.Recipes.Queries.GetRecipe;
using CloudyMobile.Application.Recipes.Queries.SearchRecipes;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CloudyMobile.API.Controllers
{
    public class RecipesController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(RecipeDto recipe)
        {
            return await Mediator.Send(new AddRecipeCommand { viewModel = recipe });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDto>> Get(int id)
        {
            return await Mediator.Send(new GetRecipeQuery { Id = id });
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<RecipeSearchResultsVm>> Search(SearchRecipeQuery query)
        {
            Debug.WriteLine(query);
            var result = await Mediator.Send(query);
            Debug.WriteLine(result);
            return result;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<BeerStylesDto>> Styles()
        {
            return await Mediator.Send(new GetBeerStylesQuery());
        }
    }
}
