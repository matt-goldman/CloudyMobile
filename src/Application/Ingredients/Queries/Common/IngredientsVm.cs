using System.Collections.Generic;

namespace CloudyMobile.Application.Ingredients.Queries.Common
{
    public class IngredientsVm
    {
        public List<IngredientDto> Ingredients { get; set; }

        public IngredientsVm()
        {
            Ingredients = new List<IngredientDto>();
        }
    }
}
