using CloudyMobile.Application.Common.Mappings;
using CloudyMobile.Domain.Entities;

namespace CloudyMobile.Application.Recipes.Common
{
    public class RecipeIngredientDto : IMapFrom<RecipeIngredients>
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public float Quantity { get; set; }
    }
}
