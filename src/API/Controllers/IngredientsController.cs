using CloudyMobile.Application.Ingredients.Commands.AddIngredient;
using CloudyMobile.Application.Ingredients.Queries.Common;
using CloudyMobile.Application.Ingredients.Queries.GetAllIngredients;
using CloudyMobile.Application.Ingredients.Queries.SearchIngredients;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CloudyMobile.API.Controllers
{
    public class IngredientsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(IngredientDto ingredient)
        {
            return await Mediator.Send(new AddIngredientCommand { Ingredient = ingredient });
        }

        [HttpGet]
        public async Task<ActionResult<IngredientsVm>> Get()
        {
            return await Mediator.Send(new GetAllIngredientsQuery());
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IngredientsVm>> Search(string searchTerm)
        {
            return await Mediator.Send(new SearchIngredientsQuery { SearchTerm = searchTerm });
        }
    }
}
