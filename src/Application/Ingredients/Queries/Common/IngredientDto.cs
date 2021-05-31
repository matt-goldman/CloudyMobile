using CloudyMobile.Application.Common.Mappings;
using CloudyMobile.Domain.Entities;

namespace CloudyMobile.Application.Ingredients.Queries.Common
{
    public class IngredientDto : IMapFrom<Ingredient>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }
    }
}
